using BusinessLayer.Interface;
using CommonLayer.Models.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressBL iAddressBL;
        public AddressController(IAddressBL iAddressBL)
        {
            this.iAddressBL = iAddressBL;
        }


        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iAddressBL.AddAddress(addressModel, UserId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address Added", data = result });
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
        [Route("DeleteAddress")]
        public IActionResult DeleteAddress(AddressIdModel addressIdModel)
        {
            try
            {
                var result = iAddressBL.DeleteAddress(addressIdModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address Deleted", data = result });
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

        [Authorize]
        [HttpPut]
        [Route("UpdateAddress")]
        public IActionResult UpdateAddress(AddressModel addressModel, int AddressId)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iAddressBL.UpdateAddress(addressModel, AddressId, UserId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address Updated", data = result });
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
        [Route("GetAllAddress")]
        public IActionResult GetAddress()
        {
            try
            {
                var result = iAddressBL.GetAddress();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrieve All Adress", data = result });
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
