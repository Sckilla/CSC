using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dflABCTipProductos : System.Web.UI.Page
{
    //copia de la clase
    clsConexiones objDatos = new clsConexiones();
    //declarar un dataset local a la página
    DataSet dsProductos;
    int idtp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarDrop();
            Session["keyWord"] = "";
            Session["Aux"] = "1";
            LlenarGrid();
        }
    }

    protected void imgbLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
    }

    protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
    {
        string msg = validar();
        try
        {
            char stat = char.Parse((dwlEstatus.SelectedIndex - 1).ToString());
            if (objDatos.RegistrarTProducto(Application["cnn"].ToString(), txtTipoProd.Text, txtDescrip.Text, stat ) == "0")
            {
                Response.Write("<script language='javascript'>alert('El registro se completó correctamente');</script>");
                Limpiar();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Ya ha sido registrado un tipo de producto con ese nombre');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ocurrió un error al registrar el tipo de producto, intentelo más tarde');</script>");
        }
    }

    protected void imgbModificar_Click(object sender, ImageClickEventArgs e)
    {
        string msg = validar();
        try
        {
            char stat = char.Parse((dwlEstatus.SelectedIndex - 1).ToString());
            if (objDatos.ModificarTProducto(Application["cnn"].ToString(), int.Parse(lblID.Text.ToString()), txtTipoProd.Text, txtDescrip.Text, stat) == "0")
            {
                Response.Write("<script language='javascript'>alert('La modificación se completó correctamente');</script>");
                Limpiar();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Ya ha sido registrado un tipo de producto con ese nombre');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ocurrió un error al modificar el tipo de producto, intentelo más tarde');</script>");
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
                    dsProductos = objDatos.BuscarTProducto(Application["cnn"].ToString(), txtbuscarP.Text, 0);
                    Session["Aux"] = "0";
                }
                else
                {
                    dsProductos = objDatos.BuscarTProducto(Application["cnn"].ToString(), txtbuscarP.Text, 1);
                    Session["Aux"] = "1";
                }
                gvTProductos.DataSource = dsProductos;
                gvTProductos.DataMember = "TProdReg";
                gvTProductos.DataBind();
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

    protected void gvTProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string resultado = "";
        try
        {
            resultado = objDatos.EliminarTProducto(Application["cnn"].ToString(), int.Parse(gvTProductos.Rows[e.RowIndex].Cells[2].Text.ToString()));
            if (resultado == "0")
            {
                Response.Write("<script language='javascript'>alert('El tipo de producto con clave: " + gvTProductos.Rows[e.RowIndex].Cells[2].Text.ToString() + " ha sido eliminado');</script>");
                Limpiar();
            }
            else if (resultado == "1")
            {
                Response.Write("<script language='javascript'>alert('El tipo de producto con clave: " + gvTProductos.Rows[e.RowIndex].Cells[2].Text.ToString() + " ya estaba dado de baja');</script>");
            }
            else if (resultado == "2")
            {
                Response.Write("<script language='javascript'>alert('El tipo de producto con clave: " + gvTProductos.Rows[e.RowIndex].Cells[2].Text.ToString() + " no se encontró');</script>");
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }

    protected void gvTProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            idtp = int.Parse(gvTProductos.Rows[e.NewSelectedIndex].Cells[2].Text.ToString());
            lblID.Text = idtp.ToString();
            MostrarDatos(idtp);
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al obtener el indice de la tabla');</script>");
        }
    }

    void MostrarDatos(int cve)
    {
        if (objDatos.DatosTProducto(Application["cnn"].ToString(), cve) == "1")
        {
            dwlEstatus.SelectedIndex = objDatos.Baja + 1;
            txtDescrip.Text = objDatos.Descrip;
            txtTipoProd.Text = objDatos.TIPO;
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Registro no encontrado.');</script>");
        }
    }

    void LlenarDrop()
    {
        dwlEstatus.Items.Insert(0, "--Selecciona el estatus--");
        dwlEstatus.Items.Insert(1, "Alta");
        dwlEstatus.Items.Insert(2, "Baja");
    }
    
    void LlenarGrid()
    {
        dsProductos = new DataSet();
        if (Session["keyWord"].ToString() != "")
        {
            dsProductos = objDatos.BuscarTProducto(Application["cnn"].ToString(), Session["keyWord"].ToString(), int.Parse(Session["Aux"].ToString()));
        }
        else
        {
            dsProductos = objDatos.ListarTipoProd(Application["cnn"].ToString());
        }
        gvTProductos.DataSource = dsProductos;
        gvTProductos.DataMember = "TProdReg";
        gvTProductos.DataBind();
    }
    
    void Limpiar()
    {
        dwlEstatus.SelectedIndex = 0;
        txtbuscarP.Text = "";
        txtDescrip.Text = "";
        txtTipoProd.Text = "";
        Session["keyWord"] = "";
        Session["Aux"] = "1";
        LlenarGrid();
    }

    string validar()
    {
        string mensaje = "";
        if (dwlEstatus.SelectedIndex <= 0)
        {
            mensaje += "\\nEstatus";
        }
        if (txtTipoProd.Text == "")
        {
            mensaje += "\\nNombre del tipo de producto";
        }
        return mensaje;
    }

    protected void gvTProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTProductos.PageIndex = e.NewPageIndex;
        LlenarGrid();
    }
}