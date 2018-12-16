//using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;


public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }
	protected void LogIn(object sender, EventArgs e)
    {
		//string username = UserName.Text;
		//string password = Password.Text;
		string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		SqlConnection sqlConn = new SqlConnection(conn);
		sqlConn.Open();

		string retrieveStaff = "SELECT * FROM Users WHERE username = @username AND password = @password";

		SqlCommand cmdRetrieveStaff = new SqlCommand(retrieveStaff, sqlConn);
		//cmdRetrieveStaff.Parameters.AddWithValue("@username", username);
		//cmdRetrieveStaff.Parameters.AddWithValue("@password", password);
		SqlDataReader sdr = cmdRetrieveStaff.ExecuteReader();

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