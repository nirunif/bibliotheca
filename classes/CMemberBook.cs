using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class CMemberBook
    {
        string sqlStatement = "";

        public Boolean AddMemberBook(int Member_ID, int Book_ID, DateTime DateBorrowed, DateTime DateDue)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO MemberBook (Member_ID, Book_ID, DateBorrowed, DateDue) 
                                                VALUES (@Member_ID, @Book_ID, @DateBorrowed, @DateDue)", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@Member_ID", Member_ID);
                cmd.Parameters.AddWithValue("@Book_ID", Book_ID);
                cmd.Parameters.AddWithValue("@DateBorrowed", DateBorrowed);
                cmd.Parameters.AddWithValue("@DateDue", DateDue);

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

        public DataSet LoadMemberBookDetails(int LoadType, string memberid, string bookid, int id)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT MemberBook.ID, MemberBook.Member_ID, MemberBook.Book_ID, Member.MemberID, Member.FullName, Book.BookID, Book.BookTitle, MemberBook.DateBorrowed, MemberBook.DateDue
                                         FROM MemberBook INNER JOIN
                                         Member ON MemberBook.Member_ID = Member.ID INNER JOIN
                                         Book ON MemberBook.Book_ID = Book.ID";
                        break;

                    case 1: //check for issue entry
                        sqlStatement = @"SELECT MemberBook.ID, MemberBook.Member_ID, MemberBook.Book_ID, Member.MemberID, Member.FullName, Book.BookID, Book.BookTitle, MemberBook.DateBorrowed, MemberBook.DateDue
                                        FROM MemberBook INNER JOIN
                                        Member ON MemberBook.Member_ID = Member.ID INNER JOIN
                                        Book ON MemberBook.Book_ID = Book.ID
                                        WHERE (Member.MemberID = '" + memberid + "') AND (Book.BookID = '"+bookid+"')";
                        break;

                    case 2:
                        sqlStatement = @"SELECT COUNT(*) AS IssueCount
                                         FROM  MemberBook
                                         WHERE (Member_ID = '" + id + "')";
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

        public Boolean RemoveRecord(int Member_ID, int Book_ID)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM MemberBook WHERE Member_ID='" + Member_ID + "' AND Book_ID='" + Book_ID + "'", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@Member_ID", Member_ID);
                cmd.Parameters.AddWithValue("@Book_ID", Book_ID);

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