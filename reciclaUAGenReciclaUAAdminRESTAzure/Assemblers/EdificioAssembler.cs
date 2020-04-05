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


                //
                // Service
        }

        return dto;
}
}
}
