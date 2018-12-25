<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="FYP_Form.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" ValidateRequestMode="Disabled">
	<script type="text/javascript">

		//document.getElementById("close").onclick = function () {
		//	mdDialog.style.display = "none";
		//};

	</script>

	<style type="text/css">
		#container {
			width: 800px;
			height: 1000px;
			background: #dbdddd;
			margin-left: 160px;
		}

			#container > div {
				width: 100px;
				height: 100px;
				padding: 10px;
                margin-top: 50px;
				margin-left: 80px;
			}

		#close {
			color: #aaa;
			float: right;
			font-size: 28px;
			font-weight: bold;
		}

			#close:hover,
			#close:focus {
				color: black;
				text-decoration: none;
				cursor: pointer;
			}
	</style>
	<div>
		<asp:Button ID="btnSend" runat="server" Text="Get URL" OnClick="btnSend_Click" />
	</div>
	<div id="mdDialog" class="modal">

		<!-- Modal content -->
		<div class="modal-content">
			<asp:TextBox ID="txtLink" runat="server" ReadOnly="true"></asp:TextBox>
		</div>

	</div>
	<div id="container" class="ui-widget-content">
		<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	</div>

</asp:Content>
