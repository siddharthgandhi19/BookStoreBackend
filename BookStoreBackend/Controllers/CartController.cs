using BusinessLayer.Interface;
using CommonLayer.Models.Admin;
using CommonLayer.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Interface;
using System.Linq;
using System;
using BusinessLayer.Service;
using System.Collections.Generic;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartBL iCartBL;
        public CartController(ICartBL iCartBL)
        {
            this.iCartBL= iCartBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public ActionResult AddToCart(CartInputModel cartInputModel)
        {
            try
            {
                var authorizeUser = HttpContext.User;
                int UserId = Convert.ToInt32(authorizeUser.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iCartBL.AddToCart(cartInputModel, UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Add To Cart", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveFromCart")]
        public ActionResult DeleteCart(int CartId)
        {
            try
            {
               
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iCartBL.DeleteCart(CartId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Remove From Cart", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateCart")]
        public ActionResult UpdateCart(int CartId, int Quantity)
        {
            try
            {
                var authorizeUser = HttpContext.User;
                int UserId = Convert.ToInt32(authorizeUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                var result = iCartBL.UpdateCart(CartId, Quantity, UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Cart Update Sucessfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "failed!" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("GetCartByUserId")]
        public IActionResult GetCartByUserId(CartByUserIdModel cartByUserIdModel)
        {
            try
            {
                var result = iCartBL.GetCartByUserId(cartByUserIdModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Get All Cart", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetCartByCartId")]
        public IActionResult GetCartByCartId(int CartId)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iCartBL.GetCartByCartId(UserId, CartId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Get All Cart", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
