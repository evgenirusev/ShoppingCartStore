namespace ShoppingCartStore.Common.Exceptions
{
    using System;
    public abstract class BaseException : Exception
    {
        protected BaseException(string message)
            : base(message)
        {
        }
    }
}
