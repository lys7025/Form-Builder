<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildForm.aspx.cs" Inherits="FYP_Form.BuildForm" %>

<!DOCTYPE html>

<link rel="stylesheet" href="Content/form_builder.css" />
<link rel="stylesheet" href="Content/bootstrap.min.css" />
<link rel="stylesheet" href="Content/tether.min.css" />
<%--<link rel="stylesheet" href="Content/font-awesome.min.css"/>--%>

<script src="Scripts/FormBuilder/test.js"></script>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style type="text/css">
	#container {
		width: 800px;
		height: 1000px;
		background: #dbdddd;
		margin-left: 300px;
	}

		#container > div {
			width: 100px;
			height: 100px;
			padding: 10px;
		}



	.bg-modal {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}



	.delete {
		width: 200px;
		height: 200px;
		background-color: red;
		position: fixed;
		bottom: 0;
		right: 0;
		opacity: 0.6;
		color: white
	}

    #btnBack {
		height: 80px;
		position: fixed;
		bottom: 350px;
		right: 0;
        width:200px;
        background-color:grey;
		color: black;
		font-size: 22px;
		font-family: Calibri;
		border-bottom: 3px solid #925b08;
		border: none;
		border-radius: 5px;
	}

	.divInsert {
		height: 50px;
		position: fixed;
		bottom: 250px;
		right: 0;
	}

	.buttonInsert {
		height: 80px;
		width: 200px;
		background: #89b6ff;
		color: white;
		font-size: 22px;
		font-family: Calibri;
		border-bottom: 3px solid #925b08;
		border: none;
		border-radius: 5px;
	}

		.buttonInsert:hover {
			background: #11479e;
		}

	.delete:hover {
		opacity: 0.2;
	}

	.modal-content {
		width: 500px;
		height: 300px;
		background-color: white;
		border-radius: 4px;
		position: relative;
        padding:20px
	}

	.close {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-txtarea {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.closetxtarea {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-select {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.close_select {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-header {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.close_header {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-para {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.close_para {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-number {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.close_number {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-radio {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.close_radio {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-check {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.close_check {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}

	.bg-modal-label {
		width: 100%;
		height: 100%;
		background-color: black;
		opacity: 0.9;
		position: absolute;
		top: 0;
		display: flex;
		justify-content: center;
		align-items: center;
		display: none;
	}

	.close_label {
		position: absolute;
		top: 0;
		right: 14px;
		font-size: 40px;
		transform: rotate(45deg);
	}
</style>

<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script type="text/javascript">
	var countTxt = 0;
	var countDdl = 0;
	var countRb = 0;
	var counttextArea = 0;
	var countcheck = 0;
	var countheader = 0;
	var countparagraph = 0;
	var countnumber = 0;
	var countdate = 0;
	var countfile = 0;
	var countlabel = 0;
	var countImage = 0;
	var getImageInt = 0;

	var countRBchild = 1;
	var countCheckchild = 1;

	var bigNumMin = 0;
	var bigNumMax = 5;

	var test = "";
	var getint = 0;
	var arrTxtLabel = [];
	var arrTextareaLabel = [];
	var arrDateLabel = [];
	var arrHeaderLabel = [];
	var arrHeaderFontSize = [];
	var arrHeaderFontFami = [];
	var arrParaLabel = [];
	var arrParaFontType = [];
	var arrParaFontColor = [];
	var arrNumberMin = [];
	var arrNumberMax = [];
	var arrDdlLabel = [];
	var arrDdlOption = [];
	var arrDdlValue = [];
	var arrCheckLabel = [];
	var arrCheckOption = [];
	var arrCheckValue = [];
	var arrRadioLabel = [];
	var arrRadioOption = [];
	var arrRadioValue = [];
	var arrLabelTxt = [];
	var arrLabelFontSize = [];

	function btnclick(id) {



		console.log("CLICKED EDIT");
		//document.querySelector(".bg-modal").style.display = "flex";

		for (var j = 1; j <= countTxt; j++) {

			if (id == "btnedit" + (j - 1)) {

				document.querySelector(".bg-modal").style.display = "flex";

			}
		}

		for (var j = 1; j <= counttextArea; j++) {

			if (id == "btntxtarea" + (j - 1)) {

				document.querySelector(".bg-modal-txtarea").style.display = "flex";

			}
		}

		for (var j = 1; j <= countDdl; j++) {

			if (id == "btneditDDL" + (j - 1)) {

				document.querySelector(".bg-modal-select").style.display = "flex";

			}
		}

		for (var j = 1; j <= countheader; j++) {

			if (id == "btneditheader" + (j - 1)) {

				document.querySelector(".bg-modal-header").style.display = "flex";

			}
		}

		for (var j = 1; j <= countparagraph; j++) {

			if (id == "btneditpara" + (j - 1)) {

				document.querySelector(".bg-modal-para").style.display = "flex";

			}
		}

		for (var j = 1; j <= countnumber; j++) {

			if (id == "btneditnumber" + (j - 1)) {

				document.querySelector(".bg-modal-number").style.display = "flex";

			}
		}

		for (var j = 1; j <= countRb; j++) {

			if (id == "addrb" + (j - 1)) {

				document.querySelector(".bg-modal-radio").style.display = "flex";

			}
		}

		for (var j = 1; j <= countcheck; j++) {

			if (id == "addcheck" + (j - 1)) {

				document.querySelector(".bg-modal-check").style.display = "flex";

			}
		}

		for (var j = 1; j <= countImage; j++) {

			if (id == "" + (j - 1)) {

				document.querySelector(".bg-modal").style.display = "flex";

			}
		}

		for (var j = 1; j <= countlabel; j++) {

			if (id == "btneditlabel" + (j - 1)) {

				document.querySelector(".bg-modal-label").style.display = "flex";

			}
		}

		test = id;
		//var slength = test.length;
		//var lastchar = test.charAt(slength - 1);
		getint = parseInt(test.match(/\d+/)[0]);
		//alert(getint +20);

	}


	function changelabeltxt() {// edit textfield label after user edited

		if (document.getElementById("changeLabel").value == "") {

			alert("Please Enter the Label");

		} else {

			var ooo = document.getElementById("changeLabel").value;
			document.getElementById("txtlb" + getint).innerHTML = ooo;
			alert("Label Change successfully");
			document.querySelector('.bg-modal').style.display = 'none';
			document.getElementById("changeLabel").value = "";
		}

	}

	function changelabeltxtarea() {// edit textarea label after user edited

		if (document.getElementById("changeLabeltxtarea").value == "") {

			alert("Please Enter the Label");
		} else {

			document.getElementById("txtarealb" + getint).innerHTML = document.getElementById("changeLabeltxtarea").value;
			alert("Label Change successfully");
			document.querySelector('.bg-modal-txtarea').style.display = 'none';
			document.getElementById("changeLabeltxtarea").value = "";
		}

	}

	function changeHeader() {// edit Header after user edited

		if (document.getElementById("changeLabelHeader").value == "") {

			alert("Please enter the header");
		} else {

			document.getElementById("headerlb" + getint).innerHTML = document.getElementById("changeLabelHeader").value;

			var headerfamily = document.getElementById('SelectFontFamily');
			var familyValue = headerfamily.options[headerfamily.selectedIndex].value;
			var headersize = document.getElementById('SelectFontSize');
			var sizeValue = headersize.options[headersize.selectedIndex].value;

			document.getElementById("headerlb" + getint).style.fontFamily = familyValue;
			document.getElementById("headerlb" + getint).style.fontSize = sizeValue + "px";
			//alert(headerStyle);
			alert("Header Change successfully");
			document.querySelector('.bg-modal-header').style.display = 'none';
			document.getElementById("changeLabelHeader").value = "";

		}
	}

	function changePara() {

		if (document.getElementById("changeParaText").value == "") {
			alert("Please enter Something into paragraph");
		} else {

			document.getElementById("para_id" + getint).innerHTML = document.getElementById("changeParaText").value;

			var para_color = document.getElementById('Para_font_color');
			var color_value = para_color.options[para_color.selectedIndex].value;

			var para_style = document.getElementsByName('parafontstyle');

			document.getElementById("para_id" + getint).style.color = color_value;

			for (var i = 0, length = para_style.length; i < length; i++) {
				if (para_style[i].checked) {
					// do whatever you want with the checked radio
					//alert(para_style[i].value);
					document.getElementById("para_id" + getint).style.fontStyle = para_style[i].value;
					document.getElementById("para_id" + getint).style.fontWeight = para_style[i].value;
				}
			}

			document.getElementById("changeParaText").value = "";
			alert("Update successfully");
			document.querySelector('.bg-modal-para').style.display = 'none';
		}
	}

	function changeBigNumber() {

		var min = document.getElementById("changeMinNumber").value;
		var max = document.getElementById("changeMaxNumber").value;


      

		if (parseInt(min) > parseInt(max)) {
			alert("Please make sure the min is less than Max");

		} else {
			document.getElementById("bigNumQty" + getint).setAttribute("min", min);
			document.getElementById("bigNumQty" + getint).setAttribute("max", max);
			alert("Update successfully");
			document.querySelector('.bg-modal-number').style.display = 'none';
		}
	}

	function addSelectValue() {

		var sel = document.getElementById("mySelect" + getint);
		var opt = document.createElement("option");

		opt.text = document.getElementById("getSelectText").value;
		//opt.value = document.getElementById("getSelectValue").value;
        opt.value = opt.text;

		if (opt.text == "" ) {
			alert("Please fill in the blank");
		} else {
			sel.add(opt);
			alert("add successfully");
			document.getElementById("getSelectText").value = "";
			document.getElementById("getSelectValue").value = "";
		}

	}

	function removeSelect(id) {

		selInt = parseInt(id.match(/\d+/)[0]);
		var sel = document.getElementById("mySelect" + selInt);
		//if (sel.selectedIndex == 0) {
		//	alert("Please select an item to delete");

		//} else {

		sel.remove(sel.selectedIndex);
		//}

	}
	function changeRadioText() {

		if (document.getElementById("changeLabelRadio").value == "") {

			alert("Please enter the label");
		} else {
			document.getElementById("rblb" + getint).innerHTML = document.getElementById("changeLabelRadio").value;
			alert("Update Successfully");
		}
	}

	function changeDDLText() {

		if (document.getElementById("changeLabelDDL").value == "") {

			alert("Please enter the label");
		} else {
			document.getElementById("ddllb" + getint).innerHTML = document.getElementById("changeLabelDDL").value;
			alert("Update Successfully");
		}

	}

	function addRadio() {

		//var val = document.getElementById("addRadioValue").value;
        var text = document.getElementById("addRadioText").value;
        var val = text;
		var divRB = document.getElementById("divRadio" + getint);
		var name = "radioName" + getint;

		var radioHtml = '<div id="childRB' + countRBchild + '" name="radioChildName' + getint + '"><input type="radio" id="rbID' + countRBchild + '" name="' + name + '" value="' + val + '" /> ' + text + ' </div> ';
		divRB.innerHTML += radioHtml;
		alert("Add Successfully");
		countRBchild++;

	}

	function removeRB(id) {

		rbInt = parseInt(id.match(/\d+/)[0]);
		var rb = document.getElementsByName("radioName" + rbInt);



		for (var i = 0, length = rb.length; i < length; i++) {
			if (rb[i].checked) {
				rbID = rb[i].id;
				temp = parseInt(rbID.match(/\d+/)[0]);
				var check = document.getElementById("childRB" + temp);
				check.parentNode.removeChild(check);

				break;
			} else {
				alert("please select an item to delete");
			}
		}


	}

	function changeCheckText() {

		if (document.getElementById("changeLabelCheck").value == "") {

			alert("Please enter the label");

		} else {
			document.getElementById("checklb" + getint).innerHTML = document.getElementById("changeLabelCheck").value;
			alert("Update successfully");
		}

		//document.getElementById("hfTextareaLabel").value = arrTextareaLabel;
	}

	function addCheck() {

		//var val = document.getElementById("addCheckValue").value;
        var text = document.getElementById("addCheckText").value;
        var val = text;
		var divCheck = document.getElementById("divCheck" + getint);
		var name = "CheckBoxName" + getint;

		var CheckHtml = "<div id='childCheck" + countCheckchild + "' name='checkChildName" + getint + "'><input type='checkbox' id='checkID" + countCheckchild + "' name='" + name + "' value='" + val + "' /> " + text + " </div> ";

		divCheck.innerHTML += CheckHtml;
		alert("Successfully Add");
		countCheckchild++;

	}

	function removeCheck(id) {

		checkInt = parseInt(id.match(/\d+/)[0]);
		var CB = document.getElementsByName("CheckBoxName" + checkInt);

		for (var i = 0, length = CB.length; i < length; i++) {
			if (CB[i].checked) {
				cbID = CB[i].id;
				temp = parseInt(cbID.match(/\d+/)[0]);
				var check = document.getElementById("childCheck" + temp);
				check.parentNode.removeChild(check);

				break;
			}
		}
	}

	function changeLabelFunction() {

		if (document.getElementById("changeLabelValue").value == "") {

			alert("Please enter the label text");
		} else {

			document.getElementById("labelID" + getint).innerHTML = document.getElementById("changeLabelValue").value;


			var labelsize = document.getElementById('SelectFontSizeLabel');
			var sizeValue = labelsize.options[labelsize.selectedIndex].value;

			document.getElementById("labelID" + getint).style.fontSize = sizeValue + "px";

			alert("Label Change successfully");
			document.querySelector('.bg-modal-label').style.display = 'none';
			document.getElementById("changeLabelValue").value = "";

		}

	}

	function changeImage(id) {

		$('#imgupload').trigger('click');

		getImageInt = parseInt(id.match(/\d+/)[0]);
	}

	function showImage() {

		if (this.files && this.files[0]) {
			var obj = new FileReader();
			obj.onload = function (data) {
				var image = document.getElementById("image" + getImageInt);
				image.src = data.target.result;
				image.style.display = "block";
			}
			obj.readAsDataURL(this.files[0]);
		}
    }
    function cancelPage() {

        if (confirm('Are you sure you want Cancel? the Changes will not be save')) {
            document.location.href = 'FormPage';
    
        } else {
    // Do nothing!
            }

    }

	function maintainDrag() {

		$(".form_bal_file1").draggable({

			cursor: 'move',
			revert: 'invalid',
			stop: function () {
				$(this).draggable('option', 'revert', 'invalid');
			}
		});

		//        $('.form_bal_file1').droppable({
		//            greedy: true,

		//         drop: function(event,ui){
		//        ui.draggable.draggable('option','revert',true);
		//    }
		//});

		//      $(".form_bal_text1").draggable({
		//	containment: '#container',  
		//          cursor: 'move',
		//});

		$(".form_bal_text1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_textarea1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_ddl1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_radio1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_checkbox1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_header1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_paragraph1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_number1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_date1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_label1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

		$(".form_bal_image1").draggable({

			cursor: 'move',
			revert: 'invalid',
			//stop: function () {
			//	$(this).draggable('option', 'revert', 'invalid');
			//}
		});

	}

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


				if (ui.draggable.attr('id') == 'li_txtfield') {

					countTxt++;

					$element.attr("id", 'li_txtfield' + countTxt);
					$element.appendTo(this);

					//Set how many item had dragged
					document.getElementById('<%=hfText.ClientID%>').value = countTxt;

				}

				if (ui.draggable.attr('id') == 'li_ddl') {
					countDdl++;

					$element.attr("id", 'li_ddl' + countDdl);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfDrop.ClientID%>').value = countDdl;

				}

				if (ui.draggable.attr('id') == 'li_rb') {
					countRb++;
					$element.attr("id", 'li_rb' + countRb);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfRadio.ClientID%>').value = countRb;

				}


				if (ui.draggable.attr('id') == 'li_textarea') {
					counttextArea++;
					$element.attr("id", 'li_textarea' + counttextArea);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfTextarea.ClientID%>').value = counttextArea;

				}

				if (ui.draggable.attr('id') == 'li_checkbox') {
					countcheck++;
					$element.attr("id", 'li_checkbox' + countcheck);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfCheck.ClientID%>').value = countcheck;

				}

				if (ui.draggable.attr('id') == 'li_header') {
					countheader++;
					$element.attr("id", 'li_header' + countheader);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfHeader.ClientID%>').value = countheader;

				}

				if (ui.draggable.attr('id') == 'li_paragraph') {
					countparagraph++;
					$element.attr("id", 'li_paragraph' + countparagraph);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfParagraph.ClientID%>').value = countparagraph;

				}

				if (ui.draggable.attr('id') == 'li_number') {
					countnumber++;
					$element.attr("id", 'li_number' + countnumber);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfNumber.ClientID%>').value = countnumber;

				}

				if (ui.draggable.attr('id') == 'li_date') {
					countdate++;
					$element.attr("id", 'li_date' + countdate);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfDate.ClientID%>').value = countdate;

				}

				if (ui.draggable.attr('id') == 'li_file') {
					countfile++;
					$element.attr("id", 'li_file' + countfile);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfFile.ClientID%>').value = countfile;

				}

				if (ui.draggable.attr('id') == 'li_label') {
					countlabel++;
					$element.attr("id", 'li_label' + countlabel);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfLabel.ClientID%>').value = countlabel;

				}

				if (ui.draggable.attr('id') == 'li_image') {
					countImage++;
					$element.attr("id", 'li_image' + countImage);
					$element.appendTo(this);
					//Set how many item had dragged
					document.getElementById('<%=hfImage.ClientID%>').value = countImage;

				}

			}


		});



		$('#<%=btnInsert.ClientID%>').click(function () {
			//Assign position into hiddenfield
			if (countTxt > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				numCount = 0;
				for (var j = 1; j <= countTxt; j++) {
					if ($("#li_txtfield" + j).length != 0) {
						arrTxtLabel.push($("#txtlb" + numCount).text());
						arrLeft.push($("#li_txtfield" + j).position().left);
						arrTop.push($("#li_txtfield" + j).position().top);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfText").value = totalNo;
				document.getElementById("hfTextLeft").value = arrLeft;
				document.getElementById("hfTextTop").value = arrTop;
				document.getElementById("hfTextLabel").value = arrTxtLabel;

			}

			if (countDdl > 0) {
				var arrLeft = [];
				var arrTop = [];
				var arrCount = [];
				var totalNo = 0;
				numCount = 0;
				for (var j = 1; j <= countDdl; j++) {
					if ($("#li_ddl" + j).length != 0) {
						var length = document.getElementById("mySelect" + numCount).length;
						arrCount.push(length);
						arrDdlLabel.push($("#ddllb" + numCount).text());
						for (var k = 0; k < length; k++) {//after count ddl length get the value inside option
							arrDdlOption.push(document.getElementById("mySelect" + numCount).options[k].text);
							arrDdlValue.push(document.getElementById("mySelect" + numCount).options[k].value);
						}
						arrLeft.push($("#li_ddl" + j).position().left);
						arrTop.push($("#li_ddl" + j).position().top);
						totalNo++;
					} 
					numCount++;
				}
				document.getElementById("hfDrop").value = totalNo;
				document.getElementById("hfDropLeft").value = arrLeft;
				document.getElementById("hfDropTop").value = arrTop;
				document.getElementById("hfDropLabel").value = arrDdlLabel;
				document.getElementById("hfDropOption").value = arrDdlOption;
				document.getElementById("hfDropValue").value = arrDdlValue;
				document.getElementById("hfDropCount").value = arrCount;
			}

			if (countRb > 0) {
				var arrLeft = [];
				var arrTop = [];
				var arrCount = [];
				var totalNo = 0;
				numCount = 0;
				for (var j = 1; j <= countRb; j++) {
					if ($("#li_rb" + j).length != 0) {
						var length = document.getElementsByName("radioName" + numCount).length;
						arrCount.push(length);
						arrRadioLabel.push($("#rblb" + numCount).text());
						for (var k = 0; k < length; k++) {//after count how many radio get the value inside radio
							arrRadioOption.push(document.getElementsByName("radioChildName" + numCount)[k].textContent);
							arrRadioValue.push(document.getElementsByName("radioName" + numCount)[k].value);
						}
						arrLeft.push($("#li_rb" + j).position().left);
						arrTop.push($("#li_rb" + j).position().top);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfRadio").value = totalNo;
				document.getElementById("hfRadioLeft").value = arrLeft;
				document.getElementById("hfRadioTop").value = arrTop;
				document.getElementById("hfRadioLabel").value = arrRadioLabel;
				document.getElementById("hfRadioOption").value = arrRadioOption;
				document.getElementById("hfRadioValue").value = arrRadioValue;
				document.getElementById("hfRadioCount").value = arrCount;
			}

			if (counttextArea > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				numCount = 0;
				for (var j = 1; j <= counttextArea; j++) {
					if ($("#li_textarea" + j).length != 0) {
						arrTextareaLabel.push($("#txtarealb" + numCount).text());
						arrLeft.push($("#li_textarea" + j).position().left);
						arrTop.push($("#li_textarea" + j).position().top);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfTextarea").value = totalNo;
				document.getElementById("hfTextareaLabel").value = arrTextareaLabel;
				document.getElementById("hfTextareaLeft").value = arrLeft;
				document.getElementById("hfTextareaTop").value = arrTop;
			}

			if (countcheck > 0) {
				var arrLeft = [];
				var arrTop = [];
				var arrCount = [];
				var totalNo = 0;
				numCount = 0;
				for (var j = 1; j <= countcheck; j++) {
					if ($("#li_checkbox" + j).length != 0) {
						var length = document.getElementsByName("CheckBoxName" + numCount).length;
						arrCount.push(length);
						arrCheckLabel.push($("#checklb" + numCount).text());
						for (var k = 0; k < length; k++) {//after count how many checkboxes get the value inside check
							arrCheckOption.push(document.getElementsByName("checkChildName" + numCount)[k].textContent);
							arrCheckValue.push(document.getElementsByName("CheckBoxName" + numCount)[k].value);
						}
						arrLeft.push($("#li_checkbox" + j).position().left);
						arrTop.push($("#li_checkbox" + j).position().top);
						totalNo++;
					}
					numCount++;

				}
				document.getElementById("hfCheck").value = totalNo;
				document.getElementById("hfCheckLeft").value = arrLeft;
				document.getElementById("hfCheckTop").value = arrTop;
				document.getElementById("hfCheckLabel").value = arrCheckLabel;
				document.getElementById("hfCheckOption").value = arrCheckOption;
				document.getElementById("hfCheckValue").value = arrCheckValue;
				document.getElementById("hfCheckCount").value = arrCount;
			}

			if (countheader > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				numCount = 0;
				for (var j = 1; j <= countheader; j++) {
					if ($("#li_header" + j).length != 0) {
						arrHeaderLabel.push($("#headerlb" + numCount).text());
						arrHeaderFontSize.push(parseInt($("#headerlb" + numCount).css("fontSize")));
						arrHeaderFontFami.push(document.getElementById("headerlb" + numCount).style.fontFamily);
						arrLeft.push($("#li_header" + j).position().left);
						arrTop.push($("#li_header" + j).position().top);
						totalNo++;
					}
					numCount++;

				}
				document.getElementById("hfHeader").value = totalNo;
				document.getElementById("hfHeaderLeft").value = arrLeft;
				document.getElementById("hfHeaderTop").value = arrTop;
				document.getElementById("hfHeaderFontFami").value = arrHeaderFontFami;
				document.getElementById("hfHeaderFontSize").value = arrHeaderFontSize;
				document.getElementById("hfHeaderLabel").value = arrHeaderLabel;
			}

			if (countparagraph > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				numCount = 0;
				for (var j = 1; j <= countparagraph; j++) {
					if ($("#li_paragraph" + j).length != 0) {
						arrParaLabel.push($("#para_id" + numCount).text());
						arrParaFontType.push(document.getElementById("para_id" + numCount).style.fontWeight == null ? "normal" : document.getElementById("para_id" + numCount).style.fontWeight);
						arrParaFontColor.push(document.getElementById("para_id" + numCount).style.color == null ? "black" : document.getElementById("para_id" + numCount).style.color);
						arrLeft.push($("#li_paragraph" + j).position().left);
						arrTop.push($("#li_paragraph" + j).position().top);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfParagraph").value = totalNo;
				document.getElementById("hfParagraphLeft").value = arrLeft;
				document.getElementById("hfParagraphTop").value = arrTop;
				document.getElementById("hfParagraphFontType").value = arrParaFontType;
				document.getElementById("hfParagraphFontColor").value = arrParaFontColor;
				document.getElementById("hfParagraphLabel").value = arrParaLabel;
			}

			if (countnumber > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				var numCount = 0;
				for (var j = 1; j <= countnumber; j++) {
					if ($("#li_number" + j).length != 0) {
						arrLeft.push($("#li_number" + j).position().left);
						arrTop.push($("#li_number" + j).position().top);
						arrNumberMin.push(document.getElementById("bigNumQty" + numCount).min);
						arrNumberMax.push(document.getElementById("bigNumQty" + numCount).max);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfNumber").value = totalNo;
				document.getElementById("hfNumberLeft").value = arrLeft;
				document.getElementById("hfNumberTop").value = arrTop;
				document.getElementById("hfNumberMin").value = arrNumberMin;
				document.getElementById("hfNumberMax").value = arrNumberMax;
			}

			if (countdate > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				var numCount = 0;
				for (var j = 1; j <= countdate; j++) {
					if ($("#li_date" + j).length != 0) {
						arrDateLabel.push($("#date_id" + numCount).val());
						arrLeft.push($("#li_date" + j).position().left);
						arrTop.push($("#li_date" + j).position().top);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfDate").value = totalNo;
				document.getElementById("hfDateLabel").value = arrDateLabel;
				document.getElementById("hfDateLeft").value = arrLeft;
				document.getElementById("hfDateTop").value = arrTop;
			}

			if (countfile > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				for (var j = 1; j <= countfile; j++) {

					arrLeft.push($("#li_file" + j).position().left);
					arrTop.push($("#li_file" + j).position().top);

				}
				document.getElementById("hfFileLeft").value = arrLeft;
				document.getElementById("hfFileTop").value = arrTop;
			}

			if (countlabel > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				var numCount = 0;
				for (var j = 1; j <= countlabel; j++) {
					if ($("#li_label" + j).length != 0) {
						arrLabelTxt.push($("#labelID" + numCount).text());
						arrLabelFontSize.push(parseInt($("#labelID" + numCount).css("fontSize")));
						arrLeft.push($("#li_label" + j).position().left);
						arrTop.push($("#li_label" + j).position().top);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfLabel").value = totalNo;
				document.getElementById("hfLabelLeft").value = arrLeft;
				document.getElementById("hfLabelTop").value = arrTop;
				document.getElementById("hfLabelText").value = arrLabelTxt;
				document.getElementById("hfLabelFontSize").value = arrLabelFontSize;
			}

			if (countImage > 0) {
				var arrLeft = [];
				var arrTop = [];
				var totalNo = 0;
				var numCount = 0;
				for (var j = 1; j <= countImage; j++) {
					if ($("#li_image" + j).length != 0) {
						arrLeft.push($("#li_image" + j).position().left);
						arrTop.push($("#li_image" + j).position().top);
						totalNo++;
					}
					numCount++;
				}
				document.getElementById("hfImage").value = totalNo;
				document.getElementById("hfImageLeft").value = arrLeft;
				document.getElementById("hfImageTop").value = arrTop;
			}

		});

		$('#deletefield').droppable({
			drop: function (event, ui) {
				$(ui.helper).remove(); //destroy clone

				if (countTxt > 0) {
					$(ui.draggable).remove();//remove from list
				}
				if (countDdl > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countRb > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (counttextArea > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countcheck > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countheader > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countparagraph > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countnumber > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countdate > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countfile > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countlabel > 0) {
					$(ui.draggable).remove();//remove from list
				}

				if (countImage > 0) {
					$(ui.draggable).remove();//remove from list
				}
			}
		});

		$(".form_bal_text").draggable({
			helper: cloneUniqueId,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_textarea").draggable({
			helper: gettextArea,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_ddl").draggable({
			helper: getdropdownlist,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_radio").draggable({
			helper: getradiobutton,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_checkbox").draggable({
			helper: getCheckbox,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_header").draggable({
			helper: getHeader,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_paragraph").draggable({
			helper: getParagraph,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_number").draggable({
			helper: getBigNumber,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_date").draggable({
			helper: getDate,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_file").draggable({
			helper: getUploadFile,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_label").draggable({
			helper: getLabel,
			containment: '#droppable',
			cursor: 'move',
		});

		$(".form_bal_image").draggable({
			helper: getImage,
			containment: '#droppable',
			cursor: 'move',
		});


		//Return dragged item
		function cloneUniqueId(event) {
			//return textbox               
			return '<div id="li_txtfield' + countTxt + '" class="form_bal_text1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i> <div id="txtlb' + countTxt + '"> Label </div> <input id="txtDrag" type="text" size="45" runat="server" /> <a href="#" id="btnedit' + countTxt + '" class="button" onclick="btnclick(this.id)" > Edit </a>  </div> '
		}

		function getdropdownlist(event) {

			return '<div id="li_ddl' + countDdl + '" class="form_bal_ddl1" ondrag="maintainDrag()" style="width:300px" > <i class="fa fa-arrows-alt" style="float:right"></i> <div id="ddllb' + countDdl + '"> Label </div> <select id="mySelect' + countDdl + '" style="width:300px" > <option > None </option> </select> <a href="#" id="btneditDDL' + countDdl + '" class="button" onclick="btnclick(this.id)"> Add </a> <a href="#" id="removeDDL' + countDdl + '" onclick="removeSelect(this.id)"> Remove selected option </a>  </div> '
		}

		function getradiobutton(event) {


			return '<div id="li_rb' + countRb + '" class="form_bal_radio1" ondrag="maintainDrag()" style="width:300px" > <i class="fa fa-arrows-alt" style="float:right"></i> <div id="rblb' + countRb + '"> Label </div> <div id="divRadio' + countRb + '">  </div> <a href="#" id="addrb' + countRb + '" class="button" onclick="btnclick(this.id)"> Add </a> <a href="#" id="removeRB' + countRb + '" onclick="removeRB(this.id)"> Remove selected option </a>  </div> '
		}

		function gettextArea(event) {

			return '<div id="li_textarea' + counttextArea + '" class="form_bal_textarea1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i> <div id="txtarealb' + counttextArea + '"> Label </div> <textarea rows="5" id="txtareaDrag' + counttextArea + '" placeholder=" "/> <a href="#" id="btntxtarea' + counttextArea + '" class="button" onclick="btnclick(this.id)" > Edit </a>  </div>'
		}

		function getCheckbox(event) {

			return '<div id="li_checkbox' + countcheck + '" class="form_bal_checkbox1" ondrag="maintainDrag()" style="width:300px" > <i class="fa fa-arrows-alt" style="float:right"></i> <div id="checklb' + countcheck + '"> Label </div> <div id="divCheck' + countcheck + '"> </div> <a href="#" id="addcheck' + countcheck + '" class="button" onclick="btnclick(this.id)" > Add </a> <a href="#" id="removeCheck' + countcheck + '" onclick="removeCheck(this.id)"> Remove selected option </a>  </div>'
		}

		function getHeader(event) {

			return ' <div id="li_header' + countheader + '" class="form_bal_header1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i>  <div id="headerlb' + countheader + '" style="font-family:Arial; font-size:32px; font-weight:bold  "> Header </div> <a href="#" id="btneditheader' + countheader + '" class="button" onclick="btnclick(this.id)"> edit </a> </div>'
		}

		function getParagraph(event) {

			return ' <div id="li_paragraph' + countparagraph + '" class="form_bal_paragraph1" style="word-wrap:break-word;width:500px" ondrag="maintainDrag()" style="max-width:450px;" > <i class="fa fa-arrows-alt" style="float:right"></i> <br /><p id="para_id' + countparagraph + '" > write something here </p> <a href="#" id="btneditpara' + countparagraph + '" class="button" onclick="btnclick(this.id)" > edit </a> </div>'
		}
		function getBigNumber(event) {

			return ' <div id="li_number' + countnumber + '" class="form_bal_number1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i> Quantity <input type="number" id="bigNumQty' + countnumber + '" name="quantity" min="1" max="5"> <a href="#" id="btneditnumber' + countnumber + '" class="button" onclick="btnclick(this.id)"> edit </a>  </div>'
		}

		function getDate(event) {

			return ' <div id="li_date' + countdate + '" class="form_bal_date1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i> Date <input type="date" id="date_id' + countdate + '" >   </div>'
		}

		function getUploadFile(event) {

            
			return ' <div id="li_file' + countfile + '" class="form_bal_file1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i> <input type="file" id="myFile' + countfile + '" multiple size="50" disabled="disabled" onchange=""> </div>'
		}

		function getLabel(event) {

			return ' <div id="li_label' + countlabel + '" class="form_bal_label1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i> <div id="labelID' + countlabel + '" style="font-size:16px; "> Label </div> <a href="#" id="btneditlabel' + countlabel + '" class="button" onclick="btnclick(this.id)"> edit </a>  </div>'
		}

		function getImage(event) {

			return ' <div id="li_image' + countImage + '" class="form_bal_image1" ondrag="maintainDrag()" > <i class="fa fa-arrows-alt" style="float:right"></i> <img src="" onclick="changeImage(this.id)" style="width:150px; height:150px" id="image' + countImage + '" />  </div>'
		}
		//Close edit dialog
		document.querySelector('.close').addEventListener('click',
			function () {
				document.querySelector('.bg-modal').style.display = 'none';

			}
		);

		document.querySelector('.closetxtarea').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-txtarea').style.display = 'none';
			}
		);

		document.querySelector('.close_select').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-select').style.display = 'none';
			}
		);

		document.querySelector('.close_header').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-header').style.display = 'none';
			}
		);

		document.querySelector('.close_para').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-para').style.display = 'none';
			}
		);

		document.querySelector('.close_number').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-number').style.display = 'none';
			}
		);

		document.querySelector('.close_radio').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-radio').style.display = 'none';
			}
		);

		document.querySelector('.close_check').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-check').style.display = 'none';
			}
		);

		document.querySelector('.close_label').addEventListener('click',
			function () {

				document.querySelector('.bg-modal-label').style.display = 'none';
			}
		);

		//                                             document.getElementById("btnedit").addEventListener("click",
		//                          function () {
		//                              console.log("CLICKED EDIT");
		//               document.querySelector(".bg-modal").style.display = "flex";
		//});

	});
		/*1. take count and put inside hidden field (if count 5 hidden filed = 5)
		  2. take the count from the cs and append to hidden field
		  3. get id + count*/
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>

			<%--          <a href="#" id="btnedit" class="button" onclick="btnclick()"> Edit </a>--%>
			<div class="form_builder" style="margin-top: 25px">
				<div class="row">
					<div class="col-sm-2">
						<nav class="nav-sidebar">
							<ul class="nav">
								<li class="form_bal_text" id="li_txtfield">
									<a href="javascript:;">Text Field <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_textarea" id="li_textarea">
									<a href="javascript:;">Text Area <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_ddl" id="li_ddl">
									<a href="javascript:;">DropDownList <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_radio" id="li_rb">
									<a href="javascript:;">Radio Button <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_checkbox" id="li_checkbox">
									<a href="javascript:;">Checkbox <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_header" id="li_header">
									<a href="javascript:;">Header <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_paragraph" id="li_paragraph">
									<a href="javascript:;">Paragraph <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_number" id="li_number">
									<a href="javascript:;">Big Number <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_date" id="li_date">
									<a href="javascript:;">Date <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_file" id="li_file">
									<a href="javascript:;">File Upload <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_label" id="li_label">
									<a href="javascript:;">Label <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
								<li class="form_bal_image" id="li_image">
									<a href="javascript:;">Image <i class="fa fa-plus-circle pull-right"></i></a>
								</li>
							</ul>
						</nav>
					</div>

             


					<div id="container" class="ui-widget-content">

						<div id="form_com">

							<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

							<%--<div style="font-family:Arial; font-size:32px; font-weight:bold  "> xxx </div>--%>
							<%--<input type="file" id="myFile" multiple size="50" onchange="">--%>
							<%--Date <input type="date" id="date_id">--%>
						</div>

					</div>

					<div id="deletefield" class="delete">
						Drag here to delete
					</div>

                    <div id="cancelPage" class="back">
                        <input id="btnBack" type="button" value="Cancel" onclick="cancelPage()" />
                    </div>

					<asp:FileUpload ID="imgupload" runat="server" Style="display: none" onchange="showImage.call(this)" />
					<%--<input type="file" id="imgupload" style="display: none" onchange="showImage.call(this)" />--%>

					<div>
						<asp:HiddenField ID="hfText" runat="server" />
						<asp:HiddenField ID="hfTextLeft" runat="server" />
						<asp:HiddenField ID="hfTextTop" runat="server" />
						<asp:HiddenField ID="hfTextLabel" runat="server" />

						<asp:HiddenField ID="hfDrop" runat="server" />
						<asp:HiddenField ID="hfDropLeft" runat="server" />
						<asp:HiddenField ID="hfDropTop" runat="server" />
						<asp:HiddenField ID="hfDropCount" runat="server" />
						<asp:HiddenField ID="hfDropLabel" runat="server" />
						<asp:HiddenField ID="hfDropOption" runat="server" />
						<asp:HiddenField ID="hfDropValue" runat="server" />

						<asp:HiddenField ID="hfRadio" runat="server" />
						<asp:HiddenField ID="hfRadioLeft" runat="server" />
						<asp:HiddenField ID="hfRadioTop" runat="server" />
						<asp:HiddenField ID="hfRadioLabel" runat="server" />
						<asp:HiddenField ID="hfRadioOption" runat="server" />
						<asp:HiddenField ID="hfRadioValue" runat="server" />
						<asp:HiddenField ID="hfRadioCount" runat="server" />

						<asp:HiddenField ID="hfTextarea" runat="server" />
						<asp:HiddenField ID="hfTextareaLeft" runat="server" />
						<asp:HiddenField ID="hfTextareaTop" runat="server" />
						<asp:HiddenField ID="hfTextareaLabel" runat="server" />

						<asp:HiddenField ID="hfCheck" runat="server" />
						<asp:HiddenField ID="hfCheckLeft" runat="server" />
						<asp:HiddenField ID="hfCheckTop" runat="server" />
						<asp:HiddenField ID="hfCheckLabel" runat="server" />
						<asp:HiddenField ID="hfCheckOption" runat="server" />
						<asp:HiddenField ID="hfCheckValue" runat="server" />
						<asp:HiddenField ID="hfCheckCount" runat="server" />

						<asp:HiddenField ID="hfHeader" runat="server" />
						<asp:HiddenField ID="hfHeaderLeft" runat="server" />
						<asp:HiddenField ID="hfHeaderTop" runat="server" />
						<asp:HiddenField ID="hfHeaderLabel" runat="server" />
						<asp:HiddenField ID="hfHeaderFontFami" runat="server" />
						<asp:HiddenField ID="hfHeaderFontSize" runat="server" />

						<asp:HiddenField ID="hfParagraph" runat="server" />
						<asp:HiddenField ID="hfParagraphLeft" runat="server" />
						<asp:HiddenField ID="hfParagraphTop" runat="server" />
						<asp:HiddenField ID="hfParagraphLabel" runat="server" />
						<asp:HiddenField ID="hfParagraphFontType" runat="server" />
						<asp:HiddenField ID="hfParagraphFontColor" runat="server" />

						<asp:HiddenField ID="hfNumber" runat="server" />
						<asp:HiddenField ID="hfNumberLeft" runat="server" />
						<asp:HiddenField ID="hfNumberTop" runat="server" />
						<asp:HiddenField ID="hfNumberLabel" runat="server" />
						<asp:HiddenField ID="hfNumberMin" runat="server" />
						<asp:HiddenField ID="hfNumberMax" runat="server" />

						<asp:HiddenField ID="hfDate" runat="server" />
						<asp:HiddenField ID="hfDateLeft" runat="server" />
						<asp:HiddenField ID="hfDateTop" runat="server" />
						<asp:HiddenField ID="hfDateLabel" runat="server" />

						<asp:HiddenField ID="hfFile" runat="server" />
						<asp:HiddenField ID="hfFileLeft" runat="server" />
						<asp:HiddenField ID="hfFileTop" runat="server" />

						<asp:HiddenField ID="hfLabel" runat="server" />
						<asp:HiddenField ID="hfLabelLeft" runat="server" />
						<asp:HiddenField ID="hfLabelTop" runat="server" />
						<asp:HiddenField ID="hfLabelText" runat="server" />
						<asp:HiddenField ID="hfLabelFontSize" runat="server" />

						<asp:HiddenField ID="hfImage" runat="server" />
						<asp:HiddenField ID="hfImageLeft" runat="server" />
						<asp:HiddenField ID="hfImageTop" runat="server" />
						<%--<div id="phHidden"></div>--%>
						<%--<asp:PlaceHolder ID="phHidden" runat="server"></asp:PlaceHolder>--%>
					</div>


					<%--                    <div class="col-md-5 bal_builder">
                        <div class="form_builder_area"></div>
                    </div>--%>
					<%--                    <div class="col-md-5">
                        <div class="col-md-12">
                            <form class="form-horizontal">
                                <div class="preview"></div>
                                <div style="display: none" class="form-group plain_html"><textarea rows="50" class="form-control"></textarea></div>
                            </form>
                        </div>
                    </div>--%>
				</div>
			</div>


			<div class="divInsert">
				<asp:Button ID="btnInsert" runat="server" Text="Save" OnClick="btnInsert_Click" CssClass="buttonInsert" />
			</div>

			<div class="bg-modal">
				<div class="modal-content">
					<div class="close">+</div>

					Label 
					<input type="text" id="changeLabel" />
					<input type="button" value="save" onclick="changelabeltxt()" />
					<%--<a href="#" id="elemdelete" class="delete" onclick="btndelete()"> remove </a>--%>
				</div>
			</div>

			<div class="bg-modal-txtarea">

				<div class="modal-content">
					<div class="closetxtarea">+</div>

					Label 
					<input type="text" id="changeLabeltxtarea" />
					<input type="button" value="save" onclick="changelabeltxtarea()" />

				</div>
			</div>

			<div class="bg-modal-select">
				<div class="modal-content">

					<div class="close_select">+</div>

					Label
					<input type="text" id="changeLabelDDL" />
					<input type="button" value="Change Label Name" onclick="changeDDLText()" />

                    <br />
                    ------------------------------------------------------------------------------------------
                    <br />
					<div id="select-option">
						Text 
						<input type="text" id="getSelectText" />
						<%--Value
						<input type="text" id="getSelectValue" />--%>

					</div>

					<input type="button" value="Add" onclick="addSelectValue()" />
				</div>
			</div>

			<div class="bg-modal-header">

				<div class="modal-content">
					<div class="close_header">+</div>

					Label 
					<input type="text" id="changeLabelHeader" />
                    <br />
                    Font Family
					<select id="SelectFontFamily" style="width: 180px; height: 23px">

						<option value="Algerian" style="font-family: Algerian;">Algerian</option>
						<option value="Garamond" style="font-family: Garamond;">Garamond</option>
						<option value="Latha" style="font-family: Latha;">Latha</option>
						<option value="Constantia" style="font-family: Constantia;">Constantia</option>
						<option value="Arial" style="font-family: Arial;">Arial</option>
					</select>
					<br />
                    Font Size
					<select id="SelectFontSize" style="width: 180px; height: 23px">

						<option value="12">12</option>
						<option value="14">14</option>
						<option value="16">16</option>
						<option value="18">18</option>
						<option value="20">20</option>
						<option value="24">24</option>
						<option value="28">28</option>
						<option value="32">32</option>
						<option value="36">36</option>
						<option value="42">42</option>
						<option value="48">48</option>
						<option value="56">56</option>
						<option value="70">70</option>
						<option value="78">78</option>
						<option value="88">88</option>
					</select>
                    <br />

					<input type="button" value="save" onclick="changeHeader()" />

				</div>
			</div>

			<div class="bg-modal-radio">

				<div class="modal-content">
					<div class="close_radio">+</div>

					Label
					<input type="text" id="changeLabelRadio" />
					<input type="button" value="Change Label Name" onclick="changeRadioText()" />
					<br />
                    ------------------------------------------------------------------------------------------
                    <br />

					Radio Text 
					<input type="text" id="addRadioText" />
					<br />
					<%--Radio Value 
					<input type="text" id="addRadioValue" />--%>
					<br />
					<input type="button" value="Add Radio" onclick="addRadio()" />

				</div>
			</div>

			<div class="bg-modal-para">

				<div class="modal-content">
					<div class="close_para">+</div>

					<textarea id="changeParaText" rows="5" cols="50">  </textarea>
					<br />
					<select id="Para_font_color" style="width: 180px; height: 23px">

						<option value="black">black</option>
						<option value="red">red</option>
						<option value="blue">blue</option>
						<option value="yellow">yellow</option>
						<option value="white">white</option>
						<option value="green">green</option>

					</select>

					<br />
					<input type="radio" name="parafontstyle" value="Bold">
					Bold<br>
					<input type="radio" name="parafontstyle" value="Normal">
					Normal<br>
					<input type="radio" name="parafontstyle" value="italic">
					italic
					
                    <br />
					<input type="button" value="save" onclick="changePara()" />

				</div>
			</div>


			<div class="bg-modal-number">

				<div class="modal-content">
					<div class="close_number">+</div>

					Min quantity 
					<input type="number" id="changeMinNumber" value="1" />
					<br />
					Max quantity 
					<input type="number" id="changeMaxNumber" value="5" />

					<input type="button" value="save" onclick="changeBigNumber()" />

				</div>
			</div>

			<div class="bg-modal-check">

				<div class="modal-content">
					<div class="close_check">+</div>

					Label
					<input type="text" id="changeLabelCheck" />
					<input type="button" value="Change Label Name" onclick="changeCheckText()" />
					<br />
                    <br />
                    ------------------------------------------------------------------------------------------
                    <br />

					Check Text 
					<input type="text" id="addCheckText" />
					<br />
					<%--Check Value 
					<input type="text" id="addCheckValue" />--%>
					<br />
					<input type="button" value="Add Check" onclick="addCheck()" />

				</div>
			</div>

			<div class="bg-modal-label">

				<div class="modal-content">
					<div class="close_label">+</div>

					Label 
					<input type="text" id="changeLabelValue" />

					<br />
                    Font Size
					<select id="SelectFontSizeLabel" style="width: 180px; height: 23px">

						<option value="12">12</option>
						<option value="14">14</option>
						<option value="16">16</option>
						<option value="18">18</option>
						<option value="20">20</option>
						<option value="24">24</option>
						<option value="28">28</option>
						<option value="32">32</option>
						<option value="36">36</option>
						<option value="42">42</option>
						<option value="48">48</option>
						<option value="56">56</option>
						<option value="70">70</option>
						<option value="78">78</option>
						<option value="88">88</option>
					</select>

					<input type="button" value="save" onclick="changeLabelFunction()" />

				</div>
			</div>

		</div>

	</form>
</body>
</html>
