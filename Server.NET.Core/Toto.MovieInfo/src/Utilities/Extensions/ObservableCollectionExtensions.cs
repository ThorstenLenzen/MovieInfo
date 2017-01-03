using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Toto.Utilities.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> CopyFrom<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();

            foreach (var item in items)
                collection.Add(item);

            //collection.OnCollectionChanged(
            //    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            collection.CollectionChanged += ((sender, args) =>  
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            return collection;
        }
    }
}
