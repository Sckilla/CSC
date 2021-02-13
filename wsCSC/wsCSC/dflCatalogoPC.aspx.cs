using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflCatalogoPC : System.Web.UI.Page
{
    clsConexiones obj = new clsConexiones();
    int cantp = 0;
    int ultp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["prodId"] = Request.QueryString["cve"];
        lblNPag.Text = Request.QueryString["pag"];
        Session["ControlP"] = ((int.Parse(lblNPag.Text) - 1) * 24) + 1;
        cantp = obj.ContListProductos(Application["cnn"].ToString(), int.Parse(Session["prodId"].ToString()));
        ultp = (int.Parse(lblNPag.Text)) * 24;
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
        if (Session["prodId"].ToString() != "0")
        {
            if (obj.DatosTProducto(Application["cnn"].ToString(), int.Parse(Session["prodId"].ToString())) == "1")
            {
                lblTitulo.Text = obj.TIPO.ToUpper();
            }
            else
            {
                lblTitulo.Text = "CATÁLOGO";
            }
        }
        else
        {
            lblTitulo.Text = "CATÁLOGO";
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
        Response.Write("<script language='javascript'>document.location.href='dflCatalogoPC.aspx?cve=" + Session["prodId"].ToString() + "&pag=" + npag + "'</script>");
    }

    protected void imgbDer_Click(object sender, ImageClickEventArgs e)
    {
        int npag = int.Parse(lblNPag.Text) + 1;
        Response.Write("<script language='javascript'>document.location.href='dflCatalogoPC.aspx?cve=" + Session["prodId"].ToString() + "&pag=" + npag + "'</script>");
    }
}