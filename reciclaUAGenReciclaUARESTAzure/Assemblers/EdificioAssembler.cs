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
public static class EdificioAssembler
{
public static EdificioDTOA Convert (EdificioEN en, NHibernate.ISession session = null)
{
        EdificioDTOA dto = null;
        EdificioRESTCAD edificioRESTCAD = null;
        EdificioCEN edificioCEN = null;
        EdificioCP edificioCP = null;

        if (en != null) {
                dto = new EdificioDTOA ();
                edificioRESTCAD = new EdificioRESTCAD (session);
                edificioCEN = new EdificioCEN (edificioRESTCAD);
                edificioCP = new EdificioCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                //
                // TravesalLink

                /* Rol: Edificio o--> Planta */
                dto.PlantasEdicio = null;
                List<PlantaEN> PlantasEdicio = edificioRESTCAD.PlantasEdicio (en.Id).ToList ();
                if (PlantasEdicio != null) {
                        dto.PlantasEdicio = new List<PlantaDTOA>();
                        foreach (PlantaEN entry in PlantasEdicio)
                                dto.PlantasEdicio.Add (PlantaAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
