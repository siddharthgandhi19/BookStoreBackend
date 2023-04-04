using CommonLayer.Models.Address;
using CommonLayer.Models.Order;
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
    public class OrderRL : IOrderRL
    {
        string connectionString;
        public OrderRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB"); //connect with db
        }

        public OrderModel AddOrder(OrderModel orderModel, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@AddressId", orderModel.AddressId);
                cmd.Parameters.AddWithValue("@BookId", orderModel.BookId);
                cmd.Parameters.AddWithValue("@TotalQuantity", orderModel.TotalQuantity);

                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return orderModel;
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
        public bool CancelOrder(int OrderId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
                {
                SqlCommand cmd = new SqlCommand("spDeleteOrder", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();

                cmd.Parameters.AddWithValue("@OrderId", OrderId);

                    int result = cmd.ExecuteNonQuery();
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
        public List<GetOrderModel> GetOrders(int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    List<GetOrderModel> getOrderModels = new List<GetOrderModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllOrders", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId ", UserId);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        getOrderModels.Add(new GetOrderModel()
                        {
                            OrderId = Convert.ToInt32(sqlDataReader["OrderId"]),
                            UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                            BookId = Convert.ToInt32(sqlDataReader["BookId"]),
                            BookName = sqlDataReader["BookName"].ToString(),
                            AuthorName = sqlDataReader["AuthorName"].ToString(),
                            OriginalPrice = Convert.ToInt32(sqlDataReader["OriginalPrice"]),
                            DiscountPrice = Convert.ToInt32(sqlDataReader["DiscountPrice"]),
                            BookImage = sqlDataReader["BookImage"].ToString(),
                            OrderDate = sqlDataReader["OrderDate"].ToString(),
                        });
                    }
                    return getOrderModels;
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