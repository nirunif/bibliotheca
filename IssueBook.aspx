<%@ Page Title="Issue Books" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="IssueBook.aspx.cs" Inherits="Bibliotheca.IssueBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
        <div class="row">
            <%--user profile--%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>Issue Books</b></h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/bookshelf.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
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

                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookID" runat="server" CssClass="form-control" placeholder="Book ID"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkbtnSearchBook" runat="server" CssClass="btn btn-primary" OnClick="linkbtnSearchBook_Click">
                                                    <i class="fas fa-search"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control" placeholder="Member Name" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookName" runat="server" CssClass="form-control" placeholder="Book Name" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="btnIssue" runat="server" Text="Issue" CssClass="btn-lg btn-block btn btn-info" OnClick="btnIssue_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="btn-lg btn-block btn btn-primary" OnClick="btnReturn_Click" />
                            </div>
                        </div>

                    </div>
                </div>

                <a href="Home.aspx">Go to Homepage</a>
                <br />
                <br />
            </div>

            <%--users books borrowed--%>
            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>List of Issued Books</b></h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="dgvIssuedBookdetails" runat="server" class="table table-striped table-bordered table-responsive" OnRowDataBound="dgvIssuedBookdetails_RowDataBound" OnSelectedIndexChanged="dgvIssuedBookdetails_SelectedIndexChanged"></asp:GridView>
                            </div>
                        </div>


                        <asp:TextBox ID="txtMemID" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtBooID" runat="server" Visible="False"></asp:TextBox>

                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
