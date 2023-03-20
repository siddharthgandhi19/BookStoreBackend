using CommonLayer.Models.WishList;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepoLayer.Service
{
    public class WishListRL : IWishListRL
    {
        string connectionString;

        public WishListRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB");
        }

        public bool AddWishList(int BookId, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddToWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", BookId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
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

        public bool DeleteWishList(int WishListId, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", WishListId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
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

        public IEnumerable<WishListModel> GetAllWishList(int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                   
                    List<WishListModel> wishlist = new List<WishListModel>();
                    SqlCommand cmd = new SqlCommand("spGetWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId ", UserId);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        wishlist.Add(new WishListModel()
                        {
                            WishListId = Convert.ToInt32(sqlDataReader["WishListId"]),
                            BookId = Convert.ToInt32(sqlDataReader["BookId"]),
                            UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                            BookImage = sqlDataReader["BookImage"].ToString(),
                            AuthorName = sqlDataReader["AuthorName"].ToString(),
                            OriginalPrice = Convert.ToInt32(sqlDataReader["OriginalPrice"]),
                            DiscountPrice = Convert.ToInt32(sqlDataReader["DiscountPrice"]),
                            BookName = sqlDataReader["BookName"].ToString(),

                        });
                    }
                    return wishlist;
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

    }
}
