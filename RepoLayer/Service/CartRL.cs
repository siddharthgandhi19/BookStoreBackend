using CommonLayer.Models.Cart;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepoLayer.Service
{
    public class CartRL : ICartRL
    {
        string connectionString;
        public CartRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB"); //connect with db
        }

        public CartInputModel AddToCart(CartInputModel cartInputModel, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spAddToCart", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@UserId ", UserId);
                cmd.Parameters.AddWithValue("@BookId ", cartInputModel.BookId);
                cmd.Parameters.AddWithValue("@BookCount ", cartInputModel.BookCount);
                


                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return cartInputModel;
                }
                else
                {
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

        public bool DeleteCart(int CartId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spDeleteFromCart", sqlConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartId", CartId);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (result > 0)
                {
                    return true;
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

        public bool UpdateCart(int CartId, int Quantity, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateCart", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CartId", CartId);
                    sqlCommand.Parameters.AddWithValue("@Quantity", Quantity);

                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public IEnumerable <GetCartOfUser> GetCartByUserId(CartByUserIdModel cartByUserIdModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spGetCartByUserId", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", cartByUserIdModel.UserId);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                List<GetCartOfUser> GetCartOfUserList = new List<GetCartOfUser>();

                while (rdr.Read())
                {
                    GetCartOfUser getCartOfUser = new GetCartOfUser();

                    getCartOfUser.CartId = Convert.ToInt32(rdr["CartId"]);

                    getCartOfUser.UserId = Convert.ToInt32(rdr["UserId"]);
                    getCartOfUser.BookId = Convert.ToInt32(rdr["BookId"]);
                    getCartOfUser.Quantity = Convert.ToInt32(rdr["Quantity"]);
                    GetCartOfUserList.Add(getCartOfUser);
                }
                sqlConnection.Close();
                return GetCartOfUserList;
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

        public IEnumerable<GetCartOfUser> GetCartByCartId(int UserId,int CartId )
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spGetCartByCartId", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@CartId", CartId);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                List<GetCartOfUser> GetCartOfUserList = new List<GetCartOfUser>();

                while (rdr.Read())
                {
                    GetCartOfUser getCartOfUser = new GetCartOfUser();

                    getCartOfUser.CartId = Convert.ToInt32(rdr["CartId"]);
                    getCartOfUser.UserId = Convert.ToInt32(rdr["UserId"]);
                    getCartOfUser.BookId = Convert.ToInt32(rdr["BookId"]);
                    getCartOfUser.Quantity = Convert.ToInt32(rdr["Quantity"]);
                    GetCartOfUserList.Add(getCartOfUser);
                }
                sqlConnection.Close();
                return GetCartOfUserList;
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
    }
}
