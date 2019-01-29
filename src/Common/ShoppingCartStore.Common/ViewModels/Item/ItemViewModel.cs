namespace ShoppingCartStore.Common.ViewModels.Item
{
    using ShoppingCartStore.Common.ViewModels.Product;

    public class ItemViewModel
    {
        public ProductViewModel Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}
