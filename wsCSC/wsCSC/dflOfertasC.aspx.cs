using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflOfertasC : System.Web.UI.Page
{
    clsConexiones obj = new clsConexiones();
    int cantp = 0;
    int ultp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["prodId"] = Request.QueryString["cve"];
        lblNPag.Text = Request.QueryString["pag"];
        Session["ControlP"] = ((int.Parse(lblNPag.Text) - 1) * 24) + 1;
        cantp = obj.ContListProdOfer(Application["cnn"].ToString(), int.Parse(Session["prodId"].ToString()));
        ultp = (int.Parse(lblNPag.Text)) * 24;
        if (cantp == 0)
        {
            lblTitulo.Text = "No hay ofertas por ahora";
        }
        if (cantp < 25)
        {
            lblNPag.Visible = false;
            imgbIzq.Visible = false;
            imgbDer.Visible = false;
        }
        if (int.Parse(lblNPag.Text) <= 1)
        {
            imgbIzq.Enabled = false;
        }
        if (cantp <= ultp)
        {
            imgbDer.Enabled = false;
        }
    }

    protected void dlCatálogo_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "VerDetalle")
        {
            Session["prodId"] = e.CommandArgument.ToString();
            Response.Write("<script language='javascript'>document.location.href='dflDescProdC.aspx'</script>");
        }
    }

    protected void imgbIzq_Click(object sender, ImageClickEventArgs e)
    {
        int npag = int.Parse(lblNPag.Text) - 1;
        Response.Write("<script language='javascript'>document.location.href='dflOfertasC.aspx?cve=" + Session["prodId"].ToString() + "&pag=" + npag + "'</script>");
    }

    protected void imgbDer_Click(object sender, ImageClickEventArgs e)
    {
        int npag = int.Parse(lblNPag.Text) + 1;
        Response.Write("<script language='javascript'>document.location.href='dflOfertasC.aspx?cve=" + Session["prodId"].ToString() + "&pag=" + npag + "'</script>");
    }
}