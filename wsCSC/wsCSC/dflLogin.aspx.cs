using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflLogin : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtPassw_TextChanged(object sender, EventArgs e)
    {

    }
    protected void imgbLogin_Click(object sender, ImageClickEventArgs e)
    {
        string res = "";
        if (txtUser.Text != "" && txtPassw.Text != "")
        {
            res = objDatos.Login(txtUser.Text, txtPassw.Text, Application["cnn"].ToString());
            if (res != "-1")
            {
                Session["nombreUsu"] = objDatos.Nombre;
                Session["rolUsu"] = objDatos.Rol;
                Session["cveUsu"] = objDatos.CveUsua;
                if (res == "0")
                {
                    Response.Write("<script language='javascript'>alert ('Bienvenido al sistema');document.location.href='dflInicioC.aspx'</script>");

                }
                else
                {
                    Response.Write("<script language='javascript'>alert ('Bienvenido al sistema');document.location.href='dflInicioA.aspx'</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert ('¡Acceso Denegado!');</script>");
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert ('Debes introducir usuario y contraseña');</script>");
        }
    }
}