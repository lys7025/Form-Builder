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
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			int staffId = int.Parse(Session["staffId"].ToString());
			//int staffId = 2;
			string title = txtTitle.Text;
			Session["title"] = title;
			int version = 1;
			Session["version"] = version;
			string status = "active";

			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();
			//string deleteForm = "DELETE Form where formId=@id";
			string insertForm = "INSERT INTO Form Values (@title, @staffId, @date, @version, @status)SELECT SCOPE_IDENTITY()";

			//SqlCommand cmdDelete = new SqlCommand(deleteForm, sqlConn);
			//cmdDelete.Parameters.AddWithValue("@id", 4);

			SqlCommand cmdInsertForm = new SqlCommand(insertForm, sqlConn);
			cmdInsertForm.Parameters.AddWithValue("@title", title);
			cmdInsertForm.Parameters.AddWithValue("@staffId", staffId);
			cmdInsertForm.Parameters.AddWithValue("@date", DateTime.Today);
			cmdInsertForm.Parameters.AddWithValue("@version", version);
			cmdInsertForm.Parameters.AddWithValue("@status", status);
			//cmdInsertForm.ExecuteNonQuery();
			
			Session["FormId"] = Convert.ToInt32(cmdInsertForm.ExecuteScalar());
			sqlConn.Close();
			Response.Write("<script>alert('Form created successfully')</script>");
			Response.Redirect("BuildForm.aspx");
		}
	}
}