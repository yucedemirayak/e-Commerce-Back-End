using eCommerce.Core.Enums;

namespace eCommerce.Core.Models
{
    public class Admin : BaseEntity
    {
        public UserRole Role { get; set; } = UserRole.ADMIN;
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        
    }
}
