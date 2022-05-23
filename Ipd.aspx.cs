using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace UdayNew
{
    public partial class hlIpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["user"] != null)
                {
                    lblmsg.Text = "hi" + Session["user"].ToString();
                }
                if (Session["username"] != null)
                {
                    
                    personName.Text = Session["username"].ToString();
                    age.Text = Session["age"].ToString();
                    if (Session["gender"].ToString() == "Male")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }
                    if (Session["hobie1"].ToString() == "Playing Cricket")
                    {
                        CheckBox1.Checked = true;
                    }
                    if (Session["hobie2"].ToString() == "Reading Books")
                    {
                        CheckBox2.Checked = true;
                    }
                    if (Session["hobie3"].ToString() == "Cooking")
                    {
                        CheckBox3.Checked = true;
                    }
                    DropDownList1.SelectedItem.Text = Session["city"].ToString();
                    btninsert.Text = "update";

                }

            }
            
                

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(btninsert.Text== "update")
            {
                int id = 0;
                
                if (Session["id"] != null)
                {
                    id = Convert.ToInt32(Session["id"]);
                      
                }
               
                string gender = "";
                string hob1 = "";
                string hob2 = "";
                string hob3 = "";

                if (RadioButton1.Checked == true)
                {
                    gender = gender + RadioButton1.Text;
                }
                else
                {
                    gender = gender + RadioButton2.Text;
                }
                if (CheckBox1.Checked == true)
                {
                    hob1 = CheckBox1.Text;
                }
                if (CheckBox2.Checked == true)
                {
                    hob2 = CheckBox2.Text;
                }
                if (CheckBox3.Checked == true)
                {
                    hob3 = CheckBox3.Text;
                }
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                con.Open();
                string q = "update MT_Persons set PersonName='" + personName.Text + "',Age='" + age.Text + "',CityId='" + DropDownList1.SelectedItem.Text + "',Hobbies1='" + hob1 + "',Hobbies2='" + hob2 + "',Hobbies3='" + hob3 + "',Sex='" + gender + "' where id='"+id+"' ";
                SqlCommand cmd = new SqlCommand(q, con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "user updated succfully!";
                    personName.Text = "";
                    age.Text = "";
                    DropDownList1.SelectedItem.Text = "--select--";
                    RadioButton1.Checked = false;
                    RadioButton1.Checked = false;
                    CheckBox1.Checked = false;
                    CheckBox2.Checked = false;
                    CheckBox3.Checked = false;
                    Response.Redirect("pl.aspx");



                }

            }
            else
            {
                string gender = "";
                string hob1 = "";
                string hob2 = "";
                string hob3 = "";

                if (RadioButton1.Checked == true)
                {
                    gender = gender + RadioButton1.Text;
                }
                else
                {
                    gender = gender + RadioButton2.Text;
                }
                if (CheckBox1.Checked == true)
                {
                    hob1 = CheckBox1.Text;
                }
                if (CheckBox2.Checked == true)
                {
                    hob2 = CheckBox2.Text;
                }
                if (CheckBox3.Checked == true)
                {
                    hob3 = CheckBox3.Text;
                }
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                con.Open();
                string q = "insert into  MT_Persons(PersonName,Age,CityId,Hobbies1,Hobbies2,Hobbies3,Sex) values( '" + personName.Text + "','" + age.Text + "','" + DropDownList1.SelectedItem.Text + "', '" + hob1 + "','" + hob2 + "','" + hob3 + "' ,'" + gender + "')  ";
                SqlCommand cmd = new SqlCommand(q, con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "user created succfully!";

                }
            }


        }
    }
}