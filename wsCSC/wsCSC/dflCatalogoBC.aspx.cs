﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflCatalogoBC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "VerDetalle")
        {
            Session["prodId"] = e.CommandArgument.ToString();
            Response.Write("<script language='javascript'>document.location.href='dflDescProdC.aspx'</script>");
        }
    }
}