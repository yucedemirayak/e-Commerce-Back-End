using eCommerce.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Core.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public UserRole Role { get; set; }

    }
}
