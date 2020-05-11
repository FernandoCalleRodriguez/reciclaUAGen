
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_AccionWeb_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class AccionWebCP : BasicCP
{
public ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN Crear (int p_usuario, int p_tipo)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_AccionWeb_crear) ENABLED START*/

        IAccionWebCAD accionWebCAD = null;
        AccionWebCEN accionWebCEN = null;
        IUsuarioWebCAD usuarioWebCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;

        ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN result = null;


        try
        {
                SessionInitializeTransaction ();
                accionWebCAD = new AccionWebCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebCAD);
                usuarioWebCAD = new UsuarioWebCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebCAD);




                int oid;
                //Initialized AccionWebEN
                AccionWebEN accionWebEN;
                accionWebEN = new AccionWebEN ();

                if (p_usuario != -1) {
                        accionWebEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN ();
                        accionWebEN.Usuario.Id = p_usuario;
                }

                accionWebEN.Fecha = DateTime.Now;


                if (p_tipo != -1) {
                        accionWebEN.Tipo = new ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN ();
                        accionWebEN.Tipo.Id = p_tipo;
                }

                //Call to AccionWebCAD

                oid = accionWebCAD.Crear (accionWebEN);
                result = accionWebCAD.ReadOIDDefault (oid);

                usuarioWebCEN.IncrementarPuntuacion (result.Usuario.Id, result.Tipo.Puntuacion);

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
        return result;


        /*PROTECTED REGION END*/
}
}
}
