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
public static class NotaInformativaAssembler
{
public static NotaInformativaDTOA Convert (NotaInformativaEN en, NHibernate.ISession session = null)
{
        NotaInformativaDTOA dto = null;
        NotaInformativaRESTCAD notaInformativaRESTCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;
        NotaInformativaCP notaInformativaCP = null;

        if (en != null) {
                dto = new NotaInformativaDTOA ();
                notaInformativaRESTCAD = new NotaInformativaRESTCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaRESTCAD);
                notaInformativaCP = new NotaInformativaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Titulo = en.Titulo;


                dto.Cuerpo = en.Cuerpo;


                dto.Fecha = en.Fecha;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
