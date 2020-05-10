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
public static class UsuarioWebVerificarCuentaAssembler
{
public static UsuarioWebVerificarCuentaDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioWebVerificarCuentaDTOA dto = null;
        UsuarioWebVerificarCuentaRESTCAD usuarioWebVerificarCuentaRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebCP usuarioWebCP = null;

        if (en != null) {
                dto = new UsuarioWebVerificarCuentaDTOA ();
                usuarioWebVerificarCuentaRESTCAD = new UsuarioWebVerificarCuentaRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebVerificarCuentaRESTCAD);
                usuarioWebCP = new UsuarioWebCP (session);


                UsuarioWebEN enHijo = usuarioWebVerificarCuentaRESTCAD.ReadOIDDefault (en.Id);




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
