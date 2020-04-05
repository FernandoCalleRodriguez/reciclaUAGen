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
public static class UsuarioAdminNoAutenticadoAssembler
{
public static UsuarioAdminNoAutenticadoDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioAdminNoAutenticadoDTOA dto = null;
        UsuarioAdminNoAutenticadoRESTCAD usuarioAdminNoAutenticadoRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioCP usuarioCP = null;

        if (en != null) {
                dto = new UsuarioAdminNoAutenticadoDTOA ();
                usuarioAdminNoAutenticadoRESTCAD = new UsuarioAdminNoAutenticadoRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioAdminNoAutenticadoRESTCAD);
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
