using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public  interface IUserRL
    {
        public UserRegistration UserRegistration(UserRegistration userRegistration);
    }
}
