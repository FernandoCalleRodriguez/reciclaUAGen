using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using reciclaUAGenReciclaUAAdminRESTAzure.DTOA;
using reciclaUAGenReciclaUAAdminRESTAzure.CAD;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CP.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.Assemblers
{
public static class AccionWebAssembler
{
public static AccionWebDTOA Convert (AccionEN en, NHibernate.ISession session = null)
{
        AccionWebDTOA dto = null;
        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;
        AccionWebCP accionWebCP = null;

        if (en != null) {
                dto = new AccionWebDTOA ();
                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);
                accionWebCP = new AccionWebCP (session);


                AccionWebEN enHijo = accionWebRESTCAD.ReadOIDDefault (en.Id);




                //
                // Attributes

                dto.Id = en.Id;

                dto.Fecha = en.Fecha;


                //
                // TravesalLink

                /* Rol: AccionWeb o--> TipoAccion */
                dto.Tipo = TipoAccionAssembler.Convert ((TipoAccionEN)enHijo.Tipo, session);

                /* Rol: AccionWeb o--> UsuarioWeb */
                dto.UsuarioAccionWeb = UsuarioWebAssembler.Convert ((UsuarioEN)enHijo.Usuario, session);


                //
                // Service
        }

        return dto;
}
}
}
