using BusinessLayer.Interface;
using CommonLayer.Models.Book;
using CommonLayer.Models.User;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        IBookRL iBookRL;
        public BookBL(IBookRL iBookRL)
        {
            this.iBookRL = iBookRL;
        }

        public BookModel AddBook(BookModel bookModel)
        {
            try
            {
                return iBookRL.AddBook(bookModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteBook(int bookId)
        {
            try
            {
                return iBookRL.DeleteBook(bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BookModel UpdateBook(BookModel bookModel, int bookId)
        {
            try
            {
                return iBookRL.UpdateBook(bookModel,bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
