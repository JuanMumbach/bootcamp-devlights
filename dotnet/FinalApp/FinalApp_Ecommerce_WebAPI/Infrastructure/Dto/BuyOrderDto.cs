namespace FinalApp_Ecommerce_WebAPI.Infrastructure.Dto
{
    public class BuyOrderDto
    {
        public Guid UserId { get; set; }

        public List<BuyOrderItemDto> BuyOrderItems { get; set; }
    }

    public class BuyOrderItemDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
