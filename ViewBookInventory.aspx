<%@ Page Title="Book Inventory" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewBookInventory.aspx.cs" Inherits="Bibliotheca.ViewBookInventory" %>
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
            <div class="col-sm-12">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>BIBLIOTHECA BOOK INVENTORY</b></h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                           <%--  <div class="card">
                    <div class="card-body">--%>
                        <%--<div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>BOOK INVENTORY</b></h4>
                                </center>
                            </div>
                        </div>--%>

                        <%--<div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>--%>

                        <div class="row">
                            <div class="col-sm-12 col-md-12">
                                <asp:GridView ID="dgvBookInventoryList" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="Bibliothecadb" >
                                    <Columns>

                                        <asp:BoundField DataField="Book ID" HeaderText="Book ID" ReadOnly="True" SortExpression="Book ID">

                                            <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookTitle") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">


                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" Text="DESCRIPTION - "></asp:Label>
                                                                    <asp:Label ID="Label8" runat="server" Font-Size="Small" Text='<%# Eval("Description") %>'></asp:Label>


                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="AUTHOR - "></asp:Label>
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("AuthorName") %>'></asp:Label>
                                                                    &nbsp;|
                                                                    <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="GENRE - "></asp:Label>
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("Genre") %>'></asp:Label>
                                                                    &nbsp;|
                                                                    <asp:Label ID="Label5" runat="server" Font-Size="Small" Text="LANGUAGE - "></asp:Label>
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("Language") %>'></asp:Label>


                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="PUBLISHER - "></asp:Label>
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("PublisherName") %>'></asp:Label>
                                                                    |
                                                                    <asp:Label ID="Label11" runat="server" Font-Size="Small" Text="PUBLISHED DATE - "></asp:Label>
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("Publish_Date", "{0:d}") %>'></asp:Label>
                                                                    &nbsp;|
                                                                    <asp:Label ID="Label13" runat="server" Font-Size="Small" Text="PAGE COUNT - "></asp:Label>
                                                                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("NoOfPages") %>'></asp:Label>
                                                                    |
                                                                    <asp:Label ID="Label15" runat="server" Font-Size="Small" Text="EDITION - "></asp:Label>
                                                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("Edition") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    <asp:Label ID="Label17" runat="server" Font-Size="Small" Text="COST (Rs) - "></asp:Label>
                                                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("Cost") %>'></asp:Label>
                                                                    &nbsp;|
                                                                    <asp:Label ID="Label19" runat="server" Font-Size="Small" Text="ACTUAL STOCK - "></asp:Label>
                                                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("ActualStock") %>'></asp:Label>
                                                                    &nbsp;|
                                                                    <asp:Label ID="Label21" runat="server" Font-Size="Small" Text="AVAILABLE - "></asp:Label>
                                                                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("CurrentStock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image ID="bookcoverimage" runat="server" ImageUrl='<%# Eval("BookImg") %>' CssClass="img-fluid p-2" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="Bibliothecadb" runat="server" ConnectionString="<%$ ConnectionStrings:dbBibliothecaConnectionString %>" SelectCommand="SELECT Book.ID, Book.BookID AS [Book ID], Book.BookTitle, Book.Description, Book.Pub_ID, Book.Publish_Date, Book.Author_ID, Book.Genre, Book.Language, Book.Edition, Book.NoOfPages, Book.Cost, Book.ActualStock, Book.CurrentStock, 
                         Book.BookImg, Author.AuthorName, Publisher.PublisherName
FROM            Book INNER JOIN
                         Author ON Book.Author_ID = Author.ID INNER JOIN
                         Publisher ON Book.Pub_ID = Publisher.ID"></asp:SqlDataSource>
                            </div>
                        </div>




                    <%--</div>
                </div>--%>
                        </div>



                <br />
                 

            </div>

        </div>
    </div>
</asp:Content>
