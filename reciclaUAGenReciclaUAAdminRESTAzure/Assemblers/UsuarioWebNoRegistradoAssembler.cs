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
public static class UsuarioWebNoRegistradoAssembler
{
public static UsuarioWebNoRegistradoDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioWebNoRegistradoDTOA dto = null;
        UsuarioWebNoRegistradoRESTCAD usuarioWebNoRegistradoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebCP usuarioWebCP = null;

        if (en != null) {
                dto = new UsuarioWebNoRegistradoDTOA ();
                usuarioWebNoRegistradoRESTCAD = new UsuarioWebNoRegistradoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebNoRegistradoRESTCAD);
                usuarioWebCP = new UsuarioWebCP (session);


                UsuarioWebEN enHijo = usuarioWebNoRegistradoRESTCAD.ReadOIDDefault (en.Id);




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
