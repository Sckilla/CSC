using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dflRegistroC : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    int claveEmpleado = 0;
    string ruta = "", foto = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgCargar_Click(object sender, ImageClickEventArgs e)
    {
        if (fluCargarFoto.HasFile)
        {
            ruta = "";
            foto = "";
            //PERMITE REFERENCIAR LA CARPETA DEL SITIO WEB
            ruta = Server.MapPath("~/FOTOS/");

            //SaveAs -- > guarda la imagen en la ruta especificada
            fluCargarFoto.PostedFile.SaveAs(ruta + fluCargarFoto.FileName);

            //Muestra la imagen cargada
            foto = fluCargarFoto.FileName;

            //imgFoto --> ImageButton
            imgCargar.ImageUrl = "FOTOS/" + foto;
            imgCargar.ImageAlign = ImageAlign.Middle;

            HDDRutaFisica.Text = "FOTOS/" + foto;
        }
    }
    protected void imgbLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        limpiar();
    }
    protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string mensaje = validar();
            if (txtContrasEmp.Text != txtConfContr.Text)
            {
                Response.Write("<script language='javascript'>alert('Revisa que la confirmación y contraseña sean idéntica');</script>");
            }
            if (mensaje == "" && txtContrasEmp.Text == txtConfContr.Text)
            {
                string resultado = "";
                resultado = objDatos.RegistrarCliente(Application["cnn"].ToString(), txtSexo.Text, txtNombreEmp.Text, txtApePaEmp.Text, txtApeMatEmp.Text, txtCorreoElEmp.Text, int.Parse(txtEdad.Text), txtTelEmp.Text, txtDirEmp.Text, HDDRutaFisica.Text, txtNombreUsuEmp.Text, txtContrasEmp.Text);
                if (int.Parse(resultado) == -1)
                {
                    Response.Write("<script language='javascript'>alert('Ya se ha registrado a un usuario con estos datos');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('El empleado " + txtNombreEmp.Text + ' ' + txtApePaEmp.Text + ' ' + txtApeMatEmp.Text + " ha sido registrado correctamente');</script>");
                    Response.Write("<script language='javascript'>alert ('Redireccionando');document.location.href='dflLogin.aspx'</script>");
                    limpiar();
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Los campos obligatorios:" + mensaje + " \\n no han sido llenados');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al leer la respuesta de la base de datos');</script>");
        }
    }
    string validar()
    {
        string mensaje = "";
        if (txtNombreEmp.Text == "")
        {
            mensaje += "\\nNombre del empleado";
        }
        if (txtApePaEmp.Text == "")
        {
            mensaje += "\\nApellido del empleado";
        }
        if (txtDirEmp.Text == "")
        {
            mensaje += "\\nDirección del empleado";
        }
        if (txtNombreUsuEmp.Text == "")
        {
            mensaje += "\\nNombre de usuario";
        }
        if (txtContrasEmp.Text == "")
        {
            mensaje += "\\nContraseña";
        }
        if (txtConfContr.Text == "")
        {
            mensaje += "\\nConfirmar contraseña";
        }
        return mensaje;
    }
    void limpiar()
    {
        txtNombreEmp.Text = "";
        txtApePaEmp.Text = "";
        txtApeMatEmp.Text = "";
        txtCorreoElEmp.Text = "";
        txtTelEmp.Text = "";
        txtDirEmp.Text = "";
        HDDRutaFisica.Text = "";
        imgCargar.ImageUrl = "";
        txtNombreUsuEmp.Text = "";
        txtContrasEmp.Text = "";
        txtConfContr.Text = "";
        txtEdad.Text = "";
        txtSexo.Text = "";
        txtNombreUsuEmp.Enabled = true;
    }
}