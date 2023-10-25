namespace JijaShop.Common.Exceptions
{
    public class HashException : Exception
    {
        public string Code { get; }
        public string Name { get; }

        #region Constructors

        public HashException()
        {
        }

        public HashException(string message) : base(message)
        {
        }

        public HashException(Exception inner) : base(inner.Message, inner)
        {
        }

        public HashException(string message, Exception inner) : base(message, inner)
        {
        }

        public HashException(string code, string message) : base(message)
        {
            Code = code;
        }

        public HashException(string code, string message, Exception inner) : base(message, inner)
        {
            Code = code;
        }

        #endregion

        public static void ThrowIf(Func<bool> predicate, string message)
        {
            if (predicate.Invoke())
                throw new HashException(message);
        }
    }
}
