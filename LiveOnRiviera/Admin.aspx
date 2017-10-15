<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LiveOnRiviera.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="padding-left: 15px;">Admin Page</h2>
    <br />
    <br />

    <p style="margin-left: 150px;"><b>Please Enter the text</b></p>
    <form name="myform">

        <textarea style="margin-left: 150px;" name="mytextarea" id="txtarea1" runat="server" cols="70" rows="20">
            
</textarea>
        <br />

        <asp:Button ID="btnsubmit" runat="server" Style="margin-left: 150px;" Text="submit" OnClick="btnsubmit_Click" />
        <br />
        <br />
    </form>

    <%--<textarea columns="6" rows="8" runat="server" id="Admin" style="margin-left: 30px;"></textarea>--%>
</asp:Content>
