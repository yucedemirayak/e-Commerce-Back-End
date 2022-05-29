
namespace eCommerce.Core.Models
{
    public class Adress : BaseEntity
    {
        public string City { get; set; }
        public string District { get; set; }
        public int? PostCode { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; } = string.Empty;
    }
}
