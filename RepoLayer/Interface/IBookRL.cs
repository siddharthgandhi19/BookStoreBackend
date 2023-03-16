using CommonLayer.Models.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IBookRL
    {
        public BookModel AddBook(BookModel bookModel);
        public bool DeleteBook(int bookId);
    }
}
