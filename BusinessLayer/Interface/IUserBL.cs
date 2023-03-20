using CommonLayer.Models.User;
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
        public bool ResetPassword(ResetPassword resetPassword, string email);
        public List<UserRegistration> GetAllUsers();
    }
}
