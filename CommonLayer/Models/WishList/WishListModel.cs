using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.WishList
{
    public class WishListModel
    {
        public long WishListId { get; set; }
        public long BookId { get; set; }
        public long UserId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public long OriginalPrice { get; set; }
        public long DiscountPrice { get; set; }
        public string BookImage { get; set; }
    }
}
