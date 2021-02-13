using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflEditarProdE : System.Web.UI.Page
{
    //copia de la clase
    clsConexiones objDatos = new clsConexiones();
    //declarar un dataset local a la página
    DataSet dsProductos;
    //Variable para identificar al producto seleccionado en el ABC
    int claveProducto = 0;
    //variables para el manejo de la fotografía
    string ruta = "", foto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarDrop();
            Session["keyWord"] = "";
            Session["Aux"] = "1";
            llenarGrid();
            imgModificar.Enabled = false;
        }
    }
    void llenarGrid()
    {
        dsProductos = new DataSet();
        if (Session["keyWord"].ToString() != "")
        {
            dsProductos = objDatos.BuscarProducto(Application["cnn"].ToString(), Session["keyWord"].ToString(), int.Parse(Session["Aux"].ToString()));
        }
        else
        {
            dsProductos = objDatos.ListarProductos(Application["cnn"].ToString(), 0);
        }
        gvProductos.DataSource = dsProductos;
        gvProductos.DataMember = "ProdReg";
        gvProductos.DataBind();
    }
    void llenarDrop()
    {
        dsProductos = new DataSet();
        dsProductos = objDatos.ListarTipoProd(Application["cnn"].ToString());
        dwlTipop.DataSource = dsProductos;
        dwlTipop.DataMember = "TProdReg";
        dwlTipop.DataValueField = "ID";
        dwlTipop.DataTextField = "TIPO";
        dwlTipop.DataBind();
        dwlTipop.Items.Insert(0, "--Selecciona el tipo de producto--");

        ddlEstatus.Items.Insert(0, "--Selecciona el estatus--");
        ddlEstatus.Items.Insert(1, "Alta");
        ddlEstatus.Items.Insert(2, "Baja");

        ddlPresentacion.Items.Insert(0, "--Selecciona la presentación--");
        ddlPresentacion.Items.Insert(1, "Pz");
        ddlPresentacion.Items.Insert(2, "Kg");
        ddlPresentacion.Items.Insert(3, "Lt");
        dsProductos = new DataSet();
        dsProductos = objDatos.ListarOfertas(Application["cnn"].ToString(), 1);
        ddlOferta.DataSource = dsProductos;
        ddlOferta.DataMember = "OffReg";
        ddlOferta.DataTextField = "NOMBRE";
        ddlOferta.DataValueField = "ID";
        ddlOferta.DataBind();
        ddlOferta.Items.Insert(0, "--Selecciona una oferta--");
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
            if (mensaje == "")
            {
                string resultado = "";
                char baja = char.Parse((ddlEstatus.SelectedIndex - 1).ToString());
                resultado = objDatos.RegistrarProducto(Application["cnn"].ToString(), int.Parse(dwlTipop.SelectedValue.ToString()), txtCodigo.Text, txtNombreProd.Text, txtDescrip.Text, ddlPresentacion.Text, HDDRutaFisica.Text, float.Parse(txtPrecio.Text), int.Parse(ddlOferta.SelectedValue), int.Parse(txtExist.Text), baja);
                if (int.Parse(resultado) != 0)
                {
                    if (int.Parse(resultado) == 2)
                    {
                        Response.Write("<script language='javascript'>alert('Ya se ha registrado a un producto con este nombre y código');</script>");
                    }
                    else
                    {
                        if (int.Parse(resultado) == 1)
                        {
                            Response.Write("<script language='javascript'>alert('Ya se ha registrado a un producto con este nombre');</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('Ya se ha registrado a un producto con este código');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('El producto " + txtNombreProd.Text + " ha sido registrado correctamente');</script>");
                    llenarGrid();
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
    protected void imgbModificar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string mensaje = validar();
            if (mensaje == "")
            {
                string resultado = "";
                char baja = char.Parse((ddlEstatus.SelectedIndex - 1).ToString());
                resultado = objDatos.ModificarProducto(Application["cnn"].ToString(), int.Parse(lblID.Text), int.Parse(dwlTipop.SelectedValue.ToString()), txtCodigo.Text, txtNombreProd.Text, txtDescrip.Text, ddlPresentacion.Text, HDDRutaFisica.Text, float.Parse(txtPrecio.Text), int.Parse(ddlOferta.SelectedValue), int.Parse(txtExist.Text), baja);
                if (int.Parse(resultado) == 0)
                {
                    Response.Write("<script language='javascript'>alert('El producto ha sido modificado correctamente');</script>");
                    llenarGrid();
                    limpiar();
                }
                else
                {
                    if (int.Parse(resultado) == 4)
                    {
                        Response.Write("<script language='javascript'>alert('El nombre del producto no se encontró en la base de datos');</script>");
                    }
                    else if (int.Parse(resultado) == 1)
                    {
                        Response.Write("<script language='javascript'>alert('Ya existe un producto con este código');</script>");
                    }
                    else if (int.Parse(resultado) == 3)
                    {
                        Response.Write("<script language='javascript'>alert('Ya existe un producto con este nombre');</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Ya existe un producto con este nombre y código');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Los campos obligatorios:" + mensaje + "\\n no han sido llenados');</script>");
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
            if (txtbuscarP.Text != "")
            {
                Session["keyWord"] = txtbuscarP.Text;
                dsProductos = new DataSet();
                if (cbBajas.Checked)
                {
                    dsProductos = objDatos.BuscarProducto(Application["cnn"].ToString(), txtbuscarP.Text, 0);
                    Session["Aux"] = "0";
                }
                else
                {
                    dsProductos = objDatos.BuscarProducto(Application["cnn"].ToString(), txtbuscarP.Text, 1);
                    Session["Aux"] = "1";
                }
                gvProductos.DataSource = dsProductos;
                gvProductos.DataMember = "ProdReg";
                gvProductos.DataBind();
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
    protected void imgCargar_Click(object sender, ImageClickEventArgs e)
    {
        if (fluCargarFoto.HasFile)
        {
            ruta = "";
            foto = "";
            ruta = Server.MapPath("~/Productos/");

            fluCargarFoto.PostedFile.SaveAs(ruta + fluCargarFoto.FileName);

            foto = fluCargarFoto.FileName;

            imgCargar.ImageUrl = "Productos/" + foto;
            imgCargar.ImageAlign = ImageAlign.Middle;

            HDDRutaFisica.Text = "Productos/" + foto;
        }
    }


    protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProductos.PageIndex = e.NewPageIndex;
        llenarGrid();
    }
    protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string resultado = "";
        try
        {
            resultado = objDatos.EliminarProducto(Application["cnn"].ToString(), int.Parse(gvProductos.Rows[e.RowIndex].Cells[3].Text.ToString()));
            if (resultado == "0")
            {
                Response.Write("<script language='javascript'>alert('El producto con clave: " + gvProductos.Rows[e.RowIndex].Cells[3].Text.ToString() + " ha sido eliminado');</script>");
                llenarGrid();
                limpiar();
            }
            else if (resultado == "1")
            {
                Response.Write("<script language='javascript'>alert('El producto con clave: " + gvProductos.Rows[e.RowIndex].Cells[3].Text.ToString() + " ya estaba dado de baja');</script>");
            }
            else if (resultado == "2")
            {
                Response.Write("<script language='javascript'>alert('El producto con clave: " + gvProductos.Rows[e.RowIndex].Cells[3].Text.ToString() + " no se encontró');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }
    protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            claveProducto = int.Parse(gvProductos.Rows[e.NewSelectedIndex].Cells[3].Text.ToString());
            mostrarDatos(claveProducto);
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }
    void mostrarDatos(int clave)
    {
        if (objDatos.DatosProducto(Application["cnn"].ToString(), clave) == "1")
        {
            for (int i = 0; i < dwlTipop.Items.Count; i++)
            {
                dwlTipop.SelectedIndex = i;
                if (dwlTipop.SelectedValue == objDatos.Tipo.ToString())
                {
                    break;
                }
            }
            for (int i = 0; i < ddlOferta.Items.Count; i++)
            {
                ddlOferta.SelectedIndex = i;
                if (ddlOferta.SelectedValue == objDatos.Oferta.ToString())
                {
                    break;
                }
            }
            txtNombreProd.Text = objDatos.Nombre;
            txtDescrip.Text = objDatos.Descrip;
            ddlPresentacion.Text = objDatos.Present;
            HDDRutaFisica.Text = objDatos.Foto;
            imgCargar.ImageUrl = HDDRutaFisica.Text;
            txtPrecio.Text = objDatos.Precio.ToString("0.00");
            txtExist.Text = objDatos.Exist.ToString();
            ddlEstatus.SelectedIndex = objDatos.Baja + 1;
            txtCodigo.Text = objDatos.Codigo.ToString();
            lblID.Text = objDatos.Id.ToString();
            imgModificar.Enabled = true;
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Usuario no encontrado.');</script>");
        }
    }
    void limpiar()
    {
        dwlTipop.SelectedIndex = 0;
        txtNombreProd.Text = "";
        txtDescrip.Text = "";
        ddlPresentacion.SelectedIndex = 0;
        ddlOferta.SelectedIndex = 0;
        HDDRutaFisica.Text = "";
        imgCargar.ImageUrl = "~/Imagenes/prod.png";
        txtPrecio.Text = "";
        txtExist.Text = "";
        ddlEstatus.SelectedIndex = 0;
        txtCodigo.Text = "";
        lblID.Text = "";
        txtbuscarP.Text = "";
        Session["keyWord"] = "";
        Session["Aux"] = "1";
        imgModificar.Enabled = false;
        llenarGrid();
    }
    string validar()
    {
        string mensaje = "";
        if (dwlTipop.SelectedIndex <= 0)
        {
            mensaje += "\\nTipo de producto";
        }
        if (ddlOferta.SelectedIndex <= 0)
        {
            mensaje += "\\nEstado de oferta";
        }
        if (txtNombreProd.Text == "")
        {
            mensaje += "\\nNombre del producto";
        }
        if (ddlPresentacion.SelectedIndex == 0)
        {
            mensaje += "\\nPresentacion";
        }
        if (txtPrecio.Text == "")
        {
            mensaje += "\\nPrecio";
        }
        if (ddlEstatus.SelectedIndex == 0)
        {
            mensaje += "\\nEstatus";
        }
        if (txtCodigo.Text == "")
        {
            mensaje += "\\nCódigo";
        }
        if (txtExist.Text == "")
        {
            mensaje += "\\nExistencia";
        }
        return mensaje;
    }
}