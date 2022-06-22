namespace eCommerce.Api.DTOs.ShopOwnerAdress
{
    public struct ShopOwnerAdressDTO
    {
        public string City { get; set; }
        public string District { get; set; }
        public int? PostCode { get; set; }
        public string Description1 { get; set; }
        public string? Description2 { get; set; }
        public int ShopOwnerId { get; set; }
    }
}
