// This file was modified by Kin Ecosystem (2019)


namespace Kin.Base
{
    public static class HashCode
    {
        public const int Start = 17;

        public static int Hash<T>(this int hash, T obj)
        {
            var h = System.Collections.Generic.EqualityComparer<T>.Default.GetHashCode(obj);
            return unchecked((hash * 31) + h);
        }
    }
}
