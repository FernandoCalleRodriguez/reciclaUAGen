
using System;
using System.Text;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Exceptions;


/*
 * Clase Accion:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class AccionCAD : BasicCAD, IAccionCAD
{
public AccionCAD() : base ()
{
}

public AccionCAD(ISession sessionAux) : base (sessionAux)
{
}



public AccionEN ReadOIDDefault (int id
                                )
{
        AccionEN accionEN = null;

        try
        {
                SessionInitializeTransaction ();
                accionEN = (AccionEN)session.Get (typeof(AccionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionEN;
}

public System.Collections.Generic.IList<AccionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AccionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AccionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AccionEN>();
                        else
                                result = session.CreateCriteria (typeof(AccionEN)).List<AccionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AccionEN accion)
{
        try
        {
                SessionInitializeTransaction ();
                AccionEN accionEN = (AccionEN)session.Load (typeof(AccionEN), accion.Id);


                accionEN.Fecha = accion.Fecha;

                session.Update (accionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (AccionEN accion)
{
        try
        {
                SessionInitializeTransaction ();
                if (accion.Usuario != null) {
                        // Argumento OID y no colección.
                        accion.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN), accion.Usuario.Id);

                        accion.Usuario.Acciones
                        .Add (accion);
                }

                session.Save (accion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accion.Id;
}

//Sin e: BuscarPorId
//Con e: AccionEN
public AccionEN BuscarPorId (int id
                             )
{
        AccionEN accionEN = null;

        try
        {
                SessionInitializeTransaction ();
                accionEN = (AccionEN)session.Get (typeof(AccionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionEN;
}

public System.Collections.Generic.IList<AccionEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AccionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AccionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AccionEN>();
                else
                        result = session.CreateCriteria (typeof(AccionEN)).List<AccionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
