using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        IWishListBL iWishListBL;
        public WishListController(IWishListBL iWishListBL)
        {
                this.iWishListBL= iWishListBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToWishList")]
        public IActionResult AddWishList(int BookId)
        {
            try
            {
             
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iWishListBL.AddWishList(BookId, UserId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Add Book To WishList", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveWishList")]
        public IActionResult DeleteWishList(int WishListId)
        {
            try
            {
             
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

                var result = iWishListBL.DeleteWishList(WishListId, UserId);

                if (result != false)
                {
                    return Ok(new { success = true, message = "Remove WishList" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetWishList")]
        public IActionResult GetAllWishList()
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iWishListBL.GetAllWishList(UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Wishlist Retrieved", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "TryAgain" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
