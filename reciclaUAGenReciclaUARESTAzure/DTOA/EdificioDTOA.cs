using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUARESTAzure.DTOA
{
public class EdificioDTOA
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


/* Rol: Edificio o--> Planta */
private IList<PlantaDTOA> plantasEdificio;
public IList<PlantaDTOA> PlantasEdificio
{
        get { return plantasEdificio; }
        set { plantasEdificio = value; }
}
}
}
