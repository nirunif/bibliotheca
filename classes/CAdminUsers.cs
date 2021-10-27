using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class CAdminUsers
    {
        string sqlStatement = "";
        public DataSet GetUser(int LoadType, string AdminUserID, string Password)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT * FROM AdminUsers
                                                WHERE (AdminUserID = '" + AdminUserID + "') AND (Password = '" + Password + "')";
                        break;

                    case 1:
                        sqlStatement = @"SELECT * FROM AdminUsers
                                                WHERE (AdminUserID = '" + AdminUserID + "')";
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
                return null;
            }
        }
    }
}