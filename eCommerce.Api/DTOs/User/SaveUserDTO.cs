using eCommerce.Core.Enums;

namespace eCommerce.Api.DTOs.User
{
    public class SaveUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRole Role { get; set; }
    }
}
