
namespace eCommerce.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public int Rating { get; set; }

    }
}
