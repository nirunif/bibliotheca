using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class CBook
    {
        string sqlStatement = "";

        public DataSet LoadBookDetails(int LoadType, string BookID, string BookTitle)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT        Book.ID, Book.BookID, Book.BookTitle, Book.Description, Book.Pub_ID, Book.Publish_Date, Book.Author_ID, Book.Genre, Book.Language, Book.Edition, Book.NoOfPages, Book.Cost, Book.ActualStock, 
                                         Book.CurrentStock, Book.BookImg
                                         FROM Book INNER JOIN
                                         Author ON Book.Author_ID = Author.ID INNER JOIN
                                         Publisher ON Book.Pub_ID = Publisher.ID
                                         WHERE (Book.BookID = '" + BookID + "') OR (Book.BookTitle='" + BookTitle + "')";
                        break;

                    case 1:
                        sqlStatement = @"SELECT Book.ID, Book.BookID AS [Book ID], Book.BookTitle AS Title, Book.Description, Author.AuthorName AS Author, Publisher.PublisherName AS Publisher, Book.Pub_ID, Book.Publish_Date, Book.Author_ID, 
                                        Book.Genre, Book.Language, Book.Edition, Book.NoOfPages AS [Page Count], Book.Cost, Book.ActualStock, Book.CurrentStock, Book.BookImg AS Cover
                                        FROM Book INNER JOIN
                                        Publisher ON Book.Pub_ID = Publisher.ID INNER JOIN
                                        Author ON Book.Author_ID = Author.ID";
                        break;

                    case 2:
                        sqlStatement = @"SELECT        Book.ID, Book.BookID, Book.BookTitle, Book.Description, Book.Pub_ID, Book.Publish_Date, Book.Author_ID, Book.Genre, Book.Language, Book.Edition, Book.NoOfPages, Book.Cost, Book.ActualStock, 
                                         Book.CurrentStock, Book.BookImg
                                         FROM Book INNER JOIN
                                         Author ON Book.Author_ID = Author.ID INNER JOIN
                                         Publisher ON Book.Pub_ID = Publisher.ID
                                         WHERE (Book.BookID = '" + BookID + "') AND (Book.BookTitle='" + BookTitle + "')";
                        break;
                }

                SqlCommand cmd = new SqlCommand(sqlStatement, sqlconn.Conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sqlconn.Conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                //Response.Write()
                return null;
            }
        }

        public Boolean AddBook(string BookTitle, string Description, int Pub_ID, DateTime Publish_Date, int Author_ID, string Genre, string Language, string Edition, int NoOfPages,
                                double Cost, int ActualStock, int CurrentStock, string BookImg)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Book] ([BookTitle],[Description],[Pub_ID],[Publish_Date],[Author_ID],[Genre],
                                                [Language],[Edition],[NoOfPages],[Cost],[ActualStock],[CurrentStock],[BookImg])
                                                VALUES (@BookTitle, @Description, @Pub_ID, @Publish_Date, @Author_ID, @Genre, @Language, @Edition,
                                                @NoOfPages, @Cost, @ActualStock, @CurrentStock, @BookImg)", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@BookTitle", BookTitle);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Pub_ID", Pub_ID);
                cmd.Parameters.AddWithValue("@Publish_Date", Publish_Date);
                cmd.Parameters.AddWithValue("@Author_ID", Author_ID);
                cmd.Parameters.AddWithValue("@Genre", Genre);
                cmd.Parameters.AddWithValue("@Language", Language);
                cmd.Parameters.AddWithValue("@Edition", Edition);
                cmd.Parameters.AddWithValue("@NoOfPages", NoOfPages);
                cmd.Parameters.AddWithValue("@Cost", Cost);
                cmd.Parameters.AddWithValue("@ActualStock", ActualStock);
                cmd.Parameters.AddWithValue("@CurrentStock", CurrentStock);
                cmd.Parameters.AddWithValue("@BookImg", BookImg);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                sqlconn.Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean UpdateBookDetails(string BookID, string BookTitle, string Description, int Pub_ID, DateTime Publish_Date, int Author_ID, string Genre, string Language, string Edition, 
                                        int NoOfPages, double Cost, int ActualStock, int CurrentStock, string BookImg)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE Book SET BookTitle=@BookTitle, Description=@Description, Pub_ID=@Pub_ID, Publish_Date=@Publish_Date, Author_ID=@Author_ID, Genre=@Genre,
                                                Language=@Language, Edition=@Edition, NoOfPages=@NoOfPages, Cost=@Cost, ActualStock=@ActualStock, CurrentStock=@CurrentStock, BookImg=@BookImg
                                                WHERE BookID=@BookID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@BookTitle", BookTitle);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Pub_ID", Pub_ID);
                cmd.Parameters.AddWithValue("@Publish_Date", Publish_Date);
                cmd.Parameters.AddWithValue("@Author_ID", Author_ID);
                cmd.Parameters.AddWithValue("@Genre", Genre);
                cmd.Parameters.AddWithValue("@Language", Language);
                cmd.Parameters.AddWithValue("@Edition", Edition);
                cmd.Parameters.AddWithValue("@NoOfPages", NoOfPages);
                cmd.Parameters.AddWithValue("@Cost", Cost);
                cmd.Parameters.AddWithValue("@ActualStock", ActualStock);
                cmd.Parameters.AddWithValue("@CurrentStock", CurrentStock);
                cmd.Parameters.AddWithValue("@BookImg", BookImg);
                cmd.Parameters.AddWithValue("@BookID", BookID);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                sqlconn.Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean RemoveBookStock(int ID)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE Book SET CurrentStock=(CurrentStock - 1) WHERE ID=@ID", sqlconn.Conn);
                                
                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                sqlconn.Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean AddBookStock(int ID)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE Book SET CurrentStock=(CurrentStock + 1) WHERE ID=@ID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                sqlconn.Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet CheckAvailability(int LoadType, string BookID, string BookTitle)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT ActualStock, CurrentStock FROM Book
                                         WHERE (BookID = '" + BookID + "') OR (BookTitle='" + BookTitle + "')";
                        break;
                }

                SqlCommand cmd = new SqlCommand(sqlStatement, sqlconn.Conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sqlconn.Conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                //Response.Write()
                return null;
            }
        }
    }
}