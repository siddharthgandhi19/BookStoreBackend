using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Order
{
    public class GetOrderModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int AddressId { get; set; }
        public int TotalPrice { get; set; }
        public string OrderDate { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int OriginalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public string BookImage { get; set; }
    }
}
