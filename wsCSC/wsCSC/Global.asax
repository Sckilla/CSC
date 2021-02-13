<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse la aplicación
        Application["cnn"] = ConfigurationManager.ConnectionStrings["cnnCSCBD"].ConnectionString;
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión
        Session["nombreUsu"] = "";
        Session["cveUsu"] = 0;//clave de usuario store
        Session["numUsu"] = 0;//numero de usuario activo en la plataforma
        Session["rolUsu"] = "";
        Session["prodId"] = 0;
        Session["keyWord"] = "";
        Session["Aux"] = "";
        Session["Det"] = "0";//DETALLE DE VENTA
        Session["MetE"] = 0;//METODO DE ENVIO
        Session["MetP"] = 0;//METODO DE PAGO
        Session["Subtotal"] = "";
        Session["Total"] = "";
        Session["IdP"] = 0;
        Session["CveVenta"] = "";
        Session["ControlP"] = 1;
    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.
        clsConexiones obj = new clsConexiones();
        if (Session["rolUsu"].ToString() == "CLIENTE")
        {
            obj.BajaCarrito(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()),'0');
        }
        else
        {
            obj.BajaCarrito(Application["cnn"].ToString(), int.Parse(Session["cveUsu"].ToString()),'1');
        }
    }

</script>
