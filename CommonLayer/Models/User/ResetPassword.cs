using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.User
{
    public class ResetPassword
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Confirm_Passwords { get; set; }
    }
}
