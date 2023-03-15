using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserRegistration UserRegistration(UserRegistration userRegistration);
        public string Login(UserLogin userLogin);
        public string ForgetLoginPassword(ForgetPassword forgetPassword);
    }
}
