using BusinessLayer.Interface;
using CommonLayer.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBL iOrderBL;
        public OrderController(IOrderBL iOrderBL)
        {
            this.iOrderBL = iOrderBL;
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult AddOrder(OrderModel orderModel)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var response = iOrderBL.AddOrder(orderModel, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Order Placed successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Try Again" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteOrder")]
        public IActionResult CancelOrder(int OrderId)
        {
            try
            {
                var result = iOrderBL.CancelOrder(OrderId);
                if (result)
                {
                    return Ok(new { success = true, message = "Order cancelled successfully." });
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

        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iOrderBL.GetOrders(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrieve All Orders", data = result });
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