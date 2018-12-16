<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYP_Form._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       <h1>TARC Form Builder</h1>
    <p class="lead">TARC Form Builder is a study project for creating web-form by using C#, html, CSS and JavaScript.</p>
    </div>

<div class="row">
    <div class="col-md-4">
        <h2>Create New Form</h2>
        <p>
            When the academic staffs want to create a new form, the system will provides the new blank template and the drag and drop tools box to design the custom form. The drag and drop tools box consists of text filed, radio button, label, checked box, and etc. Based on this tools box, the staff can generate a new custom form without any programming language.
        </p>        
    </div>
    <div class="col-md-4">
        <h2>Delete Form</h2>
        <p>The forms had been created by the academic staff can be deleted by the own users.</p>
    </div>
    <div class="col-md-4">
        <h2>Retrieve Form</h2>
        <p>The forms had been created by the academic staffs and stored in database, the users can retrieve the forms from database to view, publish or modify.</p>
    </div>
</div>

</asp:Content>
