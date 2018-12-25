using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace FYP_Form
{
	/// <summary>
	/// Summary description for ShowImage
	/// </summary>
	public class ShowImage : IHttpHandler, IRequiresSessionState
    {
        Byte[] imgBuffer = null;
        public void ProcessRequest(HttpContext context)
		{
			Int32 eleTypeId;
			if (context.Request.QueryString["id"] != null)
				eleTypeId = Convert.ToInt32(context.Request.QueryString["id"]);
			else
				throw new ArgumentException("No parameter specified");

			context.Response.ContentType = "image/jpeg";
			Stream strm = ShowEmpImage(eleTypeId);
			byte[] buffer = new byte[4096];
			int byteSeq = strm.Read(buffer, 0, 4096);
            while (byteSeq > 0)
			{
				context.Response.OutputStream.Write(buffer, 0, byteSeq);
				byteSeq = strm.Read(buffer, 0, 4096);
			}
            context.Session["buffer"] = imgBuffer;
            //context.Response.BinaryWrite(buffer);
        }

		public Stream ShowEmpImage(int eleTypeId)
		{
			string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			SqlConnection sqlConn = new SqlConnection(conn);
			string retrieveImage = "SELECT photo FROM Image WHERE eleTypeId = @eleTypeId";
			SqlCommand cmdRetrieveImage = new SqlCommand(retrieveImage, sqlConn);
			cmdRetrieveImage.CommandType = CommandType.Text;
			cmdRetrieveImage.Parameters.AddWithValue("@eleTypeId", eleTypeId);
			sqlConn.Open();
            object img = cmdRetrieveImage.ExecuteScalar();
            imgBuffer = (byte[])img;
            try
			{
				return new MemoryStream((byte[])img);
            }
			catch
			{
				return null;
			}
			finally
			{
				sqlConn.Close();
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}