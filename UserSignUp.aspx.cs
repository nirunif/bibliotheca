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
    public partial class UserSignUp : System.Web.UI.Page
    {
        DataTable dtUser = new DataTable();
        DataSet dsUser = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            CUser objUser = new CUser();
            string userid = txtUsername.Text.Trim();
            string pw = null;
            int type = 2;

            dsUser = objUser.GetUser(1, userid, pw, type); //check if the username already exists in the system

            if (dsUser.Tables[0].Rows.Count >= 1) //username exists
            {
                Response.Write("<script>alert('Username already exists! Try a different username!');</script>");
                return;
            }
            else //username does not exist
            {
                AddNewUser();
            }

        }

        private void AddNewUser() //sign up new member
        {
            string name = "", nic = "", contactno = "", address = "", email = "", occupation = "", username = "", password = "", gender = "", status = "";
            int userid = 0, type = 2;
            name = txtName.Text;
            nic = txtNIC.Text;
            address = txtAddress.Text;
            contactno = txtContact.Text;
            email = txtEmail.Text;
            occupation = txtOccupation.Text;
            username = txtUsername.Text;
            password = txtPassword.Text;
            if (rbMale.Checked == true)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked == true)
            {
                gender = "Female";
            }
            DateTime dob = DateTime.Parse(txtDOB.Text);
            status = "Pending";

            CMember objMember = new CMember();
            CUser objUser = new CUser();
            Boolean isSaved = false;
            isSaved = objUser.AddUser(username, password, type); //send user credentials to users table
            dsUser = objUser.GetUser(0, username, password, type); //retrieve user credentials (ID) of newly added user

            if (dsUser.Tables[0].Rows.Count >= 1)
            {
                userid = int.Parse(dsUser.Tables[0].Rows[0]["ID"].ToString()); //get ID of new user credentials
                isSaved = objMember.AddMember(name, nic, dob, address, contactno, gender, email, occupation, userid, status); //save member details
            }
            else
            {
                Response.Write("<script>alert('No data!');</script>");
                return;
            }

        }

        private void CheckMember() //check if the user already exists in the system
        {
           
        }
    }
}