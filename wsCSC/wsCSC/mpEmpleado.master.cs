using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mpEmpleado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblRol.Text = Session["rol"].ToString();
        lblUsuario.Text = Session["nombreUsuario"].ToString();
    }
    protected void imgbBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Session["keyWord"] = "%" + txtBuscarPr.Text + "%";
        Response.Write("<script language='javascript'>document.location.href='dflCatalogoBE.aspx'</script>");
    }
}
