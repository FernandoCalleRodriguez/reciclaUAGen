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
public static class UsuarioAdminRecuperarPassAssembler
{
public static UsuarioAdminRecuperarPassDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioAdminRecuperarPassDTOA dto = null;
        UsuarioAdminRecuperarPassRESTCAD usuarioAdminRecuperarPassRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;
        UsuarioAdministradorCP usuarioAdministradorCP = null;

        if (en != null) {
                dto = new UsuarioAdminRecuperarPassDTOA ();
                usuarioAdminRecuperarPassRESTCAD = new UsuarioAdminRecuperarPassRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminRecuperarPassRESTCAD);
                usuarioAdministradorCP = new UsuarioAdministradorCP (session);


                UsuarioAdministradorEN enHijo = usuarioAdminRecuperarPassRESTCAD.ReadOIDDefault (en.Id);




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
