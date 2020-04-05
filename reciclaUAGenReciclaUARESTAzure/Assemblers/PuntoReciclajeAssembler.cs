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
public static class PuntoReciclajeAssembler
{
public static PuntoReciclajeDTOA Convert (PuntoReciclajeEN en, NHibernate.ISession session = null)
{
        PuntoReciclajeDTOA dto = null;
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;
        PuntoReciclajeCP puntoReciclajeCP = null;

        if (en != null) {
                dto = new PuntoReciclajeDTOA ();
                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);
                puntoReciclajeCP = new PuntoReciclajeCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Latitud = en.Latitud;


                dto.Longitud = en.Longitud;


                dto.EsValido = en.EsValido;


                //
                // TravesalLink

                /* Rol: PuntoReciclaje o--> Contenedor */
                dto.Contenedores = null;
                List<ContenedorEN> Contenedores = puntoReciclajeRESTCAD.Contenedores (en.Id).ToList ();
                if (Contenedores != null) {
                        dto.Contenedores = new List<ContenedorDTOA>();
                        foreach (ContenedorEN entry in Contenedores)
                                dto.Contenedores.Add (ContenedorAssembler.Convert (entry, session));
                }

                /* Rol: PuntoReciclaje o--> Estancia */
                dto.EstanciaPunto = EstanciaAssembler.Convert ((EstanciaEN)en.Estancia, session);


                //
                // Service
        }

        return dto;
}
}
}
