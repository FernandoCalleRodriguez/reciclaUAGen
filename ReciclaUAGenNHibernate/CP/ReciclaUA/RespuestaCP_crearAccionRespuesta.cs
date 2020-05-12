
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

/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Respuesta_crearAccionRespuesta) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
    public partial class RespuestaCP : BasicCP
    {
        public void CrearAccionRespuesta(int p_oid)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Respuesta_crearAccionRespuesta) ENABLED START*/

            IRespuestaCAD respuestaCAD = null;
            RespuestaCEN respuestaCEN = null;
            AccionWebCEN accionWebCEN = null;
            ITipoAccionCAD tipoAccionCAD = null;
            TipoAccionCEN tipoAccionCEN = null;
            TipoAccionEN tipoAccion = null;
            IUsuarioWebCAD usuarioWebCAD = null;
            UsuarioWebCEN usuarioWebCEN = null;
            RespuestaEN respuesta = null;

            try
            {
                SessionInitializeTransaction();
                respuestaCAD = new RespuestaCAD(session);
                respuestaCEN = new RespuestaCEN(respuestaCAD);
                tipoAccionCAD = new TipoAccionCAD(session);
                tipoAccionCEN = new TipoAccionCEN(tipoAccionCAD);
                usuarioWebCAD = new UsuarioWebCAD(session);
                usuarioWebCEN = new UsuarioWebCEN(usuarioWebCAD);
                accionWebCEN = new AccionWebCEN();

                respuesta = respuestaCEN.BuscarPorId(p_oid);

                if (respuesta.Usuario != null && usuarioWebCEN.BuscarPorId(respuesta.Usuario.Id) != null)
                {
                    tipoAccion = tipoAccionCEN.BuscarTodos(0, -1).Where(t => t.Nombre.Equals("Respuesta")).FirstOrDefault();

                    if (tipoAccion == null)
                    {
                        var id = tipoAccionCEN.Crear(5, "Respuesta");
                        tipoAccion = tipoAccionCEN.BuscarPorId(id);
                    }
                    accionWebCEN.Crear(respuesta.Usuario.Id, tipoAccion.Id);
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
