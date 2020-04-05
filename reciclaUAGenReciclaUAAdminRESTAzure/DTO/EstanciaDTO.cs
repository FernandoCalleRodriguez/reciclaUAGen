using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class EstanciaDTO
{
private string id;
public string Id {
        get { return id; } set { id = value;  }
}
private string actividad;
public string Actividad {
        get { return actividad; } set { actividad = value;  }
}
private string latitud;
public string Latitud {
        get { return latitud; } set { latitud = value;  }
}
private string longitud;
public string Longitud {
        get { return longitud; } set { longitud = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}


private int edificio_oid;
public int Edificio_oid {
        get { return edificio_oid; } set { edificio_oid = value;  }
}



private int planta_oid;
public int Planta_oid {
        get { return planta_oid; } set { planta_oid = value;  }
}



private System.Collections.Generic.IList<int> puntos_oid;
public System.Collections.Generic.IList<int> Puntos_oid {
        get { return puntos_oid; } set { puntos_oid = value;  }
}
}
}
