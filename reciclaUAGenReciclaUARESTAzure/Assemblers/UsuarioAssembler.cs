using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using reciclaUAGenReciclaUARESTAzure.DTOA;
using reciclaUAGenReciclaUARESTAzure.CAD;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CP.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.Assemblers
{
public static class UsuarioAssembler
{
public static UsuarioDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioDTOA dto = null;
        UsuarioRESTCAD usuarioRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioCP usuarioCP = null;

        if (en != null) {
                dto = new UsuarioDTOA ();
                usuarioRESTCAD = new UsuarioRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioRESTCAD);
                usuarioCP = new UsuarioCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
