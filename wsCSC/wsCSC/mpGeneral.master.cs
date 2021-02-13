using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mpGeneral : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["rol"] = "";
        Session["nombreUsuario"]="";
    }
    protected void imgbBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Session["keyWord"] = "%" + txtBuscarPr.Text + "%";
        Response.Write("<script language='javascript'>document.location.href='dflCatalogoBG.aspx'</script>");
    }
}
