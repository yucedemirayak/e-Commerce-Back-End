namespace eCommerce.Api.DTOs.OrderDetail
{
    public struct OrderDetailDTO
    {
        public double Price { get; set; }
        public int Quantitiy { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
