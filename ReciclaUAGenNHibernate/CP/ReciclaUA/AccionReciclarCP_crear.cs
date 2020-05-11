
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_AccionReciclar_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class AccionReciclarCP : BasicCP
{
public ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN Crear (int p_usuario, int p_contenedor, int p_item, int p_cantidad)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_AccionReciclar_crear) ENABLED START*/

        IAccionReciclarCAD accionReciclarCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;

        IUsuarioWebCAD usuarioWebCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;

        ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN result = null;


        try
        {
                SessionInitializeTransaction ();
                accionReciclarCAD = new AccionReciclarCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarCAD);
                usuarioWebCAD = new UsuarioWebCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebCAD);




                int oid;
                //Initialized AccionReciclarEN
                AccionReciclarEN accionReciclarEN;
                accionReciclarEN = new AccionReciclarEN ();

                if (p_usuario != -1) {
                        accionReciclarEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN ();
                        accionReciclarEN.Usuario.Id = p_usuario;
                }

                accionReciclarEN.Fecha = DateTime.Now;


                if (p_contenedor != -1) {
                        accionReciclarEN.Contenedor = new ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN ();
                        accionReciclarEN.Contenedor.Id = p_contenedor;
                }


                if (p_item != -1) {
                        accionReciclarEN.Item = new ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN ();
                        accionReciclarEN.Item.Id = p_item;
                }

                accionReciclarEN.Cantidad = p_cantidad;

                //Call to AccionReciclarCAD

                oid = accionReciclarCAD.Crear (accionReciclarEN);
                result = accionReciclarCAD.ReadOIDDefault (oid);

                usuarioWebCEN.IncrementarPuntuacion (result.Usuario.Id, result.Item.Puntuacion * result.Cantidad);

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
