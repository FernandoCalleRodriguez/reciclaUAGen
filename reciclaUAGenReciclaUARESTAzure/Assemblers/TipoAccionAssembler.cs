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
public static class TipoAccionAssembler
{
public static TipoAccionDTOA Convert (TipoAccionEN en, NHibernate.ISession session = null)
{
        TipoAccionDTOA dto = null;
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;
        TipoAccionCP tipoAccionCP = null;

        if (en != null) {
                dto = new TipoAccionDTOA ();
                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);
                tipoAccionCP = new TipoAccionCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Puntuacion = en.Puntuacion;


                dto.Nombre = en.Nombre;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
