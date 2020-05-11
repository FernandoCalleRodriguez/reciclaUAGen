
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_AccionWeb_crearAccion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class AccionWebCP : BasicCP
{
public void CrearAccion (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_AccionWeb_crearAccion) ENABLED START*/

        IAccionWebCAD accionWebCAD = null;
        AccionWebCEN accionWebCEN = null;
        IUsuarioWebCAD usuarioWebCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        AccionWebEN result = null;

        try
        {
                SessionInitializeTransaction ();
                accionWebCAD = new AccionWebCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebCAD);
                usuarioWebCAD = new UsuarioWebCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebCAD);

                result = accionWebCAD.BuscarPorId (p_oid);

                if (result.Usuario != null) {
                        usuarioWebCEN.IncrementarPuntuacion (result.Usuario.Id, result.Tipo.Puntuacion);
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
