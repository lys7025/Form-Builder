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
	public partial class UserLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void LogIn(object sender, EventArgs e)
		{
			string username = UserName.Text;
			string password = Password.Text;
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			sqlConn.Open();

			string retrieveStaff = "SELECT * FROM Users WHERE username = @username AND password = @password";

			SqlCommand cmdRetrieveStaff = new SqlCommand(retrieveStaff, sqlConn);
			cmdRetrieveStaff.Parameters.AddWithValue("@username", username);
			cmdRetrieveStaff.Parameters.AddWithValue("@password", password);
			SqlDataReader sdr = cmdRetrieveStaff.ExecuteReader();

            if(UserName.Text == "" || Password.Text == "") {

                Response.Write("<script>alert('Cannot be blank')</script>");

			    
             } else
                {
                if (sdr == null || !sdr.HasRows)
			    {
				    Response.Write("<script>alert('Wrong username or password')</script>");
			    }
			    else
			    {
				    while (sdr.Read())
				    {
					    Session["staffId"] = int.Parse(sdr["staffId"].ToString());
				    }
				    sqlConn.Close();
				    Response.Write("<script>alert('Login successful')</script>");
				    Response.Redirect("/FormPage.aspx");
			    }
                }
		}
	}
}