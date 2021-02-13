﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class dflRepVentasTotC : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    ReportDocument rptVtaCliente = new ReportDocument();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (objDatos.VerifExistVenCli(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '0', 2) == "1")
            {
                Response.Write("<script language='javascript'>alert('No se ha realizado ninguna compra con este usuario');document.location.href='dflMenuVentasC.aspx'</script>");
            }
            else
            {
                crvVentas.Enabled = true;
                crvVentas.Visible = true;
                int cve = int.Parse(Session["cveUsu"].ToString());
                rptVtaCliente = new ReportDocument();
                rptVtaCliente.Load(Server.MapPath("~/Reportes/crReporteComprasT.rpt"));//se declara la ruta de ubicación del reporte
                ds = new DataSet();
                ds = objDatos.ReporteComprasT(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '0');
                rptVtaCliente.SetDataSource(ds.Tables[0]);
                rptVtaCliente.SetDatabaseLogon("dbuser", "dbpassword", @"dbserver", "BD_CSC_2018");//conexión con el servidor
                crvVentas.ReportSource = rptVtaCliente;//asigna la fuente del viewer
                crvVentas.DataBind();//permite la visualización de los datos del reporte en el formulario
            }
        }
    }
}