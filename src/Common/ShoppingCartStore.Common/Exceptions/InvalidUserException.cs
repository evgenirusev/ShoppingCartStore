namespace ShoppingCartStore.Common.Exceptions
{
    public class InvalidUserException : BaseException
    {
        private const string message = "User not found!";

        public InvalidUserException() : base(message)
        {
        }
    }
}
