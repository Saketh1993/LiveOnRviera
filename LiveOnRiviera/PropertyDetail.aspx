<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PropertyDetail.aspx.cs" Inherits="LiveOnRiviera.PropertyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--/ <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        .carousel {
            background: #2f4357;
            margin-top: 20px;
            width: 940px;
            height: 360px;
        }

        .carousel-inner > .item > img {
            width: 940px;
            height: 360px;
        }

        .carousel .item {
            width: 640px;
            height: 360px;
            margin-left: 150px; /* Prevent carousel from being distorted if for some reason image doesn't load */
        }

            .carousel .item img {
                margin: 0 auto; /* Align slide image horizontally center */
            }

        .bs-example {
            margin: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="container1" runat="server">
    </div>
    <asp:GridView AutoGenerateColumns="true" ID="GridViewData" runat="server"></asp:GridView>
</asp:Content>
