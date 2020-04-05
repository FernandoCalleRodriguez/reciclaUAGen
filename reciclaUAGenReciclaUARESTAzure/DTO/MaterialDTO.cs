using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class MaterialDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum contenedor;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum Contenedor {
        get { return contenedor; } set { contenedor = value;  }
}


private System.Collections.Generic.IList<int> items_oid;
public System.Collections.Generic.IList<int> Items_oid {
        get { return items_oid; } set { items_oid = value;  }
}

private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido {
        get { return esValido; } set { esValido = value;  }
}


private int usuario_oid;
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}
}
}
