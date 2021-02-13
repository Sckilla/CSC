using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class dflComprasC : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    DataSet dsVentas;
    ReportDocument rptVtaCliente = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (objDatos.VerifExistVenCli(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '0', 0) == "1")
        {
            Response.Write("<script language='javascript'>alert('No se ha realizado ninguna compra o no existe ninguna compra activa para este usuario');document.location.href='dflMenuVentasC.aspx'</script>");
        }
        if (!IsPostBack)
        {
            LlenarGrid();
            crvVenta.Enabled = false;
            crvVenta.Visible = false;
        }
    }

    protected void LlenarGrid()
    {
        dsVentas = new DataSet();
        dsVentas = objDatos.ListarVentasCli(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '0', 0);
        gvVentas.DataSource = dsVentas;
        gvVentas.DataMember = "Ventas";
        gvVentas.DataBind();
    }

    protected void gvVentasC_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        crvVenta.Enabled = false;
        crvVenta.Visible = false;
        string resultado = "";
        try
        {
            resultado = objDatos.CancelarVenta(Application["cnn"].ToString(), int.Parse(gvVentas.Rows[e.RowIndex].Cells[2].Text.ToString()));
            if (resultado == "0")
            {
                Response.Write("<script language='javascript'>alert('La venta con clave: " + gvVentas.Rows[e.RowIndex].Cells[2].Text.ToString() + " ha sido eliminada');</script>");
                LlenarGrid();
            }
            else if (resultado == "1")
            {
                Response.Write("<script language='javascript'>alert('La venta con clave: " + gvVentas.Rows[e.RowIndex].Cells[2].Text.ToString() + " ya estaba dada de baja');</script>");
            }
            else if (resultado == "2")
            {
                Response.Write("<script language='javascript'>alert('La venta con clave: " + gvVentas.Rows[e.RowIndex].Cells[2].Text.ToString() + " no se encontró');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }

    protected void gvVentas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        crvVenta.Enabled = true;
        crvVenta.Visible = true;
        int cve = int.Parse(gvVentas.Rows[e.NewSelectedIndex].Cells[2].Text.ToString());
        rptVtaCliente = new ReportDocument();
        rptVtaCliente.Load(Server.MapPath("~/Reportes/crReporteVenta.rpt"));//se declara la ruta de ubicación del reporte
        rptVtaCliente.SetParameterValue(0, cve);//Se asigna el valor del parámetro enviado a la base de datos
        rptVtaCliente.SetDatabaseLogon("dbuser", "dbpassword", @"dbserver", "BD_CSC_2018");//conexión con el servidor
        crvVenta.ReportSource = rptVtaCliente;//asigna la fuente del viewer
        crvVenta.DataBind();//permite la visualización de los datos del reporte en el formulario
        Session["Subtotal"] = "";
        Session["Total"] = "";
        Session["MetE"] = 0;
    }

    protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVentas.PageIndex = e.NewPageIndex;
        LlenarGrid();
    }
}