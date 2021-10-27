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
    public partial class UserLogin : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtMemberID.Text;
            string pw = txtMemberPw.Text;

            CUser objUser = new CUser();
            ds = objUser.GetUser(0, username, pw);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                Response.Write("<script>alert('Login to Bibliotheca successful!');</script>");
                Session["userid"] = ds.Tables[0].Rows[0]["ID"].ToString();
                Session["username"] = username;
                Session["role"] = "Member";
                Session["status"] = "Active";
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Incorrect user credentials. Please check your credentials again!');</script>");
            }

        }
    }
}