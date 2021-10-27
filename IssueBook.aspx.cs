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
    public partial class IssueBook : System.Web.UI.Page
    {
        CBook objBook = new CBook();
        CMember objMember = new CMember();
        CMemberBook objMemBook = new CMemberBook();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsBook = new DataSet();
        DataSet dsMember = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridview();
        }

        private void BindGridview()
        {
            int mid = 0;
            string id = "", name = "";
            ds = objMemBook.LoadMemberBookDetails(0, id, name, mid);
            dgvIssuedBookdetails.DataSource = ds;
            dgvIssuedBookdetails.DataBind();
        }

        private void GetDetails(int Type) //get member name and book name
        {
            string memberid, bookid, name;

            bookid = txtBookID.Text.ToString();
            memberid = txtMemberID.Text.ToString();
            name = "";

            try
            {
                switch (Type)
                {
                    case 0: //book details
                        dsBook = objBook.LoadBookDetails(0, bookid, name);

                        if (dsBook.Tables[0].Rows.Count >= 1) //book exists
                        {
                            
                            int currentstock;
                            currentstock = int.Parse(dsBook.Tables[0].Rows[0]["CurrentStock"].ToString());

                            if (currentstock <= 0)
                            {
                                Response.Write("<script>alert('Not enough books in stock! Try a different book!');</script>");
                                txtBookID.Focus();
                            }
                            else
                            {
                                txtBookName.Text = dsBook.Tables[0].Rows[0]["BookTitle"].ToString();
                                txtBooID.Text= dsBook.Tables[0].Rows[0]["ID"].ToString();
                            }
                        }
                        else  //book does not exist
                        {
                            Response.Write("<script>alert('Book ID does not exist. Try a different book ID!');</script>");
                        }

                        break;

                    case 1: //member details
                        dsMember = objMember.LoadMemberDetails(1, memberid, name);

                        if (dsMember.Tables[0].Rows.Count >= 1) //member exists
                        {
                            txtMemberName.Text = dsMember.Tables[0].Rows[0]["FullName"].ToString();
                            txtMemID.Text= dsMember.Tables[0].Rows[0]["ID"].ToString();
                        }
                        else  //member does not exist
                        {
                            Response.Write("<script>alert('Member ID does not exist. Try a different member ID!');</script>");
                        }

                        break;
                }
                
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           
        }

        private void Clear()
        {
            txtMemberID.Text = "";
            txtBooID.Text = "";
            txtBookID.Text = "";
            txtMemID.Text = "";
            txtStartDate.Text = "";
            txtMemberName.Text = "";
            txtBookName.Text = "";
            txtEndDate.Text = "";
        }

        private void AddIssue()
        {
            int booid, memid;
            DateTime issuedate, duedate;
            booid = int.Parse(txtBooID.Text.Trim().ToString());
            memid = int.Parse(txtMemID.Text.Trim().ToString());
            issuedate = DateTime.Parse(txtStartDate.Text.ToString());
            duedate = DateTime.Parse(txtEndDate.Text.ToString());

            Boolean isSaved = false;
            isSaved = objMemBook.AddMemberBook(memid, booid, issuedate, duedate);

            //update stock of issued book
            isSaved = objBook.RemoveBookStock(booid);

            Response.Write("<script>alert('Details saved successfully');</script>");
            Clear();
            BindGridview();
        }

        protected void linkbtnSearchMember_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMemberID.Text))
            {
                GetDetails(1);
            }
            else  //member id not filled
            {
                Response.Write("<script>alert('Enter member ID to search!');</script>");
            }
        }

        protected void linkbtnSearchBook_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBookID.Text))
            {
                GetDetails(0);
            }
            else //bookid not filled
            {
                Response.Write("<script>alert('Enter Book ID to search!');</script>");
            }
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter Member ID to search!');</script>");
            }
            else if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter Book ID to search!');</script>");
            }
            else if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                Response.Write("<script>alert('Enter issued date!');</script>");
            }
            else if (string.IsNullOrEmpty(txtEndDate.Text))
            {
                Response.Write("<script>alert('Enter due date!');</script>");
            }
            else
            {
                string bookid = txtBookID.Text;
                string memberid = txtMemberID.Text;
                int id = int.Parse(txtMemID.Text.Trim().ToString());
                ds = objMemBook.LoadMemberBookDetails(1, memberid, bookid, id); //check if member and book exists in issue entries

                int countissue;

                ds1.Clear();
                ds1 = objMemBook.LoadMemberBookDetails(2, memberid, bookid, id); //check if member has exceeded the borrowing limit of 2

                countissue = int.Parse(ds1.Tables[0].Rows[0]["IssueCount"].ToString());


                //if (ds1.Tables[0].Rows.Count >= 1)
                //{
                //    countissue = int.Parse(ds1.Tables[0].Rows[0]["IssueCount"].ToString());
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
                    }
                //}
                //else if (ds.Tables[0].Rows.Count >= 1)
                //{

                //    Response.Write("<script>alert('Member already has borrowed the book');</script>");
                //}
                //else
                //{
                //    AddIssue();
                //}

            }
        }

        protected void dgvIssuedBookdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.Cells.Count > 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    //e.Row.Cells[2].Visible = false;
                }

                //checks whether the due date is passed
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime duedate = Convert.ToDateTime(e.Row.Cells[8].Text);
                    DateTime today = DateTime.Today;
                    if (today > duedate)
                    {
                        e.Row.BackColor = System.Drawing.Color.IndianRed;
                    }

                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // CREATE A LinkButton AND IT TO EACH ROW.
                    LinkButton lbSelect = new LinkButton();
                    lbSelect.ID = "lbBooks";
                    lbSelect.Text = "SELECT";

                    e.Row.Cells[0].Controls.Add(lbSelect);

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        private void RemoveEntry()
        {
            int booid, memid;
            DateTime issuedate, duedate;
            booid = int.Parse(txtBooID.Text.Trim().ToString());
            memid = int.Parse(txtMemID.Text.Trim().ToString());
            issuedate = DateTime.Parse(txtStartDate.Text.ToString());
            duedate = DateTime.Parse(txtEndDate.Text.ToString());

            Boolean isSaved = false;
            isSaved = objMemBook.RemoveRecord(memid, booid);

            //update stock of issued book
            isSaved = objBook.AddBookStock(booid);

            Response.Write("<script>alert('Entry removed successfully');</script>");
            Clear();
            BindGridview();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter Member ID to search!');</script>");
            }
            else if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter Book ID to search!');</script>");
            }
            else if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                Response.Write("<script>alert('Enter issued date!');</script>");
            }
            else if (string.IsNullOrEmpty(txtEndDate.Text))
            {
                Response.Write("<script>alert('Enter due date!');</script>");
            }
            else
            {
                string bookid = txtBookID.Text;
                string memberid = txtMemberID.Text;
                int mid = int.Parse(txtMemID.Text.Trim().ToString());
                int bid = int.Parse(txtBooID.Text.Trim().ToString());

                ds = objMemBook.LoadMemberBookDetails(1, memberid, bookid, mid); //check if member and book exists in issue entries

                
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    RemoveEntry();
                }
                else
                {
                    Response.Write("<script>alert('Entry does not exist!');</script>");
                }
            }
        }

        //protected void dgvIssuedBookdetails_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow grIssuedBookDet = dgvIssuedBookdetails.SelectedRow;
        //    txtMemberName.Text = grIssuedBookDet.Cells[1].Text;
        //    //txtItemcode.Text = grReceipt.Cells[4].Text;
        //    //ddlCategory.SelectedValue = grReceipt.Cells[3].Text;
        //    //ddlGoldct.SelectedValue = grReceipt.Cells[10].Text;
        //    //ddlCondition.SelectedValue = grReceipt.Cells[13].Text;
        //    //ddlItem.SelectedValue = grReceipt.Cells[5].Text;
        //    //txtGrossweight1.Text = grReceipt.Cells[7].Text;
        //    //txtNetweight1.Text = grReceipt.Cells[8].Text;
        //    //txtPrice.Text = grReceipt.Cells[9].Text;
        //    //txtDetailid.Text = grReceipt.Cells[16].Text;

        //    //txtSelected.Text = grReceipt.RowIndex.ToString();
        //}

        protected void dgvIssuedBookdetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}