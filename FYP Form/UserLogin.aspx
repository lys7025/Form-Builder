<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="FYP_Form.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<br />
	<asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
	<br />
	<asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
	<br />
	<asp:Button ID="login" runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
</asp:Content>
