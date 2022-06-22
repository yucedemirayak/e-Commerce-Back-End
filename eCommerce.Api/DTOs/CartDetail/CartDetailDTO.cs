namespace eCommerce.Api.DTOs.CartDetail
{
    public struct CartDetailDTO
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}
