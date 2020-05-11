using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class ItemDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private string descripcion;
public string Descripcion
{
        get { return descripcion; }
        set { descripcion = value; }
}

private string imagen;
public string Imagen
{
        get { return imagen; }
        set { imagen = value; }
}

private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido
{
        get { return esValido; }
        set { esValido = value; }
}

private int puntuacion;
public int Puntuacion
{
        get { return puntuacion; }
        set { puntuacion = value; }
}


/* Rol: Item o--> Material */
private MaterialDTOA materialItem;
public MaterialDTOA MaterialItem
{
        get { return materialItem; }
        set { materialItem = value; }
}
}
}
