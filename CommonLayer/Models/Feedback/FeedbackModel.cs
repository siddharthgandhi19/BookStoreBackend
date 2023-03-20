using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Feedback
{
    public class FeedbackModel
    {
        public string Rating { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
    }
}
