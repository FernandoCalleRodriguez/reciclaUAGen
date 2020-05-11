
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_AccionReciclar_crearAccion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class AccionReciclarCP : BasicCP
{
public void CrearAccion (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_AccionReciclar_crearAccion) ENABLED START*/

        IAccionReciclarCAD accionReciclarCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;
        IUsuarioWebCAD usuarioWebCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        AccionReciclarEN result = null;


        try
        {
                SessionInitializeTransaction ();
                accionReciclarCAD = new AccionReciclarCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarCAD);
                usuarioWebCAD = new UsuarioWebCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebCAD);

                result = accionReciclarCAD.ReadOIDDefault (p_oid);

                if (result.Usuario != null) {
                        usuarioWebCEN.IncrementarPuntuacion (result.Usuario.Id, result.Item.Puntuacion * result.Cantidad);
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
