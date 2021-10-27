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
    public partial class ManagePublisher : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CPublisher objPublisher = new CPublisher();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPublisher();
        }

        private void GetPublisherDetails()
        {
            string pubid = "";
            string pubname = "";
            if (!string.IsNullOrEmpty(txtPubID.Text))
            {
                pubid = txtPubID.Text.Trim();
                ds = objPublisher.LoadPublishers(0, pubid, pubname); //check if the publisher already exists in the system
                if (ds.Tables[0].Rows.Count >= 1) //publisher exists
                {
                    txtPubName.Text = ds.Tables[0].Rows[0]["PublisherName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Publisher does not exist. Try a different publisher id!');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Enter a id to search!');</script>");
                txtPubID.Focus();
            }
        }

        private void AddNewPublisher()
        {
            string pubname = "";
            pubname = txtPubName.Text;
            Boolean isSaved = false;
            isSaved = objPublisher.AddPublisher(pubname);
            Response.Write("<script>alert('Publisher added successfully!');</script>");
            Clear();

        }

        private void LoadPublisher()
        {
            string id = "";
            string name = "";
            ds = objPublisher.LoadPublishers(1, id, name);
            dgvPublisherdetails.DataSource = ds;
            dgvPublisherdetails.DataBind();

        }

        private void Clear()
        {
            txtPubName.Text = "";
            txtPubID.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string publisherid = "";

            if (!string.IsNullOrEmpty(txtPubName.Text))
            {
                string publishername = txtPubName.Text.Trim();

                ds = objPublisher.LoadPublishers(0, publisherid, publishername); //check if the publisher already exists in the system
                if (ds.Tables[0].Rows.Count >= 1) //publisher exists
                {
                    Response.Write("<script>alert('Publisher already exist! Try a different publisher!');</script>");
                    return;
                }
                else //publisher does not exist
                {
                    AddNewPublisher();
                    Clear();
                    LoadPublisher();
                }
            }
            else
            {
                Response.Write("<script>alert('Add publisher name!');</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtPubName.Text)) &&(!string.IsNullOrEmpty(txtPubID.Text)))
            {
                string publishername = "";
                string publisherid = "";
                publishername = txtPubName.Text;
               
                ds = objPublisher.LoadPublishers(0, publisherid, publishername); //check if the publisher already exists in the system
                if (ds.Tables[0].Rows.Count >= 1) //publisher exists
                {
                    Response.Write("<script>alert('Publisher already exist! Try a different publisher!');</script>");
                    return;
                }
                else //publisher does not exist
                {
                    publisherid = txtPubID.Text.ToString();
                    Boolean isSaved = false;
                    isSaved = objPublisher.UpdatePublisher(publisherid, publishername);
                    Response.Write("<script>alert('Publisher updated successfully!');</script>");
                    Clear();
                    LoadPublisher();
                }
            }
            else
            {
                Response.Write("<script>alert('Add details to update!');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPubID.Text))
            {
                Response.Write("<script>alert('Select publisher to be deleted!');</script>");
                txtPubID.Focus();
            }
            else if (string.IsNullOrEmpty(txtPubName.Text))
            {
                Response.Write("<script>alert('Select publisher to be deleted!');</script>");
                txtPubName.Focus();
            }
            else
            {
                string publishername = "";
                string pubid = "";
                publishername = txtPubName.Text;
                pubid = txtPubID.Text.ToString();

                ds = objPublisher.LoadPublishers(2, pubid, publishername); //check if the publisher already exists in the system
                if (ds.Tables[0].Rows.Count >= 1) //publisher exists
                {
                    Boolean isSaved = false;
                    isSaved = objPublisher.DeletePublisher(pubid);
                    Response.Write("<script>alert('Publisher deleted successfully!');</script>");
                    Clear();
                    LoadPublisher();
                }
                else //publisher does not exist
                {

                    Response.Write("<script>alert('Publisher details do not match. Please try again!');</script>");
                    return;
                }

               
            }
        }

        protected void linkbtnSearch_Click(object sender, EventArgs e)
        {
            GetPublisherDetails();
        }
    }
}