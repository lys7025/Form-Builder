using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Form
{
	public partial class DeletePage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(Request.QueryString["id"]);
            string title = Request.QueryString["title"];
            if (MessageBox.Show("Are you sure want to deactivate " + title + " ?", "Deactivate Form", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //if clicked ok
                RetrieveForm(id);
            }
            else
            {
                Response.Redirect("FormPage.aspx");
            }
            
		}

		public void RetrieveForm(int formId)//get form detail by formID
		{
			
				string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
				SqlConnection sqlConn = new SqlConnection(conn);
				sqlConn.Open();
				string retrieveForm = "SELECT * FROM Form WHERE formId = @formId";
				int staffId = 0;
				int version = 0;
				string title = "";
				string status = "inactive";

				SqlCommand cmdRetrieveForm = new SqlCommand(retrieveForm, sqlConn);
				cmdRetrieveForm.Parameters.AddWithValue("@formId", formId);
				SqlDataReader sdr = cmdRetrieveForm.ExecuteReader();
				while (sdr.Read())
				{
					staffId = int.Parse(sdr["staffId"].ToString());
					title = sdr["title"].ToString();
					version = int.Parse(sdr["version"].ToString());
				}
				sqlConn.Close();

				UpdateForm(formId, title, staffId, version, status);

				Response.Write("<script>alert('Form's status had changed to INACTIVE.')</script>");
				Response.Redirect("FormPage.aspx");
			
		}

		public void UpdateForm(int formId, string title, int staffId, int version, string status)//Update form infomation
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			string updateForm = "UPDATE Form set title = @title, staffId = @staffId, dateGenerated = @date, version = @version, status = @status WHERE formId = @formId";

			SqlCommand cmdUpdateForm = new SqlCommand(updateForm, sqlConn);
			cmdUpdateForm.Parameters.AddWithValue("@formId", formId);
			cmdUpdateForm.Parameters.AddWithValue("@title", title);
			cmdUpdateForm.Parameters.AddWithValue("@staffId", staffId);
			cmdUpdateForm.Parameters.AddWithValue("@date", DateTime.Today);
			cmdUpdateForm.Parameters.AddWithValue("@version", version);
			cmdUpdateForm.Parameters.AddWithValue("@status", status);
			cmdUpdateForm.ExecuteNonQuery();
			sqlConn.Close();
		}
	}
}