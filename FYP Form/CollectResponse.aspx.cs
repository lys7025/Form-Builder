using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Form
{
	public partial class CollectResponse : System.Web.UI.Page
	{
		List<Element_Type> eletypeList = new List<Element_Type>();
		List<Form_Ele> formEleList = new List<Form_Ele>();
		List<EleListValue> eleListValueList = new List<EleListValue>();
		StringBuilder html = new StringBuilder();
		string title = "";
		int id = 0;
		int countChildCheck = 1;
		int countChildRadio = 1;
		int countNumber = 0;
		int countDdl = 0;
		int countRb = 0;
		int countCheck = 0;
		int countTxt = 0;
		int countTxtArea = 0;
		int countHeader = 0;
		int countPara = 0;
		int countDate = 0;
		int countFile = 0;
		int countLabel = 0;
		int countImage = 0;
		List<string> arrColName = new List<string>();
		List<int> arrEleId = new List<int>();
		string dbName = "ElementDataDatabase";

		protected void Page_Load(object sender, EventArgs e)
		{
			id = Convert.ToInt32(Request.QueryString["id"]);
			//get the particular id when user click edit
			//title = Session["title"].ToString();
			RetrieveFormElement(id);// Retrieve form element
			RetrieveForm();
			for (int i = 0; i < formEleList.Count; i++)
			{
				RetrieveEleType(formEleList[i].eleTypeId);
				if (eletypeList != null)
				{
					if (eletypeList[i].name == "dropdown")
					{
						arrEleId.Add(formEleList[i].eleId);
						RetrieveEleListValue(formEleList[i].eleId);
						displayEleListItem(i);
					}
					else if (eletypeList[i].name == "number")
					{
						arrEleId.Add(formEleList[i].eleId);
						RetrieveEleListValue(formEleList[i].eleId);
						displayEleListItem(i);
					}
					else if (eletypeList[i].name == "check")
					{
						arrEleId.Add(formEleList[i].eleId);
						RetrieveEleListValue(formEleList[i].eleId);
						displayEleListItem(i);
					}
					else if (eletypeList[i].name == "radio")
					{
						arrEleId.Add(formEleList[i].eleId);
						RetrieveEleListValue(formEleList[i].eleId);
						displayEleListItem(i);
					}
				}
			}
			displayEleItem();
		}

		public void displayEleItem()
		{

			for (int i = 0; i < formEleList.Count; i++)
			{
				if (eletypeList[i].name == "textarea")
				{
					countTxtArea++;
					html.Append("<div id ='li_textarea' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ></i><div id='txtarealb" + countTxtArea + "' >" + eletypeList[i].label + "</div><textarea rows='5' id='txtareaDrag" + countTxtArea + "' required='required' placeholder=''></textarea></div>");
					arrColName.Add(eletypeList[i].label);
					arrEleId.Add(formEleList[i].eleId);
				}
				else if (eletypeList[i].name == "textfield")
				{
					countTxt++;
					html.Append("<div id ='li_txtfield' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ></i><div id='txtlb" + countTxt + "' >" + eletypeList[i].label + "</div><input type='text' required='required' size='45' class='item' id='txtDrag" + countTxt + "' /></div>");
					arrColName.Add(eletypeList[i].label);
					arrEleId.Add(formEleList[i].eleId);
				}
				else if (eletypeList[i].name == "header")
				{
					countHeader++;
					html.Append("<div id ='li_header' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><div id='headerlb" + countHeader + "' style='font-family:" + eletypeList[i].fontType + "; font-size:" + eletypeList[i].fontSize + "px; font-weight:bold'>" + eletypeList[i].label + "</div></div>");
				}
				else if (eletypeList[i].name == "paragraph")
				{
					countPara++;
					html.Append("<div id ='li_paragraph' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; max-width:450px;' ><div id='para_id" + countPara + "'  style='font-weight:" + eletypeList[i].fontProperty + "; color:" + eletypeList[i].fontColor + "'>" + eletypeList[i].label + "</div></div>");
				}
				else if (eletypeList[i].name == "date")
				{
					countDate++;
					html.Append("<div id ='li_date' style='left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' > Date<input type='date' value='" + eletypeList[i].label + "' readonly='readonly' id='date_id" + countDate + "' ></div>");
				}
				else if (eletypeList[i].name == "file")
				{
					countFile++;
					html.Append("<div id ='li_file' style='left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' > <input type='file' id='myFile" + i + 1 + "' multiple size='50' readonly='readonly'></div>");
				}
				else if (eletypeList[i].name == "label")
				{
					countLabel++;
					int temp = countLabel - 1;
					html.Append("<div id ='li_label" + countLabel + "' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><div id='labelID" + temp + "' style='font-size:" + eletypeList[i].fontSize + "px;'>" + eletypeList[i].label + "</div></div>");
				}
				else if (eletypeList[i].name == "image")
				{
					countImage++;
					int temp = countImage - 1;
					html.Append("<div id ='li_image" + countImage + "' class='form_bal_image1' ondrag='maintainDrag()' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px; ' ><i class='fa fa-arrows-alt' style='float:right;'></i> <img src ='ShowImage.ashx?id=" + formEleList[i].eleTypeId + "' onclick='changeImage(this.id)' style='width: 150px; height: 150px' id='image" + temp + "'/></div>");
				}
			}
			hfText.Value = countTxt.ToString();
			hfTextarea.Value = countTxtArea.ToString();
			// Placeholder at here to avoid redundant item display on page
			PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
		}

		public void displayEleListItem(int i)
		{

			if (eletypeList[i].name == "dropdown")
			{
				countDdl++;
				html.Append("<select id='dropdown" + countDdl + "' class='item' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;'>");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<option value='" + eleListValueList[l].value + "'>" + eleListValueList[l].name + "</option>");
				}
				html.Append("</select>");
				//arrColName.Add(eletypeList[i].label);
				arrColName.Add("ddlLabel");
			}
			else if (eletypeList[i].name == "number")
			{
				countNumber++;
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					if (l == 0)
					{
						html.Append("<div id ='li_number' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' >Quantity<input class='item' id='number" + countNumber + "' type='number' style='left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' min='" + eleListValueList[l].value + "'");
					}
					else
					{
						html.Append("max='" + eleListValueList[l].value + "'/></div>");
					}
				}
				arrColName.Add("Quantity");
			}
			else if (eletypeList[i].name == "radio")
			{
				countRb++;
				int temp = countRb - 1;
				html.Append("<div id ='li_rb" + countRb + "' class='form_bal_radio1' ondrag='maintainDrag()' style='width: 300px; position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><div id='rblb" + temp + "' > " + eletypeList[i].label + " </div><div id='divRadio" + countRb + "'> ");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<div id ='childRB" + countChildRadio + "' name='radioChildName" + temp + "'><input type = 'radio' id ='rbID" + countChildRadio + "' name ='radioName" + temp + "' value = '" + eleListValueList[l].value + "' />" + eleListValueList[l].name + "</div>");
					countChildRadio++;
				}
				html.Append("</div></div>");
				arrColName.Add(eletypeList[i].label);
			}
			else if (eletypeList[i].name == "check")
			{
				countCheck++;
				int temp = countCheck - 1;
				html.Append("<div id ='li_checkbox" + countCheck + "' class='form_bal_checkbox1' ondrag='maintainDrag()' style='width: 300px; position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><div id = 'checklb" + temp + "' > " + eletypeList[i].label + " </div><div id='divCheck" + temp + "'>");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<div id = 'childCheck" + countChildCheck + "' name='checkChildName" + temp + "' ><input type = 'checkbox' id = 'checkID" + countChildCheck + "' name = 'CheckBoxName" + temp + "' value = '" + eleListValueList[l].value + "' />" + eleListValueList[l].name + "</div>");
					countChildCheck++;
				}
				html.Append("</div></div>");
				arrColName.Add(eletypeList[i].label);
			}
			hfDrop.Value = countDdl.ToString();
			hfNumber.Value = countNumber.ToString();
			hfRadio.Value = countRb.ToString();
			hfCheck.Value = countCheck.ToString();
			eleListValueList.Clear();
		}

		public class Form_Ele
		{
			public int eleId { get; set; }
			public int formId { get; set; }
			public int eleTypeId { get; set; }
			public string xPosition { get; set; }
			public string yPosition { get; set; }
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
		public class EleListValue
		{
			public int eleListId { get; set; }
			public int eleId { get; set; }
			public string name { get; set; }
			public int value { get; set; }
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
				eleListValue.value = int.Parse(sdr["value"].ToString());
				eleListValueList.Add(eleListValue);
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
			}
			sqlConn.Close();
		}

		public bool CheckTable()
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string editedTitle = "";
			if (title.Any(Char.IsWhiteSpace))//to slipt if title contains any whitespace
			{
				char[] delimiters = { ' ' };
				string[] createColTemp = title.Split(delimiters);
				for (int k = 0; k < createColTemp.Length; k++)
				{
					editedTitle += createColTemp[k].ToString();
				}
				title = editedTitle;
			}

			string checkString = @"IF not EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + title + "') SELECT 1 ELSE SELECT 0"; //Check table exist
				SqlCommand create = new SqlCommand(checkString, sqlConn);
				int x = Convert.ToInt32(create.ExecuteScalar());
				if (x == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			sqlConn.Close();
		}

		public void CreateTable()
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string createString = "";
			string createCol = "";
			int total = countCheck + countDdl + countRb + countNumber + countTxt + countTxtArea;

			for (int i = 0; i < total; i++)// count how many column need to create
			{
				if (string.IsNullOrEmpty(createCol))//if empty create add first column name to createCol
				{
					createCol = "" + arrColName[i].ToString() + " VARCHAR(250)";
				}
				else
				{
					createCol = createCol + ", " + arrColName[i].ToString() + " VARCHAR(250)"; //add next column name to previous column
				}
			}
			createString = "CREATE TABLE " + title + " (" + createCol + ")";
			

			SqlCommand create = new SqlCommand(createString, sqlConn);
			create.ExecuteNonQuery();
			sqlConn.Close();
		}
		

		public void InsertRecord(List<string> response)
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string createCol = "";
			int total = countCheck + countDdl + countRb + countNumber + countTxt + countTxtArea;
			for (int i = 0; i < total; i++)// count how many column need to create
			{
				if (string.IsNullOrEmpty(createCol))//if empty create add first column name to createCol
				{
					createCol = "@" + arrColName[i].ToString() + "";
				}
				else
				{
					createCol = createCol + ", @" + arrColName[i].ToString() + ""; //add next column name to previous column
				}
			}
			string insertRecord = "INSERT INTO " + title + " Values (" + createCol + ")";
			SqlCommand cmdInsertRecord = new SqlCommand(insertRecord, sqlConn);
			for (int i = 0; i < total; i++)//use loop to insert the record 1 by 1
			{
				cmdInsertRecord.Parameters.AddWithValue("@" + arrColName[i].ToString() + "", response[i].ToString());
			}
			cmdInsertRecord.ExecuteNonQuery();
			sqlConn.Close();
		}

		public void GetResponse(int total)//get user input 
		{
			int checkSelected = 0;
			int countDrop = 0;
			int countNum = 0;
			int countRadio = 0;
			int countTextarea = 0;
			int countText = 0;
			int countCheck = 0;
			List<string> arrResponse = new List<string>();

			for (int i = 0; i < formEleList.Count; i++)
			{
				if (eletypeList[i].name == "dropdown")
				{
					string[] arrDrop = hfDropArr.Value.Split(',');
					arrResponse.Add(arrDrop[countDrop].ToString());
					countDrop++;
				}
				else if (eletypeList[i].name == "number")
				{
					string[] arrNumber = hfNumberArr.Value.Split(',');
					arrResponse.Add(arrNumber[countNum].ToString());
					countNum++;
				}
				else if (eletypeList[i].name == "radio")
				{
					string[] arrRadio = hfRadioArr.Value.Split(',');
					arrResponse.Add(arrRadio[countRadio].ToString());
					countRadio++;
				}
				else if (eletypeList[i].name == "check")
				{//use loop to save the selected check
					string[] arrCheck = hfCheckArr.Value.Split(',');
					string[] arrCount = hfCheckCount.Value.Split(',');
					string checkResponse = "";
					for (int j = 0; j < int.Parse(arrCount[countCheck].ToString()); j++)
					{
						if (string.IsNullOrEmpty(checkResponse))
						{
							checkResponse = arrCheck[checkSelected].ToString();
						}
						else
						{
							checkResponse = checkResponse + "," + arrCheck[checkSelected].ToString();
						}
						checkSelected++;
					}
					countCheck++;
					arrResponse.Add(checkResponse);
					checkResponse = "";
				}
			}// seperate due to when save to database the textfield is save first while retrieve is drop first
			//to avoid logic error i separate to two loop
			for (int i = 0; i < formEleList.Count; i++)
			{
				if (eletypeList[i].name == "textarea")
				{
					string[] arrTxtarea = hfTextareaArr.Value.Split(',');
					arrResponse.Add(arrTxtarea[countTextarea].ToString());
					countTextarea++;
				}
				else if (eletypeList[i].name == "textfield")
				{
					string[] arrTxt = hfTextArr.Value.Split(',');
					arrResponse.Add(arrTxt[countText].ToString());
					countText++;
				}
			}
			InsertRecord(arrResponse);
		}

		public void InsertMapping()
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string insertMapping = "INSERT INTO Mapping Values (@eleId, @formId, @nameOfDatabase, @nameOfTable, @nameOfColumn)";
			
			for (int i = 0; i < arrEleId.Count; i++)
			{
				SqlCommand cmdInsertMapping = new SqlCommand(insertMapping, sqlConn);
				cmdInsertMapping.Parameters.AddWithValue("@eleId", int.Parse(arrEleId[i].ToString()));
				cmdInsertMapping.Parameters.AddWithValue("@formId", id);
				cmdInsertMapping.Parameters.AddWithValue("@nameOfDatabase", dbName);
				cmdInsertMapping.Parameters.AddWithValue("@nameOfTable", title);
				cmdInsertMapping.Parameters.AddWithValue("@nameOfColumn", arrColName[i].ToString());
				cmdInsertMapping.ExecuteNonQuery();
			}
			sqlConn.Close();

		}

		protected void btnSend_Click(object sender, EventArgs e)
		{
			int total = countCheck + countDdl + countRb + countNumber + countTxt + countTxtArea;
			//retrieve value
			bool exist = CheckTable();
			//Response.Write("<script>alert('" + exist + "')</script>");
			if (exist)
			{
				CreateTable();
				GetResponse(total);
				InsertMapping();
				Response.Write("<script>alert('Your response is submitted')</script>");
			}
			else
			{
				GetResponse(total);
				InsertMapping();
				Response.Write("<script>alert('Your response is submitted')</script>");
			}
			//string url = HttpContext.Current.Request.Url.AbsoluteUri;
			////txtLink.Text = url;
			////InsertMapping();
			//Response.Write("<script>alert('" + exist + "')</script>");
			//ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
		}
	}
}