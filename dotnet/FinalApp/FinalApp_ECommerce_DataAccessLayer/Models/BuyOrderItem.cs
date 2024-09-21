﻿namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    public class BuyOrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int BuyOrderId { get; set; }
        public BuyOrder BuyOrder { get; set; }

    }
}