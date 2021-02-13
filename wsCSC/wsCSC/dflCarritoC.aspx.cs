using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflCarrito : System.Web.UI.Page
{ 
    clsConexiones objDatos = new clsConexiones();
    DataSet dsClientes;
    int claveCliente = 0;
    double desc = 0, imp = 0.16;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            claveCliente = int.Parse(Session["cveUsu"].ToString());
            lblArtAd.Text = "0";
            datosCarrito();
            //imgbAddEnv.Attributes.Add("OnClick", "window.open('dflSelectEnvCEm.aspx',null,'heigth=500, width=500');");
        }   
    }

    protected void datosCarrito()
    {
        LlenarGrid();
        lblArtAd.Text = gvCarrito.Rows.Count.ToString();
        double subtotal = 0;
        int cantp = 0;
        for (int i = 0; i < gvCarrito.Rows.Count; i++)
        {
            cantp += int.Parse(gvCarrito.Rows[i].Cells[5].Text.ToString());
            subtotal += double.Parse(gvCarrito.Rows[i].Cells[7].Text.ToString().Remove(0, 1));
        }
        if (cantp == 0)
        {
            Response.Write("<script language='javascript'>alert('No se ha añadido ningún producto al carrito');document.location.href='dflInicioC.aspx'</script>");
        }
        if (Session["MetE"].ToString() != "0")
        {
            objDatos.ObtDatEnv(Application["cnn"].ToString(), int.Parse(Session["MetE"].ToString()));
            lblEnvío.Text = objDatos.Nombre;
            lblCostoEnv.Text = objDatos.Precio.ToString("C");
        }
        lblSubtotal.Text = subtotal.ToString("C");
        double total = objDatos.Precio + subtotal + (subtotal * imp) - (subtotal * desc);
        lblCantP.Text = cantp.ToString();
        lblImp.Text = (imp*subtotal).ToString("C");
        lblTotal.Text = total.ToString("C");
        Session["Subtotal"] = lblSubtotal.Text;
        Session["Total"] = lblTotal.Text;
    }

    protected void LlenarGrid()
    {
        dsClientes = new DataSet();
        dsClientes = objDatos.ListarCarritoC(Application["cnn"].ToString(), '0', int.Parse(Session["cveUsu"].ToString()));
        gvCarrito.DataSource = dsClientes;
        gvCarrito.DataMember = "DetReg";
        gvCarrito.DataBind();
    }

    protected void imgbAdEnvio_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>document.location.href='dflSelecEnvC.aspx'</script>");
    }

    protected void imgbPagar_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["MetE"].ToString() != "0")
        {

            Response.Write("<script language='javascript'>document.location.href='dflSelecPagoC.aspx'</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('No se ha seleccionado un método de envío');document.location.href='dflSelecEnvC.aspx'</script>");
        }
    }

    protected void gvCarritoC_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string resultado = "";
        try
        {
            resultado = objDatos.BajaDetCar(Application["cnn"].ToString(), int.Parse(gvCarrito.Rows[e.RowIndex].Cells[1].Text.ToString()));
            if (resultado == "0")
            {
                Response.Write("<script language='javascript'>alert('Se ha eliminado " + gvCarrito.Rows[e.RowIndex].Cells[2].Text.ToString() + " del carrito');</script>");
                datosCarrito();
            }
            else if (resultado == "1")
            {
                Response.Write("<script language='javascript'>alert('El producto " + gvCarrito.Rows[e.RowIndex].Cells[2].Text.ToString() + " ya estaba fuera del carrito');</script>");
            }
            else if (resultado == "2")
            {
                Response.Write("<script language='javascript'>alert('El producto " + gvCarrito.Rows[e.RowIndex].Cells[2].Text.ToString() + " no estaba en el carrito');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }

    protected void gvCarrito_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Session["Det"] = gvCarrito.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
        Session["prodId"] = objDatos.ObtDetCveP(Application["cnn"].ToString(), int.Parse(Session["Det"].ToString()));
        Response.Write("<script language='javascript'>alert('Agregue su nueva cantidad deseada');document.location.href='dflDescProdC.aspx'</script>");
    }
}