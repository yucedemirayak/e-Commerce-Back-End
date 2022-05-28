
namespace eCommerce.Core.Models
{
    public class Admin : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
