using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL iUserBL;
        public UserController(IUserBL iUserBL)
        {
            this.iUserBL = iUserBL;
            
        }

        [HttpPost]
        [Route("UserRegistration")]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                var result = iUserBL.UserRegistration(userRegistration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration Unsuccessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
