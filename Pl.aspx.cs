using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace UdayNew
{
    public partial class hlPl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label1.Text = "hi  " + Session["user"];
            Get_data();
        }
        protected void Get_data()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            string q = "select * from MT_Persons";
            SqlDataAdapter Da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            Da.Fill(ds, "uday");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btnLOgout_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                
                Control c1 = row.FindControl("Label1");//name
                Control c2 = row.FindControl("Label2");//age
                Control c3 = row.FindControl("Label3");//city name
                Control c4 = row.FindControl("Label4");//h1
                Control c5 = row.FindControl("Label5");//h2
                Control c6= row.FindControl("Label6");//h3
                Control c7 = row.FindControl("Label7");//sex
                Control c8 = row.FindControl("Label8");

                //Label iusernamed = (Label)c2;
                Label username = (Label)c1;
                Label age = (Label)c2;
                Label city = (Label)c3;
                Label hobbile1 = (Label)c4;
                Label hobbile2 = (Label)c5;
                Label hobbile3 = (Label)c6;
                Label sex = (Label)c7;
                Label id = (Label)c8;

                Session["username"] = username.Text;
                Session["age"] = age.Text;
                Session["city"] = city.Text;
                Session["hobie1"] = hobbile1.Text;
                Session["hobie2"] = hobbile2.Text;
                Session["hobie3"] = hobbile3.Text;
                Session["gender"] = sex.Text;
                Session["id"] = id.Text;
                Session.Timeout = 1;
                Response.Redirect("ipd.aspx");


            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Get_data();
        }
    }
}