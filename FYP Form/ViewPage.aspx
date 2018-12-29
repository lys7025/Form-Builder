<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogout.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="FYP_Form.ViewPage" %>

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

        .btnUrl {
		height: 80px;
		width: 200px;
		background: #89b6ff;
		color: white;
		font-size: 22px;
		font-family: Calibri;
		border-bottom: 3px solid #925b08;
		border: none;
		border-radius: 5px;
        height: 50px;
		position: fixed;
		bottom: 250px;
		right: 0;
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
		<asp:Button ID="btnSend" runat="server" CssClass="btnUrl" Text="Get URL" OnClick="btnSend_Click" />
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
