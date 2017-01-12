using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Integrador_Elect.Clases
{
    public class categoria
    {
        private int idCategoria;
        private string descripcion;
        private string estado;
        public categoria(int idCategoria, string descripcion,string estado)
        {
            this.idCategoria = idCategoria;
            this.descripcion = descripcion;
            this.estado = estado;
        }
        public categoria()
        { }
        public string Estado
        {
            get { return estado; }
        }
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}