using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUARESTAzure.DTOA
{
public class PlantaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum Planta
{
        get { return planta; }
        set { planta = value; }
}
}
}
