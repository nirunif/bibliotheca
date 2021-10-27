<%@ Page Title="Book Inventory" Language="C#" MasterPageFile="~/BibliothecaMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageBookInventory.aspx.cs" Inherits="Bibliotheca.ManageBookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="datepicker/css/jquery-ui.css" rel="stylesheet" />
    <script src="datepicker/js/jquery-1.12.4.js"></script>
    <script src="datepicker/js/jquery-ui.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });


        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

        $(function () {
            $("#txtPublishDate").datepicker();
        });

    </script>

    <style type="text/css">
        .ui-datepicker { font-size:8pt !important}

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
        <div class="row">
            <%--book detail--%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>BOOK DETAILS</b></h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" src="bookimg/library.png" width="100px"/>
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
                                <%--<div class="input-group mb-3">
                                    <div class="custom-file">
                                        <label class="custom-file-label" for="FileUpload1">Choose file</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control custom-file-input" />
                                    </div>
                                    <div class="input-group-append">
                                        <asp:LinkButton ID="linkbtnUpload" runat="server" CssClass="btn btn-info">Upload</asp:LinkButton>
                                    </div>
                                </div>--%>


                                <%--<div class="input-group mb-12">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                    <div class="input-group-append" onchange="readURL(this);">
                                        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-info" Text="Upload" />
                                    </div>
                                </div>--%>

                                <asp:FileUpload ID="fileUploadBookImg" runat="server" onchange="readURL(this);" CssClass="form-control" />


                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookID" runat="server" CssClass="form-control" placeholder="ID" ToolTip="Enter book ID"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:LinkButton ID="linkbtnSearch" runat="server" CssClass="btn btn-primary" OnClick="linkbtnSearch_Click">
                                                    <i class="fas fa-search"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookName" runat="server" CssClass="form-control" placeholder="Book Name" ToolTip="Enter book name"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control" ToolTip="Select language of book">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Sinhala" Value="English" />
                                        <asp:ListItem Text="Spanish" Value="English" />
                                        <asp:ListItem Text="Tamil" Value="English" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlPublisherName" runat="server" CssClass="form-control" ToolTip="Select name of publisher">
                                    </asp:DropDownList>
                                </div>

                            </div>

                            <div class="col-md-4">


                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlAuthorName" runat="server" CssClass="form-control" ToolTip="Select name of author">
                                    </asp:DropDownList>
                                </div>

                                <label>Published Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPublishDate" runat="server" CssClass="form-control" ToolTip="Select date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="listBoxGenre" CssClass="form-control" runat="server" SelectionMode="Multiple" Rows="5" ToolTip="Select book genre/genres">
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Fiction" Value="Fiction" />
                                        <asp:ListItem Text="Non-Fiction" Value="Non-Fiction" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Mystery" Value="Mystery" />
                                    </asp:ListBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEdition" runat="server" CssClass="form-control" placeholder="Edition"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost (per unit) </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookCost" runat="server" CssClass="form-control" placeholder="Cost per Unit"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>No. of Pages</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPages" runat="server" CssClass="form-control" placeholder="Pages"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Stock" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCurrentStock" runat="server" CssClass="form-control" placeholder="Current Stock" ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtIssuedBooks" runat="server" CssClass="form-control" placeholder="Issued" ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Book Description" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn-lg btn-block btn btn-primary" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-lg btn-block btn btn-success" OnClick="btnUpdate_Click" />
                            </div>
                            <%--<div class="col-4">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-lg btn-block btn btn-danger" />
                            </div>--%>
                        </div>

                    </div>
                </div>

                <a href="Home.aspx">Go to Homepage</a>
                <br />
                <br />
            </div>

            <%--books in system--%>
            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4><b>BOOK INVENTORY</b></h4>
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




                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
