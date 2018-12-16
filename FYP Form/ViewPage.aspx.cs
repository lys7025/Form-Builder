using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Form
{
	public partial class ViewPage : System.Web.UI.Page
	{
		List<Element_Type> eletypeList = new List<Element_Type>();
		List<Form_Ele> formEleList = new List<Form_Ele>();
		List<EleListValue> eleListValueList = new List<EleListValue>();
		StringBuilder html = new StringBuilder();
		int id = 0;
		int countChildCheck = 1;
		int countChildRadio = 1;
		string dbName = "ElementDataDatabase";

		protected void Page_Load(object sender, EventArgs e)
		{
			//get the particular id when user click edit
			id = Convert.ToInt32(Request.QueryString["id"]);
			Session["viewFormId"] = id.ToString();
			//int id = 32;
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

			for (int i = 0; i < formEleList.Count; i++)
			{
				if (eletypeList[i].name == "textarea")
				{
					countTxtArea++; 
					html.Append("<div id ='li_textarea' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ></i><div id='txtarealb" + countTxtArea + "' >" + eletypeList[i].label + "</div><textarea rows='5' id='txtareaDrag" + countTxtArea + "' readonly='readonly' placeholder=''></textarea></div>");
				}
				else if (eletypeList[i].name == "textfield")
				{
					countTxt++;
					html.Append("<div id ='li_txtfield' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ></i><div id='txtlb" + countTxt + "' >" + eletypeList[i].label + "</div><input type='text' size='45' readonly='readonly' class='item' id='txtDrag" + countTxt + "' /></div>");
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
			// Placeholder at here to avoid redundant item display on page
			PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
		}

		public void displayEleListItem(int i)
		{
			int countNumber = 0;
			int countDdl = 0;
			int countRb = 0;
			int countCheck = 0;
			
			if (eletypeList[i].name == "dropdown")
			{
				countDdl++;
				html.Append("<select id='dropdown" + countDdl + "' class='item' style='position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;'>");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<option value='" + eleListValueList[l].value + "'>" + eleListValueList[l].name + "</option>");
				}
				html.Append("</select>");
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

			}
			else if (eletypeList[i].name == "radio")
			{
				countRb++;
				int temp = countRb - 1;
				html.Append("<div id ='li_rb" + countRb + "' class='form_bal_radio1' ondrag='maintainDrag()' style='width: 300px; position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><div id='rblb" + temp + "' > " + eletypeList[i].label + " </div><div id='divRadio" + countRb + "'> ");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<div id ='childRB" + countChildRadio + "' name='radioChildName" + temp + "'><input type = 'radio' id ='rbID" + countChildRadio + "' name ='radioName" + temp + "' readonly='readonly' value = '" + eleListValueList[l].value + "' /> " + eleListValueList[l].name + " </div>");
					countChildRadio++;
				}
				html.Append("</div></div>");
			}
			else if (eletypeList[i].name == "check")
			{
				countCheck++;
				int temp = countCheck - 1;
				html.Append("<div id ='li_checkbox" + countCheck + "' class='form_bal_checkbox1' ondrag='maintainDrag()' style='width: 300px; position: absolute; left:" + formEleList[i].xPosition + "px; top:" + formEleList[i].yPosition + "px;' ><div id = 'checklb" + temp + "' > " + eletypeList[i].label + " </div><div id='divCheck" + temp + "'>");
				for (int l = 0; l < eleListValueList.Count; l++)
				{
					html.Append("<div id = 'childCheck" + countChildCheck + "' name='checkChildName" + temp + "' ><input type = 'checkbox' id = 'checkID" + countChildCheck + "' name = 'CheckBoxName" + temp + "' readonly='readonly' value = '" + eleListValueList[l].value + "' /> " + eleListValueList[l].name + " </div>");
					countChildCheck++;
				}
				html.Append("</div></div>");
			}
			
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

		public void InsertMapping(int eleId, string tableName, string column)
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			int count = 0;
			List<string> tables = new List<string>();
			//get tables name
			DataTable dt = sqlConn.GetSchema("Tables");
			foreach (DataRow row in dt.Rows)
			{
				string tablename = (string)row[2];
				tables.Add(tablename);
				count++;
			}
			Response.Write("<script>alert('" + tables.ToString() + "')</script>");
			string insertMapping = "INSERT INTO Mapping Values (@eleId, @formId, @nameOfDatabase, @nameOfTable, @nameOfColumn)";

			SqlCommand cmdInsertMapping = new SqlCommand(insertMapping, sqlConn);
			cmdInsertMapping.Parameters.AddWithValue("@eleId", eleId);
			cmdInsertMapping.Parameters.AddWithValue("@formId", id);
			cmdInsertMapping.Parameters.AddWithValue("@nameOfDatabase", dbName);
			cmdInsertMapping.Parameters.AddWithValue("@nameOfTable", tableName);
			cmdInsertMapping.Parameters.AddWithValue("@nameOfColumn", column);
			cmdInsertMapping.ExecuteNonQuery();
			sqlConn.Close();

		}

		protected void btnSend_Click(object sender, EventArgs e)
		{
			//string url = "";
			////txtLink.Text = url;
			////InsertMapping();
			//FYP_Form.CollectResponse collectResponse = new FYP_Form.CollectResponse();
			//url = collectResponse.GetUrl();
			//string referrer = Request.UrlReferrer;
			Response.Write("<script>alert('http://localhost:61441/CollectResponse?id="+id+"')</script>");
			//ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
		}
	}
}