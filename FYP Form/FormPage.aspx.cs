using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Form
{
    public partial class FormPage : System.Web.UI.Page
    {
		StringBuilder htmlTable = new StringBuilder();
		protected void Page_Load(object sender, EventArgs e)
        {
			if (!Page.IsPostBack)
			{
				RetrieveForm();
			}
		}

		public class Form1
		{
			public int formId { get; set; }
			public int staffId { get; set; }
			public string title { get; set; }
			public DateTime date { get; set; }
			public int version { get; set; }
			public string status { get; set; }
		}

		private void RetrieveForm()
		{
			int staffId = int.Parse(Session["staffId"].ToString());
			//int staffId = 2;
			List<Form1> formList = new List<Form1>();

			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string retrieveForm = "SELECT * FROM Form WHERE staffId = @staffId";

			SqlCommand cmdRetrieveForm = new SqlCommand(retrieveForm, sqlConn);
			cmdRetrieveForm.Parameters.AddWithValue("@staffId", staffId);
			SqlDataReader sdr = cmdRetrieveForm.ExecuteReader();
			htmlTable.Append("<table border = '1'>"); // Append table
			htmlTable.Append("<tr><th>Date</th><th>Title</th><th>Version</th><th>Status</th></tr>");

			if (sdr == null || !sdr.HasRows)
			{
				//NO record found
				htmlTable.Append("<tr>");
				htmlTable.Append("<td>No form created</td>");

				htmlTable.Append("</tr>");
			}
			else
			{
				while (sdr.Read())
				{
					Form1 form = new Form1();
					form.formId = int.Parse(sdr["formId"].ToString());
					form.title = sdr["title"].ToString();
					form.date = Convert.ToDateTime(sdr["dateGenerated"]);
					form.version = int.Parse(sdr["version"].ToString());
					form.status = sdr["status"].ToString();
					formList.Add(form);
				}
				sqlConn.Close();
				//Get the form info from list and using loop to display the multiple row form
				foreach (Form1 frm in formList)
				{
						htmlTable.Append("<tr>");
						htmlTable.Append("<td>" + frm.date.ToShortDateString() + "</td>");
						htmlTable.Append("<td>" + frm.title + "</td>");
						htmlTable.Append("<td>" + frm.version + "</td>");
						htmlTable.Append("<td>" + frm.status + "</td>");
						htmlTable.AppendFormat("<td><a href='Edit?id={0}'>Edit</a> | ", frm.formId);//Pass form id at that row
						htmlTable.AppendFormat("<a href='ViewPage?id={0}'>View</a> | ", frm.formId);
						htmlTable.AppendFormat("<a href='#' onClick='show({0})'>Delete</a></td>", frm.formId);
						htmlTable.Append("</tr>");
					
				}
			}
			htmlTable.Append("</table>");
			phTable.Controls.Add(new Literal { Text = htmlTable.ToString() }); // Place the table where the placeholder put at
		}
	}
}