using eCommerce.Core.Enums;
using System.Text.Json.Serialization;

namespace eCommerce.Api.DTOs.ShopOwner
{
    public class SaveShopOwnerDTO
    {
        public string ShopName { get; set; }
        public string ShopOwnerFirstName { get; set; }
        public string ShopOwnerLastName { get; set; }
        public string VKN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
    }
}
