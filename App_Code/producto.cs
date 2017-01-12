using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Proyecto_Integrador_Elect.Clases
{
    public class producto
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        private int idProducto;
        private conexion uC;
        private string descripcion;
        private string detalle;
        private string estado;
        private int stock;
        private categoria unaCategoria;
        private marca unaMarca;
        private decimal precio;
        private string nombreImagen;
        private string modelo;
        private int totalPaginas;
        
        #region Constructores
        public producto(int totalPaginas)
        {
            this.totalPaginas=totalPaginas;
        }
        public producto(int idProducto, string descripcion, string detalle, string estado, int stock, categoria unaCategoria, marca unaMarca,decimal precio,string nombreImagen)
        {
            this.idProducto = idProducto;
            this.descripcion = descripcion;
            this.detalle = detalle;
            this.estado = estado;
            this.stock = stock;
            this.unaCategoria = unaCategoria;
            this.unaMarca = unaMarca;
            this.precio = precio;
            this.nombreImagen = nombreImagen;
            uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        }
        public producto(int idProducto, string descripcion, decimal precio, string nombreImagen)
        {
            this.idProducto = idProducto;
            this.descripcion = descripcion;            
            this.precio = precio;
            this.nombreImagen = nombreImagen;
            uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        }
        public producto(int idProducto, string descripcion, string detalle, decimal precio, string modelo,int stock)
        {
            this.idProducto = idProducto;
            this.descripcion = descripcion;
            this.detalle = detalle;
            this.precio = precio;
            this.modelo = modelo;
            this.stock = stock;
            uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        }
        public producto(int idProducto, string descripcion, string detalle, decimal precio, string modelo, int stock, string nombreImagen)
        {
            this.idProducto = idProducto;
            this.descripcion = descripcion;
            this.detalle = detalle;
            this.precio = precio;
            this.modelo = modelo;
            this.stock = stock;
            this.nombreImagen = nombreImagen;
            uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        }
        public producto()
        {
            uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");

        }
        public producto(string nombreImagen)
        {
            this.nombreImagen = nombreImagen;
            uC = new conexion("Zambrano-PC", "BDPROYECTOINTEGRADOR");
        }
#endregion

        #region Propiedades
        public int TotalPaginas
        {
            get { return totalPaginas; }
        }
        public int IdProducto
        {
            get { return idProducto; }
            set {idProducto = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string NombreImagen
        {
            get { return nombreImagen; }
            set { nombreImagen = value; }

        }
        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public categoria Categoria
        {
            get { return unaCategoria; }
            set { unaCategoria = value; }
        }
        public marca Marca
        {
            get { return unaMarca; }
            set { unaMarca = value; }
        }
        public decimal Precio
        {
            get { return precio; }
            set { precio= value; }
        }
        public string Modelo
        {
            get { return modelo; }
        }
        #endregion
        #region Registros
        public void agregarCategoria(string descripcion)
        {
            SqlParameter parametro = new SqlParameter("@descripcion", descripcion);
            parametros.Add(parametro);
            uC.EjecutarProcedimientoAlmacenado("registrarCategorias", parametros);            
                        }
        public int agregarMarca(string descripcion)
        {
            SqlParameter parametro = new SqlParameter("@descripcion", descripcion);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("registrarMarcas", parametros);            
        }
        public int agregarProducto(string descripcion, string detalle, int stock, int idCategoria, int idMarcas, decimal valor,string modelo)
        {
            fecha unaFecha = new fecha();

            SqlParameter parametro = new SqlParameter("@descripcion", descripcion);
            parametros.Add(parametro);
            parametro = new SqlParameter("@detalle", detalle);
            parametros.Add(parametro);
            parametro = new SqlParameter("@stock", stock);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idCategoria", idCategoria);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idMarcas", idMarcas);
            parametros.Add(parametro);
            parametro = new SqlParameter("@valores", valor);
            parametros.Add(parametro);
            parametro = new SqlParameter("@fecha ", unaFecha.obtenerFechaParaSqlServer());
            parametros.Add(parametro);
            parametro = new SqlParameter("@modelo", modelo);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("registrarProducto", parametros);
        }
        public int agregarPrecio(string fechaInicio,decimal valor)
        {
            SqlParameter parametro = new SqlParameter("@fechaInicio", fechaInicio);
            parametros.Add(parametro);
            parametro = new SqlParameter("@valor", valor);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("registrarPrecio", parametros);
        }
        public int agregarImagen(string nombre, string extension)
        {
            SqlParameter parametro = new SqlParameter("@nombre", nombre);
            parametros.Add(parametro);
            parametro = new SqlParameter("@extension", extension);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("registrarImagen", parametros);
        }
        #endregion

        #region Actualizar
        public int actualizarCategoria(int idCategoria,string descripcion,string estado)
        {
            SqlParameter parametro = new SqlParameter("@idCategoria", idCategoria);
            parametros.Add(parametro);
            parametro = new SqlParameter("@descripcion", descripcion);
            parametros.Add(parametro);
            parametro = new SqlParameter("@estado", estado);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("actualizarCategoria", parametros);
        }

        public int actualizarImagen(int idImagen, string nombre, string extension,int idProducto, string estado)
        {
            SqlParameter parametro = new SqlParameter("@idImagen", idImagen);
            parametros.Add(parametro);
            parametro = new SqlParameter("@nombre", nombre);
            parametros.Add(parametro);
            parametro = new SqlParameter("@extension", extension);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idProducto", idProducto);
            parametros.Add(parametro);
            parametro = new SqlParameter("@estado", estado);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("actualizarImagen", parametros);
        }

        public int actualizarMarca(int idMarca, string descripcion, string estado)
        {
            SqlParameter parametro = new SqlParameter("@idMarca", idMarca);
            parametros.Add(parametro);
            parametro = new SqlParameter("@descripcion", descripcion);
            parametros.Add(parametro);
            parametro = new SqlParameter("@estado", estado);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("actualizarMarca", parametros);
        }
        public int actualizarPrecio(string fechaInicio, decimal valor,int idProducto)
        {
            SqlParameter parametro = new SqlParameter("@fechaInicio", fechaInicio);
            parametros.Add(parametro);
            parametro = new SqlParameter("@valor", valor);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idProducto", idProducto);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("actualizarPrecio", parametros);
        }
        public int actualizarProducto(int idProducto,string descripcion, string detalle, int stock, int idCategoria, int idMarcas)
        {
            SqlParameter parametro = new SqlParameter("@idProducto", idProducto);
            parametros.Add(parametro);
            parametro = new SqlParameter("@descripcion", descripcion);
            parametros.Add(parametro);
            parametro = new SqlParameter("@detalle", detalle);
            parametros.Add(parametro);
            parametro = new SqlParameter("@stock", stock);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idCategoria", idCategoria);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idMarcas", idMarcas);
            parametros.Add(parametro);
            return uC.EjecutarProcedimientoAlmacenado("actualizarProducto", parametros);
        }

        #endregion 

        #region Consultas
        public List<categoria> obtenerCategorias(string estado)
        {
            SqlParameter parametro = new SqlParameter("@estado", estado);
            parametros.Add(parametro);
            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerCategorias", parametros);
            List<categoria> categorias = new List<categoria>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    { 
                        categorias.Add(new categoria(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2)));
                    }
                }
            }
            return categorias;
            //return uC.EjecutarProcedimientoAlmacenado("registrarCategorias", parametros);            

 
        }

        public List<marca> obtenerMarcas(string estado)
        {
            SqlParameter parametro = new SqlParameter("@estado", estado);
            parametros.Add(parametro);
            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerMarcas", parametros);
            List<marca> marcas = new List<marca>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        marcas.Add(new marca(sDr.GetInt32(0), sDr.GetString(1), sDr.GetString(2)));
                    }
                }
            }
            return marcas;
        }

        public List<producto> obtenerProductosPagina(int pagina,string categorias,string marcas)
        {
            SqlParameter parametro = new SqlParameter("@NUM_PAGINA", pagina);
            parametros.Add(parametro);
            parametro= new SqlParameter("@totalRegistros",12);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idCategoria", categorias);
            parametros.Add(parametro);
            parametro = new SqlParameter("@idMarca", marcas);
            parametros.Add(parametro);
            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerProductosPaginados", parametros);
            List<producto> productos = new List<producto>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        productos.Add(new producto(sDr.GetInt32(1), sDr.GetString(2), sDr.GetDecimal(3), sDr.GetString(4)));
                        //productos.Add(new producto(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2),sDr.GetString(3),sDr.GetInt32(4),new categoria(sDr.GetInt32(5),sDr.GetString(6)),new marca(sDr.GetInt32(7),sDr.GetString(8)),sDr.GetDecimal(7)));
                        //marcas.Add(new producto(sDr.GetInt32(0), sDr.GetString(1)));
                    }
                }
            }
            return productos;
        }
        public List<producto> obtenerProductos()
        {

            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerProductos", parametros);
            List<producto> productos= new List<producto>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        productos.Add(new producto(sDr.GetInt32(0), sDr.GetString(1), sDr.GetDecimal(2), sDr.GetString(3)));
                        //productos.Add(new producto(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2),sDr.GetString(3),sDr.GetInt32(4),new categoria(sDr.GetInt32(5),sDr.GetString(6)),new marca(sDr.GetInt32(7),sDr.GetString(8)),sDr.GetDecimal(7)));
                        //marcas.Add(new producto(sDr.GetInt32(0), sDr.GetString(1)));
                    }
                }
            }
            return productos;
        }
        public List<producto> obtenerProductos(int idCategoria)
        {
            SqlParameter parametro = new SqlParameter("@idCategoria", idCategoria);
            parametros.Add(parametro);
            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerProductosCategoria", parametros);
            List<producto> productos = new List<producto>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        productos.Add(new producto(sDr.GetInt32(0), sDr.GetString(1), sDr.GetDecimal(2), sDr.GetString(3)));
                        //productos.Add(new producto(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2),sDr.GetString(3),sDr.GetInt32(4),new categoria(sDr.GetInt32(5),sDr.GetString(6)),new marca(sDr.GetInt32(7),sDr.GetString(8)),sDr.GetDecimal(7)));
                        //marcas.Add(new producto(sDr.GetInt32(0), sDr.GetString(1)));
                    }
                }
            }
            return productos;
        }
        public List<producto> obtenerProductosMarca(int idMarcas)
        {
            SqlParameter parametro = new SqlParameter("@idMarcas", idMarcas);
            parametros.Add(parametro);
            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerProductosMarcas", parametros);
            List<producto> productos = new List<producto>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        productos.Add(new producto(sDr.GetInt32(0), sDr.GetString(1), sDr.GetDecimal(2), sDr.GetString(3)));
                        //productos.Add(new producto(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2),sDr.GetString(3),sDr.GetInt32(4),new categoria(sDr.GetInt32(5),sDr.GetString(6)),new marca(sDr.GetInt32(7),sDr.GetString(8)),sDr.GetDecimal(7)));
                        //marcas.Add(new producto(sDr.GetInt32(0), sDr.GetString(1)));
                    }
                }
            }
            return productos;
        }

        public producto obtenerDetalleProducto(int idProducto)
        {
            SqlParameter parametro = new SqlParameter("@idProducto", idProducto);
            parametros.Add(parametro);
            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerDetalleProducto", parametros);
            producto unProducto=null;
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        unProducto = new producto(sDr.GetInt32(0), sDr.GetString(1), sDr.GetString(2), sDr.GetDecimal(3), sDr.GetString(4), sDr.GetInt32(5),sDr.GetString(6));
                        //productos.Add(new producto(sDr.GetInt32(0), sDr.GetString(1), sDr.GetDecimal(2), sDr.GetString(3)));
                        //productos.Add(new producto(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2),sDr.GetString(3),sDr.GetInt32(4),new categoria(sDr.GetInt32(5),sDr.GetString(6)),new marca(sDr.GetInt32(7),sDr.GetString(8)),sDr.GetDecimal(7)));
                        //marcas.Add(new producto(sDr.GetInt32(0), sDr.GetString(1)));
                    }
                }
            }
            return unProducto;
        }
        public List<producto> obtenerProductosPopulares()
        {

            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerProductosMasPopulares", parametros);
            List<producto> productos = new List<producto>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        productos.Add(new producto(sDr.GetInt32(0), sDr.GetString(1), sDr.GetDecimal(2), sDr.GetString(3)));
                        //productos.Add(new producto(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2),sDr.GetString(3),sDr.GetInt32(4),new categoria(sDr.GetInt32(5),sDr.GetString(6)),new marca(sDr.GetInt32(7),sDr.GetString(8)),sDr.GetDecimal(7)));
                        //marcas.Add(new producto(sDr.GetInt32(0), sDr.GetString(1)));
                    }
                }
            }
            return productos;
        }
        public List<producto> obtenerImagenes(int idProducto)
        {
            producto unProducto = null;
          
            SqlParameter parametro = new SqlParameter("@idProducto", idProducto);
            parametros.Add(parametro);
            SqlDataReader sDr = uC.EjecutarProcedimientoAlmacenadoConRetorno("obtenerImagenes", parametros);

            List<producto> productos = new List<producto>();
            if (sDr != null)
            {
                if (sDr.HasRows)
                {
                    while (sDr.Read())
                    {
                        unProducto= new producto(sDr.GetString(0));
                        productos.Add(unProducto);
                        //productos.Add(new producto(sDr.GetInt32(0),sDr.GetString(1),sDr.GetString(2),sDr.GetString(3),sDr.GetInt32(4),new categoria(sDr.GetInt32(5),sDr.GetString(6)),new marca(sDr.GetInt32(7),sDr.GetString(8)),sDr.GetDecimal(7)));
                        //marcas.Add(new producto(sDr.GetInt32(0), sDr.GetString(1)));
                    }
                }
            }
            return productos;

        }


        
        #endregion


    }
}