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
public static class MaterialAssembler
{
public static MaterialDTOA Convert (MaterialEN en, NHibernate.ISession session = null)
{
        MaterialDTOA dto = null;
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;
        MaterialCP materialCP = null;

        if (en != null) {
                dto = new MaterialDTOA ();
                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);
                materialCP = new MaterialCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Contenedor = en.Contenedor;


                dto.EsValido = en.EsValido;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
