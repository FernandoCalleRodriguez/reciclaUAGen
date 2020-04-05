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
public static class ContenedorAssembler
{
public static ContenedorDTOA Convert (ContenedorEN en, NHibernate.ISession session = null)
{
        ContenedorDTOA dto = null;
        ContenedorRESTCAD contenedorRESTCAD = null;
        ContenedorCEN contenedorCEN = null;
        ContenedorCP contenedorCP = null;

        if (en != null) {
                dto = new ContenedorDTOA ();
                contenedorRESTCAD = new ContenedorRESTCAD (session);
                contenedorCEN = new ContenedorCEN (contenedorRESTCAD);
                contenedorCP = new ContenedorCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Tipo = en.Tipo;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
