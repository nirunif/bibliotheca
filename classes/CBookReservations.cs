using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class CBookReservations
    {
        string sqlStatement = "";
        public DataSet GetReservations(int LoadType, string username, string bookreserveid, int memberid, int bookid)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT BookReservation.ID, BookReservation.BookReserveID, BookReservation.Book_ID, BookReservation.Member_ID, BookReservation.Date, BookReservation.Status, Book.BookID, Book.BookTitle, Member.MemberID, BookReservation.AdminStatus,
                                        Member.FullName, Member.User_ID, Users.UserID
                                        FROM BookReservation INNER JOIN
                                        Book ON BookReservation.Book_ID = Book.ID INNER JOIN
                                        Member ON BookReservation.Member_ID = Member.ID INNER JOIN
                                        Users ON Member.User_ID = Users.ID 
                                        WHERE (BookReservation.Status <> 'Collected')";
                        break;

                    case 1:
                        sqlStatement = @"SELECT BookReservation.ID, BookReservation.BookReserveID, BookReservation.Book_ID, BookReservation.Member_ID, BookReservation.Date, BookReservation.Status, Book.BookID, Book.BookTitle, Member.MemberID, BookReservation.AdminStatus,
                                        Member.FullName, Member.User_ID, Users.UserID
                                        FROM BookReservation INNER JOIN
                                        Book ON BookReservation.Book_ID = Book.ID INNER JOIN
                                        Member ON BookReservation.Member_ID = Member.ID INNER JOIN
                                        Users ON Member.User_ID = Users.ID 
                                        WHERE (Users.UserID='" + username + "') OR (BookReservation.BookReserveID='" + bookreserveid + "')";
                        break;

                    case 2:
                        sqlStatement = @"SELECT ID, BookReserveID, Book_ID, Member_ID, Date, Status, BookReservation.AdminStatus
                                       FROM BookReservation
                                       WHERE (BookReserveID = '" + bookreserveid + "')";
                        break;

                    case 3:
                        sqlStatement = @"SELECT ID, BookReserveID, Book_ID, Member_ID, Date, Status, AdminStatus
                                       FROM BookReservation
                                       WHERE (Member_ID='" + memberid + "') AND (Book_ID='" + bookid + "')";

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

        public Boolean AddReservation(int Book_ID, int Member_ID, DateTime Date, string Status, string AdminStatus)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO BookReservation (Book_ID, Member_ID, Date, Status, AdminStatus) 
                                                VALUES (@Book_ID, @Member_ID, @Date, @Status, @AdminStatus)", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@Book_ID", Book_ID);
                cmd.Parameters.AddWithValue("@Member_ID", Member_ID);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@AdminStatus", AdminStatus);

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

        public Boolean UpdateReservationStatus(string BookReserveID, string Status, string AdminStatus)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[BookReservation] SET Status='" + Status + "', AdminStatus='" + AdminStatus + "' WHERE BookReserveID='" + BookReserveID + "'", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@BookReserveID", BookReserveID);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@AdminStatus", AdminStatus);

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

        public Boolean CancelReservation(string BookReserveID)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM BookReservation WHERE BookReserveID='" + BookReserveID + "'", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@BookReserveID", BookReserveID);

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