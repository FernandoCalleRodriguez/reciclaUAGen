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
public static class ItemAssembler
{
public static ItemDTOA Convert (ItemEN en, NHibernate.ISession session = null)
{
        ItemDTOA dto = null;
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;
        ItemCP itemCP = null;

        if (en != null) {
                dto = new ItemDTOA ();
                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);
                itemCP = new ItemCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Descripcion = en.Descripcion;


                dto.Imagen = en.Imagen;


                dto.EsValido = en.EsValido;


                dto.Puntuacion = en.Puntuacion;


                //
                // TravesalLink

                /* Rol: Item o--> Material */
                dto.MaterialItem = MaterialAssembler.Convert ((MaterialEN)en.Material, session);


                //
                // Service
        }

        return dto;
}
}
}
