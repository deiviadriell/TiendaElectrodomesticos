using Proyecto_Integrador_Elect.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class transacciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] aux = Request.UrlReferrer.ToString().Split('/');
        string proviene = aux[aux.GetUpperBound(0)];
        bool contiene = Request.UrlReferrer.ToString().Contains('?');
        producto unProducto = new producto();
        if (contiene)
        {
            aux = proviene.Split('?');
            proviene = aux[0];
        }
        if (proviene == "regristroproducto.html")
        {

            HttpFileCollection files = Request.Files;
            string nombreImagen = "";
            int pos_ult_puntos = 0;
                int long_nombre = 0;
                
                string ext = "";
            for (int i = 0; i < files.Count; i++)
            {
                
                HttpPostedFile f = files[0];
                nombreImagen= f.FileName;
                f = files[i];
                f.SaveAs(Server.MapPath(".") + @"\productos\" + f.FileName);
                pos_ult_puntos=f.FileName.LastIndexOf(".");
                long_nombre=f.FileName.Length;
                int cant_caract_extraer = long_nombre - pos_ult_puntos;
                ext=f.FileName.Substring(pos_ult_puntos, cant_caract_extraer);
            }

             
            //unProducto.agregarProducto(Request.Form["txtNombre"].ToString(), Request.Form["txtDescripcion"].ToString(), Convert.ToInt32(Request.Form["txtStock"].ToString()), Convert.ToInt32(Request.Form["opCategoria"].ToString()), Convert.ToInt32(Request.Form["opMarcas"].ToString()), Convert.ToDecimal(Request.Form["txtPrecio"].ToString()));
            unProducto.agregarImagen(nombreImagen, ext);
            Response.Redirect(proviene, false);
            
 
        }

    }
}