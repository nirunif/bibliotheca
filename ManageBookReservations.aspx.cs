using Bibliotheca.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheca
{
    public partial class ManageBookReservations : System.Web.UI.Page
    {
        DataSet dsReservation = new DataSet();
        CBookReservations objReservation = new CBookReservations();
        CBook objBook = new CBook();
        DataSet dsBook = new DataSet();
        CMemberBook objMemBook = new CMemberBook();
        DataSet dsMember = new DataSet();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            linkbtnStatusReserved.Enabled = true;
            GetAllReservations();
        }

        private void GetAllReservations()
        {
            string username = "", id = "";
            int memid = 0, bid = 0;
            dsReservation = objReservation.GetReservations(0, username, id, memid, bid);
            if (dsReservation.Tables[0].Rows.Count >= 0)
            {
                dgvReservations.DataSource = dsReservation;
                dgvReservations.DataBind();
            }
        }

        protected void linkbtnSearch_Click(object sender, EventArgs e)
        {
            string bookreserveid = "", username = "";
            int memid = 0, bid = 0;
            bookreserveid = txtBookReservationID.Text;
            dsReservation = objReservation.GetReservations(1, username, bookreserveid, memid, bid);
            if (dsReservation.Tables[0].Rows.Count >= 1)
            {
                txtMemberID.Text = dsReservation.Tables[0].Rows[0]["MemberID"].ToString();
                txtMemberName.Text = dsReservation.Tables[0].Rows[0]["FullName"].ToString();
                txtBookID.Text = dsReservation.Tables[0].Rows[0]["BookID"].ToString();
                txtBookName.Text = dsReservation.Tables[0].Rows[0]["BookTitle"].ToString();
                txtDate.Text = dsReservation.Tables[0].Rows[0]["Date"].ToString();
                txtReservationstatus.Text = dsReservation.Tables[0].Rows[0]["Status"].ToString();
                txtBId.Text = dsReservation.Tables[0].Rows[0]["Book_ID"].ToString();
                txtMId.Text = dsReservation.Tables[0].Rows[0]["Member_ID"].ToString();
            }

        }

        protected void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter Book ID to get availability');</script>");
            }
            else
            {
                string bookid = "", bookname = "";
                int stock = 0;
                bookid = txtBookID.Text.ToString();
                bookname = txtBookName.Text.ToString();
                dsBook = objBook.CheckAvailability(0, bookid, bookname);
                if (dsBook.Tables[0].Rows.Count >= 1)
                {
                    stock = int.Parse(dsBook.Tables[0].Rows[0]["CurrentStock"].ToString());

                    if (stock >= 1)
                    {
                        Response.Write("<script>alert('No. of books in stock: '+'"+stock+"');</script>");
                    }
                    else
                    {
                        linkbtnStatusReserved.Enabled = false;
                    }
                }
            }
        }

        private void Clear()
        {
            txtBookReservationID.Text = "";
            txtMemberID.Text = "";
            txtMemberName.Text = "";
            txtBookName.Text = "";
            txtBookID.Text = "";
            txtDate.Text = "";
            txtReservationstatus.Text = "";
        }

        private void UpdateReservationStatus(string Status, string AdminStatus)
        {
            string reservationid = "";
            reservationid = txtBookReservationID.Text.ToString();

            Boolean isSaved = false;
            isSaved = objReservation.UpdateReservationStatus(reservationid, Status, AdminStatus);
            Response.Write("<script>alert('Reservation Status updated to '+'" + AdminStatus + "'+'!');</script>");
                Clear();
                GetAllReservations();
           


        }

        protected void linkbtnStatusReserved_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookReservationID.Text))
            {
                Response.Write("<script>alert('Enter reservation ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string reservationid = "", username = "";
                int memid = 0, bid = 0;
                reservationid = txtBookReservationID.Text.ToString();
                dsReservation = objReservation.GetReservations(1, username, reservationid, memid, bid);
                if (dsReservation.Tables[0].Rows.Count >= 1)
                {
                    string status = dsReservation.Tables[0].Rows[0]["Status"].ToString();
                    string adminstatus = dsReservation.Tables[0].Rows[0]["AdminStatus"].ToString();
                    Boolean isSaved = false;

                    if (status == "Cancel")
                    {
                        Response.Write("<script>alert('Reservation requested to cancel!');</script>");
                    }
                    else
                    {
                        dsReservation = objReservation.GetReservations(2, username, reservationid, memid, bid);
                        if (dsReservation.Tables[0].Rows.Count >= 1) //reservation exists
                        {
                            status = "Reserved";
                            adminstatus = "RESERVED";
                            UpdateReservationStatus(status, adminstatus);

                            int bookid = 0;
                            bookid = int.Parse(txtBId.Text.Trim().ToString());
                            isSaved = objBook.RemoveBookStock(bookid); //remove a book from stock
                        }
                        else //reservation does not exist
                        {
                            Response.Write("<script>alert('No reservation found for the ID entered!');</script>");
                            return;
                        }
                    }
                }

                
            }
        }

        protected void linkbtnStatusPending_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookReservationID.Text))
            {
                Response.Write("<script>alert('Enter reservation ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string reservationid = "", username = "";
                int memid = 0, bid = 0;
                reservationid = txtBookReservationID.Text.ToString();

                dsReservation = objReservation.GetReservations(2, username, reservationid, memid, bid);
                if (dsReservation.Tables[0].Rows.Count >= 1) //reservation exists
                {
                    string status = "Pending";
                    string adminstatus = "PENDING";
                    UpdateReservationStatus(status, adminstatus);
                }
                else //reservation does not exist
                {
                    Response.Write("<script>alert('No reservation found for the ID entered!');</script>");
                    return;
                }
            }
        }


        protected void linkbtnStatusCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookReservationID.Text))
            {
                Response.Write("<script>alert('Enter reservation ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {

                string reserveid = "", username = "";
                int memid = 0, bid = 0;
                reserveid = txtBookReservationID.Text.ToString();
                dsReservation = objReservation.GetReservations(1, username, reserveid, memid, bid);
                if (dsReservation.Tables[0].Rows.Count >= 1)
                {
                    string status = dsReservation.Tables[0].Rows[0]["Status"].ToString();
                    string adminstatus = dsReservation.Tables[0].Rows[0]["AdminStatus"].ToString();
                    Boolean isSaved = false;

                    if (adminstatus == "RESERVED")
                    {
                        int bookid = 0;
                        bookid = int.Parse(txtBId.Text.Trim().ToString());

                        isSaved = objReservation.CancelReservation(reserveid);
                        isSaved = objBook.AddBookStock(bookid);
                        Response.Write("<script>alert('Reservation cancelled successfully!');</script>");
                        Clear();
                        GetAllReservations();
                    }
                    else
                    {
                        isSaved = objReservation.CancelReservation(reserveid);
                        Response.Write("<script>alert('Reservation cancelled successfully!');</script>");
                        Clear();
                        GetAllReservations();
                    }
                }


                
               
            }
        }

        private void AddIssue()
        {
            int booid, memid;
            DateTime issuedate, duedate;
            booid = int.Parse(txtBId.Text.Trim().ToString());
            memid = int.Parse(txtMId.Text.Trim().ToString());
            issuedate = DateTime.Now;
            string due = DateTime.Now.AddDays(7).ToString();
            duedate = DateTime.Parse(due);

            Boolean isSaved = false;
            isSaved = objMemBook.AddMemberBook(memid, booid, issuedate, duedate);
            

            Response.Write("<script>alert('Details saved successfully');</script>");
            //Clear();
            //BindGridview();
        }

        protected void btnCollect_Click(object sender, EventArgs e)
        {

            //send a record to issued too
            if (string.IsNullOrEmpty(txtBookReservationID.Text))
            {
                Response.Write("<script>alert('Enter reservation ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string reservationid = "", username = "", memberid = "", bookid = "";
                int bid = 0;

                int countissue = 0, memid = 0;
                memid = int.Parse(txtMId.Text.ToString());
                bookid = txtBookID.Text;
                reservationid = txtBookReservationID.Text.ToString();
                memberid = txtMemberID.Text;

                //check if reservation exists

                dsReservation = objReservation.GetReservations(2, username, reservationid, memid, bid);
                if (dsReservation.Tables[0].Rows.Count >= 1) //reservation exists
                {

                    dsMember.Clear();

                    //check if member has exceeded the borrowing limit of 2
                    dsMember = objMemBook.LoadMemberBookDetails(2, memberid, bookid, memid);

                    //check if member and book exists in issue entries
                    ds = objMemBook.LoadMemberBookDetails(1, memberid, bookid, memid);


                    countissue = int.Parse(dsMember.Tables[0].Rows[0]["IssueCount"].ToString());
                    if (countissue >= 2)
                    {
                        Response.Write("<script>alert('Member has exceeded borrowing limit');</script>");
                    }
                    else if (ds.Tables[0].Rows.Count >= 1)
                    {

                        Response.Write("<script>alert('Member already has borrowed the book');</script>");
                    }
                    else
                    {
                        AddIssue();
                        string status = "Collected";
                        string adminstatus = "COLLECTED";
                        UpdateReservationStatus(status, adminstatus);
                        Clear();
                        GetAllReservations();
                    }

                    
                }
                else //reservation does not exist
                {
                    Response.Write("<script>alert('No reservation found for the ID entered!');</script>");
                    return;
                }
            }
        }
    }
}