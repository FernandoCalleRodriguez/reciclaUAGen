using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class TipoAccionDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private int puntuacion;
public int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}


private System.Collections.Generic.IList<int> acciones_oid;
public System.Collections.Generic.IList<int> Acciones_oid {
        get { return acciones_oid; } set { acciones_oid = value;  }
}

private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
}
}
