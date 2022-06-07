

namespace eCommerce.Core.Models
{
    public class UserAdress : BaseEntity
    {
        public string City { get; set; }
        public string District { get; set; }
        public int? PostCode { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
