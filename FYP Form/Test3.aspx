<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test3.aspx.cs" Inherits="FYP_Form.Test3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>

	<%--<link rel="stylesheet" href="/resources/demos/style.css" />--%>
	<%--	<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />--%>
	<style>
		.draggable {
			width: 170px;
			height: 30px;
			padding: 0.5em;
			float: left;
			margin: auto auto;
		}

		#container {
			width: 500px;
			height: 700px;
			background: pink;
			margin: 250px;
		}
	</style>
	<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
	<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	<script type="text/javascript">
		count = 0;
		$(function () {
			//$("#menu").draggable({
			//	revert: "valid",
			//});
			$("#container").droppable({
				drop: function (event, ui) {
					//get clone element
					$element = ui.helper.clone();
					$element.draggable();
					$element.selectable();

					if (ui.draggable.attr('id') == 'divTxtDrag') {
						count++;
						$element.attr("id", 'divTxtDrag' + count);
						$element.appendTo(this);
						//Set how many item had dragged
						document.getElementById('<%=hfText.ClientID%>').value = count;
						//var html = new Sys.StringBuilder();
						//Create hidden field to store the position
						//for (var i = 1; i <= count; i++) {
						//	html.append("<input id='Hidden" + i + "' type='hidden' />");
						//}
						//document.getElementById("phHidden").innerHTML = html.toString();
						//Assign the coordination to hidden field
						var arrLeft = [];
						var arrTop = [];
						for (var j = 1; j <= count; j++) {
							arrLeft.push($("#divTxtDrag" + j).position().left);
							arrTop.push($("#divTxtDrag" + j).position().top);
						}
						document.getElementById("hfTextLeft").value = arrLeft;
						document.getElementById("hfTextTop").value = arrTop;
                    }



				}
			});
			$(".draggable").draggable({
				helper: cloneUniqueId,
				containment: '#droppable',
				cursor: 'move',
			});
			$('#<%=btnInsert.ClientID%>').click(function () {

			});

			function cloneUniqueId(event) {
				//return textbox
				return '<div id="divTxtDrag" class="draggable" ><input id="txtDrag" type="text" runat="server" /></div>'
			}
		});
		/*1. take count and put inside hidden field (if count 5 hidden filed = 5)
		  2. take the count from the cs and append to hidden field
		  3. get id + count*/
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

		<%--<div class="draggable ui-widget-content">
			<asp:TextBox ID="txtDrag" runat="server" Width="90" Height="30" ></asp:TextBox>
		</div>--%>
		<div>
			<asp:Button ID="btnInsert" runat="server" Text="Button" UseSubmitBehavior="false" />
		</div>
		<br />
		<asp:FileUpload ID="FileUpload1" runat="server" />
		<div id="divTxtDrag" class="draggable">
			<a href="#" id="testTxt">Textbox</a>
			<%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>
		</div>
		<div id="container" class="ui-widget-content">Drop blue box here..</div>
		<div>
			<asp:HiddenField ID="hfText" runat="server" />
			<asp:HiddenField ID="hfTextLeft" runat="server" />
			<asp:HiddenField ID="hfTextTop" runat="server" />
			<%--<div id="phHidden"></div>--%>
			<%--<asp:PlaceHolder ID="phHidden" runat="server"></asp:PlaceHolder>--%>
		</div>

	</form>
</body>
</html>

