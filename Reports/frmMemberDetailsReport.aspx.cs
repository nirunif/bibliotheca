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
    public partial class frmMemberDetailsReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string membername = "", memberid = "";
            int type;

            type = Convert.ToInt32(Session["type"].ToString());

            CMember objMember = new CMember();
            DataSet ds = new DataSet();
            ReportDocument myReportDoc = new ReportDocument();

            if (type == 0) //details of selected member
            {
                membername = (String)Session["membernamemembername"];
                memberid = (String)Session["memberid"];

                ds = objMember.LoadMemberDetails(1, memberid, membername);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    myReportDoc.Load(Server.MapPath("~/Reports/MemberDetailsReport.rpt"));
                    myReportDoc.SetDataSource(ds.Tables[0]);
                }
                else
                {
                    Response.Write("<script>alert('No data found!');</script>");
                }
            }
            else if (type == 1) //all book details
            {
               // string name = "All";
                ds = objMember.LoadMemberDetails(3, memberid, membername);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    myReportDoc.Load(Server.MapPath("~/Reports/MemberDetailsReport.rpt"));
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