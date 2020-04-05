using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class DudaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string titulo;
public string Titulo {
        get { return titulo; } set { titulo = value;  }
}
private string cuerpo;
public string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}


private int usuario_oid;
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}

private System.Collections.Generic.IList<RespuestaDTO> respuestas;
public System.Collections.Generic.IList<RespuestaDTO> Respuestas {
        get { return respuestas; } set { respuestas = value;  }
}
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private int util;
public int Util {
        get { return util; } set { util = value;  }
}
private string temas;
public string Temas {
        get { return temas; } set { temas = value;  }
}
}
}
