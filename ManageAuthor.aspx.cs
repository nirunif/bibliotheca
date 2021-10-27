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
    public partial class ManageAuthor : System.Web.UI.Page
    {
        CAuthor objAuthor = new CAuthor();
        DataSet dsAuthor = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAuthors();
        }

        private void GetAuthorDetails()
        {
            string authorid = "";
            
            string authorname = "";
            if (!string.IsNullOrEmpty(txtAuthorID.Text))
            {
                authorid = txtAuthorID.Text.Trim();
                dsAuthor = objAuthor.LoadAuthor(1, authorid, authorname); //check if the author already exists in the system
                if (dsAuthor.Tables[0].Rows.Count >= 1) //author exists
                {
                    txtAuthorName.Text = dsAuthor.Tables[0].Rows[0]["AuthorName"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Author does not exist. Try a different author id!');</script>");
                }

            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string authorid = "";


            if (!string.IsNullOrEmpty(txtAuthorName.Text))
            {
                string authorname = txtAuthorName.Text.Trim();

                dsAuthor = objAuthor.LoadAuthor(1, authorid, authorname); //check if the author already exists in the system
                if (dsAuthor.Tables[0].Rows.Count >= 1) //author exists
                {
                    Response.Write("<script>alert('Author already exist! Try a different author!');</script>");
                    return;
                }
                else //author does not exist
                {
                    AddNewAuthor();
                    Clear();
                    LoadAuthors();
                }
            }
            else
            {
                Response.Write("<script>alert('Add author name!');</script>");
            }
        }
        
        private void AddNewAuthor()
        {
            string authorname = "";
            authorname = txtAuthorName.Text;
            Boolean isSaved = false;
            isSaved = objAuthor.AddAuthor(authorname);
            Response.Write("<script>alert('Author added successfully!');</script>");
            Clear();

        }

        private void LoadAuthors()
        {
            string id = "";
            string name = "";
            DataSet ds = new DataSet();
            ds = objAuthor.LoadAuthor(2, id, name);
            dgvAuthordetails.DataSource = ds;
            dgvAuthordetails.DataBind();

        }

        private void Clear()
        {
            txtAuthorID.Text = "";
            txtAuthorName.Text = "";
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           

            if ((!string.IsNullOrEmpty(txtAuthorName.Text)) && (!string.IsNullOrEmpty(txtAuthorID.Text)))
            {
                string authorname = "";
                string authorid = "";
                authorname = txtAuthorName.Text;
              

                dsAuthor = objAuthor.LoadAuthor(1, authorid, authorname); //check if the author already exists in the system
                if (dsAuthor.Tables[0].Rows.Count >= 1) //author exists
                {
                    Response.Write("<script>alert('Author already exist! Try a different author!');</script>");
                    return;
                }
                else //author does not exist
                {
                    authorid = txtAuthorID.Text.ToString();
                    Boolean isSaved = false;
                    isSaved = objAuthor.UpdateAuthor(authorid, authorname);
                    Response.Write("<script>alert('Author updated successfully!');</script>");
                    Clear();
                    LoadAuthors();
                }
            }
            else
            {
                Response.Write("<script>alert('Add details to update!');</script>");
            }


           
            
           

        }

        protected void linkbtnSearch_Click(object sender, EventArgs e)
        {
            GetAuthorDetails();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetAuthorDetails();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAuthorID.Text))
            {
                Response.Write("<script>alert('Select author to be deleted!');</script>");
                txtAuthorID.Focus();
            }
            else if (string.IsNullOrEmpty(txtAuthorName.Text))
            {
                Response.Write("<script>alert('Select author to be deleted!');</script>");
                txtAuthorName.Focus();
            }
            else
            {
                string authorname = "";
                string authorid = "";
                authorid = txtAuthorID.Text.ToString();
                authorname = txtAuthorName.Text;

                dsAuthor = objAuthor.LoadAuthor(0, authorid, authorname); //check if the author already exists in the system
                if (dsAuthor.Tables[0].Rows.Count >= 1) //author exists
                {
                    Boolean isSaved = false;
                    isSaved = objAuthor.DeleteAuthor(authorid);
                    Response.Write("<script>alert('Author deleted successfully!');</script>");
                    Clear();
                    LoadAuthors();
                }
                else //author does not exist
                {

                    Response.Write("<script>alert('Author details do not match. Please try again!');</script>");
                    return;
                }


            }
           
        }

        
    }
}