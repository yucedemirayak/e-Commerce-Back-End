
namespace eCommerce.Core.Models
{
    public class OrderDetail : BaseEntity
    {
        public double Price { get; set; }
        public int Quantitiy { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}