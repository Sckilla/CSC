using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class dflDescripVentaE : System.Web.UI.Page
{
    ReportDocument rptVtaCliente = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        crvVenta.Enabled = true;
        crvVenta.Visible = true;
        int cve = int.Parse(Session["CveVenta"].ToString());
        rptVtaCliente = new ReportDocument();
        rptVtaCliente.Load(Server.MapPath("~/Reportes/crReporteVentaU.rpt"));//se declara la ruta de ubicación del reporte
        rptVtaCliente.SetParameterValue(0, cve);//Se asigna el valor del parámetro enviado a la base de datos
        rptVtaCliente.SetDatabaseLogon("dbuser", "dbpassword", @"dbserver", "BD_CSC_2018");//conexión con el servidor
        crvVenta.ReportSource = rptVtaCliente;//asigna la fuente del viewer
        crvVenta.DataBind();//permite la visualización de los datos del reporte en el formulario
        Session["Subtotal"] = "";
        Session["Total"] = "";
        Session["MetE"] = 0;
    }
}