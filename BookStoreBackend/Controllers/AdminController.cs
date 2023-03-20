using BusinessLayer.Interface;
using CommonLayer.Models.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Interface;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminBL iAdminBL;
        public AdminController(IAdminBL iAdminBL)
        {
            this.iAdminBL = iAdminBL;

        }

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult AdminLogin(AdminLogin adminLogin)
        {
            try
            {
                var result = iAdminBL.AdminLogin(adminLogin);
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



    }
}
