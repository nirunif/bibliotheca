<%@ Page Title="Reports" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="BibReports.aspx.cs" Inherits="Bibliotheca.BibReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />
    <div class="container">
       <%-- stock report--%>
        <div class="row">
            <div class="col">
                <center>
                   <h4><b>STOCK</b></h4>
                </center>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <div class="form-group">
                    <div class="input-group">
                        <asp:TextBox ID="txtBookID" runat="server" CssClass="form-control" placeholder="Book ID"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="linkBtnSearchBook" runat="server" CssClass="btn btn-primary" OnClick="linkBtnSearchBook_Click">
                                <i class="fas fa-search"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Book Name" ID="txtBookName"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnReportStock" runat="server" Text="GET REPORT" CssClass="btn btn-block btn btn-info" OnClick="btnReportStock_Click"/>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnAll" runat="server" Text="ALL BOOKS" CssClass="btn btn-block btn btn-info" OnClick="btnAll_Click"/>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <hr />
            </div>
        </div>

        <%--book details report--%>

        <div class="row">
            <div class="col">
                <center>
                   <h4><b>BOOK DETAILS</b></h4>
                </center>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <div class="form-group">
                    <div class="input-group">
                        <asp:TextBox ID="txtBkDetID" runat="server" CssClass="form-control" placeholder="Book ID"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="linkbtnBkDetID" runat="server" CssClass="btn btn-primary" OnClick="linkbtnBkDetID_Click">
                                <i class="fas fa-search"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtBkName" runat="server" CssClass="form-control" placeholder="Book Name"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnGetBookDetReport" runat="server" Text="GET REPORT" CssClass="btn btn-block btn btn-info" OnClick="btnGetBookDetReport_Click" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnGetAllBookdet" runat="server" Text="ALL BOOKS" CssClass="btn btn-block btn btn-info" OnClick="btnGetAllBookdet_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col">
                <hr />
            </div>
        </div>

        <%--member details--%>

         <div class="row">
            <div class="col">
                <center>
                   <h4><b>MEMBER DETAILS</b></h4>
                </center>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <div class="form-group">
                    <div class="input-group">
                        <asp:TextBox ID="txtMemberID" runat="server" CssClass="form-control" placeholder="Member ID"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="linkbtnSearchMember" runat="server" CssClass="btn btn-primary" OnClick="linkbtnSearchMember_Click">
                                <i class="fas fa-search"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control" placeholder="Member Name"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnGetMemberReport" runat="server" Text="GET REPORT" CssClass="btn btn-block btn btn-info" OnClick="btnGetMemberReport_Click" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnGetAllMembers" runat="server" Text="ALL MEMBERS" CssClass="btn btn-block btn btn-info" OnClick="btnGetAllMembers_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col">
                <hr />
            </div>
        </div>

    </div>
</asp:Content>
