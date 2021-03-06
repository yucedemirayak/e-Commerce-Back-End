using eCommerce.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Core.Models
{
    public class Admin : BaseEntity
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole Role { get; set; }
    }
}
