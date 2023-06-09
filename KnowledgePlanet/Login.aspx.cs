﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KnowledgePlanet
{
    public partial class Login : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            txtUserName.Focus();
            if (!Page.IsPostBack)
            {
                MyLabel.Text = mydb.RandomNum(4);
            }    
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim() == "" || TextBox3.Text.Trim() != MyLabel.Text.Trim())
            {
                Response.Write("<script>alert('验证码错误或为空')</script>");
                return;
            }
            else
            {
                if (txtUserName.Text.Trim() == "" | txtPassword.Text.Trim() == "")
                {
                    Response.Write("<script>alert('用户名和密码不能为空')</script>");
                    return;
                }
                string ConnStr = ConfigurationManager.ConnectionStrings["Database"].ToString();
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    string StrSQL = "select ulevel from T_UserData where uname='" + txtUserName.Text + "'and upwd='" + txtPassword.Text + "'";
                    SqlCommand com = new SqlCommand(StrSQL, conn);
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Read();
                    string level;
                    if (dr.HasRows)
                    {
                        level = dr["ulevel"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名或密码错误')</script>");
                        return;
                    }
                    if (level == "0")
                    {
                        Session["pass"] = "admin";
                        Response.Redirect("managermenu.aspx");
                    }
                    else
                    {
                        Session["pass"] = "guest";
                        Response.Redirect("usermenu.aspx");
                    }
                }

            }
               
        }
        
        protected void MyButton_Click(object sender, EventArgs e)
        {
            MyLabel.Text = mydb.RandomNum(4);
        }

    }
}