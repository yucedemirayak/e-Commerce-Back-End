
namespace eCommerce.Core.Models
{
    public class Order : BaseEntity
    {
        public bool isActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}