using BusinessLayer.Interface;
using CommonLayer.Models.Book;
using CommonLayer.Models.User;
using Microsoft.AspNetCore.Http;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Net;
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

        public List<BookModel> GetAllBooks()
        {

            try
            {
                return iBookRL.GetAllBooks();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetBooksById(int bookId)
        {
            try
            {
                return iBookRL.GetBooksById(bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ImageUploadOnCloudinary(IFormFile imageFile, int bookId)
        {
            try
            {
                return iBookRL.ImageUploadOnCloudinary(imageFile, bookId);
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
