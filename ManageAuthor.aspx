<%@ Page Title="Author Management" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageAuthor.aspx.cs" Inherits="Bibliotheca.ManageAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <%--user profile--%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>Manage Authors</b></h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/authornobg.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtAuthorID" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkbtnSearch" runat="server" CssClass="btn btn-primary" OnClick="linkbtnSearch_Click"> <i class="fas fa-search"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtAuthorName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn-lg btn-block btn btn-success" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="btn-lg btn-block btn btn-primary" OnClick="btnUpdate_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btn-lg btn-block btn btn-danger" OnClick="btnDelete_Click" />
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
                                    <h4><b>Author Details</b></h4>
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
                                <asp:GridView ID="dgvAuthordetails" runat="server" class="table table-striped table-bordered"></asp:GridView>
                            </div>
                        </div>




                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
