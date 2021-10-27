using Bibliotheca.classes;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliotheca.Reports
{
    public partial class frmStockReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bookname = "", bookid = "";
            int type;
            
            type = Convert.ToInt32(Session["type"].ToString());

            CBook objBook = new CBook();
            DataSet ds = new DataSet();
            ReportDocument myReportDoc = new ReportDocument();

            if (type == 0)
            {
                bookname = (String)Session["booktitle"];
                bookid = (String)Session["bookid"];
               
                ds = objBook.LoadBookDetails(0, bookid, bookname);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    myReportDoc.Load(Server.MapPath("~/Reports/BookStockReport.rpt"));
                    myReportDoc.SetDataSource(ds.Tables[0]);
                }
                else
                {
                    Response.Write("<script>alert('No data found!');</script>");
                }
            }
            else if (type == 1)
            {
                ds = objBook.LoadBookDetails(3, bookid, bookname);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    myReportDoc.Load(Server.MapPath("~/Reports/BookStockReport.rpt"));
                    myReportDoc.SetDataSource(ds.Tables[0]);
                }
                else
                {
                    Response.Write("<script>alert('No data found!');</script>");
                }
            }

            CrystalReportViewer1.ReportSource = myReportDoc;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.RefreshReport();

        }
    }
}