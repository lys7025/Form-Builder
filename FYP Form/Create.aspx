<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogout.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="FYP_Form.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Create</h2>


	<%--@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()--%>

	<div class="form-horizontal">
		<h4>Basic information of the form</h4>
		<hr />


		<div class="form-group">

			<div class="col-md-10">

				<asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>

				<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>

			</div>
		</div>

		<!--<div class="form-group">
            @Html.LabelFor(model => model.staffID, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.staffID, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.staffID, "", new { @class = "text-danger" })
            </div>
        </div>-->

		<div class="form-group">

			<div class="col-md-10">

				<asp:Label ID="Label2" runat="server" Text="Version"></asp:Label>

				<asp:TextBox ID="txtVersion" runat="server"></asp:TextBox>

			</div>
		</div>

		<%--<div class="form-group">
          
            <div class="col-md-10">

                <asp:Label ID="Label3" runat="server" Text="status"></asp:Label>

                <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>

            </div>
        </div>--%>



		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<asp:Button ID="btnCreate" runat="server" Text="Create" UseSubmitBehavior="false" OnClick="btnCreate_Click"  />
				<%--<input type="button" id="btnCreate" value="Create" class="btn btn-default" onclick="btnCreate_Click()"  />--%>
				<%--                <input type="hidden" value="@User.Identity.Name" name="staffID" id="staffID"/>--%>
			</div>
		</div>
	</div>
	&nbsp;<div>
		<a href='javascript:history.go(-1)'>Go Back to Previous Page</a>
	</div>

	<%--    <script src="@Url.Content("~/bundles/jqueryval")" type="text/javascript"></script>--%>

	<%--<script src="@Url.Content("~/bundles/jqueryval")"></script>--%>
	<%-- @RenderSection("Scripts",false/*required*/)--%>
</asp:Content>
