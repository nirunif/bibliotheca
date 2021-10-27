using Bibliotheca.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheca
{
    public partial class ManageBookInventory : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CBook objBook = new CBook();

        static string global_filepath;
        static int global_actualstock, global_currentstock, global_issuedbooks;
        protected void Page_Load(object sender, EventArgs e)
        {
            dgvBookInventoryList.DataBind();
            //  LoadBookInventory();
            if (!IsPostBack)
            {
                LoadAuthor();
                LoadPublisher();
            }
           
        }

        private void LoadAuthor()
        {
            string id = "", name = "";
            CAuthor objAuthor = new CAuthor();
            ds = objAuthor.LoadAuthor(2, id, name);

            ddlAuthorName.DataTextField = "Author Name";
            ddlAuthorName.DataValueField = "ID";
            ddlAuthorName.DataSource = ds.Tables[0];

            ddlAuthorName.DataBind();
        }

        private void LoadPublisher()
        {
            string id = "", name = "";
            CPublisher objPublisher = new CPublisher();
            ds = objPublisher.LoadPublishers(1, id, name);

            ddlPublisherName.DataTextField = "Publisher Name";
            ddlPublisherName.DataValueField = "ID";
            ddlPublisherName.DataSource = ds.Tables[0];

            ddlPublisherName.DataBind();
        }

        private void LoadBookInventory()
        {
            string id = "";
            string name = "";
            ds = objBook.LoadBookDetails(1, id, name);
            dgvBookInventoryList.DataSource = ds;
            dgvBookInventoryList.DataBind();
        }

        private void getStock(object sender, EventArgs e)
        {
            int actualstock = int.Parse(txtStock.Text.ToString());
            int currentstock = int.Parse(txtCurrentStock.Text.ToString());
            int issued = 0;
            issued = (actualstock - currentstock);
            txtIssuedBooks.Text = issued.ToString();
        }


        protected void linkbtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter Book ID to search');</script>");
            }
            else
            {
                string name = "";
                string bookid = txtBookID.Text.ToString();
                ds = objBook.LoadBookDetails(0, bookid, name);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    txtBookName.Text = ds.Tables[0].Rows[0]["BookTitle"].ToString();
                    txtEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                    txtBookCost.Text = ds.Tables[0].Rows[0]["Cost"].ToString();
                    txtPages.Text = ds.Tables[0].Rows[0]["NoOfPages"].ToString();
                    txtStock.Text = ds.Tables[0].Rows[0]["ActualStock"].ToString();
                    txtCurrentStock.Text = ds.Tables[0].Rows[0]["CurrentStock"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    ddlAuthorName.SelectedValue = ds.Tables[0].Rows[0]["Author_ID"].ToString();
                    ddlLanguage.SelectedValue = ds.Tables[0].Rows[0]["Language"].ToString();
                    ddlPublisherName.SelectedValue = ds.Tables[0].Rows[0]["Pub_ID"].ToString();
                    // listBoxGenre.Text = ds.Tables[0].Rows[0]["BookTitle"].ToString();
                     DateTime pubdate = DateTime.Parse(ds.Tables[0].Rows[0]["Publish_Date"].ToString());
                   txtPublishDate.Text = pubdate.ToString("mm/dd/yyyy");
                   // txtPublishDate.Text = ds.Tables[0].Rows[0]["Publish_Date"].ToString();
                    listBoxGenre.ClearSelection();
                    string[] genre = ds.Tables[0].Rows[0]["Genre"].ToString().Trim().Split(',');
                    for(int i=0; i<genre.Length; i++)
                    {
                        for(int j=0; j<listBoxGenre.Items.Count; j++)
                        {
                            if (listBoxGenre.Items[j].ToString() == genre[i])
                            {
                                listBoxGenre.Items[j].Selected = true;
                            }
                        }
                    }

                   // getStock();

                    global_actualstock = Convert.ToInt32(txtStock.Text);
                    global_currentstock = Convert.ToInt32(txtCurrentStock.Text);
                    global_issuedbooks = (global_actualstock - global_currentstock);
                    global_filepath= ds.Tables[0].Rows[0]["BookImg"].ToString();


                }
            }
        }

        private void Clear()
        {
            txtBookID.Text = "";
            txtBookName.Text = "";
            txtPublishDate.Text = "";
            txtEdition.Text = "";
            txtCurrentStock.Text = "";
            txtBookCost.Text = "";
            txtPages.Text = "";
            txtStock.Text = "";
            txtIssuedBooks.Text = "";
            txtDescription.Text = "";
            ddlPublisherName.ClearSelection();
            ddlAuthorName.ClearSelection();
            ddlLanguage.ClearSelection();
            listBoxGenre.ClearSelection();
        }

        private void AddNewBook()
        {
            string name = "", language = "", genre = "", edition = "", description = "";
            int author = 0, publisher = 0, pagecount = 0, stock = 0, currentstock = 0, issuedbooks = 0;
            DateTime publisheddate;
            double cost = 0;

            name = txtBookName.Text.ToString();
            language = ddlLanguage.SelectedItem.Text.ToString();
            edition = txtEdition.Text.ToString();
            description = txtDescription.Text.ToString();
            author = int.Parse(ddlAuthorName.SelectedValue.ToString());
            publisher = int.Parse(ddlPublisherName.SelectedValue.ToString());
            cost = double.Parse(txtBookCost.Text.ToString());
            pagecount = int.Parse(txtPages.Text.ToString());
            stock = int.Parse(txtStock.Text.ToString());
            currentstock = int.Parse(txtStock.Text.ToString());
            //issuedbooks = int.Parse(txtIssuedBooks.Text.ToString());
            publisheddate = DateTime.Parse(txtPublishDate.Text.ToString());

            //get the selected genres
            string genres = "";
            foreach (int i in listBoxGenre.GetSelectedIndices())
            {
                genres = genres + listBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);  //removes the comma



            //save the img of bookcover to the folder (bookimg) in the project
            string bookimgpath = "~/bookimg/library.png";
            string bookimgname = Path.GetFileName(fileUploadBookImg.PostedFile.FileName);
            fileUploadBookImg.SaveAs(Server.MapPath("bookimg/" + bookimgname));
            bookimgpath = "~/bookimg/" + bookimgname;

            Boolean isSaved = false;
            isSaved = objBook.AddBook(name, description, publisher, publisheddate, author, genres, language, edition, pagecount, cost, stock, currentstock, bookimgpath);
            Response.Write("<script>alert('Book added successfully to book inventory.');</script>");
            Clear();
            dgvBookInventoryList.DataBind();
            // LoadBookInventory();
        }

        private void UpdateBookDetails()
        {
            string name = "", language = "", genre = "", edition = "", description = "", id = "";
            int author = 0, publisher = 0, pagecount = 0, stock = 0, currentstock = 0, issuedbooks = 0;
            DateTime publisheddate;
            double cost = 0;

            id = txtBookID.Text.ToString();
            name = txtBookName.Text.ToString();
            language = ddlLanguage.SelectedItem.Text.ToString();
            edition = txtEdition.Text.ToString();
            description = txtDescription.Text.ToString();
            author = int.Parse(ddlAuthorName.SelectedValue.ToString());
            publisher = int.Parse(ddlPublisherName.SelectedValue.ToString());
            cost = double.Parse(txtBookCost.Text.ToString());
            pagecount = int.Parse(txtPages.Text.ToString());
            stock = int.Parse(txtStock.Text.ToString());
            currentstock = int.Parse(txtStock.Text.ToString());
            //issuedbooks = int.Parse(txtIssuedBooks.Text.ToString());
            publisheddate = DateTime.Parse(txtPublishDate.Text.ToString());

            //get the selected genres
            string genres = "";
            foreach (int i in listBoxGenre.GetSelectedIndices())
            {
                genres = genres + listBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);  //removes the comma


            //save the img of bookcover to the folder (bookimg) in the project
            string bookimgpath = "~/bookimg/library.png";
            string bookimgname = Path.GetFileName(fileUploadBookImg.PostedFile.FileName);

            if (bookimgname == "" || bookimgname == null)
            {
                bookimgpath = global_filepath;
            }
            else
            {
                fileUploadBookImg.SaveAs(Server.MapPath("bookimg/" + bookimgname));
                bookimgpath = "~/bookimg/" + bookimgname;
            }


            stock = int.Parse(txtStock.Text.ToString());
            currentstock = int.Parse(txtCurrentStock.Text.ToString());

            if (global_actualstock == stock)
            {

            }
            else
            { 
                if (stock < global_issuedbooks)
                {
                    Response.Write("<script>alert('Stock can't be less than aamount of issued books.');</script>");
                }
                else
                {
                    currentstock = stock - global_issuedbooks;
                    txtCurrentStock.Text = "" + currentstock;
                }
            }


            Boolean isSaved = false;
            isSaved = objBook.UpdateBookDetails(id, name, description, publisher, publisheddate, author, genres, language, edition, pagecount, cost, stock, currentstock, bookimgpath);
            Response.Write("<script>alert('Book details updated successfully.');</script>");
            Clear();
            dgvBookInventoryList.DataBind();
            // LoadBookInventory();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string bookid = "", bookname = "";
            if (string.IsNullOrEmpty(txtBookName.Text))
            {
                Response.Write("<script>alert('Enter book name!');</script>");
            }
            else
            {
                bookname = txtBookName.Text.Trim().ToString();
                ds = objBook.LoadBookDetails(0, bookid, bookname);

                if (ds.Tables[0].Rows.Count >= 1)
                {
                    Response.Write("<script>alert('Book already exist in inventory! Try a different book!');</script>");
                    return;
                }
                else
                {
                    AddNewBook();
                }
            }
        }


        private void getStock()
        {
            int currentstock = 0;
            int actualstock = int.Parse(txtStock.Text.ToString());
            if (!string.IsNullOrEmpty(txtCurrentStock.Text))
            {
                currentstock = int.Parse(txtCurrentStock.Text.ToString());
            }
            
            int issued = 0;
            issued = (actualstock - currentstock);
            txtIssuedBooks.Text = issued.ToString();
        }

        //private void calculatestock(object sender, EventArgs e)
        //{
        //    int actualstock = 0;
        //    int currentstock = 0;
        //    int issuedbooks = 0;

        //    if ((string.IsNullOrEmpty(txtStock.Text)))
        //    {
        //        actualstock = 0;
        //        currentstock = 0;
        //        issuedbooks = 0;

        //        txtStock.Text = actualstock.ToString();
        //        txtCurrentStock.Text = currentstock.ToString();
        //        txtIssuedBooks.Text = issuedbooks.ToString();
        //    }
        //    else if ((!string.IsNullOrEmpty(txtStock.Text)) && (string.IsNullOrEmpty(txtCurrentStock.Text)))
        //    {
        //        actualstock = int.Parse(txtStock.Text.Trim().ToString());
        //        currentstock = actualstock;
        //        issuedbooks = (actualstock - currentstock);
        //        txtCurrentStock.Text = currentstock.ToString();
        //        txtIssuedBooks.Text = issuedbooks.ToString();
        //    }
        //    else if ((!string.IsNullOrEmpty(txtStock.Text)) && (!string.IsNullOrEmpty(txtCurrentStock.Text)))
        //    {
        //        //actualstock = int.Parse(txtStock.Text.Trim().ToString());
        //        //currentstock = actualstock;
        //    }

        //}

       

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string bookid = "", bookname = "";
            if (string.IsNullOrEmpty(txtBookName.Text))
            {
                Response.Write("<script>alert('Enter book name!');</script>");
            }
            else if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Response.Write("<script>alert('Enter book ID!');</script>");
            }
            else
            {
                bookid = txtBookID.Text.Trim().ToString();
                ds = objBook.LoadBookDetails(0, bookid, bookname);

                if (ds.Tables[0].Rows.Count >= 1)
                {
                    UpdateBookDetails();
                   
                }
                else
                {
                    Response.Write("<script>alert('Book does not exist in inventory! Try a different book!');</script>");
                    return;
                }
            }
        }

       
    }
}