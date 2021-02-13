using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class dflReporteCliReg : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    ReportDocument rptRep = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (objDatos.VerifUsuReg(Application["cnn"].ToString(), 0) == "1")
            {
                Response.Write("<script language='javascript'>alert('No existen clientes activos');document.location.href='dflMenuRep.aspx'</script>");
            }
            else
            {
                crvReporte.Enabled = true;
                crvReporte.Visible = true;
                rptRep = new ReportDocument();
                rptRep.Load(Server.MapPath("~/Reportes/crReporteUsuReg.rpt"));//se declara la ruta de ubicación del reporte
                rptRep.SetParameterValue(0, 0);//Se asigna el valor del parámetro enviado a la base de datos
                rptRep.SetDatabaseLogon("dbuser", "dbpassword", @"dbserver", "BD_CSC_2018");//conexión con el servidor
                crvReporte.ReportSource = rptRep;//asigna la fuente del viewer
                crvReporte.DataBind();//permite la visualización de los datos del reporte en el formulario
            }
        }
    }
}