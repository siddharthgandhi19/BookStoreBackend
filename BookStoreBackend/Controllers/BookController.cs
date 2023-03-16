using BusinessLayer.Interface;
using CommonLayer.Models.Book;
using CommonLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookBL iBookBL;

        public BookController(IBookBL iBookBL)
        {
            this.iBookBL = iBookBL; 
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var result = iBookBL.AddBook(bookModel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Add Book Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again!! Something Wrong" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                var result = iBookBL.DeleteBook(bookId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Delete Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again!! Something Wrong" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("UpdateBook")]
        public IActionResult UpdateBook(BookModel bookModel, int bookId)
        {
            try
            {
                var result = iBookBL.UpdateBook(bookModel, bookId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Update Book Data Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again!! Something Wrong" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("getAllBook")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = iBookBL.GetAllBooks();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrieve All Books", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again!! Something Wrong" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
       
    }
}
