using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflABCClientes : System.Web.UI.Page
{
    clsConexiones objDatos = new clsConexiones();
    DataSet dsClientes;
    int claveCliente = 0;
    string ruta = "", foto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarGrid1();
            Ocultar.Text = "0";
            ActivaControles();
        }
    }
    void llenarGrid1()
    {
        dsClientes = new DataSet();
        dsClientes = objDatos.ListarClientes(Application["cnn"].ToString());
        gvClientes.DataSource = dsClientes;
        gvClientes.DataMember = "CliReg";
        gvClientes.DataBind();
    }
    protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string mensaje = validar();
            if (txtContrasCliN.Text != txtConfContr.Text)
            {
                mensaje = mensaje + "\\nConfirmar contraseña: es diferente de la contraseña";
            }
            if (mensaje == "")
            {
                string resultado = "";
                resultado = objDatos.RegistrarCliente(Application["cnn"].ToString(), txtSexo.Text, txtNombreCli.Text, txtApePaCli.Text, txtApeMatCli.Text, txtCorreoElCli.Text, int.Parse(txtEdad.Text), txtTelCli.Text, txtDirCli.Text, HDDRutaFisica.Text, txtNombreUsuCli.Text, txtContrasCliN.Text);
                if (int.Parse(resultado) == -1)
                {
                    Response.Write("<script language='javascript'>alert('No se ha encontrado al cliente con este nombre de usuario');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('El cliente " + txtNombreUsuCli.Text + " ha sido modificado correctamente');</script>");
                    llenarGrid1();
                    limpiar();
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Los campos obligatorios:" + mensaje + " \\n no han sido llenados correctamente');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al leer la respuesta de la base de datos');</script>");
        }
    }
    protected void imgbModificar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string mensaje = validar();
            if (txtContrasCliN.Text != txtConfContr.Text && Ocultar.Text == "0") 
            {
                mensaje = mensaje + "\\nConfirmar contraseña: es diferente de la contraseña";
            }
            if (txtContrasCliN.Text != txtConfContr.Text && Ocultar.Text == "2")
            {
                mensaje = mensaje + "\\nConfirmar contraseña: es diferente de la nueva contraseña";
            }
            if (mensaje == "")
            {
                string resultado = "";
                if (Ocultar.Text == "0")
                {
                    resultado = objDatos.ModificarCliente(Application["cnn"].ToString(), txtSexo.Text, txtNombreCli.Text, txtApePaCli.Text, txtApeMatCli.Text, txtCorreoElCli.Text, int.Parse(txtEdad.Text), txtTelCli.Text, txtDirCli.Text, HDDRutaFisica.Text, txtNombreUsuCli.Text, txtContrasCliN.Text);
                }
                else if(Ocultar.Text == "1")
                {
                    if (txtContrasCliN.Text == lblPass.Text)
                    {
                        resultado = objDatos.ModificarCliente(Application["cnn"].ToString(), txtSexo.Text, txtNombreCli.Text, txtApePaCli.Text, txtApeMatCli.Text, txtCorreoElCli.Text, int.Parse(txtEdad.Text), txtTelCli.Text, txtDirCli.Text, HDDRutaFisica.Text, txtNombreUsuCli.Text, txtContrasCliN.Text);
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('La contraseña es incorrecta');</script>");
                        return;
                    }
                }
                else
                {
                    if (txtContrasCliA.Text == lblPass.Text)
                    {
                        resultado = objDatos.ModificarCliente(Application["cnn"].ToString(), txtSexo.Text, txtNombreCli.Text, txtApePaCli.Text, txtApeMatCli.Text, txtCorreoElCli.Text, int.Parse(txtEdad.Text), txtTelCli.Text, txtDirCli.Text, HDDRutaFisica.Text, txtNombreUsuCli.Text, txtContrasCliN.Text);
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('La contraseña es incorrecta');</script>");
                        return;
                    }
                }

                if (int.Parse(resultado) == 1)
                {
                    Response.Write("<script language='javascript'>alert('No se ha registrado a un cliente con este nombre de usuario');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('El cliente " + txtNombreUsuCli.Text + " ha sido modificado correctamente');</script>");
                    llenarGrid1();
                    limpiar();
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Los campos obligatorios:" + mensaje + " \\n no han sido llenados correctamente');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al leer la respuesta de la base de datos');</script>");
        }
    }
    protected void imgbLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        limpiar();
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
    protected void imgbBuscar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtbuscarC.Text != "")
            {
                dsClientes = new DataSet();
                dsClientes = objDatos.BuscarCliente(Application["cnn"].ToString(), txtbuscarC.Text);
                gvClientes.DataSource = dsClientes;
                gvClientes.DataMember = "CliReg";
                gvClientes.DataBind();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Cadena de entrada vacía, debe de haber una cadena con la cual comparar');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al leer la respuesta de la base de datos');</script>");
        }
    }

    protected void gvEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClientes.PageIndex = e.NewPageIndex;
        llenarGrid1();
    }
    protected void gvEmpleado_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string resultado = "";
        try
        {
            resultado = objDatos.EliminarCliente(Application["cnn"].ToString(), int.Parse(gvClientes.Rows[e.RowIndex].Cells[3].Text.ToString()));
            if (resultado == "0")
            {
                Response.Write("<script language='javascript'>alert('El usuario con clave: " + gvClientes.Rows[e.RowIndex].Cells[3].Text.ToString() + " ha sido eliminado');</script>");
                llenarGrid1();
                limpiar();
            }
            else if (resultado == "1")
            {
                Response.Write("<script language='javascript'>alert('El usuario con clave: " + gvClientes.Rows[e.RowIndex].Cells[3].Text.ToString() + " ya estaba dado de baja');</script>");
            }
            else if (resultado == "2")
            {
                Response.Write("<script language='javascript'>alert('El usuario con clave: " + gvClientes.Rows[e.RowIndex].Cells[3].Text.ToString() + " no se encontró');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }
    protected void gvEmpleado_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            claveCliente = int.Parse(gvClientes.Rows[e.NewSelectedIndex].Cells[3].Text.ToString());
            mostrarDatos(claveCliente);
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }
    void mostrarDatos(int clave)
    {
        if (objDatos.DatosCliente(Application["cnn"].ToString(), clave) == "1")
        {
            txtNombreCli.Text = objDatos.Nombre;
            txtApePaCli.Text = objDatos.App;
            txtApeMatCli.Text = objDatos.Apm;
            txtEdad.Text = objDatos.Edad.ToString();
            txtSexo.Text = objDatos.Sexo;
            txtCorreoElCli.Text = objDatos.Correo;
            txtTelCli.Text = objDatos.Tel;
            txtDirCli.Text = objDatos.Dir;
            HDDRutaFisica.Text = objDatos.Foto;
            imgCargar.ImageUrl = HDDRutaFisica.Text;
            txtNombreUsuCli.Text = objDatos.Usuario;
            lblID.Text = objDatos.Id.ToString();
            lblPass.Text = objDatos.Contraseña;
            txtNombreUsuCli.ReadOnly = true;
            Ocultar.Text = "1";
            ActivaControles();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Usuario no encontrado.');</script>");
        }
    }
    string validar()
    {
        string mensaje = "";
        if (txtNombreCli.Text == "")
        {
            mensaje += "\\nNombre";
        }
        if (txtApePaCli.Text == "")
        {
            mensaje += "\\nApellido paterno";
        }
        if (txtEdad.Text == "")
        {
            mensaje += "\\nEdad";
        }
        if (txtCorreoElCli.Text == "")
        {
            mensaje += "\\nCorreo electrónico";
        }
        if (txtDirCli.Text == "")
        {
            mensaje += "\\nDirección";
        }
        if (txtNombreUsuCli.Text == "")
        {
            mensaje += "\\nNombre de usuario";
        }
        if (txtContrasCliN.Text == "" && (Ocultar.Text == "0"||Ocultar.Text=="1"))
        {
            mensaje += "\\nContraseña";
        }
        if (txtContrasCliA.Text == "" && Ocultar.Text == "2")
        {
            mensaje += "\\nContraseña actual";
        }
        if (txtContrasCliN.Text == "" && Ocultar.Text == "2")
        {
            mensaje += "\\nNueva contraseña";
        }
        return mensaje;
    }
    void limpiar()
    {
        txtNombreCli.Text = "";
        txtApePaCli.Text = "";
        txtApeMatCli.Text = "";
        txtEdad.Text = "";
        txtSexo.Text = "";
        txtCorreoElCli.Text = "";
        txtTelCli.Text = "";
        txtDirCli.Text = "";
        HDDRutaFisica.Text = "";
        imgCargar.ImageUrl = "~/Imagenes/Adusuario.png";
        txtNombreUsuCli.Text = "";
        txtContrasCliN.Text = "";
        txtConfContr.Text = "";
        lblID.Text = "";
        txtNombreUsuCli.ReadOnly = false;
        Ocultar.Text = "0";
        ActivaControles();
    }

    protected void ActivaControles()
    {
        if (Ocultar.Text == "0")//registro nuevo
        {
            lblContraseñaA.Enabled = false;
            lblContraseñaA.Visible = false;
            lblContraseñaN.Text = "Contraseña";
            lblContraseñaN.Enabled = true;
            lblContraseñaN.Visible = true;
            lblConfC.Enabled = true;
            lblConfC.Visible = true;
            lblIContA.Enabled = false;
            lblIContA.Visible = false;
            lblIContN.Enabled = false;
            lblIContN.Visible = false;
            txtContrasCliA.Enabled = false;
            txtContrasCliA.Visible = false;
            txtContrasCliN.Enabled = true;
            txtContrasCliN.Visible = true;
            txtConfContr.Enabled = true;
            txtConfContr.Visible = true;
            imgModificar.Enabled = false;
            imgbGuardar.Enabled = true;
            imgbCambiarC.Enabled = false;
            imgbCambiarC.Visible = false;
        }
        else if(Ocultar.Text == "1")//modificar
        {
            lblContraseñaA.Enabled = false;
            lblContraseñaA.Visible = false;
            lblContraseñaN.Text = "Contraseña";
            lblContraseñaN.Enabled = true;
            lblContraseñaN.Visible = true;
            lblConfC.Enabled = false;
            lblConfC.Visible = false;
            lblIContA.Enabled = false;
            lblIContA.Visible = false;
            lblIContN.Enabled = false;
            lblIContN.Visible = false;
            txtContrasCliA.Enabled = false;
            txtContrasCliA.Visible = false;
            txtContrasCliN.Enabled = true;
            txtContrasCliN.Visible = true;
            txtConfContr.Enabled = false;
            txtConfContr.Visible = false;
            imgModificar.Enabled = true;
            imgbGuardar.Enabled = false;
            imgbCambiarC.Enabled = true;
            imgbCambiarC.Visible = true;
        }
        else//modificar con contraseña
        {
            lblContraseñaA.Enabled = true;
            lblContraseñaA.Visible = true;
            lblContraseñaN.Text = "Nueva Contraseña";
            lblContraseñaN.Enabled = true;
            lblContraseñaN.Visible = true;
            lblConfC.Enabled = true;
            lblConfC.Visible = true;
            lblIContA.Enabled = true;
            lblIContA.Visible = true;
            lblIContN.Enabled = true;
            lblIContN.Visible = true;
            txtContrasCliA.Enabled = true;
            txtContrasCliA.Visible = true;
            txtContrasCliN.Enabled = true;
            txtContrasCliN.Visible = true;
            txtConfContr.Enabled = true;
            txtConfContr.Visible = true;
            imgModificar.Enabled = true;
            imgbGuardar.Enabled = false;
            imgbCambiarC.Enabled = false;
            imgbCambiarC.Visible = false;
        }
    }

    protected void imgbCambiarC_Click(object sender, ImageClickEventArgs e)
    {
        Ocultar.Text = "2";
        ActivaControles();
    }
}