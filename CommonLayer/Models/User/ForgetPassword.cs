using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.User
{
    public class ForgetPassword
    {
        [Required]
        public string Email { get; set; }
    }
}
