using CommonLayer.Models.Address;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CommonLayer.Models.User;

namespace RepoLayer.Service
{
    public class AddressRL : IAddressRL
    {
        string connectionString;

        public AddressRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB"); //connect with db
        }

        public AddressModel AddAddress(AddressModel addressModel, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {               
                SqlCommand cmd = new SqlCommand("spAddAddress", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FullName", addressModel.FullName);
                cmd.Parameters.AddWithValue("@MobileNumber", addressModel.MobileNumber);
                cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                cmd.Parameters.AddWithValue("@City", addressModel.City);
                cmd.Parameters.AddWithValue("@State", addressModel.State);
                cmd.Parameters.AddWithValue("@AddressTypeId", addressModel.AddressTypeId);
                cmd.Parameters.AddWithValue("@UserId ", UserId);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (result >= 1)
                {
                    return addressModel;
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
        public bool DeleteAddress(AddressIdModel addressIdModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteAddress", sqlConnection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AddressId", addressIdModel.AddressId);

                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (result >= 1)
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
        public AddressModel UpdateAddress(AddressModel addressModel, int AddressId, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateAddress", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId ", UserId);
                cmd.Parameters.AddWithValue("@AddressId", AddressId);
                cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                cmd.Parameters.AddWithValue("@City", addressModel.City);
                cmd.Parameters.AddWithValue("@State", addressModel.State);
                cmd.Parameters.AddWithValue("@AddressTypeId", addressModel.AddressTypeId);
                


                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (result >= 1)
                {
                    return addressModel;
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
        public List<AddressModel> GetAddress()
        {
            List<AddressModel> getAllAddress = new List<AddressModel>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spGetAllAddress", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                AddressModel address = new AddressModel();
                address.Address = sqlDataReader["Address"].ToString();
                address.City = sqlDataReader["City"].ToString();
                address.State = sqlDataReader["State"].ToString();
                address.AddressTypeId = Convert.ToInt32(sqlDataReader["AddressTypeId"]);

                getAllAddress.Add(address);
            }
            sqlConnection.Close();
            return getAllAddress;
        }
    }
}
