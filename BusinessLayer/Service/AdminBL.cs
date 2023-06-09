﻿using BusinessLayer.Interface;
using CommonLayer.Models.Admin;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        IAdminRL iAdminRL;
        public AdminBL(IAdminRL iAdminRL) 
        {
            this.iAdminRL = iAdminRL;

        }

        public string AdminLogin(AdminLogin adminLogin)
        {
            try
            {
                return iAdminRL.AdminLogin(adminLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
