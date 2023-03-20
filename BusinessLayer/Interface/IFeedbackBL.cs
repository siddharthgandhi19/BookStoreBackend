using CommonLayer.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public bool AddFeedback(FeedbackModel feedbackModel, int UserId);
        public IEnumerable<GetAllFeedback> GetFeedback(int BookId);
        public object GetFeedbackbyId(int FeedbackId, int UserId);
    }
}
