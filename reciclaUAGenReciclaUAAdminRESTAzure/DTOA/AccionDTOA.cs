using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class AccionDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}



/* Rol: Accion o--> UsuarioWeb */
private UsuarioWebDTOA usuarioAccion;
public UsuarioWebDTOA UsuarioAccion
{
        get { return usuarioAccion; }
        set { usuarioAccion = value; }
}
}
}
