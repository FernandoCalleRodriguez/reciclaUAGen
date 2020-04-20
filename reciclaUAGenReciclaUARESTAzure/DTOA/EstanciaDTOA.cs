using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUARESTAzure.DTOA
{
public class EstanciaDTOA
{
private string id;
public string Id
{
        get { return id; }
        set { id = value; }
}


private string actividad;
public string Actividad
{
        get { return actividad; }
        set { actividad = value; }
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

private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}


/* Rol: Estancia o--> Edificio */
private EdificioDTOA edificioEstancia;
public EdificioDTOA EdificioEstancia
{
        get { return edificioEstancia; }
        set { edificioEstancia = value; }
}

/* Rol: Estancia o--> Planta */
private PlantaDTOA plantaEstancia;
public PlantaDTOA PlantaEstancia
{
        get { return plantaEstancia; }
        set { plantaEstancia = value; }
}
}
}
