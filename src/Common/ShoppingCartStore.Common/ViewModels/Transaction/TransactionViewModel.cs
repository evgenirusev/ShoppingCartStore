namespace ShoppingCartStore.Common.ViewModels.Transaction
{
    using ShoppingCartStore.Models.Enum;
    using System;

    public class TransactionViewModel
    {
        public DateTime CreatedAt { get; set; }

        public decimal Price { get; set; }

        public TransactionType Type { get; set; }
    }
}
