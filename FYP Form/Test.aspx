<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="FYP_Form.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="Scripts/FormBuilder/form_builder.js"></script>
        <script src="Scripts/FormBuilder/jquery.min.js"></script>
        <script src="Scripts/FormBuilder/jquery-ui.min.js"></script>
        <script src="Scripts/FormBuilder/tether.min.js"></script>
        <script src="Scripts/FormBuilder/bootstrap.min.js"></script>


    <link rel="stylesheet" href="Content/form_builder.css"/>
            <link rel="stylesheet" href="Content/bootstrap.min.css"/>
        <link rel="stylesheet" href="Content/tether.min.css"/>
        <link rel="stylesheet" href="Content/font-awesome.min.css"/>



    <div class="form_builder" style="margin-top: 25px">
                <div class="row">
                    <div class="col-sm-2">
                        <nav class="nav-sidebar">
                            <ul class="nav">
                                <li class="form_bal_textfield">
                                    <a href="javascript:;">Text Field <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_textarea">
                                    <a href="javascript:;">Text Area <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_select">
                                    <a href="javascript:;">Select <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_radio">
                                    <a href="javascript:;">Radio Button <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_checkbox">
                                    <a href="javascript:;">Checkbox <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_email">
                                    <a href="javascript:;">Email <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_number">
                                    <a href="javascript:;">Number <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_password">
                                    <a href="javascript:;">Password <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_date">
                                    <a href="javascript:;">Date <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                                <li class="form_bal_button">
                                    <a href="javascript:;">Button <i class="fa fa-plus-circle pull-right"></i></a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                    <div class="col-md-5 bal_builder">
                        <div class="form_builder_area"></div>
                    </div>
                    <div class="col-md-5">
                        <div class="col-md-12">
                            <form class="form-horizontal">
                                <div class="preview"></div>
                                <div style="display: none" class="form-group plain_html"><textarea rows="50" class="form-control"></textarea></div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        



</asp:Content>
