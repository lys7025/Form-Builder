using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Form
{
	public partial class Edit : System.Web.UI.Page
	{
		int id = 0;
		int eleId = 0;
		int countNumber = 0;
		int countDdl = 0;
		int countRb = 0;
		int countCheck = 0;
		int countChildCheck = 1;
		int countChildRadio = 1;
        int width = 0;
        int height = 0;
		string title = "";
		int version = 0;
		List<Element_Type> eletypeList = new List<Element_Type>();
		List<Form_Ele> formEleList = new List<Form_Ele>();
		List<EleListValue> eleListValueList = new List<EleListValue>();
		StringBuilder html = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			//get the particular id when user click edit
			id = Convert.ToInt32(Request.QueryString["id"]);
			if (!IsPostBack)
			{
				//int id = 40;
				RetrieveFormElement(id);// Retrieve form element
				for (int i = 0; i < formEleList.Count; i++)
				{
					RetrieveEleType(formEleList[i].eleTypeId);

					if (eletypeList != null)
					{
						if (eletypeList[i].name == "dropdown")
						{
							RetrieveEleListValue(formEleList[i].eleId);
							displayEleListItem(i);
						}
						else if (eletypeList[i].name == "number")
						{
							RetrieveEleListValue(formEleList[i].eleId);
							displayEleListItem(i);
						}
						else if (eletypeList[i].name == "check")
						{
							RetrieveEleListValue(formEleList[i].eleId);
							displayEleListItem(i);
						}
						else if (eletypeList[i].name == "radio")
						{
							RetrieveEleListValue(formEleList[i].eleId);
							displayEleListItem(i);
						}
					}
				}
				displayEleItem();
			}
			
		}

		public void displayEleItem()
		{
			int countTxt = 0;
			int countTxtArea = 0;
			int countHeader = 0;
			int countPara = 0;
			int countDate = 0;
			int countFile = 0;
			int countLabel = 0;
			int countImage = 0;
			List<string> arrTxtLabel = new List<string>();
			List<string> arrTextareaLabel = new List<string>();
			List<string> arrDateLabel = new List<string>();
			List<string> arrHeaderLabel = new List<string>();
			List<int> arrHeaderFontSize = new List<int>();
			List<string> arrHeaderFontFami = new List<string>();
			List<string> arrParaLabel = new List<string>();
			List<string> arrParaFontType = new List<string>();
			List<string> arrParaFontColor = new List<string>();
			List<string> arrLabelText = new List<string>();
			List<int> arrLabelFontSize = new List<int>();

			for (int i = 0; i < formEleList.Count; i++)
			{
				if (eletypeList[i].name == "textarea")
				{
					countTxtArea++;
					int temp = countTxtArea - 1;
					html.Append("<div id ='li_textarea"+ countTxtArea + "' class='form_bal_textarea1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><i class='fa fa-arrows-alt' style='float:right;'></i><div id='txtarealb" + temp + "' >" + eletypeList[i].label + "</div><textarea rows='5' id='txtareaDrag" + countTxtArea + "' placeholder=''></textarea><a href='#' id='btntxtarea" + temp + "' class='button' onclick='btnclick(this.id)' > Edit</a></div>");
					arrTextareaLabel.Add(eletypeList[i].label);
				}
				else if (eletypeList[i].name == "textfield")
				{
					countTxt++;
					int temp = countTxt - 1;
					html.Append("<div id ='li_txtfield" + countTxt + "' class='form_bal_text1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><i class='fa fa-arrows-alt' style='float:right;'></i><div id='txtlb" + temp + "' >" + eletypeList[i].label + "</div><input type='text' size='45' class='item' id='txtDrag" + countTxt + "' /><a href='#' id='btnedit" + temp + "' class='button' onclick='btnclick(this.id)' > Edit</a></div>");
					arrTxtLabel.Add(eletypeList[i].label);
				}
				else if (eletypeList[i].name == "header")
				{
					countHeader++;
					int temp = countHeader - 1;
					html.Append("<div id ='li_header" + countHeader + "' class='form_bal_header1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><i class='fa fa-arrows-alt' style='float:right;'></i> <div id='headerlb" + temp + "' style='font-family:" + eletypeList[i].fontType + "; font-size:" + eletypeList[i].fontSize + "px; font-weight:bold'>" + eletypeList[i].label + "</div><a href='#' id='btneditheader" + temp + "' class='button' onclick='btnclick(this.id)' > Edit</a></div>");
					arrHeaderLabel.Add(eletypeList[i].label);
					arrHeaderFontFami.Add(eletypeList[i].fontType);
					arrHeaderFontSize.Add(eletypeList[i].fontSize);
				}
				else if (eletypeList[i].name == "paragraph")
				{
					countPara++;
					int temp = countPara - 1;
					html.Append("<div id ='li_paragraph" + countPara + "' class='form_bal_paragraph1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; max-width:450px;' ><i class='fa fa-arrows-alt' style='float:right;'></i><div id='para_id" + temp + "'  style='font-weight:" + eletypeList[i].fontProperty + "; color:" + eletypeList[i].fontColor + "'>" + eletypeList[i].label + "</div><a href='#' id='btneditpara" + temp + "' class='button' onclick='btnclick(this.id)' > Edit</a></div>");
					arrParaLabel.Add(eletypeList[i].label);
					arrParaFontType.Add(eletypeList[i].fontProperty);
					arrParaFontColor.Add(eletypeList[i].fontColor);
				}
				else if (eletypeList[i].name == "date")
				{
					countDate++;
					int temp = countDate - 1;
					html.Append("<div id ='li_date" + countDate + "' class='form_bal_date1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><i class='fa fa-arrows-alt' style='float:right;'></i>Date<input id='date_id" + temp + "' type='date' value='" + eletypeList[i].label + "'/></div>");
					arrDateLabel.Add(eletypeList[i].label);
				}
				else if (eletypeList[i].name == "file")
				{
					countFile++;
					int temp = countFile - 1;
					html.Append("<input class='item' id='file" + countFile + "' type='file' style='left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;'/>");
					//add
				}
				else if (eletypeList[i].name == "label")
				{
					countLabel++;
					int temp = countLabel - 1;
					html.Append("<div id ='li_label" + countLabel + "' class='form_bal_label1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><i class='fa fa-arrows-alt' style='float:right;'></i> <div id='labelID" + temp + "' style='font-size:" + eletypeList[i].fontSize + "px;'>" + eletypeList[i].label + "</div><a href='#' id='btneditlabel" + temp + "' class='button' onclick='btnclick(this.id)' > Edit</a></div>");
					arrLabelText.Add(eletypeList[i].label);
					arrLabelFontSize.Add(eletypeList[i].fontSize);
				}
				else if (eletypeList[i].name == "image")
				{
                    RetrieveImage(eletypeList[i].eleTypeId);
					countImage++;
					int temp = countImage - 1;
                    //<a href='#' id='btneditImage" + countImage + "' class='button' onclick='btnclick(this.id)'> resize </a>
					html.Append("<div id ='li_image" + countImage + "' class='form_bal_image1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><i class='fa fa-arrows-alt' style='float:right;'></i> <img src ='ShowImage.ashx?id=" + formEleList[i].eleTypeId + "' onclick='changeImage(this.id)' style='width:"+ width +"px; height:"+ height +"px;' id='image" + temp + "'/><a href='#' id='btneditImage" + temp + "' class='button' onclick='btnclick(this.id)'> resize </a></div>");
				}
			}
			//hfTextLabel.Value = string.Join(",", arrTxtLabel);
			//hfTextareaLabel.Value = string.Join(",", arrTextareaLabel);
			//hfHeaderLabel.Value = string.Join(",", arrHeaderLabel);
			//hfHeaderFontFami.Value = string.Join(",", arrHeaderFontFami);
			//hfHeaderFontSize.Value = string.Join(",", arrHeaderFontSize);
			//hfParagraphLabel.Value = string.Join(",", arrParaLabel);
			//hfParagraphFontType.Value = string.Join(",", arrParaFontType);
			//hfParagraphFontColor.Value = string.Join(",", arrParaFontColor);
			//hfDateLabel.Value = string.Join(",", arrDateLabel);
			//hfLabelText.Value = string.Join(",", arrLabelText);
			//hfLabelFontSize.Value = string.Join(",", arrLabelFontSize);
			hfText.Value = countTxt.ToString();
			hfTextarea.Value = countTxtArea.ToString();
			hfHeader.Value = countHeader.ToString();
			hfParagraph.Value = countPara.ToString();
			hfDate.Value = countDate.ToString();
			hfFile.Value = countFile.ToString();
			hfLabel.Value = countLabel.ToString();
			hfImage.Value = countImage.ToString();
			// Placeholder at here to avoid redundant item display on page
			PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
		}

		public void displayEleListItem(int i)
		{
			List<string> arrDdlOption = new List<string>();
			List<string> arrDdlValue = new List<string>();
			List<string> arrDdlLabel = new List<string>();
			List<string> arrRadioLabel = new List<string>();
			List<string> arrRadioOption = new List<string>();
			List<string> arrRadioValue = new List<string>();
			List<string> arrCheckLabel = new List<string>();
			List<string> arrCheckOption = new List<string>();
			List<string> arrCheckValue = new List<string>();
			List<string> arrNumberMin = new List<string>();
			List<string> arrNumberMax = new List<string>();
			
			if (eletypeList[i].name == "dropdown")
			{
				countDdl++;
				int temp = countDdl - 1;
				html.Append("<div id ='li_ddl" + countDdl + "' class='form_bal_ddl1' ondrag='maintainDrag()' style='width: 300px; position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><i class='fa fa-arrows-alt' style='float:right;'></i><div id='ddllb" + temp + "'>" + eletypeList[i].label + "</div><select id='mySelect" + temp + "'>");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<option value='" + eleListValueList[l].value + "'>" + eleListValueList[l].name + "</option>");
					arrDdlOption.Add(eleListValueList[l].name);
					arrDdlValue.Add(eleListValueList[l].value);
				}
				html.Append("</select><a href='#' id='btneditDDL" + temp + "' class='button' onclick='btnclick(this.id)'> Add </a> <a href='#' id='removeDDL" + temp + "' onclick='removeSelect(this.id)'> Remove selected option </a></div>");

				arrDdlLabel.Add(eletypeList[i].label);
			}
			else if (eletypeList[i].name == "number")
			{
				countNumber++;
				int temp = countNumber - 1;
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					if (l == 0)
					{
						html.Append("<div id ='li_number" + countNumber + "' class='form_bal_number1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><i class='fa fa-arrows-alt' style='float:right;'></i>" + eletypeList[i].label + "<input class='item' id='bigNumQty" + temp + "' type='number' style='left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' min='" + eleListValueList[l].value + "'");
						arrNumberMin.Add(eleListValueList[l].value);
					}
					else
					{
						html.Append("max='" + eleListValueList[l].value + "'/><a href='#' id='btneditnumber" + temp + "' class='button' onclick='btnclick(this.id)' > Edit</a></div>");
						arrNumberMax.Add(eleListValueList[l].value);
					}
				}
			}
			else if (eletypeList[i].name == "radio")
			{
				countRb++;
				int temp = countRb - 1;
				html.Append("<div id ='li_rb" + countRb + "' class='form_bal_radio1' ondrag='maintainDrag()' style='width: 300px; position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><i class='fa fa-arrows-alt' style='float:right;'></i><div id='rblb" + temp + "' >" + eletypeList[i].label + " </div><div id='divRadio" + temp + "'> ");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<div id ='childRB" + countChildRadio + "' name='radioChildName" + temp + "'><input type = 'radio' id ='rbID" + countChildRadio + "' name ='radioName" + temp + "' value = '" + eleListValueList[l].value + "' />" + eleListValueList[l].name + "</div>");
					arrRadioOption.Add(eleListValueList[l].name);
					arrRadioValue.Add(eleListValueList[l].value);
					countChildRadio++;
				}
				html.Append("</div><a href = '#' id='addrb" + temp + "' class='button' onclick='btnclick(this.id)'>Add</a><a href = '#' id='removeRB" + temp + "' onclick='removeRB(this.id)'> Remove selected option</a></div>");

				arrRadioLabel.Add(eletypeList[i].label);
			}
			else if (eletypeList[i].name == "check")
			{
				countCheck++;
				int temp = countCheck - 1;
				html.Append("<div id ='li_checkbox" + countCheck + "' class='form_bal_checkbox1' ondrag='maintainDrag()' style='width: 300px; position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><i class='fa fa-arrows-alt' style='float:right;'></i><div id = 'checklb" + temp + "' >" + eletypeList[i].label + " </div><div id='divCheck" + temp + "'>");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<div id = 'childCheck" + countChildCheck + "' name='checkChildName" + temp + "' ><input type = 'checkbox' id = 'checkID" + countChildCheck + "' name = 'CheckBoxName" + temp + "' value = '" + eleListValueList[l].value + "' />" + eleListValueList[l].name + "</div>");
					arrCheckOption.Add(eleListValueList[l].name);
					arrCheckValue.Add(eleListValueList[l].value);
					countChildCheck++;
				}
				html.Append("</div><a href = '#' id='addcheck" + temp + "' class='button' onclick='btnclick(this.id)'>Add</a><a href = '#' id='removeCheck" + temp + "' onclick='removeCheck(this.id)'> Remove selected option</a>  </div>");
				
				arrCheckLabel.Add(eletypeList[i].label);
			}
			//Response.Write("<script>alert('" + arrDdlOption[1] + "')</script>");
			//hfDropLabel.Value += string.Join(",", arrDdlLabel);
			//hfDropOption.Value += string.Join(",", arrDdlOption);
			//hfDropValue.Value += string.Join(",", arrDdlValue);
			//hfCheckLabel.Value += string.Join(",", arrCheckLabel);
			//hfCheckOption.Value += string.Join(",", arrCheckOption);
			//hfCheckValue.Value += string.Join(",", arrCheckValue);
			//hfRadioLabel.Value += string.Join(",", arrRadioLabel);
			//hfRadioOption.Value += string.Join(",", arrRadioOption);
			//hfRadioValue.Value += string.Join(",", arrRadioValue);
			//hfNumberMin.Value += string.Join(",", arrNumberMin);
			//hfNumberMax.Value += string.Join(",", arrNumberMax);
			hfDrop.Value = countDdl.ToString();
			hfNumber.Value = countNumber.ToString();
			hfRadio.Value = countRb.ToString();
			hfCheck.Value = countCheck.ToString();
			hfCheckChild.Value = countChildCheck.ToString();
			hfRadioChild.Value = countChildRadio.ToString();
			eleListValueList.Clear();
		}

		public void RetrieveFormElement(int formId)
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string retrieveFormElement = "SELECT * FROM Form_element WHERE formId = @formId";

			SqlCommand cmdRetrieveFormElement = new SqlCommand(retrieveFormElement, sqlConn);
			cmdRetrieveFormElement.Parameters.AddWithValue("@formId", formId);
			SqlDataReader sdr = cmdRetrieveFormElement.ExecuteReader();
			while (sdr.Read())
			{
				Form_Ele formEle = new Form_Ele();
				formEle.eleId = int.Parse(sdr["eleId"].ToString());
				formEle.formId = int.Parse(sdr["formId"].ToString());
				formEle.eleTypeId = int.Parse(sdr["eleTypeId"].ToString());
				formEle.xPosition = sdr["xPosition"].ToString();
				formEle.yPosition = sdr["yPosition"].ToString();
				formEleList.Add(formEle);
			}
			sqlConn.Close();

		}

		public void RetrieveEleType(int eleTypeId)//get element type by eleTypeId
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string retrieveEleType = "SELECT * FROM Element_type WHERE eleTypeId = @eleTypeId";

			SqlCommand cmdRetrieveEleType = new SqlCommand(retrieveEleType, sqlConn);
			cmdRetrieveEleType.Parameters.AddWithValue("@eleTypeId", eleTypeId);
			SqlDataReader sdr = cmdRetrieveEleType.ExecuteReader();
			while (sdr.Read())
			{
				Element_Type eleType = new Element_Type();
				eleType.eleTypeId = int.Parse(sdr["eleTypeId"].ToString());
				eleType.name = sdr["name"].ToString();
				eleType.fontSize = sdr["fontSize"].ToString() == null ? 0 : int.Parse(sdr["fontSize"].ToString());
				eleType.fontColor = sdr["fontColor"].ToString();
				eleType.fontProperty = sdr["fontProperty"].ToString();
				eleType.fontType = sdr["fontType"].ToString();
				eleType.label = sdr["label"].ToString();
				eletypeList.Add(eleType);
			}
			sqlConn.Close();
		}

		public void RetrieveEleListValue(int eleId)
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string retrieveEleListValue = "SELECT * FROM Element_list_values WHERE eleId = @eleId";

			SqlCommand cmdRetrieveEleListValue = new SqlCommand(retrieveEleListValue, sqlConn);
			cmdRetrieveEleListValue.Parameters.AddWithValue("@eleId", eleId);
			SqlDataReader sdr = cmdRetrieveEleListValue.ExecuteReader();
			while (sdr.Read())
			{
				EleListValue eleListValue = new EleListValue();
				eleListValue.eleListId = int.Parse(sdr["eleListId"].ToString());
				eleListValue.eleId = int.Parse(sdr["eleId"].ToString());
				eleListValue.name = sdr["name"].ToString();
				eleListValue.value = sdr["value"].ToString();
				eleListValueList.Add(eleListValue);
			}
			sqlConn.Close();
		}
        
        private void RetrieveImage(int eleTypeId)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(conn);
            string retrieveImage = "SELECT * FROM Image WHERE eleTypeId = @eleTypeId";
            SqlCommand cmdRetrieveImage = new SqlCommand(retrieveImage, sqlConn);
            cmdRetrieveImage.Parameters.AddWithValue("@eleTypeId", eleTypeId);
            sqlConn.Open();
            SqlDataReader sdr = cmdRetrieveImage.ExecuteReader();
            while (sdr.Read())
            {
                width = int.Parse(sdr["width"].ToString());
                height = int.Parse(sdr["height"].ToString());
            }
            sqlConn.Close();
        }

		private void RetrieveForm()
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string retrieveForm = "SELECT * FROM Form WHERE formId = @formId";

			SqlCommand cmdRetrieveForm = new SqlCommand(retrieveForm, sqlConn);
			cmdRetrieveForm.Parameters.AddWithValue("@formId", id);
			SqlDataReader sdr = cmdRetrieveForm.ExecuteReader();
			while (sdr.Read())
			{
				title = sdr["title"].ToString();
				version = int.Parse(sdr["version"].ToString());
			}
			sqlConn.Close();
		}

		public class Form_Ele
		{
			public int eleId { get; set; }
			public int formId { get; set; }
			public int eleTypeId { get; set; }
			public string xPosition { get; set; }
			public string yPosition { get; set; }
		}

		public class Element_Type
		{
			public int eleTypeId { get; set; }
			public string name { get; set; }
			public int fontSize { get; set; }
			public string fontColor { get; set; }
			public string fontProperty { get; set; }
			public string fontType { get; set; }
			public string label { get; set; }
		}
		public class EleListValue
		{
			public int eleListId { get; set; }
			public int eleId { get; set; }
			public string name { get; set; }
			public string value { get; set; }
		}

		public class Image
		{
			public int imageId { get; set; }
			public int eleTypeId { get; set; }
			public string name { get; set; }
			public string path { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}


		protected void btnInsert_Click(object sender, EventArgs e)
		{
			RetrieveForm();
			int staffId = int.Parse(Session["staffId"].ToString());
			string status = "active";
			version += 1;

			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string insertForm = "INSERT INTO Form Values (@title, @staffId, @date, @version, @status)SELECT SCOPE_IDENTITY()";

			SqlCommand cmdInsertForm = new SqlCommand(insertForm, sqlConn);
			cmdInsertForm.Parameters.AddWithValue("@title", title);
			cmdInsertForm.Parameters.AddWithValue("@staffId", staffId);
			cmdInsertForm.Parameters.AddWithValue("@date", DateTime.Today);
			cmdInsertForm.Parameters.AddWithValue("@version", version);
			cmdInsertForm.Parameters.AddWithValue("@status", status);

			Session["FormId"] = Convert.ToInt32(cmdInsertForm.ExecuteScalar());
			sqlConn.Close();

			int totalTxtNo = hfText.Value == "" ? 0 : Convert.ToInt32(hfText.Value);
			int totalDdlNo = hfDrop.Value == "" ? 0 : int.Parse(hfDrop.Value);
			int totalRbNo = hfRadio.Value == "" ? 0 : Convert.ToInt32(hfRadio.Value);
			int totalTxtAreaNo = hfTextarea.Value == "" ? 0 : Convert.ToInt32(hfTextarea.Value);
			int totalCheckNo = hfCheck.Value == "" ? 0 : Convert.ToInt32(hfCheck.Value);
			int totalHeaderNo = hfHeader.Value == "" ? 0 : Convert.ToInt32(hfHeader.Value);
			int totalParagraphNo = hfParagraph.Value == "" ? 0 : Convert.ToInt32(hfParagraph.Value);
			int totalNumberNo = hfNumber.Value == "" ? 0 : Convert.ToInt32(hfNumber.Value);
			int totalDateNo = hfDate.Value == "" ? 0 : Convert.ToInt32(hfDate.Value);
			int totalFileNo = hfFile.Value == "" ? 0 : Convert.ToInt32(hfFile.Value);
			int totalLabelNo = hfLabel.Value == "" ? 0 : Convert.ToInt32(hfLabel.Value);
			int totalImageNo = hfImage.Value == "" ? 0 : Convert.ToInt32(hfImage.Value);
			//pass how many item has been created
			GetElementType(totalTxtNo, totalDdlNo, totalRbNo, totalTxtAreaNo, totalCheckNo, totalHeaderNo, totalParagraphNo, totalNumberNo, totalDateNo, totalFileNo, totalLabelNo, totalImageNo);
			Response.Write("<script>alert('New Version Created')</script>");
			Response.Redirect("FormPage.aspx");
		}

		public void GetElementType(int totalTxtNo, int totalDdlNo, int totalRbNo, int totalTxtAreaNo, int totalCheckNo, int totalHeaderNo, int totalParagraphNo, int totalNumberNo, int totalDateNo, int totalFileNo, int totalLabelNo, int totalImageNo)
		{

			if (totalTxtNo > 0)
			{
				CollectElementType("textfield", totalTxtNo);
			}
			if (totalDdlNo > 0)
			{
				CollectElementType("dropdown", totalDdlNo);
			}
			if (totalRbNo > 0)
			{
				CollectElementType("radio", totalRbNo);
			}
			if (totalTxtAreaNo > 0)
			{
				CollectElementType("textarea", totalTxtAreaNo);
			}
			if (totalCheckNo > 0)
			{
				CollectElementType("check", totalCheckNo);
			}
			if (totalHeaderNo > 0)
			{
				CollectElementType("header", totalHeaderNo);
			}
			if (totalParagraphNo > 0)
			{
				CollectElementType("paragraph", totalParagraphNo);
			}
			if (totalNumberNo > 0)
			{
				CollectElementType("number", totalNumberNo);
			}
			if (totalDateNo > 0)
			{
				CollectElementType("date", totalDateNo);
			}
			if (totalFileNo > 0)
			{
				CollectElementType("file", totalFileNo);
			}
			if (totalLabelNo > 0)
			{
				CollectElementType("label", totalLabelNo);
			}
			if (totalImageNo > 0)
			{
				CollectElementType("image", totalImageNo);
			}

		}

		public void CollectElementType(string name, int totalNo)//insert element type
		{
			int fontSize = 12;
			string fontColor = "black";
			string fontProperty = "normal";
			string fontType = "arial";
			string label = "null";
			int eleTypeId = 0;
			int numOfLoop = 0;

			for (int i = 1; i <= totalNo; i++)
			{
				if (name == "textfield")
				{
					string[] arrTxtLabel = hfTextLabel.Value.Split(',');
					label = arrTxtLabel[i - 1].ToString();

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "textarea")
				{
					string[] arrTextareaLabel = hfTextareaLabel.Value.Split(',');
					label = arrTextareaLabel[i - 1].ToString();

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "date")
				{
					string[] arrDateLabel = hfDateLabel.Value.Split(',');
					label = arrDateLabel[i - 1].ToString();

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "header")
				{
					string[] arrHeaderLabel = hfHeaderLabel.Value.Split(',');
					string[] arrHeaderFontFami = hfHeaderFontFami.Value.Split(',');
					string[] arrHeaderFontSize = hfHeaderFontSize.Value.Split(',');
					label = arrHeaderLabel[i - 1].ToString();
					fontType = arrHeaderFontFami[i - 1].ToString();
					fontSize = Convert.ToInt32(arrHeaderFontSize[i - 1].ToString());

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "paragraph")
				{
					string[] arrParaLabel = hfParagraphLabel.Value.Split(',');
					string[] arrParaFontColor = hfParagraphFontColor.Value.Split(',');
					string[] arrParaFontType = hfParagraphFontType.Value.Split(',');
					label = arrParaLabel[i - 1].ToString();
					fontProperty = arrParaFontType[i - 1].ToString();
					fontColor = arrParaFontColor[i - 1].ToString();

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "number")
				{
                    string[] arrNumberLabel = hfNumberLabel.Value.Split(',');
                    label = arrNumberLabel[i - 1].ToString();

                    eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "dropdown")
				{
					string[] arrDropLabel = hfDropLabel.Value.Split(',');
					label = arrDropLabel[i - 1].ToString();

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "radio")
				{
					string[] arrRadioLabel = hfRadioLabel.Value.Split(',');
					label = arrRadioLabel[i - 1].ToString();

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "check")
				{
					string[] arrCheckLabel = hfCheckLabel.Value.Split(',');
					label = arrCheckLabel[i - 1].ToString();

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "label")
				{
					string[] arrLabelText = hfLabelText.Value.Split(',');
					string[] arrLabelFontSize = hfLabelFontSize.Value.Split(',', 'p', 'x');
					label = arrLabelText[i - 1].ToString();
					fontSize = Convert.ToInt32(arrLabelFontSize[i - 1].ToString());

					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}
				else if (name == "image")
				{
					fontSize = 0;
					fontColor = "null";
					fontProperty = "null";
					fontType = "null";
					label = "null";
					eleTypeId = InsertElementtype(name, fontSize, fontColor, fontProperty, fontType, label);
				}

				int xPosition = 0;
				int yPosition = 0;

				if (name == "textfield")
				{
					string[] arrTxtLeft = hfTextLeft.Value.Split(',');
					string[] arrTxtTop = hfTextTop.Value.Split(',');
					xPosition = int.Parse(arrTxtLeft[i - 1].ToString());
					yPosition = int.Parse(arrTxtTop[i - 1].ToString());
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
				}
				else if (name == "dropdown")
				{
					string value = "";
					string ddlName = "";
					string[] arrDropLeft = hfDropLeft.Value.Split(',');
					string[] arrDropTop = hfDropTop.Value.Split(',');
					decimal tempDdlY = decimal.Parse(arrDropTop[i - 1].ToString());
					xPosition = int.Parse(arrDropLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempDdlY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);

					string[] arrDdlOption = hfDropOption.Value.Split(',');
					//string[] arrDdlValue = hfDropValue.Value.Split(',');
					string[] arrDdlCount = hfDropCount.Value.Split(',');
					for (int j = 0; j < int.Parse(arrDdlCount[i - 1].ToString()); j++)
					{
						ddlName = arrDdlOption[numOfLoop].ToString();
						value = ddlName;
						//insert into form ele list
						InsertEleListValue(ddlName, value);
						numOfLoop++;
					}
				}
				else if (name == "radio")
				{
					string value = "";
					string rdName = "";
					string[] arrRadioLeft = hfRadioLeft.Value.Split(',');
					string[] arrRadioTop = hfRadioTop.Value.Split(',');
					decimal tempRbY = decimal.Parse(arrRadioTop[i - 1].ToString());
					xPosition = int.Parse(arrRadioLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempRbY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);

					string[] arrRadioOption = hfRadioOption.Value.Split(',');
					//string[] arrRadioValue = hfRadioValue.Value.Split(',');
					string[] arrRadioCount = hfRadioCount.Value.Split(',');
					for (int j = 0; j < int.Parse(arrRadioCount[i - 1].ToString()); j++)
					{
						rdName = arrRadioOption[numOfLoop];
						value = rdName;
						//insert into form ele list
						InsertEleListValue(rdName, value);
						numOfLoop++;
					}
				}
				else if (name == "textarea")
				{
					string[] arrTextareaLeft = hfTextareaLeft.Value.Split(',');
					string[] arrTextareaTop = hfTextareaTop.Value.Split(',');
					decimal tempTxtareaY = decimal.Parse(arrTextareaTop[i - 1].ToString());
					xPosition = int.Parse(arrTextareaLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempTxtareaY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
				}
				else if (name == "check")
				{
					string value = "";
					string checkName = "";
					string[] arrCheckLeft = hfCheckLeft.Value.Split(',');
					string[] arrCheckTop = hfCheckTop.Value.Split(',');
					decimal tempCheckY = decimal.Parse(arrCheckTop[i - 1].ToString());
					xPosition = int.Parse(arrCheckLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempCheckY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);

					string[] arrCheckOption = hfCheckOption.Value.Split(',');
					//string[] arrCheckValue = hfCheckValue.Value.Split(',');
					string[] arrCheckCount = hfCheckCount.Value.Split(',');
					for (int j = 0; j < int.Parse(arrCheckCount[i - 1].ToString()); j++)
					{
						checkName = arrCheckOption[numOfLoop];
						value = checkName;
						//insert into form ele list
						InsertEleListValue(checkName, value);
						numOfLoop++;
					}
				}
				else if (name == "header")
				{
					string[] arrHeaderLeft = hfHeaderLeft.Value.Split(',');
					string[] arrHeaderTop = hfHeaderTop.Value.Split(',');
					decimal tempHeaderY = decimal.Parse(arrHeaderTop[i - 1].ToString());
					xPosition = int.Parse(arrHeaderLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempHeaderY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
				}
				else if (name == "paragraph")
				{
					string[] arrParagraphLeft = hfParagraphLeft.Value.Split(',');
					string[] arrParagraphTop = hfParagraphTop.Value.Split(',');
					decimal tempParagraphY = decimal.Parse(arrParagraphTop[i - 1].ToString());
					xPosition = int.Parse(arrParagraphLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempParagraphY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
				}
				else if (name == "number")
				{
					string value = "";
					string[] arrNumberLeft = hfNumberLeft.Value.Split(',');
					string[] arrNumberTop = hfNumberTop.Value.Split(',');
					decimal tempNumberY = decimal.Parse(arrNumberTop[i - 1].ToString());
					xPosition = int.Parse(arrNumberLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempNumberY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);

					string[] arrNumberMin = hfNumberMin.Value.Split(',');
					string[] arrNumberMax = hfNumberMax.Value.Split(',');
					//insert min value
					value = arrNumberMin[i-1].ToString();
					InsertEleListValue(name, value);
					//insert max value
					value = arrNumberMax[i-1].ToString();
					InsertEleListValue(name, value);

				}
				else if (name == "date")
				{
					string[] arrDateLeft = hfDateLeft.Value.Split(',');
					string[] arrDateTop = hfDateTop.Value.Split(',');
					decimal tempDateY = decimal.Parse(arrDateTop[i - 1].ToString());
					xPosition = int.Parse(arrDateLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempDateY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
				}
				else if (name == "file")
				{
					string[] arrFileLeft = hfFileLeft.Value.Split(',');
					string[] arrFileTop = hfFileTop.Value.Split(',');
					decimal tempFileY = decimal.Parse(arrFileTop[i - 1].ToString());
					xPosition = int.Parse(arrFileLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempFileY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
				}
				else if (name == "label")
				{
					string[] arrLabelLeft = hfLabelLeft.Value.Split(',');
					string[] arrLabelTop = hfLabelTop.Value.Split(',');
					decimal tempLabelY = decimal.Parse(arrLabelTop[i - 1].ToString());
					xPosition = int.Parse(arrLabelLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempLabelY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
				}
				else if (name == "image")
				{
					string[] arrImageLeft = hfImageLeft.Value.Split(',');
					string[] arrImageTop = hfImageTop.Value.Split(',');
					decimal tempImageY = decimal.Parse(arrImageTop[i - 1].ToString());
					xPosition = int.Parse(arrImageLeft[i - 1].ToString());
					yPosition = Decimal.ToInt32(tempImageY);
					//insert form element
					InsertFormElement(eleTypeId, xPosition, yPosition);
					InsertImage(eleTypeId);

				}

			}
		}

		public void InsertImage(int eleTypeId)
		{
			string name = "null";
			string path = "null";
            int width = hfImageWidth.Value == "" ? 150 : Convert.ToInt32(hfImageWidth.Value);
            int height = hfImageHeight.Value == "" ? 150 : Convert.ToInt32(hfImageHeight.Value);

            FileUpload img = (FileUpload)imgupload;
			Byte[] imgByte = null;
			if (img.HasFile && img.PostedFile != null)
			{
				//To create a PostedFile
				HttpPostedFile File = imgupload.PostedFile;
				//Create byte Array with file len
				imgByte = new Byte[File.ContentLength];
				//force the control to load data in array
				File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            else
            {
                imgByte = (byte[])Session["buffer"];
            }
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);

			sqlConn.Open();
			string insertImage = "INSERT INTO Image Values (@eleTypeId, @photo, @name, @path, @width, @height)";

			SqlCommand cmdInsertImage = new SqlCommand(insertImage, sqlConn);
			cmdInsertImage.Parameters.AddWithValue("@eleTypeId", eleTypeId);
			cmdInsertImage.Parameters.AddWithValue("@photo", imgByte);
			cmdInsertImage.Parameters.AddWithValue("@name", name);
			cmdInsertImage.Parameters.AddWithValue("@path", path);
			cmdInsertImage.Parameters.AddWithValue("@width", width);
			cmdInsertImage.Parameters.AddWithValue("@height", height);
			cmdInsertImage.ExecuteNonQuery();
			sqlConn.Close();
		}

		public void InsertEleListValue(string name, string value) //Insert new element list
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string insertEleListValue = "INSERT INTO Element_list_values Values (@eleId, @name, @value)";

			SqlCommand cmdInsertEleListValue = new SqlCommand(insertEleListValue, sqlConn);
			cmdInsertEleListValue.Parameters.AddWithValue("@eleId", eleId);
			cmdInsertEleListValue.Parameters.AddWithValue("@name", name);
			cmdInsertEleListValue.Parameters.AddWithValue("@value", value);
			cmdInsertEleListValue.ExecuteNonQuery();
			sqlConn.Close();

		}

		public int InsertElementtype(string name, int fontSize, string fontColor, string fontProperty, string fontType, string label)
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string insertEleType = "INSERT INTO Element_type Values (@name, @fontSize, @fontColor, @fontProperty, @fontType, @label)SELECT SCOPE_IDENTITY()";

			SqlCommand cmdInsertEleType = new SqlCommand(insertEleType, sqlConn);
			cmdInsertEleType.Parameters.AddWithValue("@name", name);
			cmdInsertEleType.Parameters.AddWithValue("@fontSize", fontSize);
			cmdInsertEleType.Parameters.AddWithValue("@fontColor", fontColor);
			cmdInsertEleType.Parameters.AddWithValue("@fontProperty", fontProperty);
			cmdInsertEleType.Parameters.AddWithValue("@fontType", fontType);
			cmdInsertEleType.Parameters.AddWithValue("@label", label);
			//Get last id inserted
			int eleTypeId = Convert.ToInt32(cmdInsertEleType.ExecuteScalar());
			sqlConn.Close();
			return eleTypeId;
		}

		public void InsertFormElement(int eleTypeId, int xPosition, int yPosition) //Insert new form element 
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			//int formId = 32;
			int formId = int.Parse(Session["FormId"].ToString());
			string insertFormElement = "INSERT INTO Form_element Values (@formId, @eleTypeId, @xPosition, @yPosition)SELECT SCOPE_IDENTITY()";

			SqlCommand cmdInsertFormElement = new SqlCommand(insertFormElement, sqlConn);
			cmdInsertFormElement.Parameters.AddWithValue("@formId", formId);
			cmdInsertFormElement.Parameters.AddWithValue("@eleTypeId", eleTypeId);
			cmdInsertFormElement.Parameters.AddWithValue("@xPosition", xPosition);
			cmdInsertFormElement.Parameters.AddWithValue("@yPosition", yPosition);
			eleId = Convert.ToInt32(cmdInsertFormElement.ExecuteScalar());
			sqlConn.Close();
		}
	}
}