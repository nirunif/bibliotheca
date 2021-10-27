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
    public partial class MemberProfile : System.Web.UI.Page
    {
        DataSet dsMember = new DataSet();
        CMember objMember = new CMember();
        CUser objUser = new CUser();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session expired.Please login to Bibliotheca again!');</script>");
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        GetMemberBooks();
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }

            // string username = Session["username"].ToString();
            


        }

        private void GetMemberBooks()
        {
            try
            {
                string username = Session["username"].ToString();
               // string username = "nirunif";
                int mid = 0;
                string id = "", name = "";
                dsMember = objMember.LoadMemberDetails(2, username, id);
                if (dsMember.Tables[0].Rows.Count >= 1)
                {
                    dgvMemberBooks.DataSource = dsMember;
                    dgvMemberBooks.DataBind();
                }
                txtName.Text = dsMember.Tables[0].Rows[0]["FullName"].ToString();
                txtDOB.Text = dsMember.Tables[0].Rows[0]["DOB"].ToString();
                txtNIC.Text = dsMember.Tables[0].Rows[0]["NIC"].ToString();
                txtContact.Text = dsMember.Tables[0].Rows[0]["Phone"].ToString();
                txtAddress.Text = dsMember.Tables[0].Rows[0]["Address"].ToString();
                txtEmail.Text = dsMember.Tables[0].Rows[0]["Email"].ToString();
                ddlOccupation.SelectedValue = dsMember.Tables[0].Rows[0]["Occupation"].ToString();
                txtPassword.Text = dsMember.Tables[0].Rows[0]["Password"].ToString();
                txtUsername.Text = dsMember.Tables[0].Rows[0]["UserID"].ToString();
                string gender = dsMember.Tables[0].Rows[0]["Gender"].ToString();
                txtUserID.Text = dsMember.Tables[0].Rows[0]["User_ID"].ToString();
                txtMemberID.Text = dsMember.Tables[0].Rows[0]["MemberID"].ToString();
                if (gender == "Male")
                {
                    rbMale.Checked = true;
                }
                else if (gender == "Female")
                {
                    rbFemale.Checked = true;
                }
                
                string accountstatus= dsMember.Tables[0].Rows[0]["Status"].ToString();
                lblAccountStatus.Text = accountstatus.ToString();
                if (accountstatus == "Active")
                {
                    lblAccountStatus.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (accountstatus == "Pending")
                {
                    lblAccountStatus.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (accountstatus == "Inactive")
                {
                    lblAccountStatus.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    lblAccountStatus.Attributes.Add("class", "badge badge-pill badge-info");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void dgvMemberBooks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.Cells.Count > 0)
                {
                    e.Row.Cells[0].Visible = false;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[14].Visible = false;
                    e.Row.Cells[17].Visible = false;
                    e.Row.Cells[18].Visible = false;
                }

                //checks whether the due date is passed
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime duedate = Convert.ToDateTime(e.Row.Cells[16].Text);
                    DateTime today = DateTime.Today;
                    if (today > duedate)
                    {
                        e.Row.BackColor = System.Drawing.Color.IndianRed;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string fullname = "", nic = "", contact = "", address = "", gender = "", email = "", occupation = "",
                username = "", pw = "", status = "", memberid = "";
            DateTime dob;
            int userid;

            fullname = txtName.Text;
            nic = txtNIC.Text;
            contact = txtContact.Text;
            address = txtAddress.Text;
            if (rbMale.Checked == true)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked == true)
            {
                gender = "Female";
            }
            email = txtEmail.Text;
            occupation = ddlOccupation.SelectedItem.Text;
            username = txtUsername.Text;
            if (txtNewPassword.Text == "")
            {
                pw = txtPassword.Text;
            }
            else
            {
                pw = txtNewPassword.Text;
            }
            userid = int.Parse(txtUserID.Text.ToString());
            status = "Pending";
            memberid = txtMemberID.Text;
            dob = DateTime.Parse(txtDOB.Text.ToString());

            Boolean isSaved = false;
            isSaved = objMember.UpdateMemberDetails(memberid, fullname, nic, dob, address, contact, gender, email, occupation, userid, status);
            isSaved = objUser.UpdateUser(userid, username, pw);
            Response.Write("<script>alert('Your profile is updated!');</script>");
            GetMemberBooks();
        
        
        }
    }
}