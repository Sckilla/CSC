using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflABCEmpleados : System.Web.UI.Page
{
    //copia de la clase
    clsConexiones objDatos = new clsConexiones();
    //declarar un dataset local a la página
    DataSet dsEmpleados;
    //Variable para identificar al producto seleccionado en el ABC
    int claveEmpleado = 0;
    //variables para el manejo de la fotografía
    string ruta = "", foto = "";
    //opciones de contraseña: 0 nuevo registro, 1 mod usuario no contraseña, 2 mod usuario y contraseña
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarDrop();
            Session["keyWord"] = "";
            llenarGrid();
            ocultar.Text = "0";
            ControlContraseña();
        }
    }
    void llenarGrid()
    {
        dsEmpleados = new DataSet();
        if (Session["keyWord"].ToString() != "")
        {
            dsEmpleados = objDatos.BuscarEmpleado(Application["cnn"].ToString(), Session["keyWord"].ToString());
        }
        else
        {
            dsEmpleados = objDatos.ListarEmpleados(Application["cnn"].ToString(), dwlTipoE.SelectedIndex);
        }
        gvEmpleados.DataSource = dsEmpleados;
        gvEmpleados.DataMember = "EmpReg";
        gvEmpleados.DataBind();
    }
    void llenarDrop()
    {
        dsEmpleados = new DataSet();
        dsEmpleados = objDatos.ListarTipoEmpleado(Application["cnn"].ToString());
        dwlTipoE.DataSource = dsEmpleados;
        dwlTipoE.DataMember = "TEmpReg";
        dwlTipoE.DataValueField = "ID";
        dwlTipoE.DataTextField = "TIPO";
        dwlTipoE.DataBind();
        dwlTipoE.Items.Insert(0, "--Selecciona el tipo de empleado--");
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

    protected void imgbLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        limpiar();
    }

    protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string mensaje = validar();
            if (txtContraseñaEmp.Text != txtConfContr.Text)
            {
                mensaje = mensaje + "\\nConfirmar contraseña: es diferente de la contraseña";
            }
            if (mensaje == "")
            {
                string resultado = "";
                resultado = objDatos.RegistrarEmpleado(Application["cnn"].ToString(), dwlTipoE.SelectedIndex, txtSexo.Text, txtNombreEmp.Text, txtApePaEmp.Text, txtApeMatEmp.Text, txtCorreoElEmp.Text, int.Parse(txtEdad.Text), txtTelEmp.Text, txtDirEmp.Text, HDDRutaFisica.Text, txtNombreUsuEmp.Text, txtContrasAEmp.Text);
                if (int.Parse(resultado) == -1)
                {
                    Response.Write("<script language='javascript'>alert('Ya se ha registrado a un usuario con este nombre de usuario');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('El usuario " + txtNombreUsuEmp.Text + " ha sido registrado correctamente');</script>");
                    llenarGrid();
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
            if (txtContraseñaEmp.Text != txtConfContr.Text && ocultar.Text == "0") 
            {
                mensaje = mensaje + "\\nConfirmar contraseña: es diferente de la contraseña";
            }
            if (txtContraseñaEmp.Text != txtConfContr.Text && ocultar.Text == "2") 
            {
                mensaje = mensaje + "\\nConfirmar contraseña: es diferente de la nueva contraseña";
            }
            if (mensaje == "")
            {
                string resultado = "";
                if (ocultar.Text == "0")
                {
                    resultado = objDatos.ModificarEmpleado(Application["cnn"].ToString(), dwlTipoE.SelectedIndex, txtSexo.Text, txtNombreEmp.Text, txtApePaEmp.Text, txtApeMatEmp.Text, txtCorreoElEmp.Text, int.Parse(txtEdad.Text), txtTelEmp.Text, txtDirEmp.Text, HDDRutaFisica.Text, txtNombreUsuEmp.Text, txtContraseñaEmp.Text);
                }
                else if (ocultar.Text == "1")
                {
                    if (txtContraseñaEmp.Text == lblPass.Text)
                    {
                        resultado = objDatos.ModificarEmpleado(Application["cnn"].ToString(), dwlTipoE.SelectedIndex, txtSexo.Text, txtNombreEmp.Text, txtApePaEmp.Text, txtApeMatEmp.Text, txtCorreoElEmp.Text, int.Parse(txtEdad.Text), txtTelEmp.Text, txtDirEmp.Text, HDDRutaFisica.Text, txtNombreUsuEmp.Text, txtContraseñaEmp.Text);
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('La contraseña es incorrecta');</script>");
                        return;
                    }
                }
                else
                {
                    if (txtContrasAEmp.Text == lblPass.Text)
                    {
                        resultado = objDatos.ModificarEmpleado(Application["cnn"].ToString(), dwlTipoE.SelectedIndex, txtSexo.Text, txtNombreEmp.Text, txtApePaEmp.Text, txtApeMatEmp.Text, txtCorreoElEmp.Text, int.Parse(txtEdad.Text), txtTelEmp.Text, txtDirEmp.Text, HDDRutaFisica.Text, txtNombreUsuEmp.Text, txtContraseñaEmp.Text);
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('La contraseña actual es incorrecta');</script>");
                        return;
                    }
                }
                if (int.Parse(resultado) == 1)
                {
                    Response.Write("<script language='javascript'>alert('No se encontró al usuario en la base de datos');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('El usuario " + txtNombreUsuEmp.Text + " ha sido modificado correctamente');</script>");
                    llenarGrid();
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

    protected void imgbBuscar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtbuscarE.Text != "")
            {
                Session["keyWord"] = txtbuscarE.Text;
                dsEmpleados = new DataSet();
                dsEmpleados = objDatos.BuscarEmpleado(Application["cnn"].ToString(), txtbuscarE.Text);
                gvEmpleados.DataSource = dsEmpleados;
                gvEmpleados.DataMember = "EmpReg";
                gvEmpleados.DataBind();
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
        gvEmpleados.PageIndex = e.NewPageIndex;
        llenarGrid();
    }

    protected void gvEmpleado_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string resultado = "";
        try
        {
            resultado = objDatos.EliminarEmpleado(Application["cnn"].ToString(), int.Parse(gvEmpleados.Rows[e.RowIndex].Cells[3].Text.ToString()));
            if (resultado == "0")
            {
                Response.Write("<script language='javascript'>alert('El usuario con clave: " + gvEmpleados.Rows[e.RowIndex].Cells[3].Text.ToString() + " ha sido eliminado');</script>");
                llenarGrid();
                limpiar();
            }
            else if (resultado == "1")
            {
                Response.Write("<script language='javascript'>alert('El usuario con clave: " + gvEmpleados.Rows[e.RowIndex].Cells[3].Text.ToString() + " ya estaba dado de baja');</script>");
            }
            else if (resultado == "2")
            {
                Response.Write("<script language='javascript'>alert('El usuario con clave: " + gvEmpleados.Rows[e.RowIndex].Cells[3].Text.ToString() + " no se encontró');</script>");
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
            claveEmpleado = int.Parse(gvEmpleados.Rows[e.NewSelectedIndex].Cells[3].Text.ToString());
            mostrarDatos(claveEmpleado);
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }


    void mostrarDatos(int clave)
    {
        if (objDatos.DatosEmpleado(Application["cnn"].ToString(), clave) == "1")
        {
            dwlTipoE.SelectedIndex = objDatos.Tipo;
            txtNombreEmp.Text = objDatos.Nombre;
            txtApePaEmp.Text = objDatos.App;
            txtApeMatEmp.Text = objDatos.Apm;
            txtEdad.Text = objDatos.Edad.ToString();
            txtSexo.Text = objDatos.Sexo;
            txtCorreoElEmp.Text = objDatos.Correo;
            txtTelEmp.Text = objDatos.Tel;
            txtDirEmp.Text = objDatos.Dir;
            HDDRutaFisica.Text = objDatos.Foto;
            imgCargar.ImageUrl = HDDRutaFisica.Text;
            txtNombreUsuEmp.Text = objDatos.Usuario;
            lblID.Text = objDatos.Id.ToString();
            lblPass.Text = objDatos.Contraseña;
            txtNombreUsuEmp.ReadOnly = true;
            ocultar.Text = "1";
            ControlContraseña();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Usuario no encontrado.');</script>");
        }
    }
    void limpiar()
    {
        dwlTipoE.SelectedIndex = 0;
        txtNombreEmp.Text = "";
        txtApePaEmp.Text = "";
        txtApeMatEmp.Text = "";
        txtEdad.Text = "";
        txtSexo.Text = "";
        txtCorreoElEmp.Text = "";
        txtTelEmp.Text = "";
        txtDirEmp.Text = "";
        HDDRutaFisica.Text = "";
        imgCargar.ImageUrl = "~/Imagenes/Adusuario.png";
        txtNombreUsuEmp.Text = "";
        txtContrasAEmp.Text = "";
        txtConfContr.Text = "";
        lblID.Text = "";
        txtbuscarE.Text = "";
        txtNombreUsuEmp.ReadOnly = false;
        ocultar.Text = "0";
        ControlContraseña();
        Session["keyWord"] = "";
        llenarGrid();
    }
    string validar()
    {
        string mensaje = "";
        if (dwlTipoE.SelectedIndex <= 0)
        {
            mensaje += "\\nTipo de usuario";
        }
        if (txtNombreEmp.Text == "")
        {
            mensaje += "\\nNombre";
        }
        if (txtApePaEmp.Text == "")
        {
            mensaje += "\\nApellido paterno";
        }
        if (txtEdad.Text == "")
        {
            mensaje += "\\nEdad";
        }
        if (txtDirEmp.Text == "")
        {
            mensaje += "\\nDirección";
        }
        if (txtNombreUsuEmp.Text == "")
        {
            mensaje += "\\nNombre de usuario";
        }
        if (txtContraseñaEmp.Text == "" && ocultar.Text == "0")
        {
            mensaje += "\\nContraseña";
        }
        if (txtContraseñaEmp.Text == "" && ocultar.Text == "1")
        {
            mensaje += "\\nContraseña";
        }
        if (txtContrasAEmp.Text==""&& ocultar.Text == "2")
        {
            mensaje += "\\nContraseña Actual";
        }
        if (txtContraseñaEmp.Text == "" && ocultar.Text == "2")
        {
            mensaje += "\\nNueva Contraseña";
        }
        return mensaje;
    }

    protected void ControlContraseña()
    {
        if (ocultar.Text=="0")
        {
            txtContrasAEmp.Enabled = false;
            txtConfContr.Enabled = true;
            txtContraseñaEmp.Enabled = true;
            lblConfCont.Enabled = true;
            lblContraseñaAc.Enabled = false;
            lblContraseñan.Enabled = true;
            lblContraseñan.Text = "Contraseña";
            lblIPassA.Enabled = false;
            lblIPassN.Enabled = false;
            txtContrasAEmp.Visible = false;
            txtConfContr.Visible = true;
            txtContraseñaEmp.Visible = true;
            lblConfCont.Visible = true;
            lblContraseñaAc.Visible = false;
            lblContraseñan.Visible = true;
            lblIPassA.Visible = false;
            lblIPassN.Visible = false;
            imgbCambiarC.Visible = false;
            imgbCambiarC.Enabled = false;
            imgModificar.Enabled = false;
            imgbGuardar.Enabled = true;
        }
        else if(ocultar.Text=="1")
        {
            txtContrasAEmp.Enabled = false;
            txtConfContr.Enabled = false;
            txtContraseñaEmp.Enabled = true;
            lblConfCont.Enabled = false;
            lblContraseñaAc.Enabled = false;
            lblContraseñan.Text = "Contraseña";
            lblContraseñan.Enabled = true;
            lblIPassA.Enabled = false;
            lblIPassN.Enabled = false;
            txtContrasAEmp.Visible = false;
            txtConfContr.Visible = false;
            txtContraseñaEmp.Visible = true;
            lblConfCont.Visible = false;
            lblContraseñaAc.Visible = false;
            lblContraseñan.Visible = true;
            lblIPassA.Visible = false;
            lblIPassN.Visible = false;
            imgbCambiarC.Visible = true;
            imgbCambiarC.Enabled = true;
            imgModificar.Enabled = true;
            imgbGuardar.Enabled = false;
        }
        else
        {
            txtContrasAEmp.Enabled = true;
            txtConfContr.Enabled = true;
            txtContraseñaEmp.Enabled = true;
            lblConfCont.Enabled = true;
            lblContraseñaAc.Enabled = true;
            lblContraseñan.Enabled = true;
            lblContraseñan.Text = "Nueva Contraseña";
            lblIPassA.Enabled = true;
            lblIPassN.Enabled = true;
            txtContrasAEmp.Visible = true;
            txtConfContr.Visible = true;
            txtContraseñaEmp.Visible = true;
            lblConfCont.Visible = true;
            lblContraseñaAc.Visible = true;
            lblContraseñan.Visible = true;
            lblIPassA.Visible = true;
            lblIPassN.Visible = true;
            imgbCambiarC.Visible = false;
            imgbCambiarC.Enabled = false;
            imgModificar.Enabled = true;
            imgbGuardar.Enabled = false;
        }
    }

    protected void imgbCambiarC_Click(object sender, ImageClickEventArgs e)
    {
        ocultar.Text = "2";
        ControlContraseña();
    }
}