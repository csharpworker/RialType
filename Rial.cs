using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public struct Rial 
    {
        public double Value { get { return value.GetValueOrDefault(); } }

        private double? value { get; set; }

        public bool HasValue { get { return value.HasValue; } }

        public Rial(double? value)
        {
            this.value = value;
        }

        public static implicit operator Rial(double? value)
        {
            return new Rial(value);
        }

        public static explicit operator double? (Rial value)
        {
            return value.Value;
        }


        public override bool Equals(object other)
        {
            if (!HasValue) return other == null;
            if (other == null) return false;
            return Value.Equals(other);
        }

        public override int GetHashCode()
        {
            return HasValue ? Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format("{0} ريال", HasValue ? string.Format("{0:N0}", Value.ToString()) : "");
        }


        public static int Compare(Rial n1, Rial n2)
        {
            if (n1.HasValue && n2.HasValue)
            {
                if (n1.Value > n2.Value) return 1;
                else if (n1.Value < n2.Value) return -1;
                else return 0;
            }
            if (n2.HasValue) return -1;
            return 0;
        }

        public static bool Equals(Rial n1, Rial n2)
        {
            if (n1.HasValue)
            {
                if (n2.HasValue) return n1.Value.Equals(n2.Value);
                return false;
            }
            if (n2.HasValue) return false;
            return true;
        }



        // If the type provided is not a Nullable Type, return null.
        // Otherwise, returns the underlying type of the Nullable type
        public static Type GetUnderlyingType(Type nullableType)
        {
            if ((object)nullableType == null)
            {
                throw new ArgumentNullException("nullableType");
            }
            Type result = null;
            if (nullableType.IsGenericType && !nullableType.IsGenericTypeDefinition)
            {
                // instantiated generic type only                
                Type genericType = nullableType.GetGenericTypeDefinition();
                if (Object.ReferenceEquals(genericType, typeof(Rial)))
                {
                    result = nullableType.GetGenericArguments()[0];
                }
            }
            return result;
        }


        public static Rial operator +(Rial c1, int? c2)
        {
            return new Rial(c1.Value + c2.GetValueOrDefault(0));
        }

        public static Rial operator +(Rial c1, double? c2)
        {
            return new Rial(c1.Value + c2.GetValueOrDefault(0));
        }

        public static Rial operator -(Rial c1, int? c2)
        {
            return new Rial(c1.Value - c2.GetValueOrDefault(0));
        }

        public static Rial operator -(Rial c1, double? c2)
        {
            return new Rial(c1.Value - c2.GetValueOrDefault(0));
        }


    }

}
