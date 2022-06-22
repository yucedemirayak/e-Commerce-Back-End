namespace eCommerce.Api.DTOs.Auth
{
    public struct LoginResponseDTO
    {
        public string Token { get; set; }
        public int Role { get; set; }
    }
}
