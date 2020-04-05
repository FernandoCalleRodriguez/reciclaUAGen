using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class NotaInformativaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int usuarioAdministrador_oid;
public int UsuarioAdministrador_oid {
        get { return usuarioAdministrador_oid; } set { usuarioAdministrador_oid = value;  }
}

private string titulo;
public string Titulo {
        get { return titulo; } set { titulo = value;  }
}
private string cuerpo;
public string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
}
}
