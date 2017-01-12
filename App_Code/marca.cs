using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Integrador_Elect.Clases
{
    public class marca
    {
        private int idMarca;
        private string descripcion;
        private string estado;
        public marca(int idMarca, string descripcion, string estado)
        {
            this.idMarca = idMarca;
            this.descripcion = descripcion;
            this.estado = estado;
        }
        public marca()
        { }
        public string Estado
        {
            get { return estado; }
        }
        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

    }
}