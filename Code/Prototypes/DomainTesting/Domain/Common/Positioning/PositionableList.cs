using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CygX1.AuthorAid.Domain.Common.Positioning
{
    public interface IPositionedItem
    {
        int Ordinal { get; set; }
    }

    public class PositionableList<T> where T : class, IPositionedItem
    {
        private List<T> positionedItemList = new List<T>();

        public List<T> ItemsList
        {
            get { return positionedItemList; }
        }
        
        public T LastItem
        {
            get { return positionedItemList[positionedItemList.Count - 1]; }
        }

        public int Count { get { return positionedItemList.Count; } }

        public void Insert(T item)
        {
            if (positionedItemList.Count > 0)
            {
                item.Ordinal = (from ts in positionedItemList
                                select ts.Ordinal).Max() + 1;
            }
            else
                item.Ordinal = 1;

            positionedItemList.Add(item);
        }

        public bool CanMoveDown(T item)
        {
            int itemCount = positionedItemList.Count();

            if (itemCount > 1)
            {
                if (item.Ordinal < itemCount)
                    return true;
            }
            return false;
        }

        public bool CanMoveUp(T item)
        {
            int itemCount = positionedItemList.Count();

            if (itemCount > 1)
            {
                if (item.Ordinal > 1)
                    return true;
            }
            return false;
        }

        public bool CanMoveTo(T item, int ordinal)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            T positionedItem = (from ts in positionedItemList
                                              where ts.Ordinal == item.Ordinal
                                              select ts).SingleOrDefault();

            int deleteOrdinal = positionedItem.Ordinal;
            positionedItemList.Remove(positionedItem);

            // fix ordinals.
            foreach (IPositionedItem posItem in positionedItemList)
            {
                if (posItem.Ordinal > deleteOrdinal)
                    posItem.Ordinal = posItem.Ordinal - 1;
            }
        }

        public void MoveUp(T item)
        {
            if (CanMoveUp(item))
            {
                T positionedItem = (from ts in positionedItemList
                                                  where ts.Ordinal == item.Ordinal
                                                  select ts).SingleOrDefault();

                T displacedItem = (from ts in positionedItemList
                                                 where ts.Ordinal == item.Ordinal - 1
                                                 select ts).SingleOrDefault();
                //swap
                positionedItem.Ordinal -= 1;
                displacedItem.Ordinal += 1;
            }
        }

        public void MoveDown(T item)
        {
            if (CanMoveDown(item))
            {
                T positionedItem = (from ts in positionedItemList
                                                  where ts.Ordinal == item.Ordinal
                                                  select ts).SingleOrDefault();



                T displacedItem = (from ts in positionedItemList
                                                 where ts.Ordinal == positionedItem.Ordinal + 1
                                                 select ts).SingleOrDefault();
                // swap
                positionedItem.Ordinal += 1;
                displacedItem.Ordinal -= 1;
            }
        }

        public void MoveTo(T item, int ordinal)
        {
            throw new NotImplementedException();
        }

        public void InitializeList(List<T> itemList)
        {
            positionedItemList = itemList;
            OrderAll();
        }

        public void OrderAll()
        {
            // correct way.
            positionedItemList.Sort((x, y) => x.Ordinal.CompareTo(y.Ordinal));
            // old way
            //positionedItemList.OrderBy(r => r.Ordinal);
        }
    }
}
