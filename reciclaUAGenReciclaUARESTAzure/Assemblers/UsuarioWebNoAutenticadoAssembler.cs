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
public static class UsuarioWebNoAutenticadoAssembler
{
public static UsuarioWebNoAutenticadoDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioWebNoAutenticadoDTOA dto = null;
        UsuarioWebNoAutenticadoRESTCAD usuarioWebNoAutenticadoRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioCP usuarioCP = null;

        if (en != null) {
                dto = new UsuarioWebNoAutenticadoDTOA ();
                usuarioWebNoAutenticadoRESTCAD = new UsuarioWebNoAutenticadoRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioWebNoAutenticadoRESTCAD);
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
