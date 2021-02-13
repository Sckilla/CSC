using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflInicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["nombreUsu"] = "";
        Session["cveUsu"] = 0;
        Session["numUsu"] = 0;
        Session["rolUsu"] = "";
        Session["prodId"] = 0;
        Session["keyWord"] = "";
        Session["Aux"] = "";
        Session["Det"] = "0";
        Session["MetE"] = 0;
        Session["MetP"] = 0;
        Session["IdP"] = 0;
    }

    protected void dlCatálogo_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if(e.CommandName == "VerDetalle")
        {
            Session["prodId"] = e.CommandArgument.ToString();
            Response.Write("<script language='javascript'>document.location.href='dflDescProdG.aspx'</script>");
        }
    }
}