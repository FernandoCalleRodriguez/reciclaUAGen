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
public static class DudaAssembler
{
public static DudaDTOA Convert (DudaEN en, NHibernate.ISession session = null)
{
        DudaDTOA dto = null;
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;
        DudaCP dudaCP = null;

        if (en != null) {
                dto = new DudaDTOA ();
                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);
                dudaCP = new DudaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Titulo = en.Titulo;


                dto.Cuerpo = en.Cuerpo;


                dto.Fecha = en.Fecha;


                dto.Util = en.Util;


                dto.Tema = en.Tema;


                //
                // TravesalLink

                /* Rol: Duda o--> UsuarioAdminAutenticado */
                dto.UsuarioDuda = UsuarioAdminAutenticadoAssembler.Convert ((UsuarioEN)en.Usuario, session);


                //
                // Service

                /* ServiceLink: obtenerNumeroDeRespuestas */
                dto.ObtenerNumeroDeRespuestas = dudaCP.ObtenerNumeroDeRespuestas (en.Id);

                /* ServiceLink: obtenerSiRespuestaValida */
                dto.ObtenerSiRespuestaValida = dudaCP.ObtenerSiRespuestaValida (en.Id);
        }

        return dto;
}
}
}
