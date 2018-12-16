<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CollectResponse.aspx.cs" Inherits="FYP_Form.CollectResponse" %>

<style type="text/css">
	#container {
		width: 800px;
		height: 1000px;
		background: #dbdddd;
		margin-left: 130px;
	}

		#container > div {
			width: 100px;
			height: 100px;
			padding: 10px;
			margin-left: 100px;
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
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script type="text/javascript">
	var arrText = [];
	var arrTextarea = [];
	var arrCheck = [];
	var arrCheckCount = [];
	var arrRadio = [];
	var arrRadioCount = [];
	var arrDrop = [];
	var arrNumber = [];

	$(function () {
		$('#<%=btnSend.ClientID%>').click(function () {
			if (document.getElementById('<%=hfText.ClientID%>').value > 0) {
				for (var i = 1; i <= document.getElementById('<%=hfText.ClientID%>').value; i++) {
					arrText.push(document.getElementById("txtDrag" + i).value);
				}
				document.getElementById("hfTextArr").value = arrText;
			}

			if (document.getElementById('<%=hfTextarea.ClientID%>').value > 0) {
				for (var i = 1; i <= document.getElementById('<%=hfTextarea.ClientID%>').value; i++) {
					arrTextarea.push(document.getElementById("txtareaDrag" + i).value);
				}
				document.getElementById("hfTextareaArr").value = arrTextarea;
			}

			if (document.getElementById('<%=hfRadio.ClientID%>').value > 0) {
				var count = 0;
				var radioCount = 1;
				for (var i = 1; i <= document.getElementById('<%=hfRadio.ClientID%>').value; i++) {
					var length = document.getElementsByName("radioName" + count).length;
					for (var j = 0; j < length; j++) {//after count how many checkboxes get the value inside check
						if (document.getElementById("rbID" + radioCount).checked == true) {
							arrRadio.push(document.getElementsByName("radioChildName" + count)[j].textContent);
						}
						radioCount++;
					}
					count++;
				}
				document.getElementById("hfRadioArr").value = arrRadio;
			}

			if (document.getElementById('<%=hfCheck.ClientID%>').value > 0) {
				var count = 0;
				var checkCount = 1;
				var arrCount = 0;
				for (var i = 1; i <= document.getElementById('<%=hfCheck.ClientID%>').value; i++) {
					var length = document.getElementsByName("CheckBoxName" + count).length;
					for (var j = 0; j < length; j++) {//after count how many checkboxes get the value inside check
						if (document.getElementById("checkID" + checkCount).checked == true) {
							arrCheck.push(document.getElementsByName("checkChildName" + count)[j].textContent);
							arrCount++;
						}
						checkCount++;
					}
					arrCheckCount.push(arrCount);
					count++;
				}
				document.getElementById("hfCheckArr").value = arrCheck;
				document.getElementById("hfCheckCount").value = arrCheckCount;
			}

			if (document.getElementById('<%=hfDrop.ClientID%>').value > 0) {
				for (var i = 1; i <= document.getElementById('<%=hfDrop.ClientID%>').value; i++) {
					arrDrop.push($("#dropdown" + i + " :selected").text());
				}
				document.getElementById("hfDropArr").value = arrDrop;
			}

			if (document.getElementById('<%=hfNumber.ClientID%>').value > 0) {
				for (var i = 1; i <= document.getElementById('<%=hfNumber.ClientID%>').value; i++) {
					arrNumber.push(document.getElementById("number" + i).value);
				}
				document.getElementById("hfNumberArr").value = arrNumber;
			}
		})
	});
</script>
<style type="text/css">
	#container {
		width: 800px;
		height: 1000px;
		background: #dbdddd;
		margin-left: 200px;
	}

		#container > div {
			width: 100px;
			height: 100px;
			padding: 10px;
			margin-left: 100px;
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

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
	<title></title>
</head>

<body>
	<form id="form1" runat="server">
		<div>
			<asp:Button ID="btnSend" runat="server" Text="Submit" OnClick="btnSend_Click" />
		</div>
		<div id="mdDialog" class="modal">

			<!-- Modal content -->
			<%--<div class="modal-content">
				<asp:TextBox ID="txtLink" runat="server" ReadOnly="true"></asp:TextBox>
			</div>--%>
		</div>
		<div id="container" class="ui-widget-content">
			<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
		</div>
		<div>
			<asp:HiddenField ID="hfText" runat="server" />
			<asp:HiddenField ID="hfDrop" runat="server" />
			<asp:HiddenField ID="hfRadio" runat="server" />
			<asp:HiddenField ID="hfTextarea" runat="server" />
			<asp:HiddenField ID="hfCheck" runat="server" />
			<asp:HiddenField ID="hfCheckCount" runat="server" />
			<asp:HiddenField ID="hfNumber" runat="server" />
			<asp:HiddenField ID="hfTextArr" runat="server" />
			<asp:HiddenField ID="hfTextareaArr" runat="server" />
			<asp:HiddenField ID="hfRadioArr" runat="server" />
			<asp:HiddenField ID="hfCheckArr" runat="server" />
			<asp:HiddenField ID="hfDropArr" runat="server" />
			<asp:HiddenField ID="hfNumberArr" runat="server" />
		</div>
	</form>
</body>
</html>
