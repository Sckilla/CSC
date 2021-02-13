using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflSelecPagoE : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarDrops();
        }
    }

    protected void imgbTar_Click(object sender, ImageClickEventArgs e)
    {
        dwlNTarjeta.Visible = true;
        dwlAño.Visible = true;
        dwlMes.Visible = true;
        dwlDia.Visible = false;
        txtNumero.Visible = true;
        txtCveTj.Visible = true;
        txtNumero.MaxLength = 16;
        lblTarjetaNom.Visible = true;
        lblCve.Text = "Número de tarjeta";
        lblCve.Visible = true;
        lblFecha.Text = "Fecha de exp y cve de seguridad";
        lblFecha.Visible = true;
        lblTarjetaNom.Visible = true;
        lblMet.Text = "Tarjeta";
        revNumero.ValidationExpression = "(4[0-9]{3}[0-9]{4}[0-9]{4}[0-9]{4})|(5[1-5][0-9]{2}[0-9]{4}[0-9]{4}[0-9]{4})";
        revNumero.ErrorMessage = "Numero incorrecto ################";
        imgbContinuar.Visible = true;
    }

    protected void imgbTra_Click(object sender, ImageClickEventArgs e)
    {
        dwlNTarjeta.Visible = false;
        dwlAño.Visible = true;
        dwlMes.Visible = true;
        dwlDia.Visible = true;
        txtNumero.Visible = true;
        txtCveTj.Visible = false;
        txtNumero.MaxLength = 18;
        lblTarjetaNom.Visible = false;
        lblCve.Text = "Clave de la transferencia";
        lblCve.Visible = true;
        lblFecha.Text = "Fecha día/mes/año";
        lblFecha.Visible = true;
        lblTarjetaNom.Visible = false;
        lblMet.Text = "Transferencia";
        revNumero.ValidationExpression = "[0-9]{5}[0-9]*";
        revNumero.ErrorMessage = "Clave incorrecta #####[#############]";
        imgbContinuar.Visible = true;
    }

    protected void imgbDep_Click(object sender, ImageClickEventArgs e)
    {
        dwlNTarjeta.Visible = false;
        dwlAño.Visible = true;
        dwlMes.Visible = true;
        dwlDia.Visible = true;
        txtNumero.Visible = true;
        txtCveTj.Visible = false;
        txtNumero.MaxLength = 18;
        lblTarjetaNom.Visible = false;
        lblCve.Text = "Clave del depósito";
        lblCve.Visible = true;
        lblFecha.Text = "Fecha día/mes/año";
        lblFecha.Visible = true;
        lblTarjetaNom.Visible = false;
        lblMet.Text = "Depósito";
        revNumero.ValidationExpression = "[0-9]{5}[0-9]*";
        revNumero.ErrorMessage = "Clave incorrecta #####[#############]";
        imgbContinuar.Visible = true;

    }

    void LlenarDrops()
    {
        dwlDia.Items.Clear();
        dwlDia.Items.Insert(0, "--");
        dwlAño.Items.Clear();
        dwlAño.Items.Insert(0, "--");
        for (int i = 1; i <= 40; i++)
        {
            if (i < 10)
            {
                dwlAño.Items.Insert(i, "0" + i.ToString());
            }
            else
            {
                dwlAño.Items.Insert(i, i.ToString());
            }
        }
        dwlMes.Items.Clear();
        dwlMes.Items.Insert(0, "--");
        for (int i = 1; i <= 12; i++)
        {
            if (i < 10)
            {
                dwlMes.Items.Insert(i, "0" + i.ToString());
            }
            else
            {
                dwlMes.Items.Insert(i, i.ToString());
            }
        }
        dwlNTarjeta.Items.Clear();
        ds = objDatos.ListarTarjetasCli(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '1');
        dwlNTarjeta.DataSource = ds;
        dwlNTarjeta.DataMember = "Tarjetas";
        dwlNTarjeta.DataValueField = "ID";
        dwlNTarjeta.DataTextField = "NOM";
        dwlNTarjeta.DataBind();
        int id = dwlNTarjeta.Items.Count;
        dwlNTarjeta.Items.Insert(0, "-Selecciona tu tarjeta-");
        dwlNTarjeta.Items.Insert(id + 1, "VISA");
        dwlNTarjeta.Items.Insert(id + 2, "MASTER CARD");
    }

    void LlenarDropDia()
    {
        if (dwlMes.SelectedIndex != 0 && dwlAño.SelectedIndex != 0)
        {
            int[] dias = { 0, 32, 29, 32, 31, 32, 31, 32, 32, 31, 32, 31, 32 };
            if (dwlAño.SelectedIndex % 4 == 0)
            {
                dias[2] = 30;
            }
            dwlDia.Items.Clear();
            dwlDia.Items.Insert(0, "--");
            int dm = dias[int.Parse(dwlMes.SelectedIndex.ToString())];
            for (int i = 1; i < dm; i++)
            {
                if (i < 10)
                {
                    dwlDia.Items.Insert(i, "0" + i.ToString());
                }
                else
                {
                    dwlDia.Items.Insert(i, i.ToString());
                }
            }
        }

    }

    protected void dwlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        LlenarDropDia();
    }

    protected void dwlAño_SelectedIndexChanged(object sender, EventArgs e)
    {
        LlenarDropDia();
    }

    protected void imgbContinuar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string msg = Validar();
            if (msg != "")
            {
                Response.Write("<script language='javascript'>alert('Los campos " + msg + " \\nno han sido seleccionados')</script>");
                return;
            }
            if (lblMet.Text == "Tarjeta")
            {
                string res = objDatos.AgregarTarjeta(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '1', txtNumero.Text, txtCveTj.Text, dwlMes.SelectedValue.ToString(), dwlAño.SelectedValue.ToString(), dwlNTarjeta.SelectedValue.ToString());
                Session["MetP"] = 1;
                Session["IdP"] = objDatos.Id;
                if (res == "0")
                {
                    Response.Write("<script language='javascript'>alert ('Se ha registrado su nuevo método de pago');document.location.href='dflDetalleVentaE.aspx'</script>");
                }
                else if (res == "2")
                {
                    Response.Write("<script language='javascript'>alert ('Las modificaciones se han realizado correctamnete');document.location.href='dflDetalleVentaE.aspx'</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>document.location.href='dflDetalleVentaE.aspx'</script>");
                }
            }
            if (lblMet.Text == "Transferencia")
            {
                string res = objDatos.AgregarTransf(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '1', txtNumero.Text, dwlDia.SelectedValue.ToString(), dwlMes.SelectedValue.ToString(), dwlAño.SelectedValue.ToString());
                if (res != "0")
                {
                    Session["MetP"] = 2;
                    Session["IdP"] = int.Parse(res);
                    Response.Write("<script language='javascript'>alert('Se ha recibido su método de pago para su verificación');document.location.href='dflDetalleVentaE.aspx'</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('No se pudo realizar la acción, este pago ya está registrado');</script>");
                }
            }
            if (lblMet.Text == "Depósito")
            {
                string res = objDatos.AgregarDeposito(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()), '1', txtNumero.Text, dwlDia.SelectedValue.ToString(), dwlMes.SelectedValue.ToString(), dwlAño.SelectedValue.ToString());
                if (res != "0")
                {
                    Session["MetP"] = 3;
                    Session["IdP"] = int.Parse(res);
                    Response.Write("<script language='javascript'>alert('Se ha recibido su método de pago para su verificación');document.location.href='dflDetalleVentaE.aspx'</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('No se pudo realizar la acción, este pago ya está registrado');</script>");
                }
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('No se pudo realizar la acción');document.location.href='dflCarritoE.aspx'</script>");
        }
    }


    protected void dwlNTarjeta_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dwlNTarjeta.SelectedIndex != 0 && dwlNTarjeta.SelectedIndex < (dwlNTarjeta.Items.Count - 2))
        {
            string res = objDatos.DatosTarjeta(Application["cnn"].ToString(), int.Parse(dwlNTarjeta.SelectedValue.ToString()));
            if (res == "0")
            {
                dwlNTarjeta.SelectedIndex = 0;
                txtNumero.Enabled = true;
            }
            else
            {
                txtNumero.Text = objDatos.Nombre;
                txtNumero.Enabled = false;
                dwlAño.SelectedIndex = int.Parse(objDatos.App);
                dwlMes.SelectedIndex = int.Parse(objDatos.Apm);
                txtCveTj.Text = objDatos.Rol;
            }
        }
        else
        {
            txtNumero.Enabled = true;
        }
        if (dwlNTarjeta.SelectedValue.ToString().StartsWith("VISA"))
        {
            revNumero.ValidationExpression = "(4[0-9]{3}[0-9]{4}[0-9]{4}[0-9]{4})";
            revNumero.ErrorMessage = "Numero incorrecto 4###############";
        }
        else if (dwlNTarjeta.SelectedValue.ToString().StartsWith("MASTER CARD"))
        {
            revNumero.ValidationExpression = "(5[1-5][0-9]{2}[0-9]{4}[0-9]{4}[0-9]{4})";
            revNumero.ErrorMessage = "Numero incorrecto 5###############";
        }
    }

    protected string Validar()
    {
        string msg = "";
        if (txtNumero.Text == "")
        {
            msg = msg + "\\nNumero de tarjeta o clave de transferencia";
        }

        if (lblMet.Text == "Tarjeta")//campos tarjeta
        {
            if (dwlNTarjeta.SelectedIndex == 0)
            {
                msg = msg + "\\nTarjeta";
            }
            if (txtCveTj.Text == "")
            {
                msg = msg + "\\nClave de seguridad";
            }

        }
        else
        {
            if (dwlDia.SelectedIndex == 0)
            {
                msg = msg + "\\nDía";
            }
        }
        if (dwlMes.SelectedIndex == 0)
        {
            msg = msg + "\\nMes";

        }
        if (dwlAño.SelectedIndex == 0)
        {
            msg = msg + "\\nAño";
        }
        return msg;
    }
}