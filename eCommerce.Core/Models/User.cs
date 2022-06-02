using eCommerce.Core.Enums;

namespace eCommerce.Core.Models
{
    public class User : BaseEntity
    {
        public UserRole Role { get; set; } = UserRole.USER;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

        
    }
}
