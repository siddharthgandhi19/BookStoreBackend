using CommonLayer.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IAdminRL
    {
        public string AdminLogin(AdminLogin adminLogin);
    }
}
