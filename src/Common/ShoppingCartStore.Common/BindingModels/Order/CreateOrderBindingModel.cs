using System.Collections.Generic;

namespace ShoppingCartStore.Common.BindingModels.Order
{
    public class CreateOrderBindingModel
    {
        public CreateOrderBindingModel()
        {
            ItemIds = new List<string>();
        }

        public string DeliveryAddress { get; set; }
        
        public string OrderNote { get; set; }

        public List<string> ItemIds { get; set; }
    }
}
