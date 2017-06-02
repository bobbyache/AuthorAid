using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookManager_Prototype.Domain
{
    public interface IPositionableList
    {
        void InitializeList(List<IPositionedItem> itemList);
        void OrderAll();
        void Insert(IPositionedItem item);
        bool CanMoveDown(IPositionedItem item);
        bool CanMoveUp(IPositionedItem item);
        bool CanMoveTo(IPositionedItem item, int ordinal);
        void Remove(IPositionedItem item);
        void MoveUp(IPositionedItem item);
        void MoveDown(IPositionedItem item);
        void MoveTo(IPositionedItem item, int ordinal);

    }

    public interface IPositionedItem
    {
        int Ordinal { get; set; }
    }

    public class PositionalList : IPositionableList
    {
        private List<IPositionedItem> positionedItemList = new List<IPositionedItem>();

        public void Insert(IPositionedItem item)
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

        public bool CanMoveDown(IPositionedItem item)
        {
            int sectionCount = positionedItemList.Count();

            if (sectionCount > 1)
            {
                if (item.Ordinal < sectionCount)
                    return true;
            }
            return false;
        }

        public bool CanMoveUp(IPositionedItem item)
        {
            int sectionCount = positionedItemList.Count();

            if (sectionCount > 1)
            {
                if (item.Ordinal > 1)
                    return true;
            }
            return false;
        }

        public bool CanMoveTo(IPositionedItem item, int ordinal)
        {
            throw new NotImplementedException();
        }

        public void Remove(IPositionedItem item)
        {
            IPositionedItem positionedItem = (from ts in positionedItemList
                                              where ts.Ordinal == item.Ordinal
                                              select ts).SingleOrDefault();

            int deleteOrdinal = positionedItem.Ordinal;
            positionedItemList.Remove(positionedItem);

            // fix ordinals.
            foreach (IPositionedItem section in positionedItemList)
            {
                if (section.Ordinal > deleteOrdinal)
                    section.Ordinal = section.Ordinal - 1;
            }
        }

        public void MoveUp(IPositionedItem item)
        {
            if (CanMoveUp(item))
            {
                IPositionedItem positionedItem = (from ts in positionedItemList
                                                  where ts.Ordinal == item.Ordinal
                                                  select ts).SingleOrDefault();

                IPositionedItem displacedItem = (from ts in positionedItemList
                                                 where ts.Ordinal == item.Ordinal - 1
                                                 select ts).SingleOrDefault();
                //swap
                positionedItem.Ordinal -= 1;
                displacedItem.Ordinal += 1;
            }
        }

        public void MoveDown(IPositionedItem item)
        {
            if (CanMoveDown(item))
            {
                IPositionedItem positionedItem = (from ts in positionedItemList
                                                  where ts.Ordinal == item.Ordinal
                                                  select ts).SingleOrDefault();



                IPositionedItem displacedItem = (from ts in positionedItemList
                                                 where ts.Ordinal == positionedItem.Ordinal + 1
                                                 select ts).SingleOrDefault();
                // swap
                positionedItem.Ordinal += 1;
                displacedItem.Ordinal -= 1;
            }
        }

        public void MoveTo(IPositionedItem item, int ordinal)
        {
            throw new NotImplementedException();
        }

        public void InitializeList(List<IPositionedItem> itemList)
        {
            positionedItemList = itemList;
            OrderAll();
        }

        public void OrderAll()
        {
            positionedItemList.OrderBy(r => r.Ordinal);
        }
    }
}
