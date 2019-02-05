namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Models;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task SubtractBalance(decimal amount, Customer customer);
    }
}
