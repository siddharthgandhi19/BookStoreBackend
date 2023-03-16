using BusinessLayer.Interface;
using CommonLayer.Models.User;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL iUserRL;
        public UserBL(IUserRL iUserRL)
        {
            this.iUserRL = iUserRL;
        }

        public UserRegistration UserRegistration(UserRegistration userRegistration)
        {
            try
            {
                return iUserRL.UserRegistration(userRegistration);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return iUserRL.Login(userLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ForgetLoginPassword(ForgetPassword forgetPassword)
        {
            try
            {
                return iUserRL.ForgetLoginPassword(forgetPassword);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ResetPassword(ResetPassword resetPassword, string email)
        {
            try
            {
                return iUserRL.ResetPassword(resetPassword, email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
