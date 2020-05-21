using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class UsuarioDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string apellidos;
public string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}
private string email;
public string Email {
        get { return email; } set { email = value;  }
}
private String pass;
public String Pass {
        get { return pass; } set { pass = value;  }
}
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}


private System.Collections.Generic.IList<int> items_oid;
public System.Collections.Generic.IList<int> Items_oid {
        get { return items_oid; } set { items_oid = value;  }
}



private System.Collections.Generic.IList<int> dudas_oid;
public System.Collections.Generic.IList<int> Dudas_oid {
        get { return dudas_oid; } set { dudas_oid = value;  }
}



private System.Collections.Generic.IList<int> respuestas_oid;
public System.Collections.Generic.IList<int> Respuestas_oid {
        get { return respuestas_oid; } set { respuestas_oid = value;  }
}



private System.Collections.Generic.IList<int> puntos_oid;
public System.Collections.Generic.IList<int> Puntos_oid {
        get { return puntos_oid; } set { puntos_oid = value;  }
}

private bool emailVerificado;
public bool EmailVerificado {
        get { return emailVerificado; } set { emailVerificado = value;  }
}


private System.Collections.Generic.IList<int> materiales_oid;
public System.Collections.Generic.IList<int> Materiales_oid {
        get { return materiales_oid; } set { materiales_oid = value;  }
}

private bool borrado;
public bool Borrado {
        get { return borrado; } set { borrado = value;  }
}


private int juegos_oid;
public int Juegos_oid {
        get { return juegos_oid; } set { juegos_oid = value;  }
}
}
}
