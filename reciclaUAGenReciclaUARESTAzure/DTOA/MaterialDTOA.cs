using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUARESTAzure.DTOA
{
public class MaterialDTOA
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

private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum contenedor;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum Contenedor
{
        get { return contenedor; }
        set { contenedor = value; }
}

private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido
{
        get { return esValido; }
        set { esValido = value; }
}
}
}
