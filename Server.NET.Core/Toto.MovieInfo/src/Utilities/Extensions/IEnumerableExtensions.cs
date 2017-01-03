using System;
using System.Collections.Generic;
using System.Linq;

namespace Toto.Utilities.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var list = items.ToList(); //To prevent possible multiple enumeration.

            foreach (var item in list)
                action(item);

            return list;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return items.Where(item => predicate(item));
        }
    }
}
