using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace UdayNew
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSignIn_Click1(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ToString());
            con.Open();
            string q = "select * from mt_udaylogin  ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string username = dr[1].ToString();
                    string password = dr[2].ToString();
                    if (username == txtUserName.Text && password == txtPassword.Text)
                    {
                        Session["user"] = username;
                        Session.Timeout = 10;
                        Response.Redirect("Home.aspx");



                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "invalid credencials";

                    }

                }
            }



            }
        }
}