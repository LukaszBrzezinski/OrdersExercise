using System;

namespace Shop.Domain.Products
{
    public class Sku : IEquatable<Sku>
    {
        public string Value { get; }
        public Sku(string value)
        {
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Sku)obj);
        }

        public bool Equals(Sku? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator ==(Sku left, Sku right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Sku left, Sku right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}