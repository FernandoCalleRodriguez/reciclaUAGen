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
public static class JuegoAssembler
{
public static JuegoDTOA Convert (JuegoEN en, NHibernate.ISession session = null)
{
        JuegoDTOA dto = null;
        JuegoRESTCAD juegoRESTCAD = null;
        JuegoCEN juegoCEN = null;
        JuegoCP juegoCP = null;

        if (en != null) {
                dto = new JuegoDTOA ();
                juegoRESTCAD = new JuegoRESTCAD (session);
                juegoCEN = new JuegoCEN (juegoRESTCAD);
                juegoCP = new JuegoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.ItemActual = en.ItemActual;


                dto.Aciertos = en.Aciertos;


                dto.Fallos = en.Fallos;


                dto.Puntuacion = en.Puntuacion;


                dto.IntentosItemActual = en.IntentosItemActual;


                dto.Finalizado = en.Finalizado;


                dto.NivelActual = en.NivelActual;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
