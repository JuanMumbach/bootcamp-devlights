using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    public class BuyOrder
    {
        //Properties
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<BuyOrderItem> OrderItems { get; set; }
    }
}
