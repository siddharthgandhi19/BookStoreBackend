using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Book
{
    public class UpdateBookModel
    {
        public int BookId { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
