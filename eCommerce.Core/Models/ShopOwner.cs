
namespace eCommerce.Core.Models
{
    public class ShopOwner : BaseEntity
    {
        public string ShopName { get; set; }
        public string ShopOwnerFirstName { get; set; }
        public string ShopOwnerLastName { get; set; }
        public int VKN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int ContactNumber { get; set; }
        

    }
}
