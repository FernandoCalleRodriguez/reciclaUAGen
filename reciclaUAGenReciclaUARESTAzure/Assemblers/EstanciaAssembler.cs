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
public static class EstanciaAssembler
{
public static EstanciaDTOA Convert (EstanciaEN en, NHibernate.ISession session = null)
{
        EstanciaDTOA dto = null;
        EstanciaRESTCAD estanciaRESTCAD = null;
        EstanciaCEN estanciaCEN = null;
        EstanciaCP estanciaCP = null;

        if (en != null) {
                dto = new EstanciaDTOA ();
                estanciaRESTCAD = new EstanciaRESTCAD (session);
                estanciaCEN = new EstanciaCEN (estanciaRESTCAD);
                estanciaCP = new EstanciaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Actividad = en.Actividad;


                dto.Latitud = en.Latitud;


                dto.Longitud = en.Longitud;


                dto.Nombre = en.Nombre;


                //
                // TravesalLink

                /* Rol: Estancia o--> Edificio */
                dto.EdificioEstancia = EdificioAssembler.Convert ((EdificioEN)en.Edificio, session);

                /* Rol: Estancia o--> Planta */
                dto.PlantaEstancia = PlantaAssembler.Convert ((PlantaEN)en.Planta, session);


                //
                // Service
        }

        return dto;
}
}
}
