using System;
using Proyecto_Integrador_Elect.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de WSPeticiones
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class WSPeticiones : System.Web.Services.WebService
{
    producto unProducto = new producto();
    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }

    //nuevas

    [WebMethod]
    public void registrocategoria(string descripcion)
    {
        unProducto.agregarCategoria(descripcion);
    }
    #region Insertar

    [WebMethod]
    public void agregarCategoria(string descripcion)
    {
                unProducto.agregarCategoria(descripcion);
    }

    [WebMethod]
    public int agregarMarca(string descripcion)
    {
        
        return unProducto.agregarMarca(descripcion);
    }
    [WebMethod]
    public int agregarProducto(string descripcion, string detalle, int stock, int idCategoria, int idMarcas, decimal valor,string modelo)
    {
        return unProducto.agregarProducto(descripcion, detalle, stock, idCategoria, idMarcas, valor,modelo);
    }
    


    [WebMethod]
    public int agregarPrecio(string fechaInicio, decimal valor)
    {
        return unProducto.agregarPrecio(fechaInicio, valor);
    }
    [WebMethod]
    public int agregarImagen(string nombre, string extension)
    {
        return unProducto.agregarImagen(nombre, extension);
    }
    #endregion

    #region Actualizar
    [WebMethod]
    public int actualizarCategoria(int idCategoria, string descripcion, string estado)
    {
        return unProducto.actualizarCategoria(idCategoria, descripcion, estado);
    }
    [WebMethod]
    public void actualizarCategoriaCampo(string campo, string valor, int id)
    {
        conexion uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        uC.EjecutarSentencia("update categoria set "+campo+"='"+valor+"' where idcategoria='"+id+"'");
        //return unProducto.actualizarCategoria(idCategoria, descripcion, estado);
    }
    [WebMethod]
    public void actualizarMarcaCampo(string campo, string valor, int id)
    {
        conexion uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        uC.EjecutarSentencia("update marcas set " + campo + "='" + valor + "' where idmarcas='" + id + "'");
        //return unProducto.actualizarCategoria(idCategoria, descripcion, estado);
    }

    [WebMethod]
    public int actualizarImagen(int idImagen, string nombre, string extension, int idProducto, string estado)
    {
        return unProducto.actualizarImagen(idImagen, nombre, extension, idProducto, estado);
    }

    [WebMethod]
    public int actualizarMarca(int idMarca, string descripcion, string estado)
    {
        return unProducto.actualizarMarca(idMarca, descripcion, estado);
    }
    [WebMethod]
    public int actualizarPrecio(string fechaInicio, decimal valor, int idProducto)
    {
        return unProducto.actualizarPrecio(fechaInicio, valor, idProducto);
    }

    [WebMethod]
    public int actualizarProducto(int idProducto, string descripcion, string detalle, int stock, int idCategoria, int idMarcas)
    {
        return unProducto.actualizarProducto(idProducto, descripcion, detalle, stock, idCategoria, idMarcas);
    }
    #endregion

    #region Consultas
    [WebMethod]
    public List<categoria> obtenerCategorias()
    {
        string estado = "Activo";
        return unProducto.obtenerCategorias(estado);
    }

    [WebMethod]
    public List<marca> obtenerMarcas()
    {
        string estado="Activo";
        return unProducto.obtenerMarcas(estado);
    }


    [WebMethod]
    public List<producto> obtenerProductosPagina(int pagina, string categoria,string marcas)
    {
        return unProducto.obtenerProductosPagina(pagina,categoria,marcas);
    }

    [WebMethod]
    public List<producto> obtenerProductos()
    {
        return unProducto.obtenerProductos();
    }
    [WebMethod]
    public List<producto> obtenerProductosCategoria(int idCategoria)
    {
        return unProducto.obtenerProductos(idCategoria);
    }
    [WebMethod]
    public List<producto> obtenerProductosMarcas(int idMarca)
    {
        return unProducto.obtenerProductosMarca(idMarca);
    }

    [WebMethod]
    public producto obtenerDetalleProducto(int idProducto)
    {
        return unProducto.obtenerDetalleProducto(idProducto);
    }
    [WebMethod]
    public List<producto> obtenerProductosPopulares()
    {
        return unProducto.obtenerProductosPopulares();
    }
    [WebMethod]
    public List<producto> obtenerImagenes(int idProducto)
    {
        return unProducto.obtenerImagenes(idProducto);
    }
    [WebMethod(EnableSession = true)]
    public usuario login(string usuario,string clave)
    {
        conexion uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        string elUsuario=uC.login(usuario, clave);
        if (elUsuario != "")
            HttpContext.Current.Session["usuario"] = elUsuario;
        return new usuario(elUsuario);
            


    }
    [WebMethod(EnableSession = true)]
    public usuario obtenerSession()
    {
        usuario unUsuario = null;
        if (HttpContext.Current.Session["usuario"] != null)
        {
            string elUsuario = HttpContext.Current.Session["usuario"].ToString();
            unUsuario = new usuario(elUsuario);
        }
        else
        {
             unUsuario = new usuario("");

        }
        return unUsuario;

        

        
    }
   [WebMethod]
    public string UploadFile()
    {
        try
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/productos"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    int pos_ult_puntos = httpPostedFile.FileName.LastIndexOf(".");
                    int long_nombre = httpPostedFile.FileName.Length;
                    int cant_caract_extraer = long_nombre - pos_ult_puntos;
                    string ext = httpPostedFile.FileName.Substring(pos_ult_puntos, cant_caract_extraer);
                    agregarImagen(httpPostedFile.FileName, ext);

                    return "Subido";
                }

                return "No subido";
            }

            return "No subido";
        }
        catch (Exception ex)
        {
            return "Ocurrió un error mientras se estaba subiendo el archivo error en: " + ex.Message;
        }
    }
   [WebMethod]
   public int enviarContacto(string emailDestino, string asunto, string contenido)
   {
       email unEmail= new email();
       unEmail.enviarMail(emailDestino,asunto,contenido);
       return 1;
   }
   [WebMethod]
   public producto totalPaginas(string idCategoria, string idMarca)
   {
       //total de registros a mostrar
       int mostrar=12;

       conexion uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
       string totalRegistros = uC.ObtenerUnValor("select COUNT(idProducto) from producto where categoria_idcategoria like '"+idCategoria+"' and marcas_idmarcas like '"+idMarca+"'");
       int totalRegistro=Convert.ToInt32(totalRegistros);
       if (totalRegistro % mostrar == 0)
       {
           return new producto(Convert.ToInt32(totalRegistro / mostrar));
           
       }
       else
       {
           return new producto(Convert.ToInt32(totalRegistro / mostrar)+1);
       }       
       
       
   }
    #endregion
}