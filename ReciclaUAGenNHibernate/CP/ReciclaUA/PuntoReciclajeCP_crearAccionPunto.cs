
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

/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_PuntoReciclaje_crearAccionPunto) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
    public partial class PuntoReciclajeCP : BasicCP
    {
        public void CrearAccionPunto(int p_oid)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_PuntoReciclaje_crearAccionPunto) ENABLED START*/

            IPuntoReciclajeCAD puntoReciclajeCAD = null;
            PuntoReciclajeCEN puntoReciclajeCEN = null;
            AccionWebCEN accionWebCEN = null;
            ITipoAccionCAD tipoAccionCAD = null;
            TipoAccionCEN tipoAccionCEN = null;
            TipoAccionEN tipoAccion = null;
            IUsuarioWebCAD usuarioWebCAD = null;
            UsuarioWebCEN usuarioWebCEN = null;
            PuntoReciclajeEN punto = null;


            try
            {
                SessionInitializeTransaction();
                puntoReciclajeCAD = new PuntoReciclajeCAD(session);
                puntoReciclajeCEN = new PuntoReciclajeCEN(puntoReciclajeCAD);
                tipoAccionCAD = new TipoAccionCAD(session);
                tipoAccionCEN = new TipoAccionCEN(tipoAccionCAD);
                usuarioWebCAD = new UsuarioWebCAD(session);
                usuarioWebCEN = new UsuarioWebCEN(usuarioWebCAD);
                accionWebCEN = new AccionWebCEN();

                punto = puntoReciclajeCEN.BuscarPorId(p_oid);

                if (usuarioWebCEN.BuscarPorId(punto.Usuario.Id) != null)
                {
                    tipoAccion = tipoAccionCEN.BuscarTodos(0, -1).Where(t => t.Nombre.Equals("Punto")).FirstOrDefault();

                    if (tipoAccion == null)
                    {
                        var id = tipoAccionCEN.Crear(30, "Punto");
                        tipoAccion = tipoAccionCEN.BuscarPorId(id);
                    }
                    accionWebCEN.Crear(punto.Usuario.Id, tipoAccion.Id);
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
