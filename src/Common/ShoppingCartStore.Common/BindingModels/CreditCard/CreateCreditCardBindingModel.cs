namespace ShoppingCartStore.Common.BindingModels.CreditCard
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateCreditCardBindingModel
    {
        [Required]
        [StringLength(16, MinimumLength = 12)]
        [Display(Name = "Card Number")]
        public string Number { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 3)]
        [Display(Name = "Card CVV")]
        public string CVV { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
