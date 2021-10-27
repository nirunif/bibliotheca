using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class CPublisher
    {
        string sqlStatement = "";
        public DataSet LoadPublishers(int LoadType, string PublisherID, string PublisherName)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT PublisherID, PublisherName FROM Publisher
                                                WHERE (PublisherName = '" + PublisherName + "') OR (PublisherID = '" + PublisherID + "')";
                        break;

                    case 1:
                        sqlStatement = @"SELECT ID, PublisherID AS [Publisher ID], PublisherName AS [Publisher Name] FROM Publisher";
                        break;
                    case 2:
                        sqlStatement = @"SELECT PublisherID, PublisherName FROM Publisher
                                                WHERE (PublisherName = '" + PublisherName + "') AND (PublisherID = '" + PublisherID + "')";
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

        public Boolean AddPublisher(string PublisherName)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Publisher (PublisherName) 
                                                VALUES (@PublisherName)", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@PublisherName", PublisherName);

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

        public Boolean UpdatePublisher(string PublisherID, string PublisherName)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE Publisher SET PublisherName=@PublisherName
                                                WHERE PublisherID=@PublisherID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@PublisherName", PublisherName);
                cmd.Parameters.AddWithValue("@PublisherID", PublisherID);

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

        public Boolean DeletePublisher(string PublisherID)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Publisher WHERE PublisherID=@PublisherID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@PublisherID", PublisherID);

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