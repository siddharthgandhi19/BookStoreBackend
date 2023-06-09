﻿using CommonLayer.Models.Book;
using Microsoft.AspNetCore.Http;
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
        public List<BookModel> GetAllBooks();
        public object GetBooksById(int bookId);
        public bool BookImageUpdate(UpdateBookModel updateBookModel);
    }
}
