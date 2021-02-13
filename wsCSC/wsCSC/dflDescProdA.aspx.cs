using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflDescProdA : System.Web.UI.Page
{
    //copia de la clase
    clsConexiones objDatos = new clsConexiones();
    //declarar un dataset local a la página
    DataSet dsProductos;
    //Variable para identificar al producto 
    int claveProducto = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblIdet.Text = Session["Det"].ToString();
            Session["Det"] = "0";
            claveProducto = int.Parse(Session["prodId"].ToString());
            string res = objDatos.DatosProducto(Application["cnn"].ToString(), claveProducto);
            if (res == "0")
            {
                Response.Write("<script language='javascript'>alert ('No se encontró el producto');document.location.href='dflCatalogoGralA.aspx'</script>");
            }
            else
            {
                int canta = 0;//cantidad de productos anterior
                if (lblIdet.Text != "0")
                {
                    canta = int.Parse(objDatos.ObtDetCant(Application["cnn"].ToString(), int.Parse(lblIdet.Text)));
                }

                lblArticulo.Text = objDatos.Nombre;
                lblDescripción.Text = objDatos.Descrip;
                lblExistencias.Text = (canta + objDatos.Exist).ToString();
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
    }

    protected void llenarDrop(int exist)
    {
        if (lblIdet.Text != "0")
        {
            try
            {
                exist = exist + int.Parse(objDatos.ObtDetCant(Application["cnn"].ToString(), int.Parse(lblIdet.Text)));
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('Ha ocurrido un error, intente de nuevo');document.location.href='dflCarritoA.aspx'</script>");
            }
        }
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
        try
        {
            if (lblIdet.Text != "0")
            {
                objDatos.BajaDetCar(Application["cnn"].ToString(), int.Parse(lblIdet.Text));
                objDatos.AgregarDetCar(Application["cnn"].ToString(), '1', int.Parse(Session["cveUsu"].ToString()), int.Parse(Session["prodId"].ToString()), int.Parse(dwlCant.SelectedValue.ToString()));
                Response.Write("<script language='javascript'>alert('Se ha confirmado la nueva cantidad');document.location.href='dflCarritoA.aspx'</script>");
                return;
            }
            else
            {
                objDatos.AgregarDetCar(Application["cnn"].ToString(), '1', int.Parse(Session["cveUsu"].ToString()), int.Parse(Session["prodId"].ToString()), int.Parse(dwlCant.SelectedValue.ToString()));
                Response.Write("<script language='javascript'>alert('El producto " + lblArticulo.Text + " ha sido agregado al carrito')</script>");
                int ex = int.Parse(lblExistencias.Text);
                ex = ex - int.Parse(dwlCant.SelectedValue.ToString());
                lblExistencias.Text = ex.ToString();
                llenarDrop(ex);
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ocurrió un error al leer la base de datos')</script>");
        }
    }
}