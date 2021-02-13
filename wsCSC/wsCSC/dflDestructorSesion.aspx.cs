using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflDestructorSesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsConexiones obj = new clsConexiones();
        if (Session["rolUsu"].ToString() == "CLIENTE")
        {
            obj.BajaCarrito(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '0');
        }
        else
        {
            obj.BajaCarrito(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '1');
        }
        Response.Write("<script language='javascript'>document.location.href='dflInicio.aspx'</script>");
    }
}