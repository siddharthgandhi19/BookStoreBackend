using CommonLayer.Models.Book;
using CommonLayer.Models.User;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepoLayer.Service
{
    public class BookRL : IBookRL
    {
        string connectionString;
        public BookRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStoreDB"); //connect with db
        }

        public BookModel AddBook(BookModel bookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("[spAddNewBook]", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@BookImage", bookModel.BookCount);
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);

                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return bookModel;
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
