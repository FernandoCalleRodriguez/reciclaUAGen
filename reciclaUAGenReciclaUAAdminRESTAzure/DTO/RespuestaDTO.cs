using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class RespuestaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string cuerpo;
public string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}


private int duda_oid;
public int Duda_oid {
        get { return duda_oid; } set { duda_oid = value;  }
}



private int usuario_oid;
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private bool esCorrecta;
public bool EsCorrecta {
        get { return esCorrecta; } set { esCorrecta = value;  }
}
private int util;
public int Util {
        get { return util; } set { util = value;  }
}
}
}
