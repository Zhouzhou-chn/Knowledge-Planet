﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KnowledgePlanet.Manager
{
    public partial class editfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pass"] == null || (bool)(Session["pass"].ToString() != "admin"))
            {
                Response.Redirect("../main.html");
            }
        }
    }
}