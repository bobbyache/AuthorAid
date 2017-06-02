//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;

//namespace Domain.Mapping
//{
//    public class DataTableTransfer<ST, SR, DT, DR>
//        where ST : DataTable
//        where SR : DataRow
//        where DT : DataTable
//        where DR : DataRow
//    {
//        private Dictionary<string, string> columnMappingDictionary = new Dictionary<string, string>();

//        public void ClearColumnMappings()
//        {
//            columnMappingDictionary.Clear();
//        }

//        public void AddColumnMapping(string sourceColumn, string destinationColumn)
//        {
//            if (!columnMappingDictionary.ContainsKey(sourceColumn))
//                columnMappingDictionary.Add(sourceColumn, destinationColumn);
//            else
//                throw new ApplicationException("Source column already exists for column mapping.");
//        }

//        public void TableToTable(ST sourceTable, DT destinationTable)
//        {
//            foreach (SR row in sourceTable.Rows)
//            {
//                DR destinationRow = destinationTable.NewRow() as DR;
//                foreach (DataColumn column in sourceTable.Columns)
//                {
//                    // first check the dictionary...
//                    if (columnMappingDictionary.ContainsKey(column.ColumnName))
//                    {
//                        if (destinationTable.Columns.Contains(columnMappingDictionary[column.ColumnName]))
//                        {
//                            if (destinationTable.Columns[columnMappingDictionary[column.ColumnName]].DataType == column.DataType)
//                                destinationRow[columnMappingDictionary[column.ColumnName]] = row[column.ColumnName];
//                        }
//                    }

//                    else if (destinationTable.Columns.Contains(column.ColumnName))
//                    {
//                        if (destinationTable.Columns[column.ColumnName].DataType == column.DataType)
//                            destinationRow[column.ColumnName] = row[column.ColumnName];
//                    }
//                }
//                destinationTable.Rows.Add(destinationRow);
//            }
//        }

//        public void RowArrayToTable(SR[] sourceRows, DT destinationTable)
//        {
//            foreach (SR row in sourceRows)
//            {
//                DR destinationRow = destinationTable.NewRow() as DR;
//                foreach (DataColumn column in row.Table.Columns)
//                {
//                    // first check the dictionary...
//                    if (columnMappingDictionary.ContainsKey(column.ColumnName))
//                    {
//                        if (destinationTable.Columns.Contains(columnMappingDictionary[column.ColumnName]))
//                        {
//                            if (destinationTable.Columns[columnMappingDictionary[column.ColumnName]].DataType == column.DataType)
//                                destinationRow[columnMappingDictionary[column.ColumnName]] = row[column.ColumnName];
//                        }
//                    }

//                    else if (destinationTable.Columns.Contains(column.ColumnName))
//                    {
//                        if (destinationTable.Columns[column.ColumnName].DataType == column.DataType)
//                            destinationRow[column.ColumnName] = row[column.ColumnName];
//                    }

//                }
//                destinationTable.Rows.Add(destinationRow);
//            }
//        }
//    }
//}
