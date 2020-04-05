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
public static class UsuarioWebAssembler
{
public static UsuarioWebDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioWebDTOA dto = null;
        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebCP usuarioWebCP = null;

        if (en != null) {
                dto = new UsuarioWebDTOA ();
                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);
                usuarioWebCP = new UsuarioWebCP (session);


                UsuarioWebEN enHijo = usuarioWebRESTCAD.ReadOIDDefault (en.Id);




                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                dto.Email = en.Email;


                dto.Fecha = en.Fecha;


                if (enHijo != null)
                        dto.Puntuacion = enHijo.Puntuacion;


                dto.EmailVerificado = en.EmailVerificado;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
