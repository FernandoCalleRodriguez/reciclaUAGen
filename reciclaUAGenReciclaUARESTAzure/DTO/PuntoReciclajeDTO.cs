using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class PuntoReciclajeDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private double latitud;
public double Latitud {
        get { return latitud; } set { latitud = value;  }
}
private double longitud;
public double Longitud {
        get { return longitud; } set { longitud = value;  }
}
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido {
        get { return esValido; } set { esValido = value;  }
}


private int usuario_oid;
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}

private System.Collections.Generic.IList<ContenedorDTO> contenedores;
public System.Collections.Generic.IList<ContenedorDTO> Contenedores {
        get { return contenedores; } set { contenedores = value;  }
}


private string estancia_oid;
public string Estancia_oid {
        get { return estancia_oid; } set { estancia_oid = value;  }
}
}
}
