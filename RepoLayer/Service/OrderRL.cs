using CommonLayer.Models.Address;
using CommonLayer.Models.Order;
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
        public List<GetOrderModel> GetOrders()
        {
            List<GetOrderModel> getAllOrderModel = new List<GetOrderModel>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spGetAllOrders", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                GetOrderModel getOrderModel = new GetOrderModel();
                getOrderModel.OrderId = Convert.ToInt32(sqlDataReader["OrderId"]);
                getOrderModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                getOrderModel.BookId = Convert.ToInt32(sqlDataReader["BookId"]);
                getOrderModel.AddressId = Convert.ToInt32(sqlDataReader["AddressId"]);
                getOrderModel.TotalPrice = Convert.ToInt32(sqlDataReader["TotalPrice"]);
                getOrderModel.OrderDate = sqlDataReader["OrderDate"].ToString();

                getAllOrderModel.Add(getOrderModel);
            }
            sqlConnection.Close();
            return getAllOrderModel;
        }
    }
}