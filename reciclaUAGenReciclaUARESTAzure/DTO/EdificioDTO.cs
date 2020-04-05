using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class EdificioDTO
{
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private System.Collections.Generic.IList<string> estancias_oid;
public System.Collections.Generic.IList<string> Estancias_oid {
        get { return estancias_oid; } set { estancias_oid = value;  }
}



private System.Collections.Generic.IList<int> plantas_oid;
public System.Collections.Generic.IList<int> Plantas_oid {
        get { return plantas_oid; } set { plantas_oid = value;  }
}
}
}
