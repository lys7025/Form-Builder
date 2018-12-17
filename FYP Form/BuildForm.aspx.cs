using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Form
{
    public partial class BuildForm : System.Web.UI.Page
    {
		int eleId = 0;

		protected void Page_Load(object sender, EventArgs e)
        {

        }

		protected void btnInsert_Click(object sender, EventArgs e)
		{
			//StringBuilder htmlTxt = new StringBuilder();
			int totalTxtNo = hfText.Value == "" ? 0 : Convert.ToInt32(hfText.Value);
			int totalDdlNo = hfDrop.Value == "" ? 0 : Convert.ToInt32(hfDrop.Value);
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
			//GetElementType(totalTxtNo, totalDdlNo, totalRbNo, totalTxtAreaNo, totalCheckNo, totalHeaderNo, totalParagraphNo, totalNumberNo, totalDateNo, totalFileNo, totalLabelNo, totalImageNo);
			//Response.Write("<script>alert('Form created successful')</script>");
			//Response.Redirect("FormPage.aspx");
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
					string[] arrLabelFontSize = hfLabelFontSize.Value.Split(',','p','x');
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
					string[] arrDdlValue = hfDropValue.Value.Split(',');
					string[] arrDdlCount = hfDropCount.Value.Split(',');
					for (int j = 0; j < int.Parse(arrDdlCount[i - 1].ToString()); j++)
					{
						ddlName = arrDdlOption[numOfLoop];
						value = ddlName;
						//insert into form ele list
						InsertEleListValue(eleId, ddlName, value);
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
					string[] arrRadioValue = hfRadioValue.Value.Split(',');
					string[] arrRadioCount = hfRadioCount.Value.Split(',');
					for (int j = 0; j < int.Parse(arrRadioCount[i - 1].ToString()); j++)
					{
						rdName = arrRadioOption[numOfLoop];
						value = rdName;
						//insert into form ele list
						InsertEleListValue(eleId, rdName, value);
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
					string[] arrCheckValue = hfCheckValue.Value.Split(',');
					string[] arrCheckCount = hfCheckCount.Value.Split(',');
					for (int j = 0; j < int.Parse(arrCheckCount[i - 1].ToString()); j++)
					{
						checkName = arrCheckOption[numOfLoop];
						value = checkName;
						//insert into form ele list
						InsertEleListValue(eleId, checkName, value);
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
					InsertEleListValue(eleId, name, value);
					//insert max value
					value = arrNumberMax[i-1].ToString();
					InsertEleListValue(eleId, name, value);
						
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
			int width = 150;
			int height = 150;

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

		public void InsertEleListValue(int eleId, string name, string value) //Insert new element list
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
			//int formId = 17;
			int formId = Convert.ToInt32(Session["FormId"].ToString());
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