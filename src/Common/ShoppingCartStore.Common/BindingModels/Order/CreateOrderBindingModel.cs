using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartStore.Common.BindingModels.Order
{
    public class CreateOrderBindingModel
    {
        [Required]
        public string DeliveryAddress { get; set; }
        
        public string OrderNote { get; set; }

        public List<string> ItemIds { get; set; }
    }
}
