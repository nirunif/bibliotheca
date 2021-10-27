using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class CAuthor
    {
        string sqlStatement = "";
        public DataSet LoadAuthor(int LoadType, string AuthorID, string Authorname)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT AuthorID AS [Author ID], AuthorName AS [Author Name] FROM Author
                                                WHERE (AuthorID = '" + AuthorID + "') AND (AuthorName = '" + Authorname + "')";
                        break;

                    case 1:
                        sqlStatement = @"SELECT AuthorID, AuthorName FROM Author
                                                WHERE (AuthorName = '" + Authorname + "') OR (AuthorID = '" + AuthorID + "')";
                        break;

                    case 2:
                        sqlStatement = @"SELECT ID, AuthorID AS [Author ID], AuthorName AS [Author Name] FROM Author";
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

        public Boolean AddAuthor(string AuthorName)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Author (AuthorName) 
                                                VALUES (@AuthorName)", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@AuthorName", AuthorName);

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

        public Boolean UpdateAuthor(string AuthorID, string AuthorName)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE Author SET AuthorName=@AuthorName
                                                WHERE AuthorID=@AuthorID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@AuthorName", AuthorName);
                cmd.Parameters.AddWithValue("@AuthorID", AuthorID);

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

        public Boolean DeleteAuthor(string AuthorID)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Author WHERE AuthorID=@AuthorID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@AuthorID", AuthorID);

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
    }
}