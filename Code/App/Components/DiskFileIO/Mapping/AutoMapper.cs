using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using CygX1.PersistentObjects;

namespace CygX1.DiskFileIO.Mapping
{
    public class AutoMapper
    {
        private static EntityMapper entityMapper = new EntityMapper();

        public static void AddMapping<E, T>(string primaryKey)
            where E : PersistableEntity
            where T : DataTable, new()
        {
            entityMapper.AddMapping<E, T>(primaryKey);
        }

        public static void ClearMapping()
        {
            entityMapper.ClearMappings();
        }

        public static void ChangeMapping<E>(string propertyIdentifier, string fieldName)
            where E : PersistableEntity
        {
            entityMapper.ChangeMapping<E>(propertyIdentifier, fieldName);
        }

        public static List<E> ToEntityList<E>(DataTable dataTable)
            where E : PersistableEntity, new()
        {
            return entityMapper.ToEntityList<E>(dataTable);
        }

        public static List<E> ToEntityList<E>(DataRow[] dataRows)
            where E : PersistableEntity, new()
        {
            return entityMapper.ToEntityList<E>(dataRows);
        }

        public static void ToDataTable<E>(DataTable dataTable, List<E> itemsList)
            where E : PersistableEntity, new()
        {
            entityMapper.ToDataTable<E>(dataTable, itemsList);
        }
    }

    internal class EntityMapper
    {
        private Dictionary<string, EntityMapping> mappingDictionary = new Dictionary<string, EntityMapping>();

        public EntityMapping this[string identifier]
        {
            get { return mappingDictionary[identifier]; }
        }

        public void ClearMappings()
        {
            mappingDictionary.Clear();
        }

        public void AddMapping<E, T>(string primaryKey)
            where E : PersistableEntity
            where T : DataTable, new()
        {
            string identifier = typeof(E).Name;
            if (!mappingDictionary.ContainsKey(identifier))
            {
                EntityMapping mapping = MappingFactory.CreateMapping<E, T>(identifier, primaryKey);
                mappingDictionary.Add(identifier, mapping);
            }
        }

        public void ChangeMapping<E>(string propertyIdentifier, string fieldName)
            where E : PersistableEntity
        {
            EntityMapping entityMapping = mappingDictionary[typeof(E).Name];
            entityMapping.PropertyMappings[propertyIdentifier].FieldName = fieldName;
        }


        public List<E> ToEntityList<E>(DataRow[] dataRows)
            where E : PersistableEntity, new()
        {
            List<E> entityList = new List<E>();

            if (dataRows.Count() > 0)
            {
                string tableName = dataRows[0].Table.TableName;
                EntityMapping entityMapping = mappingDictionary.Values.Where(v => v.EntityType.Name == tableName).SingleOrDefault();

                if (entityMapping != null)
                {
                    foreach (DataRow row in dataRows)
                    {
                        E entity = new E();
                        entity.CurrentState = MapState(row);

                        // setting the below properties will also set the "Code" field because reflection allows
                        // for the setting of "private setters".
                        foreach (PropertyFieldMapping propMapping in entityMapping.PropertyMappings.Values)
                        {
                            PropertyInfo propInfo = propMapping.PropertyInfo;
                            if (propMapping.FieldName != string.Empty)
                            {
                                if (!row.IsNull(propMapping.FieldName))
                                    propInfo.SetValue(entity, row[propMapping.FieldName], new object[] { });
                            }
                        }
                        entityList.Add(entity);
                    }
                }
            }
            return entityList;
        }

        public List<E> ToEntityList<E>(DataTable dataTable)
            where E : PersistableEntity, new()
        {
            string tableName = dataTable.TableName;
            List<E> entityList = new List<E>();

            EntityMapping entityMapping = mappingDictionary.Values.Where(v => v.EntityType.Name == tableName).SingleOrDefault();

            if (entityMapping != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached)
                    {
                        E entity = new E();
                        entity.CurrentState = MapState(row);

                        // setting the below properties will also set the "Code" field because reflection allows
                        // for the setting of "private setters".
                        foreach (PropertyFieldMapping propMapping in entityMapping.PropertyMappings.Values)
                        {
                            PropertyInfo propInfo = propMapping.PropertyInfo;
                            if (propMapping.FieldName != string.Empty)
                            {
                                if (!row.IsNull(propMapping.FieldName))
                                    propInfo.SetValue(entity, row[propMapping.FieldName], new object[] { });
                            }
                        }
                        entityList.Add(entity);
                    }
                }
            }

            return entityList;
        }

        private PersistableEntityStateEnum MapState(DataRow row)
        {
            switch (row.RowState)
            {
                case DataRowState.Added: return PersistableEntityStateEnum.Added;
                case DataRowState.Deleted: return PersistableEntityStateEnum.Deleted;
                case DataRowState.Detached: return PersistableEntityStateEnum.Deleted;
                case DataRowState.Modified: return PersistableEntityStateEnum.Modified;
                case DataRowState.Unchanged: return PersistableEntityStateEnum.Unchanged;
                default: throw new NotSupportedException();
            }
        }

        private void SetRowState(DataRow row, PersistableEntityStateEnum state)
        {
            switch (state)
            {
                case PersistableEntityStateEnum.Added:
                    if (row.RowState != DataRowState.Added)
                        row.SetAdded();
                    break;
                case PersistableEntityStateEnum.Deleted:
                    // detached occurs when delete occurs prior to a row being added.
                    if (row.RowState != DataRowState.Detached || row.RowState != DataRowState.Deleted)
                        row.Delete();
                    break;
                case PersistableEntityStateEnum.Modified:
                    if (row.RowState != DataRowState.Modified && row.RowState != DataRowState.Added)
                        row.SetModified();
                    break;
                case PersistableEntityStateEnum.Unchanged:
                    row.AcceptChanges();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        public void ToDataTable<E>(DataTable dataTable, List<E> itemsList)
            where E : PersistableEntity, new()
        {
            EntityMapping entityMapping = mappingDictionary[typeof(E).Name];

            dataTable.BeginLoadData();

            if (entityMapping != null)
            {
                foreach (E item in itemsList)
                {
                    DataRow dummyRow = dataTable.NewRow();
                    foreach (PropertyFieldMapping propMapping in entityMapping.PropertyMappings.Values)
                    {
                        if (propMapping.FieldName != string.Empty)
                            dummyRow[propMapping.FieldName] = propMapping.PropertyInfo.GetValue(item, new object[] { });
                    }
                    // handle row state...
                    DataRow row = dataTable.LoadDataRow(dummyRow.ItemArray, LoadOption.Upsert);
                    SetRowState(row, item.CurrentState);
                }

            }
            dataTable.EndLoadData();
        }
    }

    internal class PropertyFieldMapping
    {
        internal PropertyFieldMapping() { }
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public string FieldName { get; set; }
    }

    internal class EntityMapping
    {
        public string Identifier { get; private set; }
        public Type EntityType { get; private set; }
        public Type TableType { get; private set; }
        public string PrimaryKey { get; private set; }
        public Dictionary<string, PropertyFieldMapping> PropertyMappings { get; private set; }

        internal EntityMapping(Type entityType, Type tableType, string identifier, Dictionary<string, PropertyFieldMapping> propertyFieldMappingDictionary, string primaryKey)
        {
            this.EntityType = entityType;
            this.TableType = tableType;
            this.Identifier = identifier;
            this.PrimaryKey = primaryKey;
            this.PropertyMappings = propertyFieldMappingDictionary;
        }

        public PropertyFieldMapping this[string propertyName]
        {
            get { return PropertyMappings[propertyName]; }
        }
    }

    internal class MappingFactory
    {
        public static EntityMapping CreateMapping<E, T>(string identifier, string primaryKey)
            where E : class
            where T : DataTable, new()
        {
            Dictionary<string, PropertyFieldMapping> propertyFieldMappingDictionary = new Dictionary<string, PropertyFieldMapping>();
            Type classType = typeof(E);
            Type tableType = typeof(T);

            PropertyInfo[] propertyInfoArray = classType.GetProperties();
            List<string> fieldNamesList = GetTableColumnNames<E, T>();

            foreach (PropertyInfo property in propertyInfoArray)
            {
                PropertyFieldMapping propertyFieldMapping = new PropertyFieldMapping();
                propertyFieldMapping.PropertyName = property.Name;
                propertyFieldMapping.PropertyInfo = property;
                propertyFieldMapping.PropertyType = property.PropertyType;
                propertyFieldMappingDictionary[property.Name] = propertyFieldMapping;

                if (fieldNamesList.Contains(property.Name))
                    propertyFieldMapping.FieldName = fieldNamesList.Where(f => f.ToUpper() == property.Name.ToUpper()).SingleOrDefault();
                else
                    propertyFieldMapping.FieldName = "";
            }

            EntityMapping entityMapping = new EntityMapping(classType, tableType, identifier, propertyFieldMappingDictionary, primaryKey);

            return entityMapping;
        }

        private static List<string> GetTableColumnNames<E, T>()
            where E : class
            where T : DataTable, new()
        {
            T table = new T();
            List<string> fieldNames = new List<string>();

            foreach (DataColumn column in table.Columns)
                fieldNames.Add(column.ColumnName);

            return fieldNames;
        }
    }
}
