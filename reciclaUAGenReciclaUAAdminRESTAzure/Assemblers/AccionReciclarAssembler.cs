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
public static class AccionReciclarAssembler
{
public static AccionReciclarDTOA Convert (AccionEN en, NHibernate.ISession session = null)
{
        AccionReciclarDTOA dto = null;
        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;
        AccionReciclarCP accionReciclarCP = null;

        if (en != null) {
                dto = new AccionReciclarDTOA ();
                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);
                accionReciclarCP = new AccionReciclarCP (session);


                AccionReciclarEN enHijo = accionReciclarRESTCAD.ReadOIDDefault (en.Id);




                //
                // Attributes

                dto.Id = en.Id;

                if (enHijo != null)
                        dto.Cantidad = enHijo.Cantidad;


                dto.Fecha = en.Fecha;


                //
                // TravesalLink

                /* Rol: AccionReciclar o--> Item */
                dto.ItemAccion = ItemAssembler.Convert ((ItemEN)enHijo.Item, session);

                /* Rol: AccionReciclar o--> Contenedor */
                dto.ContenedorAccion = ContenedorAssembler.Convert ((ContenedorEN)enHijo.Contenedor, session);

                /* Rol: AccionReciclar o--> UsuarioWeb */
                dto.UsuarioAccionReciclar = UsuarioWebAssembler.Convert ((UsuarioEN)enHijo.Usuario, session);


                //
                // Service
        }

        return dto;
}
}
}
