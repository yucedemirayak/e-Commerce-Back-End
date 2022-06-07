
namespace eCommerce.Core.Models
{
    public class ProductImage : BaseEntity
    {
        public string ImgSource { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
