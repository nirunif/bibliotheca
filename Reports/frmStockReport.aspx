﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmStockReport.aspx.cs" Inherits="Bibliotheca.Reports.frmStockReport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src='<%=ResolveUrl("~/crystalreportviewers13/js/crviewer/crv.js")%>' type="text/javascript"></script>
    <title>Book Stock Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="Reports\BookStockReport.rpt">
                </Report>
            </CR:CrystalReportSource>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />

        </div>
    </form>
</body>
</html>
