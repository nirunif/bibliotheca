using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class connect
    {
        //class used to connect to database
        public DataSet DSet = new DataSet();
        public SqlDataAdapter Sqlda = new SqlDataAdapter();
        public SqlCommand Cmd = new SqlCommand();
        public SqlConnection Conn = new SqlConnection();

        public string Sqlds = @"Data Source=LAPTOP-ECBB9IGA;Initial Catalog=dbBibliotheca;Integrated Security=True";  //change the string here according to the where the db is restored

        public SqlConnection OpenCo()
        {
            Conn.ConnectionString = Sqlds;
            Conn.Open();
            return Conn;
        }
    }
}