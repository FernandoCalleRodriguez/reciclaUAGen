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
public static class RespuestaAssembler
{
public static RespuestaDTOA Convert (RespuestaEN en, NHibernate.ISession session = null)
{
        RespuestaDTOA dto = null;
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;
        RespuestaCP respuestaCP = null;

        if (en != null) {
                dto = new RespuestaDTOA ();
                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);
                respuestaCP = new RespuestaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cuerpo = en.Cuerpo;


                dto.Fecha = en.Fecha;


                dto.EsCorrecta = en.EsCorrecta;


                dto.Util = en.Util;


                //
                // TravesalLink

                /* Rol: Respuesta o--> UsuarioAdminAutenticado */
                dto.UsuarioRespuesta = UsuarioAdminAutenticadoAssembler.Convert ((UsuarioEN)en.Usuario, session);


                //
                // Service
        }

        return dto;
}
}
}
