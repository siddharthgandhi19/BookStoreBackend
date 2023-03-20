using BusinessLayer.Interface;
using CommonLayer.Models.Book;
using CommonLayer.Models.Feedback;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedbackBL : IFeedbackBL
    {
        IFeedbackRL iFeedbackRL;
        public FeedbackBL(IFeedbackRL iFeedbackRL)
        {
            this.iFeedbackRL = iFeedbackRL;
        }

        public bool AddFeedback(FeedbackModel feedbackModel, int UserId)
        {
            try
            {
                return iFeedbackRL.AddFeedback(feedbackModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetAllFeedback> GetFeedback(int BookId)
        {
            try
            {
                return iFeedbackRL.GetFeedback(BookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetFeedbackbyId(int FeedbackId, int UserId)
        {
            try
            {
                return iFeedbackRL.GetFeedbackbyId(FeedbackId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
