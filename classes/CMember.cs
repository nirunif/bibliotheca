using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bibliotheca.classes
{
    public class CMember
    {
        string sqlStatement = "";
        public bool AddMember(string FullName, string NIC, DateTime DOB, string Address, string Phone, string Gender, string Email,
            string Occupation, int User_ID, string Status)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Member] ([FullName], [NIC], [DOB], [Address], [Phone],
                                                [Gender], [Email], [Occupation], [User_ID], [Status]) VALUES (@FullName, @NIC, @DOB,
                                                @Address, @Phone, @Gender, @Email, @Occupation, @User_ID, @Status)", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@NIC", NIC);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Occupation", Occupation);
                cmd.Parameters.AddWithValue("@User_ID", User_ID);
                cmd.Parameters.AddWithValue("@Status", Status);

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

        public DataSet LoadMemberDetails(int LoadType, string memberid, string membername)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();

                switch (LoadType)
                {
                    case 0:
                        sqlStatement = @"SELECT Member.ID, Member.MemberID AS [Member ID], Member.FullName AS [Name], Member.Status, Member.NIC, Member.DOB AS [Date of Birth], Member.Address, Member.Phone, Member.Gender, Member.Email, 
                                         Member.Occupation, Member.User_ID AS Username, Users.Password
                                         FROM Member INNER JOIN
                                         Users ON Member.User_ID = Users.ID
                                         WHERE (Member.Status <> 'REMOVED') ORDER BY [Member ID]";
                        break;

                    case 1:
                        sqlStatement = @"SELECT Member.ID, Member.FullName, Member.Status, Member.NIC, Member.DOB, Member.Address, Member.Phone, Member.Gender, Member.Email, 
                                         Member.Occupation, Member.User_ID, Users.Password
                                         FROM Member INNER JOIN
                                         Users ON Member.User_ID = Users.ID
                                         WHERE (Member.MemberID = '" + memberid + "') OR (Member.FullName = '" + membername + "') AND (Member.Status <> 'REMOVED')";
                        break;

                    case 2:
                        sqlStatement = @"SELECT Member.ID, Member.MemberID, Member.FullName, Member.NIC, Member.DOB, Member.Address, Member.Phone, Member.Gender, Member.Email, Member.Occupation, Member.User_ID, Member.Status, 
                                        Book.BookID, Book.BookTitle, MemberBook.Book_ID, MemberBook.DateBorrowed, MemberBook.DateDue, Users.UserID, Users.Password
                                        FROM Member INNER JOIN
                                        MemberBook ON Member.ID = MemberBook.Member_ID INNER JOIN
                                        Users ON Member.User_ID = Users.ID INNER JOIN
                                        Book ON MemberBook.Book_ID = Book.ID
                                        WHERE (Users.UserID='" + memberid + "')";
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

        public Boolean UpdateMemberStatus(string MemberID, string Status)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Member] SET Status='" + Status + "' WHERE MemberID='" + MemberID + "'", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@MemberID", MemberID);
                cmd.Parameters.AddWithValue("@Status", Status);

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

        public Boolean UpdateMemberDetails(string MemberID, string FullName, string NIC, DateTime DOB, string Address, string Phone, string Gender, string Email, string Occupation, int User_ID, string Status)
        {
            try
            {
                connect sqlconn = new connect();
                sqlconn.OpenCo();
                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Member] SET FullName=@FullName, NIC=@NIC, DOB=@DOB, Address=@Address,Phone@Phone,
                                                Gender=@Gender, Email=@Email, Occupation=@Occupation, User_ID=@User_ID, Status=@Status 
                                                WHERE MemberID=@MemberID", sqlconn.Conn);

                cmd.Parameters.AddWithValue("@MemberID", MemberID);
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@NIC", NIC);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Occupation", Occupation);
                cmd.Parameters.AddWithValue("@User_ID", User_ID);
                cmd.Parameters.AddWithValue("@Status", Status);

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