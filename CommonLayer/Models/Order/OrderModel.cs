using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Order
{
    public class OrderModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int BookId { get; set; }
        public int TotalQuantity { get; set; }
    }
}
