<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ClassifiedSiteAdmin._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
       <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
       <asp:TextBox ID="txtName" runat="server" Text="Yashoman"></asp:TextBox>

       <br />
       <asp:Label ID="Label2" runat="server" Text="Image Upload"></asp:Label>
       <asp:FileUpload ID="FileUpload1" runat="server" />

       <br />

       <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />

       <br />
       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
       <br />
       <br />
        <asp:Image ID="Image1" Visible = "true" runat="server" Height = "100" Width = "100" />
   </div>
</asp:Content>
