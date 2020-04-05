using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class ContenedorDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum tipo;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}


private int punto_oid;
public int Punto_oid {
        get { return punto_oid; } set { punto_oid = value;  }
}



private System.Collections.Generic.IList<int> acciones_oid;
public System.Collections.Generic.IList<int> Acciones_oid {
        get { return acciones_oid; } set { acciones_oid = value;  }
}
}
}
