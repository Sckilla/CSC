using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflDescProdG : System.Web.UI.Page
{
    //copia de la clase
    clsConexiones objDatos = new clsConexiones();
    //Variable para identificar al producto 
    int claveProducto = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        claveProducto = int.Parse(Session["prodId"].ToString());
        string res = objDatos.DatosProducto(Application["cnn"].ToString(), claveProducto);
        if (res == "0")
        {
            Response.Write("<script language='javascript'>alert ('No se encontró el producto');document.location.href='dflCatalogoGralG.aspx'</script>");
        }
        else
        {
            lblArticulo.Text = objDatos.Nombre;
            lblDescripción.Text = objDatos.Descrip;
            lblExistencias.Text = objDatos.Exist.ToString();
            lblPrecio.Text = objDatos.PrecioF.ToString("C");
            lblPrecioSD.Text = objDatos.Precio.ToString("C");
            if (lblPrecio.Text == lblPrecioSD.Text)
            {
                lblPrecioSD.Visible = false;
            }
            imgFotoProd.ImageUrl = objDatos.Foto;
            if (!IsPostBack)
            {
                llenarDrop(objDatos.Exist);
            }
        }
    }

    protected void llenarDrop(int exist)
    {
        dwlCant.Items.Clear();
        for (int i = 1; i <= exist; i++)
        {
            dwlCant.Items.Insert(i - 1, i.ToString());
        }
        if (exist == 0)
        {
            imgbAddCart.Enabled = false;
        }
    }


    protected void imgbAddCart_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>alert ('No se ha iniciado sesión, para agregar algo al carrito debes iniciar sesión');document.location.href='dflLogin.aspx'</script>");
    }
}