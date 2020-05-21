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
public static class UsuarioWebAutenticadoAssembler
{
public static UsuarioWebAutenticadoDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioWebAutenticadoDTOA dto = null;
        UsuarioWebAutenticadoRESTCAD usuarioWebAutenticadoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebCP usuarioWebCP = null;

        if (en != null) {
                dto = new UsuarioWebAutenticadoDTOA ();
                usuarioWebAutenticadoRESTCAD = new UsuarioWebAutenticadoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebAutenticadoRESTCAD);
                usuarioWebCP = new UsuarioWebCP (session);


                UsuarioWebEN enHijo = usuarioWebAutenticadoRESTCAD.ReadOIDDefault (en.Id);




                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                dto.Email = en.Email;


                if (enHijo != null)
                        dto.Puntuacion = enHijo.Puntuacion;


                dto.Fecha = en.Fecha;


                dto.Borrado = en.Borrado;


                //
                // TravesalLink

                /* Rol: UsuarioWebAutenticado o--> Juego */
                dto.JuegoUsuario = JuegoAssembler.Convert ((JuegoEN)enHijo.Juegos, session);


                //
                // Service
        }

        return dto;
}
}
}
