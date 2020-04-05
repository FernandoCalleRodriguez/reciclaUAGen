using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class ItemDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
private string imagen;
public string Imagen {
        get { return imagen; } set { imagen = value;  }
}
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido {
        get { return esValido; } set { esValido = value;  }
}


private int usuario_oid;
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}



private int niveles_oid;
public int Niveles_oid {
        get { return niveles_oid; } set { niveles_oid = value;  }
}



private int material_oid;
public int Material_oid {
        get { return material_oid; } set { material_oid = value;  }
}



private System.Collections.Generic.IList<int> accionReciclar_oid;
public System.Collections.Generic.IList<int> AccionReciclar_oid {
        get { return accionReciclar_oid; } set { accionReciclar_oid = value;  }
}
}
}
