using CommonLayer.Models.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        public BookModel AddBook(BookModel bookModel);
        public bool DeleteBook(int bookId);
        public BookModel UpdateBook(BookModel bookModel, int BookId);
    }
}
