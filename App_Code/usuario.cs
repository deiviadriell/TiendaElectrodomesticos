using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de usuario
/// </summary>
public class usuario
{
    private string nombres;
    public usuario()
    { }
	public usuario( string nombres)
	{
        this.nombres = nombres;
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public string Nombres
    {
        get { return nombres; }
    }
}