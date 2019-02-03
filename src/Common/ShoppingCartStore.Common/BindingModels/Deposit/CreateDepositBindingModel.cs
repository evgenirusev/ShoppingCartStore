namespace ShoppingCartStore.Common.BindingModels.Deposit
{
    using System.ComponentModel.DataAnnotations;

    public class CreateDepositBindingModel
    {
        public string Id { get; set; }

        [Required]
        [Range(10.00, 10000.00)]
        public decimal Amount { get; set; }

        [Required]
        public string CreditCardId { get; set; }
    }
}
