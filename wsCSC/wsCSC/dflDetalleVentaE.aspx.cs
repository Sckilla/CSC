using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflDetalleVentaE : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InfoVenta();
        }
    }

    protected void imgbMetEnv_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>alert ('Selecciona un nuevo método de envío');document.location.href='dflSelecEnvE.aspx'</script>");
    }

    protected void InfoVenta()
    {
        objDatos.DatosEmpleado(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()));
        txtCliente.Text = objDatos.Nombre;
        txtDir.Text = objDatos.Dir;
        objDatos.ObtDatEnv(Application["cnn"].ToString(), int.Parse(Session["MetE"].ToString()));
        txtEnvío.Text = objDatos.Nombre;
        imgbMetEnv.ImageUrl = objDatos.Foto;
        txtSubtotal.Text = Session["Subtotal"].ToString();
        lblTotal.Text = Session["Total"].ToString();
        txtImpuestos.Text = "IVA (16%)";
        if (Session["MetP"].ToString() == "1")
        {
            txtPago.Text = "Tarjeta Crédito/Débito";
        }
        else if (Session["MetP"].ToString() == "2")
        {
            txtPago.Text = "Transferencia Bancaria";
        }
        else if (Session["MetP"].ToString() == "3")
        {
            txtPago.Text = "Depósito Bancario";
        }
        string msg = Validar();
        if (msg != "")
        {
            Response.Write("<script language='javascript'>alert('Error al obtener:" + msg + " ');document.location.href='dflCarritoE.aspx'</script>");
        }
    }

    protected void imgbConfirmarC_Click(object sender, ImageClickEventArgs e)
    {
        string msg = Validar();
        if (msg != "")
        {
            Response.Write("<script language='javascript'>alert('Los campos:" + msg + "\\nSon obligatorios');document.location.href='dflCarritoE.aspx'</script>");
        }
        else
        {
            Session["CveVenta"] = objDatos.ConfirmarVenta(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), 0, float.Parse("0.16"), '1', int.Parse(Session["MetE"].ToString()), txtDir.Text, int.Parse(Session["MetP"].ToString()), int.Parse(Session["IdP"].ToString()));
            Response.Write("<script language='javascript'>alert('La venta con clave" + Session["CveVenta"].ToString() + " ha sido completada correctamente');document.location.href='dflDescripVentaE.aspx'</script>");
        }
    }

    protected string Validar()
    {
        string mensaje = "";
        if (txtCliente.Text == "")
        {
            mensaje += "\\nNombre del cliente";
        }
        if (txtDir.Text == "")
        {
            mensaje += "\\nDirección";
        }
        if (txtEnvío.Text == "")
        {
            mensaje += "\\nDatos de Envío";
        }
        if (txtPago.Text == "")
        {
            mensaje += "\\nDatos del pago";
        }
        if (txtSubtotal.Text == "" || lblTotal.Text == "")
        {
            mensaje += "\\nResumen de montos de la compra";
        }
        return mensaje;
    }
}