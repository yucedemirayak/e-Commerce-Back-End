
namespace eCommerce.Core.Models
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
