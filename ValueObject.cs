namespace NetExtensions.ValueObject.Legacy
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            return obj is T valueObject && (GetType() == obj.GetType() && EqualsCustom(valueObject));
        }

        protected abstract bool EqualsCustom(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCustom();
        }

        protected abstract int GetHashCodeCustom();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
