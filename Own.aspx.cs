using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UdayNew
{
    public partial class hlOwn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Visible = true;
            HttpCookie cookie = Request.Cookies["useinfo"];
            if (cookie != null)
            {
                lblWelcome.Text = "hi" + cookie["usernmae"];
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(lblNumber1.Text);
            int y = Convert.ToInt32(lblNumber2.Text);
            ADDNums(x, y);

        }
        protected void ADDNums(int a,int b)
        {
            int SummOftwoNums = a + b;
            lblSumofN1PlusN2.Text = SummOftwoNums.ToString();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(lblNumber1.Text);
            int y = Convert.ToInt32(lblNumber2.Text);
            int z = Convert.ToInt32(lblNumber3.Text);

            ADDNums(x, y,z);
        }
        protected void ADDNums(int a, int b,int c)
        {
            int SumOdThreeNums = a + b+c;
            lblSumofN1PlusN2PlusN3.Text = SumOdThreeNums.ToString();

        }
    }
}