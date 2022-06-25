
namespace eCommerce.Core.Models
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public string ImgSource { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
