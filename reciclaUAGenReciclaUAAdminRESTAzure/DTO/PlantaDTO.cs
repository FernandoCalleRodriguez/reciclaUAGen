using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class PlantaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum Planta {
        get { return planta; } set { planta = value;  }
}


private System.Collections.Generic.IList<string> estancias_oid;
public System.Collections.Generic.IList<string> Estancias_oid {
        get { return estancias_oid; } set { estancias_oid = value;  }
}



private int edificio_oid;
public int Edificio_oid {
        get { return edificio_oid; } set { edificio_oid = value;  }
}
}
}
