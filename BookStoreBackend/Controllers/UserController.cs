using BusinessLayer.Interface;
using CommonLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Security.Claims;

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

        [HttpPost]
        [Route("UserLogin")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                var result = iUserBL.Login(userLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Login Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Login UnSuccessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("ForgotPassword")]

        public IActionResult ForgetLoginPassword(ForgetPassword forgetPassword)
        {
            try
            {
                var result = iUserBL.ForgetLoginPassword(forgetPassword);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Mail Send Successfull", data = result });
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
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = iUserBL.ResetPassword(resetPassword,email);
                if (result)
                {
                    return this.Ok(new { success = true, message = "Password Reset Successfully", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Password Not Reset Try Again" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("getAllUser")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var result = iUserBL.GetAllUsers();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrieve All Users", data = result });
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
