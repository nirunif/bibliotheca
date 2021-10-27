<%@ Page Title="Member Management" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="Bibliotheca.MemberManagement" %>

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
                                    <h4><b>Member Details</b></h4>
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
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtMemberID" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkbtnSearch" runat="server" CssClass="btn btn-primary" OnClick="linkbtnSearch_Click">
                                                    <i class="fas fa-search"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Member Name" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtAccountStatus" runat="server" CssClass="form-control" placeholder="Status" ReadOnly="True"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkbtnStatusActive" runat="server" CssClass="btn btn-success" OnClick="linkbtnStatusActive_Click">
                                                    <i class="far fa-check-circle"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnStatusPending" runat="server" CssClass="btn btn-warning" OnClick="linkbtnStatusPending_Click">
                                                    <i class="far fa-pause-circle"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnStatusDeactivate" runat="server" CssClass="btn btn-danger" OnClick="linkbtnStatusDeactivate_Click">
                                                    <i class="far fa-times-circle"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>NIC</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNIC" runat="server" CssClass="form-control" placeholder="NIC no." ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="dd - mm - yyyy" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Contact No.</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Contact no." TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Address</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Address" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" placeholder="Gender" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Occupation</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control" placeholder="Occupation" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6 mx-auto">
                                <asp:Button ID="btnRemoveMember" runat="server" Text="Remove Member" CssClass="btn-lg btn-block btn btn-danger" OnClick="btnRemoveMember_Click" />
                            </div>
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
                                    <h4><b>Members of Bibliotheca</b></h4>
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
                                <asp:GridView ID="dgvMemberdetails" runat="server" class="table table-striped table-bordered table-responsive table-hover" OnRowDataBound="dgvMemberdetails_RowDataBound"></asp:GridView>
                            </div>
                        </div>




                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
