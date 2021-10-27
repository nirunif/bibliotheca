<%@ Page Title="Reserve a Book" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="BookReservation.aspx.cs" Inherits="Bibliotheca.BookReservation" %>

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
                                    <h4><b>Reserve a Book</b></h4>
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
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                        <asp:TextBox ID="txtMemberID" runat="server" CssClass="form-control" placeholder="Member ID"></asp:TextBox>
                                        
                                </div>
                            </div>

                            <div class="col-md-9">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control" placeholder="Member Name"></asp:TextBox>

                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
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

                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookName" runat="server" CssClass="form-control" placeholder="Book Name"></asp:TextBox>

                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-3"></div>
                            <div class="col-6">
                                <asp:Button ID="btnReserve" runat="server" Text="Reserve" CssClass="btn btn-block btn btn-info" OnClick="btnReserve_Click" />
                            </div>
                            <div class="col-md-3"></div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookReserveID" runat="server" CssClass="form-control" placeholder="Reservation ID"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkBtnReservationID" runat="server" CssClass="btn btn-primary" OnClick="linkBtnReservationID_Click">
                                                    <i class="fas fa-search"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-block btn btn-primary" OnClick="btnCancel_Click" />
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
                                    <h4><b>My Reservations</b></h4>
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
                                <asp:GridView ID="dgvReservations" runat="server" class="table table-striped table-bordered table-responsive"></asp:GridView>
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
