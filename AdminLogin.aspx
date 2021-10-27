<%@ Page Title="Administrator Login" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Bibliotheca.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <br />
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/adminuser.png" width="150px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2><b>ADMIN LOGIN</b></h2>
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
                                <div class="form-group">
                                    <asp:TextBox ID="txtAdminID" runat="server" CssClass="form-control" placeholder="Enter Admin ID"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtAdminPw" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                     <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-lg btn-block btn btn-success" Font-Bold="True" OnClick="btnLogin_Click" />
                                </div>
                            </div>
                        </div>
                        
                        
                    </div>
                </div>
                
                <a href="Home.aspx">Go to Homepage</a>
                <br /><br /><br /><br />
            </div>
        </div>
    </div>

</asp:Content>
