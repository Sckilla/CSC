using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de clsConexiones
/// </summary>
public class clsConexiones
{
    public string Nombre;
    public string App;
    public string Apm;
    public string Rol;
    public string Usuario;
    public string Contraseña;
    public string Correo;
    public string Tel;
    public string Dir;
    public string Foto;
    public string Sexo;
    public string Codigo;
    public string TIPO;//tipo en cadena
    public string Descrip;
    public string Present;
    public int Baja;
    public int Tipo;//tipo en número
    public int CveUsua;
    public int Edad;
    public int Id;
    public int Exist;
    public int Oferta;
    public float Precio;
    public float PrecioF;


    SqlCommand cmd;
    public SqlConnection cnn;
    SqlDataReader dr;
    public SqlDataAdapter da;
    public DataSet ds;
    string resultadoConsulta = "";

    public clsConexiones()
    {
        Nombre = "";
        App = "";
        Apm = "";
        Rol = "";
        Usuario = "";
        Contraseña = "";
        Correo = "";
        Tel = "";
        Dir = "";
        Foto = "";
        Sexo = "";
        Codigo = "";
        Descrip = "";
        Present = "";
        Baja = 0;
        CveUsua = 0;
        Edad = 0;
        Tipo = 0;
        Id = 0;
        Exist = 0;
        Oferta = 0;
        Precio = 0;
    }
    ~clsConexiones()
    {
        System.GC.Collect();
    }


    public string Login(string usu, string psw, string cn)
    {
        resultadoConsulta = "-1";
        cnn = new SqlConnection(cn);
        //establecer el procedimiento a ejecutar
        cmd = new SqlCommand("TSP_Login", cnn);
        SqlParameter nusu = cmd.Parameters.Add("@USU", SqlDbType.NVarChar, 8);
        SqlParameter npass = cmd.Parameters.Add("@PAS", SqlDbType.NVarChar, 15);
        cmd.CommandType = CommandType.StoredProcedure;
        //asignar valor a los parámetros
        nusu.Value = usu;
        npass.Value = psw;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            //asigna el resultado de la consulta a una variable
            resultadoConsulta = dr.GetValue(0).ToString();
            if (resultadoConsulta != "-1")
            {
                //se obtienen datos con el GetValue con indice de los campos del registro
                Rol = dr.GetValue(1).ToString();
                CveUsua = int.Parse(dr.GetValue(2).ToString());
                Nombre = dr.GetValue(3).ToString();
            }
        }
        cnn.Close();
        return resultadoConsulta;
    }


    //CLIENTES
    public DataSet ListarClientes(string con)
    {
        da = new SqlDataAdapter("TSP_ListarClientes", con);
        ds = new DataSet();
        da.Fill(ds, "CliReg");
        return ds;
    }
    public DataSet BuscarCliente(string con, string wordkey)
    {
        wordkey = "%" + wordkey + "%";
        da = new SqlDataAdapter("TSP_BuscarCliente '" + wordkey + "'", con);
        ds = new DataSet();
        da.Fill(ds, "CliReg");
        return ds;
    }
    public string RegistrarCliente(string con, string sexo, string cli, string aPat, string aMat, string email, int edad, string tel, string dir, string foto, string usu, string pas)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegCliente", cnn);
        SqlParameter empb = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 60);
        empb.Value = cli;
        SqlParameter apatb = cmd.Parameters.Add("@APE_PAT", SqlDbType.VarChar, 60);
        apatb.Value = aPat;
        SqlParameter amatb = cmd.Parameters.Add("@APE_MAT", SqlDbType.VarChar, 60);
        amatb.Value = aMat;
        SqlParameter sexb = cmd.Parameters.Add("@SEXO", SqlDbType.VarChar, 9);
        sexb.Value = sexo;
        SqlParameter emailb = cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 80);
        emailb.Value = email;
        SqlParameter edadb = cmd.Parameters.Add("@EDAD", SqlDbType.Int, 4);
        edadb.Value = edad;
        SqlParameter telb = cmd.Parameters.Add("@TEL", SqlDbType.VarChar, 60);
        telb.Value = tel;
        SqlParameter dirb = cmd.Parameters.Add("@DIR", SqlDbType.VarChar, 60);
        dirb.Value = dir;
        SqlParameter fotob = cmd.Parameters.Add("@FOTO", SqlDbType.NVarChar, 1000);
        fotob.Value = foto;
        SqlParameter usub = cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 8);
        usub.Value = usu;
        SqlParameter pasb = cmd.Parameters.Add("@PAS", SqlDbType.VarChar, 15);
        pasb.Value = pas;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ModificarCliente(string con, string sexo, string emp, string aPat, string aMat, string email, int edad, string tel, string dir, string foto, string usu, string pas)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_ModificarCliente", cnn);
        SqlParameter empb = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 60);
        empb.Value = emp;
        SqlParameter apatb = cmd.Parameters.Add("@APE_PAT", SqlDbType.VarChar, 60);
        apatb.Value = aPat;
        SqlParameter amatb = cmd.Parameters.Add("@APE_MAT", SqlDbType.VarChar, 60);
        amatb.Value = aMat;
        SqlParameter sexb = cmd.Parameters.Add("@SEXO", SqlDbType.VarChar, 9);
        sexb.Value = sexo;
        SqlParameter emailb = cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 80);
        emailb.Value = email;
        SqlParameter edadb = cmd.Parameters.Add("@EDAD", SqlDbType.Int, 4);
        edadb.Value = edad;
        SqlParameter telb = cmd.Parameters.Add("@TEL", SqlDbType.VarChar, 60);
        telb.Value = tel;
        SqlParameter dirb = cmd.Parameters.Add("@DIR", SqlDbType.VarChar, 60);
        dirb.Value = dir;
        SqlParameter fotob = cmd.Parameters.Add("@FOTO", SqlDbType.NVarChar, 1000);
        fotob.Value = foto;
        SqlParameter usub = cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 8);
        usub.Value = usu;
        SqlParameter pasb = cmd.Parameters.Add("@PAS", SqlDbType.VarChar, 15);
        pasb.Value = pas;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string EliminarCliente(string con, int id)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_EliminarCliente", cnn);
        SqlParameter edadb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        edadb.Value = id;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string DatosCliente(string con, int id)
    {
        resultadoConsulta = "0";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DatosCliente", cnn);
        SqlParameter idb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        idb.Value = id;
        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = "1";
            Id = int.Parse(dr.GetValue(0).ToString());
            Nombre = dr.GetValue(1).ToString();
            App = dr.GetValue(2).ToString();
            Apm = dr.GetValue(3).ToString();
            Edad = int.Parse(dr.GetValue(4).ToString());
            Sexo = dr.GetValue(5).ToString();
            Correo = dr.GetValue(6).ToString();
            Tel = dr.GetValue(7).ToString();
            Dir = dr.GetValue(8).ToString();
            Foto = dr.GetValue(9).ToString();
            Usuario = dr.GetValue(10).ToString();
            Contraseña = dr.GetValue(11).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }

    //USUARIOS
    public DataSet ListarEmpleados(string con, int tipo)
    {
        da = new SqlDataAdapter("TSP_ListarEmpleados " + tipo, con);
        ds = new DataSet();
        da.Fill(ds, "EmpReg");
        return ds;
    }
    public DataSet ListarTipoEmpleado(string con)
    {
        da = new SqlDataAdapter("TSP_ListarTipoEmp", con);
        ds = new DataSet();
        da.Fill(ds, "TEmpReg");
        return ds;
    }
    public DataSet BuscarEmpleado(string con, string wordkey)
    {
        wordkey = "%" + wordkey + "%";
        da = new SqlDataAdapter("TSP_BuscarEmpleado '" + wordkey + "'", con);
        ds = new DataSet();
        da.Fill(ds, "EmpReg");
        return ds;
    }
    public string RegistrarEmpleado(string con, int tipo, string sexo, string emp, string aPat, string aMat, string email, int edad, string tel, string dir, string foto, string usu, string pas)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegEmpleado", cnn);
        SqlParameter tipob = cmd.Parameters.Add("@TIPO", SqlDbType.Int, 4);
        tipob.Value = tipo;
        SqlParameter empb = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 60);
        empb.Value = emp;
        SqlParameter apatb = cmd.Parameters.Add("@APE_PAT", SqlDbType.VarChar, 60);
        apatb.Value = aPat;
        SqlParameter amatb = cmd.Parameters.Add("@APE_MAT", SqlDbType.VarChar, 60);
        amatb.Value = aMat;
        SqlParameter sexb = cmd.Parameters.Add("@SEXO", SqlDbType.VarChar, 9);
        sexb.Value = sexo;
        SqlParameter emailb = cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 80);
        emailb.Value = email;
        SqlParameter edadb = cmd.Parameters.Add("@EDAD", SqlDbType.Int, 4);
        edadb.Value = edad;
        SqlParameter telb = cmd.Parameters.Add("@TEL", SqlDbType.VarChar, 60);
        telb.Value = tel;
        SqlParameter dirb = cmd.Parameters.Add("@DIR", SqlDbType.VarChar, 60);
        dirb.Value = dir;
        SqlParameter fotob = cmd.Parameters.Add("@FOTO", SqlDbType.NVarChar, 1000);
        fotob.Value = foto;
        SqlParameter usub = cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 8);
        usub.Value = usu;
        SqlParameter pasb = cmd.Parameters.Add("@PAS", SqlDbType.VarChar, 15);
        pasb.Value = pas;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ModificarEmpleado(string con, int tipo, string sexo, string emp, string aPat, string aMat, string email, int edad, string tel, string dir, string foto, string usu, string pas)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_ModificarEmpleado", cnn);
        SqlParameter tipob = cmd.Parameters.Add("@TIPO", SqlDbType.Int, 4);
        tipob.Value = tipo;
        SqlParameter empb = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 60);
        empb.Value = emp;
        SqlParameter apatb = cmd.Parameters.Add("@APE_PAT", SqlDbType.VarChar, 60);
        apatb.Value = aPat;
        SqlParameter amatb = cmd.Parameters.Add("@APE_MAT", SqlDbType.VarChar, 60);
        amatb.Value = aMat;
        SqlParameter sexb = cmd.Parameters.Add("@SEXO", SqlDbType.VarChar, 9);
        sexb.Value = sexo;
        SqlParameter emailb = cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 80);
        emailb.Value = email;
        SqlParameter edadb = cmd.Parameters.Add("@EDAD", SqlDbType.Int, 4);
        edadb.Value = edad;
        SqlParameter telb = cmd.Parameters.Add("@TEL", SqlDbType.VarChar, 60);
        telb.Value = tel;
        SqlParameter dirb = cmd.Parameters.Add("@DIR", SqlDbType.VarChar, 60);
        dirb.Value = dir;
        SqlParameter fotob = cmd.Parameters.Add("@FOTO", SqlDbType.NVarChar, 1000);
        fotob.Value = foto;
        SqlParameter usub = cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 8);
        usub.Value = usu;
        SqlParameter pasb = cmd.Parameters.Add("@PAS", SqlDbType.VarChar, 15);
        pasb.Value = pas;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string EliminarEmpleado(string con, int id)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_EliminarEmpleado", cnn);
        SqlParameter edadb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        edadb.Value = id;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string DatosEmpleado(string con, int id)
    {
        resultadoConsulta = "0";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DatosEmpleado", cnn);
        SqlParameter edadb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        edadb.Value = id;
        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = "1";
            Id = int.Parse(dr.GetValue(0).ToString());
            TIPO = dr.GetValue(1).ToString();
            Nombre = dr.GetValue(2).ToString();
            App = dr.GetValue(3).ToString();
            Apm = dr.GetValue(4).ToString();
            Edad = int.Parse(dr.GetValue(5).ToString());
            Sexo = dr.GetValue(6).ToString();
            Correo = dr.GetValue(7).ToString();
            Tel = dr.GetValue(8).ToString();
            Dir = dr.GetValue(9).ToString();
            Foto = dr.GetValue(10).ToString();
            Usuario = dr.GetValue(11).ToString();
            Contraseña = dr.GetValue(12).ToString();
            Tipo = int.Parse(dr.GetValue(13).ToString());
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }

    //PRODUCTOS
    public DataSet ListarProductos(string con, int tipo)
    {
        da = new SqlDataAdapter("TSP_ListarProductos " + tipo, con);
        ds = new DataSet();
        da.Fill(ds, "ProdReg");
        return ds;
    }
    public DataSet ListarNProductos(string con, int tipo, int inic)
    {
        da = new SqlDataAdapter("TSP_ListarNProductos " + tipo + ',' + inic, con);
        ds = new DataSet();
        da.Fill(ds, "ProdReg");
        return ds;
    }
    public int ContListProductos(string con, int tipo)
    {
        resultadoConsulta = "0";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_CuentaConsProd", cnn);
        SqlParameter TIPO = cmd.Parameters.Add("@TIPO", SqlDbType.Int, 4);
        TIPO.Value = tipo;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return int.Parse(resultadoConsulta);
    }
    public int ContListProdOfer(string con, int tipo)
    {
        resultadoConsulta = "0";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_CuentaConsOfer", cnn);
        SqlParameter TIPO = cmd.Parameters.Add("@TIPO", SqlDbType.Int, 4);
        TIPO.Value = tipo;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return int.Parse(resultadoConsulta);
    }
    public DataSet ListarTipoProd(string con)
    {
        da = new SqlDataAdapter("TSP_ListarTipoProd", con);
        ds = new DataSet();
        da.Fill(ds, "TProdReg");
        return ds;
    }
    public DataSet BuscarProducto(string con, string wordkey, int tb)
    {
        if (!wordkey.StartsWith("%"))
        {
            wordkey = "%" + wordkey + "%";
        }
        da = new SqlDataAdapter("TSP_BuscarProducto '" + wordkey + "'," + tb, con);
        ds = new DataSet();
        da.Fill(ds, "ProdReg");
        return ds;
    }
    public string RegistrarProducto(string con, int tipo, string codigo, string nombre, string descrip, string present, string imagen, float precio, int oferta, int exist, char baja)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegProducto", cnn);
        SqlParameter tipob = cmd.Parameters.Add("@TIPO", SqlDbType.Int, 4);
        tipob.Value = tipo;
        SqlParameter codigob = cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 60);
        codigob.Value = codigo;
        SqlParameter nombreb = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 60);
        nombreb.Value = nombre;
        SqlParameter descripb = cmd.Parameters.Add("@DESCRIP", SqlDbType.VarChar, 250);
        descripb.Value = descrip;
        SqlParameter presentb = cmd.Parameters.Add("@PRESENT", SqlDbType.VarChar, 100);
        presentb.Value = present;
        SqlParameter imagenb = cmd.Parameters.Add("@IMAGEN", SqlDbType.VarChar, 1000);
        imagenb.Value = imagen;
        SqlParameter preciob = cmd.Parameters.Add("@PRECIO", SqlDbType.Float, 10);
        preciob.Value = precio;
        SqlParameter idoffm = cmd.Parameters.Add("@IDOFF", SqlDbType.Float, 10);
        idoffm.Value = oferta;
        SqlParameter existb = cmd.Parameters.Add("@EXIST", SqlDbType.Int, 4);
        existb.Value = exist;
        SqlParameter BAJA = cmd.Parameters.Add("@BAJA", SqlDbType.Char, 1);
        BAJA.Value = baja;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ModificarProducto(string con, int id, int tipo, string codigo, string nombre, string descrip, string present, string imagen, float precio, int oferta, int exist, char baja)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_ModificarProducto", cnn);
        SqlParameter idb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        idb.Value = id;
        SqlParameter tipob = cmd.Parameters.Add("@TIPO", SqlDbType.Int, 4);
        tipob.Value = tipo;
        SqlParameter codigob = cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 60);
        codigob.Value = codigo;
        SqlParameter nombreb = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 60);
        nombreb.Value = nombre;
        SqlParameter descripb = cmd.Parameters.Add("@DESCRIP", SqlDbType.VarChar, 250);
        descripb.Value = descrip;
        SqlParameter presentb = cmd.Parameters.Add("@PRESENT", SqlDbType.VarChar, 100);
        presentb.Value = present;
        SqlParameter imagenb = cmd.Parameters.Add("@IMAGEN", SqlDbType.VarChar, 1000);
        imagenb.Value = imagen;
        SqlParameter preciob = cmd.Parameters.Add("@PRECIO", SqlDbType.Float, 10);
        preciob.Value = precio;
        SqlParameter idoffm = cmd.Parameters.Add("@CVE_OFF", SqlDbType.Float, 10);
        idoffm.Value = oferta;
        SqlParameter existb = cmd.Parameters.Add("@EXIST", SqlDbType.Int, 4);
        existb.Value = exist;
        SqlParameter bajab = cmd.Parameters.Add("@BAJA", SqlDbType.Char, 1);
        bajab.Value = baja;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string EliminarProducto(string con, int id)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_EliminarProducto", cnn);
        SqlParameter edadb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        edadb.Value = id;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string DatosProducto(string con, int id) 
    {
        resultadoConsulta = "0";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DatosProducto", cnn);
        SqlParameter edadb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        edadb.Value = id;
        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = "1";
            Id = int.Parse(dr.GetValue(0).ToString());
            TIPO = dr.GetValue(1).ToString();
            Nombre = dr.GetValue(2).ToString();
            Descrip = dr.GetValue(3).ToString();
            Present = dr.GetValue(4).ToString();
            Foto = dr.GetValue(5).ToString();
            Precio = float.Parse(dr.GetValue(6).ToString());
            Exist = int.Parse(dr.GetValue(7).ToString());
            Baja = int.Parse(dr.GetValue(8).ToString());
            Codigo = dr.GetValue(9).ToString();
            Tipo = int.Parse(dr.GetValue(10).ToString());
            Oferta = int.Parse(dr.GetValue(11).ToString());
            PrecioF = float.Parse(dr.GetValue(12).ToString());
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }

    public string RegistrarTProducto(string con, string tipo, string desc, char baja)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegTProductos", cnn);
        SqlParameter tipob = cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 60);
        tipob.Value = tipo;
        SqlParameter descripb = cmd.Parameters.Add("@DESC", SqlDbType.VarChar, 250);
        descripb.Value = desc;
        SqlParameter bajab = cmd.Parameters.Add("@BAJA", SqlDbType.VarChar, 1);
        bajab.Value = baja;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ModificarTProducto(string con, int id, string tipo, string desc, char baja)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_ModificarTProductos", cnn);
        SqlParameter idb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        idb.Value = id;
        SqlParameter tipob = cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 60);
        tipob.Value = tipo;
        SqlParameter descripb = cmd.Parameters.Add("@DESC", SqlDbType.VarChar, 250);
        descripb.Value = desc;
        SqlParameter bajab = cmd.Parameters.Add("@BAJA", SqlDbType.VarChar, 1);
        bajab.Value = baja;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string EliminarTProducto(string con, int id)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_EliminarTProductos", cnn);
        SqlParameter idb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        idb.Value = id;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public DataSet BuscarTProducto(string con, string wordkey, int tb)
    {
        wordkey = "%" + wordkey + "%";
        da = new SqlDataAdapter("TSP_BuscarTProducto '" + wordkey + "'," + tb, con);
        ds = new DataSet();
        da.Fill(ds, "TProdReg");
        return ds;
    }
    public string DatosTProducto(string con, int id)
    {
        resultadoConsulta = "0";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DatosTProductos", cnn);
        SqlParameter edadb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        edadb.Value = id;
        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = "1";
            Id = int.Parse(dr.GetValue(0).ToString());
            TIPO = dr.GetValue(1).ToString();
            Descrip = dr.GetValue(2).ToString();
            Baja = int.Parse(dr.GetValue(3).ToString());
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }

    public string RegistrarOferta(string con, string nombre, string descrip, float razon, string foto, char baja)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegOferta", cnn);
        SqlParameter NOMB = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 60);
        NOMB.Value = nombre;
        SqlParameter DESCB = cmd.Parameters.Add("@DESCRIP", SqlDbType.VarChar, 250);
        DESCB.Value = descrip;
        SqlParameter RAZONB = cmd.Parameters.Add("@RAZON", SqlDbType.Float, 10);
        RAZONB.Value = razon;
        SqlParameter FOTOB = cmd.Parameters.Add("@FOTO", SqlDbType.VarChar, 1000);
        FOTOB.Value = foto;
        SqlParameter BAJAB = cmd.Parameters.Add("@BAJA", SqlDbType.VarChar, 1);
        BAJAB.Value = baja;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ModificarOferta(string con, int cve, string descrip, float razon, string foto, char baja)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_ModificarOferta", cnn);
        SqlParameter CVEB = cmd.Parameters.Add("@CVE", SqlDbType.Int, 4);
        CVEB.Value = cve;
        SqlParameter DESCB = cmd.Parameters.Add("@DESCRIP", SqlDbType.VarChar, 250);
        DESCB.Value = descrip;
        SqlParameter RAZONB = cmd.Parameters.Add("@RAZON", SqlDbType.Float, 10);
        RAZONB.Value = razon;
        SqlParameter FOTOB = cmd.Parameters.Add("@FOTO", SqlDbType.VarChar, 1000);
        FOTOB.Value = foto;
        SqlParameter BAJAB = cmd.Parameters.Add("@BAJA", SqlDbType.VarChar, 1);
        BAJAB.Value = baja;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string BajaOferta(string con, int cve)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_EliminarOferta", cnn);
        SqlParameter CVEB = cmd.Parameters.Add("@CVE", SqlDbType.Int, 4);
        CVEB.Value = cve;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string DatosOferta(string con, int cve)
    {
        resultadoConsulta = "0";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DatosOferta", cnn);
        SqlParameter edadb = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        edadb.Value = cve;
        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = "1";
            Id = int.Parse(dr.GetValue(0).ToString());
            Nombre = dr.GetValue(1).ToString();
            Precio = float.Parse(dr.GetValue(2).ToString());
            Baja = int.Parse(dr.GetValue(3).ToString());
            Descrip= dr.GetValue(4).ToString();
            Foto = dr.GetValue(5).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public DataSet ListarOfertas(string con, int ab)
    {
        da = new SqlDataAdapter("TSP_ListarOfertas " + ab, con);
        ds = new DataSet();
        da.Fill(ds, "OffReg");
        return ds;
    }
    public DataSet BuscarOfertas(string con, string key)
    {
        key = "%" + key + "%";
        da = new SqlDataAdapter("TSP_ListarOfertas '" + key + "'", con);
        ds = new DataSet();
        da.Fill(ds, "OffReg");
        return ds;
    }

    //ventas
    public DataSet ListarCarritoC(string con, char tc, int idc)
    {
        da = new SqlDataAdapter("TSP_ListarCarritoCliente " + idc + ",'" + tc + "'", con);
        ds = new DataSet();
        da.Fill(ds, "DetReg");
        return ds;
    }
    public string AgregarDetCar(string con, char tc, int idc, int idp, int cant)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_NuevoDetV", cnn);
        SqlParameter TC = cmd.Parameters.Add("@TC", SqlDbType.Char, 1);
        TC.Value = tc;
        SqlParameter IDCB = cmd.Parameters.Add("@IDC", SqlDbType.Int, 4);
        IDCB.Value = idc;
        SqlParameter IDPB = cmd.Parameters.Add("@IDP", SqlDbType.Int, 4);
        IDPB.Value = idp;
        SqlParameter CANT = cmd.Parameters.Add("@CANT", SqlDbType.Int, 4);
        CANT.Value = cant;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string BajaDetCar(string con, int detid)//quita un artículo del carrito
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_BajaDetV", cnn);
        SqlParameter idet = cmd.Parameters.Add("@IDET", SqlDbType.Int, 4);
        idet.Value = detid;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ObtDetCant(string con, int detid)//obtiene la cantidad de un det
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DetObtCant", cnn);
        SqlParameter id = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        id.Value = detid;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ObtDetCveP(string con, int detid)//obtiene la clave del prod de un det
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DetObtCveP", cnn);
        SqlParameter id = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        id.Value = detid;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ObtDatEnv(string con, int idenv)//obtiene la clave del prod de un det
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_ListarDatosEnv", cnn);
        SqlParameter id = cmd.Parameters.Add("@IDENV", SqlDbType.Int, 4);
        id.Value = idenv;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
            Nombre = dr.GetValue(1).ToString();
            Precio = float.Parse(dr.GetValue(2).ToString());
            Foto = dr.GetValue(3).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }

    public string AgregarTarjeta(string con, int clid, char tc, string not, string cves, string mes, string año, string banco)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegistrarTarj", cnn);
        SqlParameter CLID = cmd.Parameters.Add("@CLID", SqlDbType.Int, 4);
        CLID.Value = clid;
        SqlParameter TC = cmd.Parameters.Add("@TC", SqlDbType.Char, 1);
        TC.Value = tc;
        SqlParameter NOT = cmd.Parameters.Add("@NOT", SqlDbType.VarChar, 16);
        NOT.Value = not;
        SqlParameter CVES = cmd.Parameters.Add("@CVE", SqlDbType.VarChar, 4);
        CVES.Value = cves;
        SqlParameter MES = cmd.Parameters.Add("@MES", SqlDbType.VarChar, 2);
        MES.Value = mes;
        SqlParameter AÑO = cmd.Parameters.Add("@AÑO", SqlDbType.VarChar, 2);
        AÑO.Value = año;
        SqlParameter BANCO = cmd.Parameters.Add("@BAN", SqlDbType.VarChar, 15);
        BANCO.Value = banco;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
            Id = int.Parse(dr.GetValue(1).ToString());
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string AgregarDeposito(string con, int clid, char tc, string cve, string dia, string mes, string año)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegistrarDep", cnn);
        SqlParameter CLID = cmd.Parameters.Add("@CLID", SqlDbType.Int, 4);
        CLID.Value = clid;
        SqlParameter TC = cmd.Parameters.Add("@TC", SqlDbType.Char, 1);
        TC.Value = tc;
        SqlParameter CVE = cmd.Parameters.Add("@CVE", SqlDbType.VarChar, 18);
        CVE.Value = cve;
        SqlParameter DIA = cmd.Parameters.Add("@DIA", SqlDbType.VarChar, 2);
        DIA.Value = dia;
        SqlParameter MES = cmd.Parameters.Add("@MES", SqlDbType.VarChar, 2);
        MES.Value = mes;
        SqlParameter AÑO = cmd.Parameters.Add("@AÑO", SqlDbType.VarChar, 2);
        AÑO.Value = año;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string AgregarTransf(string con, int clid, char tc, string cve, string dia, string mes, string año)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_RegistrarTran", cnn);
        SqlParameter CLID = cmd.Parameters.Add("@CLID", SqlDbType.Int, 4);
        CLID.Value = clid;
        SqlParameter TC = cmd.Parameters.Add("@TC", SqlDbType.Char, 1);
        TC.Value = tc;
        SqlParameter CVE = cmd.Parameters.Add("@CVE", SqlDbType.VarChar, 18);
        CVE.Value = cve;
        SqlParameter DIA = cmd.Parameters.Add("@DIA", SqlDbType.VarChar, 2);
        DIA.Value = dia;
        SqlParameter MES = cmd.Parameters.Add("@MES", SqlDbType.VarChar, 2);
        MES.Value = mes;
        SqlParameter AÑO = cmd.Parameters.Add("@AÑO", SqlDbType.VarChar, 2);
        AÑO.Value = año;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public DataSet ListarTarjetasCli(string con, int clid, char tc)
    {
        da = new SqlDataAdapter("TSP_ListarTarjetasCli " + clid + ",'" + tc + "'", con);
        ds = new DataSet();
        da.Fill(ds, "Tarjetas");
        return ds;
    }

    public string DatosTarjeta(string con, int id)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_DatosTarjetaCliente", cnn);
        SqlParameter ID = cmd.Parameters.Add("@ID", SqlDbType.Int, 4);
        ID.Value = id;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
            Nombre= dr.GetValue(0).ToString();
            App= dr.GetValue(1).ToString();//año
            Apm= dr.GetValue(2).ToString();//mes
            Rol= dr.GetValue(3).ToString();//clave
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string ConfirmarVenta(string con, int idc, float desc, float imp, char tc, int mete, string dir,int metp, int idp)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_GenerarVenta", cnn);
        SqlParameter IDC = cmd.Parameters.Add("@IDC", SqlDbType.Int, 4);
        IDC.Value = idc;
        SqlParameter DESC = cmd.Parameters.Add("@DESC", SqlDbType.Float, 4);
        DESC.Value = desc;
        SqlParameter IMP = cmd.Parameters.Add("@IMP", SqlDbType.Float, 4);
        IMP.Value = imp;
        SqlParameter TC = cmd.Parameters.Add("@TC", SqlDbType.Char, 1);
        TC.Value = tc;
        SqlParameter METE = cmd.Parameters.Add("@METE", SqlDbType.Int, 4);
        METE.Value = mete;
        SqlParameter DIR = cmd.Parameters.Add("@DIR", SqlDbType.VarChar, 250);
        DIR.Value = dir;
        SqlParameter METP = cmd.Parameters.Add("@METP", SqlDbType.Int, 4);
        METP.Value = metp;
        SqlParameter IDP = cmd.Parameters.Add("@IDP", SqlDbType.Int, 4);
        IDP.Value = idp;
        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string BajaCarrito(string con, int idc, char tc)//baja del carrito al cierre de sesión o cancelación general
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_BajaCarrrito", cnn);
        SqlParameter CLIID = cmd.Parameters.Add("@CLID", SqlDbType.Int, 4);
        CLIID.Value = idc;
        SqlParameter TC = cmd.Parameters.Add("@TC", SqlDbType.Char, 1);
        TC.Value = tc;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string VerifExistVenCli(string con, int idc, char tc, int stus) //stus 0 alta 1 baja 2 ambas
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_VerificaVentasCli", cnn);
        SqlParameter IDC = cmd.Parameters.Add("@IDC", SqlDbType.Int, 4);
        IDC.Value = idc;
        SqlParameter TC = cmd.Parameters.Add("@TC", SqlDbType.Char, 1);
        TC.Value = tc;
        SqlParameter STUS = cmd.Parameters.Add("@STUS", SqlDbType.Int, 4);
        STUS.Value = stus;
        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }//verifica si hay ventas de un cliente

    public DataSet ListarVentasCli(string con, int clid, char tc, int baja)
    {
        da = new SqlDataAdapter("TSP_ListarVentasCli " + clid + ",'" + tc + "'," + baja, con);
        ds = new DataSet();
        da.Fill(ds, "Ventas");
        return ds;
    }
    public string CancelarVenta(string con, int idv)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_CancelarVenta", cnn);
        SqlParameter id = cmd.Parameters.Add("@IDV", SqlDbType.Int, 4);
        id.Value = idv;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }

    //Reportes
    public DataSet ReporteVenta(string con, int id)
    {
        da = new SqlDataAdapter("TSP_DatosVenta " + id, con);
        ds = new DataSet();
        da.Fill(ds, "Venta");
        return ds;
    }
    public DataSet ReporteComprasT(string con, int id, char tc)
    {
        da = new SqlDataAdapter("TSP_RepVentasCli " + id + ",'" + tc + "'", con);
        ds = new DataSet();
        da.Fill(ds, "Venta");
        return ds;
    }
    public DataSet ReporteComprasC(string con, int id, char tc)
    {
        da = new SqlDataAdapter("TSP_RepVentasCancCli " + id + ",'" + tc + "'", con);
        ds = new DataSet();
        da.Fill(ds, "Venta");
        return ds;
    }

    //ValidEx -> procedimientos para validar la existencia de ciertos parámetros en los reportes
    public string VerifVentasG(string con)
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_VerifExistVenG", cnn);

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string VerifVentasProd(string con)//productos con ventas
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_VerifVenProd", cnn);

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string VerifUsuReg(string con, int tc)//Usuarios reg 0 cli, 1 emp
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_VerifCliReg", cnn);
        SqlParameter TC = cmd.Parameters.Add("@TU", SqlDbType.Int, 4);
        TC.Value = tc;

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string VerifProdEX(string con)//productos con Existencias
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_VerifExistProd", cnn);

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }
    public string VerifProdSEX(string con)//productos sin Existencias
    {
        resultadoConsulta = "";
        cnn = new SqlConnection(con);
        cmd = new SqlCommand("TSP_VerifSExistProd", cnn);

        cmd.CommandType = CommandType.StoredProcedure;
        cnn.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            resultadoConsulta = dr.GetValue(0).ToString();
        }
        dr.Close();
        cnn.Close();
        return resultadoConsulta;
    }

    public DataSet ListarBusquedaUsuarios(string con, string key, int nkey, char tc, int tb)
    {
        key = "%" + key + "%";
        da = new SqlDataAdapter("TSP_BuscarClientesCV '" + key + "'," + nkey + ",'" + tc + "'," + tb, con);
        ds = new DataSet();
        da.Fill(ds, "Venta");
        return ds;
    }
}
