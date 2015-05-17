using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Common.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<T> GetType<T>(this IEnumerable<object> list)
        {
            return list.GetType().IsGenericType ? list.Where(i => i.GetType() == typeof(T)).Cast<T>().ToList() : null;
        }

        public static IEnumerable<T> GetType<T>(this List<object> list)
        {
            return list.GetType().IsGenericType ? list.Where(i => i.GetType() == typeof(T)).Cast<T>().ToList() : null;
        }
    }
}
