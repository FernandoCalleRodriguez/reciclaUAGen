using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class UsuarioAdministradorDTO                    :                           UsuarioDTO


{
private System.Collections.Generic.IList<int> notas_oid;
public System.Collections.Generic.IList<int> Notas_oid {
        get { return notas_oid; } set { notas_oid = value;  }
}
}
}
