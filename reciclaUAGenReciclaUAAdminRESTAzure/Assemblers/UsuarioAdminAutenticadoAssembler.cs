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
public static class UsuarioAdminAutenticadoAssembler
{
public static UsuarioAdminAutenticadoDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioAdminAutenticadoDTOA dto = null;
        UsuarioAdminAutenticadoRESTCAD usuarioAdminAutenticadoRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;
        UsuarioAdministradorCP usuarioAdministradorCP = null;

        if (en != null) {
                dto = new UsuarioAdminAutenticadoDTOA ();
                usuarioAdminAutenticadoRESTCAD = new UsuarioAdminAutenticadoRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminAutenticadoRESTCAD);
                usuarioAdministradorCP = new UsuarioAdministradorCP (session);


                UsuarioAdministradorEN enHijo = usuarioAdminAutenticadoRESTCAD.ReadOIDDefault (en.Id);




                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                dto.Email = en.Email;


                dto.Fecha = en.Fecha;


                dto.EmailVerificado = en.EmailVerificado;


                dto.Borrado = en.Borrado;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
