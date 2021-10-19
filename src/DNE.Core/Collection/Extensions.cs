using System.Collections.Generic;

namespace DNE.Core.Collection
{
    public static class Extensions
    {
        public static IReadOnlyList<T> ToList<T>(this T value)
        {
            if (value == null)
            {
                return new List<T>();
            }

            return new List<T>() {value};
        }
        
        public static IEnumerable<T> ToEnumerable<T>(this T value)
        {
            return ToList(value);
        }

        public static IReadOnlyList<T> ToReadOnlyList<T>(this T value)
        {
            return ToList(value);
        }
        
    }
}