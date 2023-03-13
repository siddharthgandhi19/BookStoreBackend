using BusinessLayer.Interface;
using CommonLayer.Models;
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
    }
}
