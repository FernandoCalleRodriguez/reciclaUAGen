
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Item_crearAccionItem) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class ItemCP : BasicCP
{
public void CrearAccionItem (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Item_crearAccionItem) ENABLED START*/

        IItemCAD itemCAD = null;
        ItemCEN itemCEN = null;
        AccionWebCEN accionWebCEN = null;
        ITipoAccionCAD tipoAccionCAD = null;
        TipoAccionCEN tipoAccionCEN = null;
        TipoAccionEN tipoAccion = null;
        IUsuarioWebCAD usuarioWebCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        ItemEN item = null;

        try
        {
                SessionInitializeTransaction ();
                itemCAD = new ItemCAD (session);
                itemCEN = new ItemCEN (itemCAD);
                tipoAccionCAD = new TipoAccionCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionCAD);
                usuarioWebCAD = new UsuarioWebCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebCAD);
                accionWebCEN = new AccionWebCEN ();

                item = itemCEN.BuscarPorId (p_oid);

                if (item.Usuario != null && usuarioWebCEN.BuscarPorId (item.Usuario.Id) != null) {
                        tipoAccion = tipoAccionCEN.BuscarTodos (0, -1).Where (t => t.Nombre.Equals ("Item")).FirstOrDefault ();

                        if (tipoAccion == null) {
                                var id = tipoAccionCEN.Crear (10, "Item");
                                tipoAccion = tipoAccionCEN.BuscarPorId (id);
                        }
                        accionWebCEN.Crear (item.Usuario.Id, tipoAccion.Id);
                }
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
