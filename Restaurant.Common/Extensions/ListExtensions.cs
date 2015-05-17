using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Common.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<T> GetTypes<T>(this IEnumerable<object> list)
        {
            return list.GetType().IsGenericType ? list.Where(i => i.GetType() == typeof(T)).Cast<T>().ToList() : null;
        }

        public static object GetTypes(this IEnumerable<object> list, Type type)
        {
            return list.GetType().IsGenericType ? list.Where(i => i.GetType() == type) : null;
        }
    }
}
