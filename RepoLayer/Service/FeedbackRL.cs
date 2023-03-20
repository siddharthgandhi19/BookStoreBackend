using CommonLayer.Models.Feedback;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using RepoLayer.Interface;
using System.Runtime.InteropServices;

namespace RepoLayer.Service
{
    public class FeedbackRL : IFeedbackRL
    {
        string connectionString;
        public FeedbackRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB");
        }

        public bool AddFeedback(FeedbackModel feedbackModel, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spAddFeedback", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rating", feedbackModel.Rating);
                    cmd.Parameters.AddWithValue("@Comment", feedbackModel.Comment);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@BookId", feedbackModel.BookId);
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
        }

        public IEnumerable<GetAllFeedback> GetFeedback(int BookId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    List<GetAllFeedback> getAllFeedbacks = new List<GetAllFeedback>();
                    SqlCommand cmd = new SqlCommand("spGetFeedback", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId ", BookId);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        getAllFeedbacks.Add(new GetAllFeedback()
                        {
                            FeedbackId = Convert.ToInt32(sqlDataReader["FeedbackId"]),
                            Rating = sqlDataReader["Rating"].ToString(),
                            Comment = sqlDataReader["Comment"].ToString(),
                            BookId = Convert.ToInt32(sqlDataReader["BookId"]),
                            UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                            FullName = sqlDataReader["FullName"].ToString(),
                        });
                    }
                    return getAllFeedbacks;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public object GetFeedbackbyId(int FeedbackId, int UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetFeedbackById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeedbackId", FeedbackId);
                    sqlConnection.Open();

                    GetAllFeedback getAllFeedback = new GetAllFeedback();

                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        getAllFeedback.FeedbackId = Convert.ToInt32(sqlDataReader["FeedbackId"]);
                        getAllFeedback.BookId = Convert.ToInt32(sqlDataReader["BookId"]);
                        getAllFeedback.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                        getAllFeedback.Rating = sqlDataReader["Rating"].ToString();
                        getAllFeedback.Comment = sqlDataReader["Comment"].ToString();
                        getAllFeedback.FullName = sqlDataReader["FullName"].ToString();
                    }
                    return getAllFeedback;
                }
                catch (Exception)
                {

                    throw;
                }
        }
    }
}
