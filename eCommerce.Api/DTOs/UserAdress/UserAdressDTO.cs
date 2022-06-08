namespace eCommerce.Api.DTOs.UserAdress
{
    public class UserAdressDTO
    {
        public string City { get; set; }
        public string District { get; set; }
        public int? PostCode { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
