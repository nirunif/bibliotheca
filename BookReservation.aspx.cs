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
    public partial class BookReservation : System.Web.UI.Page
    {
        DataSet dsReserved = new DataSet();
        CBookReservations objReserve = new CBookReservations();
        CBook objBook = new CBook();
        DataSet dsBook = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReservedBooks();
            //try
            //{
            //    if (Session["username"].ToString() == "" || Session["username"] == null)
            //    {
            //        Response.Write("<script>alert('Session expired.Please login to Bibliotheca again!');</script>");
            //       // Response.Redirect("UserLogin.aspx");
            //        GetReservedBooks();
            //    }
            //    else
            //    {
            //        if (!Page.IsPostBack)
            //        {
            //            GetReservedBooks();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //}
        }

        private void GetReservedBooks()
        {
            //string username = Session["username"].ToString();
            //string userid = Session["userid"].ToString();

            string username = "nirunif";
            string id = "";
            int bookid = 0, memberid = 0;
            dsReserved = objReserve.GetReservations(1, username, id, memberid, bookid);
            if (dsReserved.Tables[0].Rows.Count >= 1)
            {
                dgvReservations.DataSource = dsReserved;
                dgvReservations.DataBind();
            }
        }

        private void PlaceReservation()
        {
            string bookid = "", memberid = "", membername = "", bookname = "", status = "", uname = "", brid = "";
            int bid = 0, mid = 0;

            bookid = txtBookID.Text;
            memberid = txtMemberID.Text;
            membername = txtMemberName.Text;
            bookname = txtBookName.Text;
            bid = int.Parse(txtBooID.Text.ToString());
            //   mid = int.Parse(txtMemID.Text.ToString());
            mid = 1;
            DateTime date = DateTime.Now;
            status = "Pending";
            string adstatus = "PENDING";

            dsBook = objBook.LoadBookDetails(2, bookid, bookname);
            if (dsBook.Tables[0].Rows.Count >= 1)
            {
                dsReserved = objReserve.GetReservations(3, uname, brid, mid, bid);
                if (dsReserved.Tables[0].Rows.Count >= 1)
                {
                    Response.Write("<script>alert('You cannot place the reservation for the same book twice!');</script>");
                }
                else
                {
                    Boolean isSaved = false;
                    isSaved = objReserve.AddReservation(bid, mid, date, status, adstatus);
                    Response.Write("<script>alert('Request for reservation successful. Please check in later to check reservation status!');</script>");
                    Clear();
                    GetReservedBooks();
                }
            }
            else
            {
                Response.Write("<script>alert('Book details do not match. Please try again!');</script>");
            }






        }

        private void CancelReservation()
        {
            string BookReserveID = "", status = "", uname = "";
            string adstatus = "";
            int mid = 0, bid = 0;
            bid = int.Parse(txtBooID.Text.ToString());
            //   mid = int.Parse(txtMemID.Text.ToString());
            mid = 1;
            BookReserveID = txtBookReserveID.Text;
            status = "Cancel";

            //check if reservation exists
            dsReserved = objReserve.GetReservations(3, uname, BookReserveID, mid, bid);
            if (dsReserved.Tables[0].Rows.Count >= 1) //reservation exists
            {
                adstatus= dsReserved.Tables[0].Rows[0]["AdminStatus"].ToString();
                Boolean isSaved = false;
                isSaved = objReserve.UpdateReservationStatus(BookReserveID, status, adstatus);
                Response.Write("<script>alert('Request to cancel reservation sent!');</script>");
                Clear();
                GetReservedBooks();
            }
            else
            {
                Response.Write("<script>alert('No details to entered reservation id!');</script>");
            }

            

            
        }

        private void Clear()
        {
            txtMemberID.Text = "";
            txtBooID.Text = "";
            txtMemID.Text = "";
            txtMemberName.Text = "";
            txtBookName.Text = "";
            txtBookID.Text = "";
        }

        protected void linkBtnSearchBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter Book ID to search');</script>");
            }
            else
            {
                string name = "";
                string bookid = txtBookID.Text.ToString();
                dsBook = objBook.LoadBookDetails(0, bookid, name);
                if (dsBook.Tables[0].Rows.Count >= 1)
                {
                    txtBookName.Text = dsBook.Tables[0].Rows[0]["BookTitle"].ToString();
                    txtBooID.Text = dsBook.Tables[0].Rows[0]["ID"].ToString();
                }
            }
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            PlaceReservation();
            //Response.Redirect("~/BookReservation.aspx");
        }

        protected void linkBtnReservationID_Click(object sender, EventArgs e)
        {
            string bookreserveid = "", username = "";
            int bookid = 0, memberid = 0;
            bookreserveid = txtBookReserveID.Text;
            dsReserved = objReserve.GetReservations(1, username, bookreserveid, memberid, bookid);
            if (dsReserved.Tables[0].Rows.Count >= 1)
            {
                txtMemberID.Text = dsReserved.Tables[0].Rows[0]["MemberID"].ToString();
                txtMemberName.Text = dsReserved.Tables[0].Rows[0]["FullName"].ToString();
                txtBookID.Text = dsReserved.Tables[0].Rows[0]["BookID"].ToString();
                txtBookName.Text = dsReserved.Tables[0].Rows[0]["BookTitle"].ToString();
                txtBooID.Text = dsReserved.Tables[0].Rows[0]["Book_ID"].ToString();
                txtMemID.Text = dsReserved.Tables[0].Rows[0]["Member_ID"].ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelReservation();    
        }
    }
}