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


                dto.EsCorrecta = en.EsCorrecta;


                dto.Util = en.Util;


                dto.Fecha = en.Fecha;


                //
                // TravesalLink

                /* Rol: Respuesta o--> UsuarioWebAutenticado */
                dto.UsuarioRespuesta = UsuarioWebAutenticadoAssembler.Convert ((UsuarioEN)en.Usuario, session);


                //
                // Service
        }

        return dto;
}
}
}
