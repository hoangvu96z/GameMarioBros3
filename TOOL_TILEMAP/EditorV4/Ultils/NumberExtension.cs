using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Ultils
{
    public static class NumberExtension
    {
        public static T GreaterOrEqualThan<T>(this T value , T limitValue) where T : IComparable
        {
            if(value.CompareTo(limitValue)<0)
            {
                return limitValue;
            }
            return value;
        }

        public static T SmallerOrEqualThan<T>(this T value, T limitValue) where T : IComparable
        {
            if (value.CompareTo(limitValue) > 0)
            {
                return limitValue;
            }
            return value;
        }

        public static T Beetween<T>(this T value, T minValue,T maxValue) where T : IComparable
        {
            return value.GreaterOrEqualThan(minValue).SmallerOrEqualThan(maxValue);
        }

        public static bool IsBeetween<T>(this T value, T minValue, T maxValue) where T : IComparable
        {
            return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
        }
    }
}
