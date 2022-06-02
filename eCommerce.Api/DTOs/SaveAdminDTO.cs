using eCommerce.Core.Enums;
using System.Text.Json.Serialization;

namespace eCommerce.Api.DTOs
{
    public class SaveAdminDTO
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public UserRole Role { get; set; } = UserRole.USER;
    }
}
