using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Domain.Positioning
{
    /// <summary>
    /// http://stackoverflow.com/questions/1945461/how-do-i-sort-an-observable-collection
    /// Answered by maplemale: search for "None of these answers worked in my case."
    /// 
    /// Another option here:
    /// http://kiwigis.blogspot.com/2010/03/how-to-sort-obversablecollection.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class OrdinalObservableCollection<T> : ObservableCollection<T>
        where T : IPositionedItem
    {
        public OrdinalObservableCollection() : base() { }
        public OrdinalObservableCollection(IEnumerable<T> collection) : base(collection) { }
        public OrdinalObservableCollection(List<T> list) : base(list) { }

        public void Sort()
        {
            //TODO: Add logic to look at _sItem and decide what property to sort on
            IEnumerable<T> si_enum = this.AsEnumerable();
            si_enum = si_enum.OrderBy(p => p.Ordinal).AsEnumerable();

            foreach (T si in si_enum)
            {
                int _OldIndex = this.IndexOf(si);
                int _NewIndex = si_enum.ToList().IndexOf(si);
                this.MoveItem(_OldIndex, _NewIndex);
            }
        }

    }
}
