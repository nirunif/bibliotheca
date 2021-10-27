<%@ Page Title="Manage Book Reservations" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageBookReservations.aspx.cs" Inherits="Bibliotheca.ManageBookReservations" %>

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
            <%--member detail--%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>Reservation Details</b></h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/user.png" width="100px"/>
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
                                <label>Book Reservation ID</label>
                            </div>
                           <%-- <div class="col-md-8">
                                <asp:TextBox ID="txtBookReservationID" runat="server" CssClass="form-control" placeholder="Book Reservation ID"></asp:TextBox>
                            </div>--%>
                            <div class="col-md-8">
                            <div class="form-group">
                            <div class="input-group">
                                        <asp:TextBox ID="txtBookReservationID" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkbtnSearch" runat="server" CssClass="btn btn-primary" OnClick="linkbtnSearch_Click">
                                                    <i class="fas fa-search"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtMemberID" runat="server" CssClass="form-control" placeholder="Member ID" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control" placeholder="Member Name" ReadOnly="True"></asp:TextBox>

                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookID" runat="server" CssClass="form-control" placeholder="Book ID" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookName" runat="server" CssClass="form-control" placeholder="Book Name" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-3"></div>
                            <div class="col-md-6">
                                <asp:Button ID="btnCheckAvailability" runat="server" Text="Check Book Availability" CssClass="btn btn-block btn btn-info" OnClick="btnCheckAvailability_Click"/>
                            </div>
                            <div class="col-md-3"></div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDate" runat="server" placeholder="Date" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                <label>Reservation Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtReservationstatus" runat="server" CssClass="form-control" placeholder="Status" ReadOnly="True"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkbtnStatusReserved" runat="server" CssClass="btn btn-success" OnClick="linkbtnStatusReserved_Click">
                                                    <i class="far fa-check-circle"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnStatusPending" runat="server" CssClass="btn btn-warning" OnClick="linkbtnStatusPending_Click">
                                                    <i class="far fa-pause-circle"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnStatusCancel" runat="server" CssClass="btn btn-danger" OnClick="linkbtnStatusCancel_Click">
                                                    <i class="far fa-times-circle"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-3"></div>
                            <div class="col-md-6">
                                <asp:Button ID="btnCollect" runat="server" Text="Collected" CssClass="btn btn-block btn btn-success" OnClick="btnCollect_Click"/>
                            </div>
                            <div class="col-md-3"></div>
                        </div>

                    </div>
                </div>

                <a href="Home.aspx">Go to Homepage</a>
                <br />
                <br />
            </div>

            <%--members in system--%>
            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>Reservations</b></h4>
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
                                <asp:GridView ID="dgvReservations" runat="server" class="table table-striped table-bordered table-responsive table-hover"></asp:GridView>
                            </div>
                        </div>



                        <asp:TextBox ID="txtBId" runat="server"></asp:TextBox><asp:TextBox ID="txtMId" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
