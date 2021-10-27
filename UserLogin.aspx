<%@ Page Title="User Login" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Bibliotheca.UserLogin" %>
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
                                    <img src="img/user.png" width="150px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2><b>MEMBER LOGIN</b></h2>
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
                                    <asp:TextBox ID="txtMemberID" runat="server" CssClass="form-control" placeholder="Enter member ID"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtMemberPw" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                </div>

                                 <div class="form-group">
                                     <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-lg btn-block btn btn-success" Font-Bold="True" OnClick="btnLogin_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="UserSignUp.aspx">
                                        <input class="btn-lg btn-block btn btn-primary" id="btnSignUp" type="button" value="Sign Up"/>
                                        
                                        <%--<asp:Button ID="btnSignUp" runat="server" Text="SIGN UP" CssClass="btn-lg btn-block btn btn-primary" />--%>

                                    </a>
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
