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
    public partial class MemberManagement : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CMember objMember = new CMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            string id = "";
            string name = "";
            ds = objMember.LoadMemberDetails(0, id, name);
            dgvMemberdetails.DataSource = ds;
            dgvMemberdetails.DataBind();
        }

        protected void dgvMemberdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 0)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[12].Visible = false;
            }
        }

        private void GetMember()
        {
            string memberid = "";
            string membername = "";
            if (!string.IsNullOrEmpty(txtMemberID.Text))
            {
                memberid = txtMemberID.Text.Trim();
                ds = objMember.LoadMemberDetails(1, memberid, membername); //check if the publisher already exists in the system
                if (ds.Tables[0].Rows.Count >= 1) //publisher exists
                {
                    txtFullName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtAccountStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                    txtNIC.Text = ds.Tables[0].Rows[0]["NIC"].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0]["Contact Number"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                    txtOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                    DateTime dateofbirth = DateTime.Parse(ds.Tables[0].Rows[0]["DOB"].ToString());
                    txtDOB.Text = dateofbirth.ToString("dd-MM-yyyy");

                }
                else
                {
                    Response.Write("<script>alert('Member does not exist. Try a different member id!');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Enter a member id!');</script>");
            }
        }

        private void Clear()
        {
            txtFullName.Text = "";
            txtMemberID.Text = "";
            txtDOB.Text = "";
            txtAccountStatus.Text = "";
            txtContact.Text = "";
            txtNIC.Text = "";
            txtAddress.Text = "";
            txtGender.Text = "";
            txtOccupation.Text = "";
        }
        private void UpdateMemberStatus(string Status)
        {
            string memberid = "";
            memberid = txtMemberID.Text.Trim();

            Boolean isSaved = false;
            isSaved = objMember.UpdateMemberStatus(memberid, Status);
            if (Status == "REMOVED")
            {
                Response.Write("<script>alert('Member deleted successfully!');</script>");
                Clear();
                LoadMembers();

            }
            else
            {
                Response.Write("<script>alert('Member Status updated to '+'" + Status + "'+'!');</script>");
                Clear();
                LoadMembers();
            }
            

        }


        protected void linkbtnSearch_Click(object sender, EventArgs e)
        {
            GetMember();
        }

        protected void linkbtnStatusActive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter member ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string memberid = "";
                string name = "";
                memberid = txtMemberID.Text.Trim().ToString();
                name = txtFullName.Text.Trim().ToString();

                ds = objMember.LoadMemberDetails(1, memberid, name);
                if (ds.Tables[0].Rows.Count >= 1) //member exists
                {
                    string status = "Active";
                    UpdateMemberStatus(status);
                }
                else //member does not exist
                {
                    Response.Write("<script>alert('Member details do not match. Please try again!');</script>");
                    return;
                }
            }
            
        }

        protected void linkbtnStatusPending_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter member ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string memberid = "";
                string name = "";
                memberid = txtMemberID.Text.Trim().ToString();
                name = txtFullName.Text.Trim().ToString();

                ds = objMember.LoadMemberDetails(1, memberid, name);
                if (ds.Tables[0].Rows.Count >= 1) //member exists
                {
                    string status = "Pending";
                    UpdateMemberStatus(status);
                }
                else //member does not exist
                {
                    Response.Write("<script>alert('Member details do not match. Please try again!');</script>");
                    return;
                }
            }
            
        }

        protected void linkbtnStatusDeactivate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter member ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string memberid = "";
                string name = "";
                memberid = txtMemberID.Text.Trim().ToString();
                name = txtFullName.Text.Trim().ToString();

                ds = objMember.LoadMemberDetails(1, memberid, name);
                if (ds.Tables[0].Rows.Count >= 1) //member exists
                {
                    string status = "Inactive";
                    UpdateMemberStatus(status);
                }
                else //member does not exist
                {
                    Response.Write("<script>alert('Member details do not match. Please try again!');</script>");
                    return;
                }
            }
        }

        protected void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                Response.Write("<script>alert('Enter member ID!');</script>");
                txtMemberID.Focus();
            }
            else
            {
                string memberid = "";
                string name = "";
                memberid = txtMemberID.Text.Trim().ToString();
                name = txtFullName.Text.Trim().ToString();

                ds = objMember.LoadMemberDetails(1, memberid, name);
                if (ds.Tables[0].Rows.Count >= 1) //member exists
                {
                    string status = "REMOVED";
                    UpdateMemberStatus(status);
                }
                else //member does not exist
                {
                    Response.Write("<script>alert('Member details do not match. Please try again!');</script>");
                    return;
                }
            }
            
        }
    }
}