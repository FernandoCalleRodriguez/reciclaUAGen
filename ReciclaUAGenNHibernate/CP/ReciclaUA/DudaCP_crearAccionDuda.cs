
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

/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Duda_crearAccionDuda) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
    public partial class DudaCP : BasicCP
    {
        public void CrearAccionDuda(int p_oid)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Duda_crearAccionDuda) ENABLED START*/

            IDudaCAD dudaCAD = null;
            DudaCEN dudaCEN = null;
            AccionWebCEN accionWebCEN = null;
            ITipoAccionCAD tipoAccionCAD = null;
            TipoAccionCEN tipoAccionCEN = null;
            TipoAccionEN tipoAccion = null;
            IUsuarioWebCAD usuarioWebCAD = null;
            UsuarioWebCEN usuarioWebCEN = null;
            DudaEN duda = null;


            try
            {
                SessionInitializeTransaction();
                dudaCAD = new DudaCAD(session);
                dudaCEN = new DudaCEN(dudaCAD);
                tipoAccionCAD = new TipoAccionCAD(session);
                tipoAccionCEN = new TipoAccionCEN(tipoAccionCAD);
                usuarioWebCAD = new UsuarioWebCAD(session);
                usuarioWebCEN = new UsuarioWebCEN(usuarioWebCAD);
                accionWebCEN = new AccionWebCEN();

                duda = dudaCEN.BuscarPorId(p_oid);

                if (usuarioWebCEN.BuscarPorId(duda.Usuario.Id) != null)
                {
                    tipoAccion = tipoAccionCEN.BuscarTodos(0, -1).Where(t => t.Nombre.Equals("Duda")).FirstOrDefault();

                    if (tipoAccion == null)
                    {
                        var id = tipoAccionCEN.Crear(10, "Duda");
                        tipoAccion = tipoAccionCEN.BuscarPorId(id);
                    }
                    accionWebCEN.Crear(duda.Usuario.Id, tipoAccion.Id);
                }

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }


            /*PROTECTED REGION END*/
        }
    }
}
