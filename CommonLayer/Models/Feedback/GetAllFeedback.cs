using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Feedback
{
    public class GetAllFeedback
    {
        public int UserId { get; set; }
        public int FeedbackId { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
        public string FullName { get; set; }
    }
}
