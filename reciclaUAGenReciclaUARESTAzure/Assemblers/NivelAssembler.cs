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
public static class NivelAssembler
{
public static NivelDTOA Convert (NivelEN en, NHibernate.ISession session = null)
{
        NivelDTOA dto = null;
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;
        NivelCP nivelCP = null;

        if (en != null) {
                dto = new NivelDTOA ();
                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);
                nivelCP = new NivelCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Numero = en.Numero;


                dto.Puntuacion = en.Puntuacion;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
