using BusinessLayer.Interface;
using CommonLayer.Models.Feedback;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackBL iFeedbackBL;
        public FeedbackController(IFeedbackBL iFeedbackBL)
        {
            this.iFeedbackBL= iFeedbackBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddFeedBack")]
        public IActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var response = iFeedbackBL.AddFeedback(feedbackModel, UserId);
            if (response != null)
            {
                return Ok(new { success = true, Message = "Thanks For Feedback", data = response });
            }
            else
            {
                return BadRequest(new { success = false, message = "Try Again", data = response });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("FeedbacksByBookId")]
        public IActionResult GetFeedback(int BookId)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "UserId").Value);
                var result = iFeedbackBL.GetFeedback(BookId);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = " Here all the feedbacks ", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Try Again" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [Authorize]
        [HttpGet]
        [Route("GetFeedbackById")]
        public IActionResult GetFeedbackbyId(int FeedbackId)
        {
            int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserId").Value);
            var result = iFeedbackBL.GetFeedbackbyId(FeedbackId, UserId);

            if (result != null)
            {
                return Ok(new { Success = true, Message = "Retreive Feedback by Id ", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Try Again", });
            }
        }
    }
}
