namespace eCommerce.Api.DTOs.Product
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }
        public int ShopOwnerId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
