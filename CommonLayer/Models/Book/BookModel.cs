using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Book
{
    public class BookModel
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Rating { get; set; }
        public int TotalCountRating { get; set; }
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string Description { get; set; }
        public string BookImage { get; set; }
        public int BookCount { get; set; }

    }
}