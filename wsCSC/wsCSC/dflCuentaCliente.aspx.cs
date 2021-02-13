using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflCuentaCliente : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    string ruta = "", foto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ObtInfo();
            HabilitarCajas();
        }     
    }

    protected void imgCargar_Click(object sender, ImageClickEventArgs e)
    {
        if (fluCargarFoto.HasFile)
        {
            ruta = "";
            foto = "";
            ruta = Server.MapPath("~/FOTOS/");

            fluCargarFoto.PostedFile.SaveAs(ruta + fluCargarFoto.FileName);

            foto = fluCargarFoto.FileName;

            imgCargar.ImageUrl = "FOTOS/" + foto;
            imgCargar.ImageAlign = ImageAlign.Middle;

            HDDRutaFisica.Text = "FOTOS/" + foto;
        }
    }

    protected void imgbCambiarC_Click(object sender, ImageClickEventArgs e)
    {
        Ocultar.Text = "2";
        HabilitarCajas();
    }

    protected void imgbHabEd_Click(object sender, ImageClickEventArgs e)
    {
        Ocultar.Text = "1";
        HabilitarCajas();
    }

    protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
    {
        string msg=validar();
        try
        {
            if (msg == "")
            {
                if (Ocultar.Text != "1")
                {
                    if (txtContrasN.Text != txtConfContr.Text)
                    {
                        Response.Write("<script language='javascript'>alert('La nueva contraseña no coincide con la confirmación');</script>");
                        return;
                    }
                }
                msg = objDatos.ModificarCliente(Application["cnn"].ToString(), txtSexo.Text, txtNombre.Text, txtApePa.Text, txtApeMat.Text, txtCorreoEl.Text, int.Parse(txtEdad.Text), txtTel.Text, txtDir.Text, HDDRutaFisica.Text, txtNombreUsu.Text, txtContrasN.Text);
                if (msg == "1")
                {
                    Response.Write("<script language='javascript'>alert('No se ha podido confirmar la existencia del cliente en la base de datos');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Los datos han sido modificado correctamente');</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Atencion en los campos:" + msg + " \\n no han sido llenados correctamente');</script>");
            }
            Ocultar.Text = "0";
            ObtInfo();
            HabilitarCajas();
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error, vuelva a intentarlo más tarde');</script>");
        }
    }

    protected void ObtInfo()
    {
        if (objDatos.DatosCliente(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString())) == "1")
        {
            txtNombre.Text = objDatos.Nombre;
            txtApePa.Text = objDatos.App;
            txtApeMat.Text = objDatos.Apm;
            txtEdad.Text = objDatos.Edad.ToString();
            txtSexo.Text = objDatos.Sexo;
            txtCorreoEl.Text = objDatos.Correo;
            txtTel.Text = objDatos.Tel;
            txtDir.Text = objDatos.Dir;
            HDDRutaFisica.Text = objDatos.Foto;
            imgCargar.ImageUrl = HDDRutaFisica.Text;
            txtNombreUsu.Text = objDatos.Usuario;
            lblPass.Text = objDatos.Contraseña;
            txtNombreUsu.ReadOnly = true;
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Usuario no encontrado.');</script>");
        }
    }

    protected void HabilitarCajas()
    {
        if (Ocultar.Text == "0")// vista de los datos del cliente
        {
            lblCampOb.Visible = false;
            txtNombre.ReadOnly = true;
            txtApePa.ReadOnly = true;
            txtApeMat.ReadOnly = true;
            txtEdad.ReadOnly = true;
            txtSexo.ReadOnly = true;
            txtCorreoEl.ReadOnly = true;
            txtTel.ReadOnly = true;
            txtDir.ReadOnly = true;
            txtNombreUsu.ReadOnly = true;
            fluCargarFoto.Visible = false;
            txtContrasA.Visible = false;
            txtContrasN.Visible = false;
            txtConfContr.Visible = false;
            imgbHabEd.Visible = true;
            imgbCambiarC.Visible = false;
            imgbGuardar.Visible = false;
            lblIContA.Visible = false;
            lblIConfN.Visible = false;
            lblContraseñaA.Visible = false;
            lblContraseñaN.Visible = false;
            lblConfC.Visible = false;
        }
        else if(Ocultar.Text=="1")//edición habilitada
        {
            lblCampOb.Visible = true;
            txtNombre.ReadOnly = false;
            txtApePa.ReadOnly = false;
            txtApeMat.ReadOnly = false;
            txtEdad.ReadOnly = false;
            txtSexo.ReadOnly = false;
            txtCorreoEl.ReadOnly = false;
            txtTel.ReadOnly = false;
            txtDir.ReadOnly = false;
            txtNombreUsu.ReadOnly = true;
            fluCargarFoto.Visible = true;
            txtContrasA.Visible = false;
            txtContrasN.Visible = true;
            txtConfContr.Visible = false;
            imgbHabEd.Visible = false;
            imgbCambiarC.Visible = true;
            imgbGuardar.Visible = true;
            lblIContA.Visible = false;
            lblIConfN.Visible = false;
            lblContraseñaA.Visible = false;
            lblContraseñaN.Visible = true;
            lblConfC.Visible = false;
        }else if (Ocultar.Text == "2")//edicion con cambio de contraseña activado
        {
            lblCampOb.Visible = true;
            txtNombre.ReadOnly = false;
            txtApePa.ReadOnly = false;
            txtApeMat.ReadOnly = false;
            txtEdad.ReadOnly = false;
            txtSexo.ReadOnly = false;
            txtCorreoEl.ReadOnly = false;
            txtTel.ReadOnly = false;
            txtDir.ReadOnly = false;
            txtNombreUsu.ReadOnly = true;
            fluCargarFoto.Visible = true;
            txtContrasA.Visible = true;
            txtContrasN.Visible = true;
            txtConfContr.Visible = true;
            imgbHabEd.Visible = false;
            imgbCambiarC.Visible = false;
            imgbGuardar.Visible = true;
            lblIContA.Visible = true;
            lblIConfN.Visible = true;
            lblContraseñaA.Visible = true;
            lblContraseñaN.Visible = true;
            lblConfC.Visible = true;
        }
    }

    string validar()
    {
        string mensaje = "";
        if (txtNombre.Text == "")
        {
            mensaje += "\\nNombre (Vacío)";
        }
        if (txtApePa.Text == "")
        {
            mensaje += "\\nApellido paterno (Vacío)";
        }
        if (txtEdad.Text == "")
        {
            mensaje += "\\nEdad (Vacío)";
        }
        if (txtDir.Text == "")
        {
            mensaje += "\\nDirección (Vacío)";
        }
        if (txtNombreUsu.Text == "")
        {
            mensaje += "\\nNombre de usuario (Vacío)";
        }
        if (txtContrasN.Text != lblPass.Text && Ocultar.Text == "1")
        {
            mensaje += "\\nContraseña actual (Incorrecta)";
        }
        if (txtContrasA.Text != lblPass.Text && Ocultar.Text == "2")
        {
            mensaje += "\\nContraseña actual (Incorrecta)";
        }
        if (txtContrasN.Text == "" && Ocultar.Text == "2")
        {
            mensaje += "\\nNueva contraseña (Vacío)";
        }
        return mensaje;
    }

}