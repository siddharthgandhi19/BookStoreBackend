using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Cart
{
    public class GetCartOfUser
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
