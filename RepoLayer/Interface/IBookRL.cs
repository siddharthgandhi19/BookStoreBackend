using CommonLayer.Models.Book;
using CommonLayer.Models.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IBookRL
    {
        public BookModel AddBook(BookModel bookModel);
        public bool DeleteBook(int bookId);
        public BookModel UpdateBook(BookModel bookModel, int bookId);
        public List<BookModel> GetAllBooks();
        public object GetBooksById(int bookId);
        public bool BookImageUpdate(UpdateBookModel updateBookModel);
        
    }
}
