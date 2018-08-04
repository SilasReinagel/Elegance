using System.Collections.Generic;

namespace Elegance._Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> target, T item)
        {
            foreach (var t in target ?? new List<T>(0)) 
                yield return t;
            yield return item;
        }
    }
}
