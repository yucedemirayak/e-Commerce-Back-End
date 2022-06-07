using System.ComponentModel.DataAnnotations;
using eCommerce.Core.Enums;

namespace eCommerce.Core.Models
{
    public class ShopOwner : BaseEntity
    {
        public string ShopName { get; set; }
        public string ShopOwnerFirstName { get; set; }
        public string ShopOwnerLastName { get; set; }

        [StringLength(10)]
        public string VKN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string ContactNumber { get; set; }
        public UserRole Role { get; set; }
        
    }
}
