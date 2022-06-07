
namespace eCommerce.Core.Models
{
    public class CartDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
