using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de fecha
/// </summary>
public class fecha
{
	private string fechaRetorno;
        public fecha()
        {
            fechaRetorno = "";
        }
        public string obtenerFechaParaSqlServer()
        {
            string dia=DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();

            if (dia.Length < 2)
                dia = "0" + dia;
            if (mes.Length < 2)
                mes = "0" + mes;

            fechaRetorno = DateTime.Now.Year.ToString() + "-" + dia + "-" + mes;
            return fechaRetorno;
        }
        public string obtenerFechaParaSqlServer(DateTime fecha)
        {
            string dia = fecha.Day.ToString();
            string mes = fecha.Month.ToString();

            if (dia.Length < 2)
                dia = "0" + dia;
            if (mes.Length < 2)
                mes = "0" + mes;

            fechaRetorno = fecha.Year.ToString() + "-" + mes + "-" + dia;            
            return fechaRetorno;
        }
        public string obtenerFechaCorta(string fechaLarga)
        {
            for (int i = 0; i < fechaLarga.Length; i++)
            {
                fechaRetorno = fechaRetorno + fechaLarga[i];
                if (fechaLarga[i] == ' ')
                    break;
            }
            return obtenerFechaParaSqlServer(Convert.ToDateTime(fechaRetorno)); ;
        }
}