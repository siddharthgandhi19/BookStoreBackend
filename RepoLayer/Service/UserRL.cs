using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace RepoLayer.Service
{
    public class UserRL : IUserRL
    {
        string connectionString;

        public UserRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB");
        }

        public UserRegistration UserRegistration (UserRegistration userRegistration)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spUserRegistration", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", userRegistration.FullName);
                    cmd.Parameters.AddWithValue("@Email", userRegistration.Email);
                    cmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                    cmd.Parameters.AddWithValue("@Mobile", userRegistration.Mobile);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        return userRegistration;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
