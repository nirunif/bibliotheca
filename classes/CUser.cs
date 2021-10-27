using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{    
    public class CUser
    {
        string sqlStatement = "";

        public Boolean AddUser(string UserID, string Password, int Type)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Users (UserID, Password, Type) 
                                                VALUES (@UserID, @Password, @Type)", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Type", Type);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                sqlconn.Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                //Response.Write()
                return false;
            }
        }

        public Boolean UpdateUser(int ID, string UserID, string Password)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE Users SET UserID=@UserID, Password=@Password
                                                WHERE ID=@ID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Password", Password);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                sqlconn.Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                //Response.Write()
                return false;
            }
        }

        public DataSet GetUser(int LoadType, string UserID, string Password, int Type)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT * FROM Users
                                                WHERE (UserID = '" + UserID + "') AND (Password = '" + Password + "') AND (Type = '" + Type+ "')";
                        break;

                    case 1:
                        sqlStatement = @"SELECT * FROM Users
                                                WHERE (UserID = '" + UserID + "')";
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