﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KnowledgePlanet
{
    public partial class usermenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pass"] == null || (bool)(Session["pass"].ToString() != "guest"))
            {
                Response.Redirect("main.html");
            }
        }
    }
}