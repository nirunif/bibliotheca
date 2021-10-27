<%@ Page Title="Sign Up as New User" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="Bibliotheca.UserSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/addnewuser.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>Register to Bibliotheca</b></h4>
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
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter address" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                               
                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                 <label>Gender</label>
                            </div>
                            <div class="col-md-10 float">
                             <%-- <input type="radio" id="Male" name="Gender" class="custom-control-input">--%>
                                <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" />
                              <label for="rbMale">Male</label> &nbsp&nbsp&nbsp&nbsp&nbsp
                            
                                <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" />
                              <%--<input type="radio" id="female" name="Gender" class="custom-control-input">--%>
                              <label for="rbFemale">Female</label> &nbsp
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
                                    <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control" placeholder="Enter occupation"></asp:TextBox>
                                </div>
                            </div>
                               
                         </div>

                        <div class="row">
                            <div class="col">
                                 <center>
                                    <span class="badge badge-pill badge-warning">Login Credentials</span>
                                 </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                               
                         </div>

                        <div class="row">
                            <div class="col">
                                 <div class="form-group">
                                     <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn-lg btn-block btn btn-primary" OnClick="btnSignUp_Click"/>
                                </div>
                            </div>
                        </div>

                    </div>
                  </div>
                        
                <a href="Home.aspx">Go to Homepage</a>
                <br /><br /> 
            </div>
          </div>
                
                
            </div>
       

</asp:Content>
