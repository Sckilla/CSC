using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class dflABCOfertas : System.Web.UI.Page
{
    //copia de la clase
    clsConexiones objDatos = new clsConexiones();
    //declarar un dataset local a la página
    DataSet dsProductos;
    //Variable para identificar al producto seleccionado en el ABC
    int clave = 0;
    //variables para el manejo de la fotografía
    string ruta = "", foto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarDrop();
            Session["keyWord"] = "";
            llenarGrid();
            imgModificar.Enabled = false;
        }
    }
    void llenarGrid()
    {
        dsProductos = new DataSet();
        if (Session["keyWord"].ToString() != "")
        {
            dsProductos = objDatos.BuscarOfertas(Application["cnn"].ToString(), Session["keyWord"].ToString());
        }
        else
        {
            dsProductos = objDatos.ListarOfertas(Application["cnn"].ToString(), 0);
        }
        gvProductos.DataSource = dsProductos;
        gvProductos.DataMember = "OffReg";
        gvProductos.DataBind();
    }
    void llenarDrop()
    {
        ddlEstatus.Items.Insert(0, "--Selecciona el estatus--");
        ddlEstatus.Items.Insert(1, "Alta");
        ddlEstatus.Items.Insert(2, "Baja");
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
                float razon = float.Parse(txtRazon.Text) / 100;
                char baja = char.Parse((ddlEstatus.SelectedIndex - 1).ToString());
                resultado = objDatos.RegistrarOferta(Application["cnn"].ToString(), txtNombreOfer.Text, txtDescrip.Text, razon, HDDRutaFisica.Text, baja);
                if (int.Parse(resultado) != 0)
                {
                    Response.Write("<script language='javascript'>alert('Ya se ha registrado a una oferta con este nombre y código');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('La oferta " + txtNombreOfer.Text + " ha sido registrado correctamente');</script>");
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
                float razon = float.Parse(txtRazon.Text) / 100;
                char baja = char.Parse((ddlEstatus.SelectedIndex - 1).ToString());
                resultado = objDatos.ModificarOferta(Application["cnn"].ToString(), int.Parse(lblID.Text), txtDescrip.Text, razon, HDDRutaFisica.Text, baja);
                if (int.Parse(resultado) == 0)
                {
                    Response.Write("<script language='javascript'>alert('El producto ha sido modificado correctamente');</script>");
                    llenarGrid();
                    limpiar();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('El nombre del producto no se encontró en la base de datos');</script>");
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
                dsProductos = objDatos.BuscarOfertas(Application["cnn"].ToString(), txtbuscarP.Text);
                gvProductos.DataSource = dsProductos;
                gvProductos.DataMember = "OffReg";
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
            resultado = objDatos.BajaOferta(Application["cnn"].ToString(), int.Parse(gvProductos.Rows[e.RowIndex].Cells[3].Text.ToString()));
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
            clave = int.Parse(gvProductos.Rows[e.NewSelectedIndex].Cells[3].Text.ToString());
            mostrarDatos(clave);
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }
    void mostrarDatos(int clave)
    {
        if (objDatos.DatosOferta(Application["cnn"].ToString(), clave) == "1")
        {
            txtNombreOfer.Text = objDatos.Nombre;
            txtDescrip.Text = objDatos.Descrip;
            HDDRutaFisica.Text = objDatos.Foto;
            imgCargar.ImageUrl = HDDRutaFisica.Text;
            txtRazon.Text = (objDatos.Precio * 100).ToString();
            ddlEstatus.SelectedIndex = objDatos.Baja + 1;
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
        txtNombreOfer.Text = "";
        txtDescrip.Text = "";
        HDDRutaFisica.Text = "";
        imgCargar.ImageUrl = "~/Imagenes/promo.png";
        txtRazon.Text = "";
        ddlEstatus.SelectedIndex = 0;
        lblID.Text = "";
        txtbuscarP.Text = "";
        Session["keyWord"] = "";
        imgModificar.Enabled = false;
        llenarGrid();
    }
    string validar()
    {
        string mensaje = "";
        if (txtNombreOfer.Text == "")
        {
            mensaje += "\\nNombre del producto";
        }
        if (txtRazon.Text == "")
        {
            mensaje += "\\nRazón";
        }
        if (ddlEstatus.SelectedIndex == 0)
        {
            mensaje += "\\nEstatus";
        }
        if (txtRazon.Text == "")
        {
            mensaje += "\\nRazón";
        }
        return mensaje;
    }
}