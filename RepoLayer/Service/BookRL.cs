using CommonLayer.Models.Book;
using CommonLayer.Models.User;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
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
                    SqlCommand cmd = new SqlCommand("spAddNewBook", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
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

        public bool DeleteBook(int bookId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
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
        }

        public BookModel UpdateBook(BookModel bookModel, int bookId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spUpdateBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
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
        public List<BookModel> GetAllBooks()
        {
            try
            {
                List<BookModel> getBookList = new List<BookModel>();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spGetAllBooks", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    BookModel bookModel = new BookModel();
                    bookModel.BookId = Convert.ToInt32(sqlDataReader["BookId"]);
                    bookModel.BookName = sqlDataReader["BookId"].ToString();
                    bookModel.AuthorName = sqlDataReader["AuthorName"].ToString();
                    bookModel.Rating = sqlDataReader["Rating"].ToString();
                    bookModel.TotalCountRating = Convert.ToInt32(sqlDataReader["TotalCountRating"]);
                    bookModel.DiscountPrice = Convert.ToInt32(sqlDataReader["DiscountPrice"]);
                    bookModel.OriginalPrice = Convert.ToInt32(sqlDataReader["OriginalPrice"]);
                    bookModel.Description = sqlDataReader["Description"].ToString();
                    bookModel.BookImage = sqlDataReader["BookImage"].ToString();
                    bookModel.BookCount = Convert.ToInt32(sqlDataReader["BookCount"]);
                    getBookList.Add(bookModel);
                }
                sqlConnection.Close();
                return getBookList;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public object GetBooksById(int bookId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spGetBookById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    sqlConnection.Open();
                    BookModel bookModel = new BookModel();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            bookModel.BookId = Convert.ToInt32(sqlDataReader["BookId"]);
                            bookModel.BookName = sqlDataReader["BookId"].ToString();
                            bookModel.AuthorName = sqlDataReader["AuthorName"].ToString();
                            bookModel.Rating = sqlDataReader["Rating"].ToString();
                            bookModel.TotalCountRating = Convert.ToInt32(sqlDataReader["TotalCountRating"]);
                            bookModel.DiscountPrice = Convert.ToInt32(sqlDataReader["DiscountPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(sqlDataReader["OriginalPrice"]);
                            bookModel.Description = sqlDataReader["Description"].ToString();
                            bookModel.BookImage = sqlDataReader["BookImage"].ToString();
                            bookModel.BookCount = Convert.ToInt32(sqlDataReader["BookCount"]);
                        }
                        sqlConnection.Close();
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
