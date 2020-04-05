using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class PuntoReciclajeDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private double latitud;
public double Latitud
{
        get { return latitud; }
        set { latitud = value; }
}

private double longitud;
public double Longitud
{
        get { return longitud; }
        set { longitud = value; }
}

private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido
{
        get { return esValido; }
        set { esValido = value; }
}


/* Rol: PuntoReciclaje o--> Contenedor */
private IList<ContenedorDTOA> contenedores;
public IList<ContenedorDTOA> Contenedores
{
        get { return contenedores; }
        set { contenedores = value; }
}

/* Rol: PuntoReciclaje o--> Estancia */
private EstanciaDTOA estanciaPunto;
public EstanciaDTOA EstanciaPunto
{
        get { return estanciaPunto; }
        set { estanciaPunto = value; }
}
}
}
