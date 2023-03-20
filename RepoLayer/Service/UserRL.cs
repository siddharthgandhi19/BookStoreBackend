using CommonLayer.Models.Book;
using CommonLayer.Models.MSMQ;
using CommonLayer.Models.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RepoLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly string _secret;
        private readonly string _expDate;
        string connectionString;

        public UserRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB"); //connect with db
            _secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public UserRegistration UserRegistration(UserRegistration userRegistration)
        {
            //Read the connection string 
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using (sqlConnection)
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand("spUserRegistration", sqlConnection);
                    //Specify that the SqlCommand is a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@FullName", userRegistration.FullName);
                    cmd.Parameters.AddWithValue("@Email", userRegistration.Email);
                    cmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                    cmd.Parameters.AddWithValue("@Mobile", userRegistration.Mobile);
                    //Open the connection and execute the query
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery(); // FOR COMMANDS

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

        public string Login(UserLogin userLogin)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spUserLogin", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", userLogin.Password);

                    sqlConnection.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        LoginCredentials loginCredentials = new LoginCredentials();
                        loginCredentials.UserId = Convert.ToInt32(rdr["UserId"]);
                        loginCredentials.Email = rdr["Email"].ToString();

                        if (loginCredentials.Email != null)
                        {
                            sqlConnection.Close();
                            return GenerateSecurityToken(loginCredentials.Email, loginCredentials.UserId);
                        }
                        sqlConnection.Close();
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GenerateSecurityToken(string email, long UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        public string ForgetLoginPassword(ForgetPassword forgetPassword)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spForgotPassword", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", forgetPassword.Email);
                    sqlConnection.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        LoginCredentials loginCredentials = new LoginCredentials();
                        loginCredentials.UserId = Convert.ToInt32(rdr["UserId"]);
                        loginCredentials.Email = rdr["Email"].ToString();

                        if (loginCredentials.Email != null)
                        {
                            sqlConnection.Close();
                            MSMQModel mSMQModel = new MSMQModel();
                            string token = GenerateSecurityToken(loginCredentials.Email, loginCredentials.UserId);
                            mSMQModel.sendData2Queue(token);
                            return token;
                        }
                    }
                    sqlConnection.Close();
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public bool ResetPassword(ResetPassword resetPassword, string email)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (resetPassword.Password == resetPassword.Confirm_Passwords)
                {
                    SqlCommand cmd = new SqlCommand("spResetPassword", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", resetPassword.Password);

                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public List<UserRegistration> GetAllUsers()
        {
            try
            {
                List<UserRegistration> getAllUsers = new List<UserRegistration>();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spGetAllUsers", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    UserRegistration userRegistration = new UserRegistration();
                    userRegistration.FullName = sqlDataReader["FullName"].ToString();
                    userRegistration.Email = sqlDataReader["Email"].ToString();
                    userRegistration.Password = sqlDataReader["Password"].ToString();
                    userRegistration.Mobile = sqlDataReader["Mobile"].ToString();
                    getAllUsers.Add(userRegistration);
                }
                sqlConnection.Close();
                return getAllUsers;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}