using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class dflReporteVentasXCli : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    DataSet dsVentas;
    ReportDocument rptVtaCliente = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (objDatos.VerifVentasG(Application["cnn"].ToString()) == "1")
        {
            Response.Write("<script language='javascript'>alert('No existen compras/ventas activas');document.location.href='dflMenuRep.aspx'</script>");
        }
    }

    protected void gvVentas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        crvReporte.Enabled = true;
        crvReporte.Visible = true;
        int cve = int.Parse(gvVentas.Rows[e.NewSelectedIndex].Cells[1].Text.ToString());
        rptVtaCliente = new ReportDocument();
        rptVtaCliente.Load(Server.MapPath("~/Reportes/crReporteComprasT.rpt"));//se declara la ruta de ubicación del reporte
        dsVentas = new DataSet();
        dsVentas = objDatos.ReporteComprasT(Application["cnn"].ToString(), cve, char.Parse(lbltc.Text));
        rptVtaCliente.SetDataSource(dsVentas.Tables[0]);
        rptVtaCliente.SetDatabaseLogon("dbuser", "dbpassword", @"dbserver", "BD_CSC_2018");//conexión con el servidor
        crvReporte.ReportSource = rptVtaCliente;//asigna la fuente del viewer
        crvReporte.DataBind();//permite la visualización de los datos del reporte en el formulario
    }
    protected void LlenarGrid()
    {
        char tu = char.Parse(lbltc.Text);
        int CVE = 0;
        if (lbltb.Text == "0")
        {
            try
            {
                CVE = int.Parse(lblBusqueda.Text);
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('La cadena de busqueda no corresponde con el tipo de búsqueda');</script>");
                return;
            }
        }
        dsVentas = new DataSet();
        dsVentas = objDatos.ListarBusquedaUsuarios(Application["cnn"].ToString(), lblBusqueda.Text, CVE, tu, int.Parse(lbltb.Text));
        gvVentas.DataSource = dsVentas;
        gvVentas.DataMember = "Venta";
        gvVentas.DataBind();
        if (gvVentas.Rows.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('No se encontraron coincidencias para la búsqueda');</script>");
        }
    }

    protected void imgbBuscar_Click(object sender, ImageClickEventArgs e)
    {
        crvReporte.Enabled = false;
        crvReporte.Visible = false;
        try
        {
            if (txtBuscar.Text != "")
            {
                lbltc.Text = rblTU.SelectedIndex.ToString();
                lbltb.Text = rblTB.SelectedIndex.ToString();
                lblBusqueda.Text = txtBuscar.Text;
                LlenarGrid(); 
            }
            else
            {
                Response.Write("<script language='javascript'>alert('La cadena de búsqueda esta vacía');'</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ocurrió un error al consultar la base de datos');document.location.href='dflMenuRep.aspx'</script>");
        }
    }

    protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVentas.PageIndex = e.NewPageIndex;
        LlenarGrid();
    }
}