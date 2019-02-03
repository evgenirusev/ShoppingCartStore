namespace ShoppingCartStore.Common.ViewModels.Order
{
    using System;

    public class OrderViewModel
    {
        public DateTime CreatedAt { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderNote { get; set; }
    }
}
