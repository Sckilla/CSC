using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflSelecEnvE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void imgbFedEx_Click(object sender, ImageClickEventArgs e)
    {
        Session["MetE"] = 3;
        Response.Write("<script language='javascript'>alert ('Se ha elegido FedEx como método de envío');document.location.href='dflCarritoE.aspx'</script>");
    }

    protected void imgbDHL_Click(object sender, ImageClickEventArgs e)
    {
        Session["MetE"] = 2;
        Response.Write("<script language='javascript'>alert ('Se ha elegido DHL como método de envío');document.location.href='dflCarritoE.aspx'</script>");
    }

    protected void imgbEstafeta_Click(object sender, ImageClickEventArgs e)
    {
        Session["MetE"] = 1;
        Response.Write("<script language='javascript'>alert ('Se ha elegido Estafeta como método de envío');document.location.href='dflCarritoE.aspx'</script>");
    }
}