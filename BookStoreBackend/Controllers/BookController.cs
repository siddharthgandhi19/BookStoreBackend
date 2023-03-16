using BusinessLayer.Interface;
using CommonLayer.Models.Book;
using CommonLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
