<%@ Page Title="Member Profile" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="MemberProfile.aspx.cs" Inherits="Bibliotheca.MemberProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <img src="img/user.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>My Profile</b></h4>
                                    <span>Status - </span>
                                    <asp:Label class="badge badge-pill badge-info" ID="lblAccountStatus" runat="server" Text="Account status"></asp:Label>
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
                                <label>Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter full name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="dd - mm - yyyy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                               
                         </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>NIC</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNIC" runat="server" CssClass="form-control" placeholder="Enter NIC no."></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Contact No.</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Enter contact no." TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                               
                         </div>

                        <div class="row">
                            <div class="col">
                                <label>Address</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter address" ></asp:TextBox>
                                </div>
                            </div>
                               
                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                 <label>Gender</label>
                            </div>
                            <div class="col-md-2">
                                <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" />
                              <label for="rbMale">Male</label>
                            </div>
                            <div class="col-md-2">
                                <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" />
                              <label for="rbfemale">Female</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Occupation</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlOccupation" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Student" Value="Student" />
                                        <asp:ListItem Text="Teacher" Value="Teacher" />
                                        <asp:ListItem Text="Other" Value="Other" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                               
                         </div>

                        <div class="row">
                            <div class="col">
                                 <center>
                                    <span class="badge badge-pill badge-warning">Your Login Credentials</span>
                                 </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Current Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                               
                         </div>

                        <div class="row">
                            <div class="col-md-8 mx-auto">
                                <center>
                                 <div class="form-group">
                                     <asp:Button ID="btnUpdate" runat="server" Text="Looking Good!" CssClass="btn-lg btn-block btn btn-primary" OnClick="btnUpdate_Click"/>
                                </div>
                                    </center>
                            </div>
                        </div>

                    </div>
                  </div>
                        
                <a href="Home.aspx">Go to Homepage</a>
                <br /><br /> 
            </div>

            <%--users books borrowed--%>
            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/books1.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>My Books</b></h4>
                                    <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="Book due date"></asp:Label>
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
                                <asp:GridView ID="dgvMemberBooks" runat="server" class="table table-striped table-bordered" OnRowDataBound="dgvMemberBooks_RowDataBound"></asp:GridView>
                            </div>
                        </div>




                    </div>
                  </div>

            </div>

          </div>
    </div>
    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox><asp:TextBox ID="txtMemberID" runat="server"></asp:TextBox>


</asp:Content>
