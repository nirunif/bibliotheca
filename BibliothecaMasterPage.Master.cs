using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheca
{
    public partial class BibliothecaMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    //string role = Session["role"].ToString();

            //    if (Session["role"].ToString().Equals(null)) //no user logged in
            //    {
            //        linkbtnUserLogin.Visible = true;
            //        linkbtnSignUp.Visible = true;
            //        linkbtnLogOut.Visible = false;
            //        linkbtnHello.Visible = false;
            //        linkbtnAdminLogin.Visible = true;
            //        linkbtnAuthorManagement.Visible = false;
            //        linkbtnPublisherManagement.Visible = false;
            //        linkbtnBookInventory.Visible = false;
            //        linkbtnIssueBook.Visible = false;
            //        linkbtnManageMember.Visible = false;
            //    }
            //    else if (Session["role"].Equals("Admin")) //admin logged in
            //    {
            //        linkbtnUserLogin.Visible = false;
            //        linkbtnSignUp.Visible = false;
            //        linkbtnLogOut.Visible = true;
            //        linkbtnHello.Visible = true;
            //        linkbtnAdminLogin.Visible = false;
            //        linkbtnAuthorManagement.Visible = true;
            //        linkbtnPublisherManagement.Visible = true;
            //        linkbtnBookInventory.Visible = true;
            //        linkbtnIssueBook.Visible = true;
            //        linkbtnManageMember.Visible = true;

            //        linkbtnHello.Text = "Hello Admin";
            //    }
            //    else if (Session["role"].Equals("Member")) //member logged in
            //    {
            //        linkbtnUserLogin.Visible = false;
            //        linkbtnSignUp.Visible = false;
            //        linkbtnLogOut.Visible = true;
            //        linkbtnHello.Visible = true;
            //        linkbtnAdminLogin.Visible = true;
            //        linkbtnAuthorManagement.Visible = false;
            //        linkbtnPublisherManagement.Visible = false;
            //        linkbtnBookInventory.Visible = false;
            //        linkbtnIssueBook.Visible = false;
            //        linkbtnManageMember.Visible = false;

            //        linkbtnHello.Text = "Hello " + Session["username"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //}
        }

        protected void linkbtnAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }

        protected void linkbtnAuthorManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageAuthor.aspx");
        }

        protected void linkbtnPublisherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManagePublisher.aspx");
        }

        protected void linkbtnBookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageBookInventory.aspx");
        }

        protected void linkbtnIssueBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IssueBook.aspx");
        }

        protected void linkbtnManageMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MemberManagement.aspx");
        }

        protected void linkbtnUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserLogin.aspx");
        }

        protected void linkbtnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserSignUp.aspx");
        }

        protected void linkbtnViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewBookInventory.aspx");
        }

        protected void linkbtnLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            Session["status"] = "";

            linkbtnUserLogin.Visible = true;
            linkbtnSignUp.Visible = true;
            linkbtnLogOut.Visible = false;
            linkbtnHello.Visible = false;
            linkbtnAdminLogin.Visible = true;
            linkbtnAuthorManagement.Visible = false;
            linkbtnPublisherManagement.Visible = false;
            linkbtnBookInventory.Visible = false;
            linkbtnIssueBook.Visible = false;
            linkbtnManageMember.Visible = false;
        }

        protected void linkbtnBookReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookReservation.aspx");
        }

        protected void linkbtnHello_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MemberProfile.aspx");
        }

        protected void linkbtnManageBookReservations_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageBookReservations.aspx");
        }
    }
}