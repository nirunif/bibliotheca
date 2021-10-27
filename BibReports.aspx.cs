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
    public partial class BibReports : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CBook objBook = new CBook();
        CMember objMember = new CMember();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkBtnSearchBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter book ID to search!');</script>");
                txtBookID.Focus();
            }
            else
            {
                string bookid = "", bookname = "";
                bookid = txtBookID.Text;
                ds = objBook.LoadBookDetails(0, bookid, bookname);

                if (ds.Tables[0].Rows.Count >= 1)
                {
                    txtBookName.Text = ds.Tables[0].Rows[0]["BookTitle"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Book ID does not exist in inventory!');</script>");
                    return;
                }
            }
        }

        protected void btnReportStock_Click(object sender, EventArgs e)
        {
            //get stock of selected book
            if (string.IsNullOrWhiteSpace(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter book ID to search!');</script>");
                txtBookID.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtBookName.Text))
            {
                Response.Write("<script>alert('Enter book ID to search!');</script>");
                txtBookID.Focus();
            }
            else
            {
                string bookname = "", bookid = "";
                int type = 0;
                bookname = txtBookName.Text;
                bookid = txtBookID.Text;

                Session["booktitle"] = bookname;
                Session["bookID"] = bookid;
                Session["type"] = type;

                Response.Redirect("~/Reports/frmStockReport.aspx");
            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            //get all stock details 
            int type = 1;
            Session["type"] = type;

            Response.Redirect("~/Reports/frmStockReport.aspx");
        }

        protected void linkbtnBkDetID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBkDetID.Text))
            {
                Response.Write("<script>alert('Enter book ID to search!');</script>");
                txtBookID.Focus();
            }
            else
            {
                string bookid = "", bookname = "";
                bookid = txtBkDetID.Text;
                ds = objBook.LoadBookDetails(0, bookid, bookname);

                if (ds.Tables[0].Rows.Count >= 1)
                {
                    txtBkName.Text = ds.Tables[0].Rows[0]["BookTitle"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Book ID does not exist in inventory!');</script>");
                    return;
                }
            }
        }

        protected void btnGetBookDetReport_Click(object sender, EventArgs e)
        {
            //get details of selected book
            if (string.IsNullOrWhiteSpace(txtBkDetID.Text))
            {
                Response.Write("<script>alert('Enter book ID to search!');</script>");
                txtBkDetID.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtBkName.Text))
            {
                Response.Write("<script>alert('Enter book ID to search!');</script>");
                txtBkDetID.Focus();
            }
            else
            {
                string bookname = "", bookid = "";
                int type = 0;
                bookname = txtBkName.Text;
                bookid = txtBkDetID.Text;

                Session["booktitle"] = bookname;
                Session["bookID"] = bookid;
                Session["type"] = type;

                Response.Redirect("~/Reports/frmBookDetailsReport.aspx");
            }
        }

        protected void btnGetAllBookdet_Click(object sender, EventArgs e)
        {
            //get all book details 
            int type = 1;
            Session["type"] = type;

            Response.Redirect("~/Reports/frmBookDetailsReport.aspx");
        }

        protected void linkbtnSearchMember_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter Member ID to search!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string memberid = "", membername = "";
                memberid = txtMemberID.Text;
                ds = objMember.LoadMemberDetails(1, memberid, membername);

                if (ds.Tables[0].Rows.Count >= 1)
                {
                    txtMemberName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Member ID does not exist!');</script>");
                    return;
                }
            }
        }

        protected void btnGetMemberReport_Click(object sender, EventArgs e)
        {
            //get details of selected book
            if (string.IsNullOrWhiteSpace(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter Member ID to search!');</script>");
                txtMemberID.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtMemberName.Text))
            {
                Response.Write("<script>alert('Enter member ID to search!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string membername = "", memberid = "";
                int type = 0;
                membername = txtMemberName.Text;
                memberid = txtMemberID.Text;

                Session["membername"] = membername;
                Session["memberid"] = memberid;
                Session["type"] = type;

                Response.Redirect("~/Reports/frmMemberDetailsReport.aspx");
            }
        }

        protected void btnGetAllMembers_Click(object sender, EventArgs e)
        {
            //get all book details 
            int type = 1;
            Session["type"] = type;

            Response.Redirect("~/Reports/frmMemberDetailsReport.aspx");
        }
    }
}