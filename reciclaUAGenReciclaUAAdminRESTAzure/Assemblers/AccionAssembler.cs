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
public static class AccionAssembler
{
public static AccionDTOA Convert (AccionEN en, NHibernate.ISession session = null)
{
        AccionDTOA dto = null;
        AccionRESTCAD accionRESTCAD = null;
        AccionCEN accionCEN = null;
        AccionCP accionCP = null;

        if (en != null) {
                dto = new AccionDTOA ();
                accionRESTCAD = new AccionRESTCAD (session);
                accionCEN = new AccionCEN (accionRESTCAD);
                accionCP = new AccionCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: Accion o--> UsuarioWeb */
                dto.UsuarioAccion = UsuarioWebAssembler.Convert ((UsuarioEN)en.Usuario, session);


                //
                // Service
        }

        return dto;
}
}
}
