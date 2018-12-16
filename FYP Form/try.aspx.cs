using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Form
{




    public partial class _try : System.Web.UI.Page
    {

            TextBox tb;
            static int i = 0;
        RadioButton rb;
        Label lb;

        protected void Page_Load(object sender, EventArgs e)
        {
            i = 0;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            i++;
            int j;
            for (j = 0; j <= i; j++)
            {
                tb = new TextBox();
                tb.ID = j.ToString();
                lb = new Label();
                lb.Text = "Name";
                lb.ID = j.ToString();
                

                PlaceHolder1.Controls.Add(lb);
                PlaceHolder1.Controls.Add(tb);
                
            }

        }
    }
}