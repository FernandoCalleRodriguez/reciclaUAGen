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
public static class PlantaAssembler
{
public static PlantaDTOA Convert (PlantaEN en, NHibernate.ISession session = null)
{
        PlantaDTOA dto = null;
        PlantaRESTCAD plantaRESTCAD = null;
        PlantaCEN plantaCEN = null;
        PlantaCP plantaCP = null;

        if (en != null) {
                dto = new PlantaDTOA ();
                plantaRESTCAD = new PlantaRESTCAD (session);
                plantaCEN = new PlantaCEN (plantaRESTCAD);
                plantaCP = new PlantaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Planta = en.Planta;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
