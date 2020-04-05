
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
 * Clase TipoAccion:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class TipoAccionCAD : BasicCAD, ITipoAccionCAD
{
public TipoAccionCAD() : base ()
{
}

public TipoAccionCAD(ISession sessionAux) : base (sessionAux)
{
}



public TipoAccionEN ReadOIDDefault (int id
                                    )
{
        TipoAccionEN tipoAccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoAccionEN = (TipoAccionEN)session.Get (typeof(TipoAccionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoAccionEN;
}

public System.Collections.Generic.IList<TipoAccionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TipoAccionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TipoAccionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TipoAccionEN>();
                        else
                                result = session.CreateCriteria (typeof(TipoAccionEN)).List<TipoAccionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TipoAccionEN tipoAccion)
{
        try
        {
                SessionInitializeTransaction ();
                TipoAccionEN tipoAccionEN = (TipoAccionEN)session.Load (typeof(TipoAccionEN), tipoAccion.Id);

                tipoAccionEN.Puntuacion = tipoAccion.Puntuacion;



                tipoAccionEN.Nombre = tipoAccion.Nombre;

                session.Update (tipoAccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (TipoAccionEN tipoAccion)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tipoAccion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoAccion.Id;
}

public void Modificar (TipoAccionEN tipoAccion)
{
        try
        {
                SessionInitializeTransaction ();
                TipoAccionEN tipoAccionEN = (TipoAccionEN)session.Load (typeof(TipoAccionEN), tipoAccion.Id);

                tipoAccionEN.Puntuacion = tipoAccion.Puntuacion;


                tipoAccionEN.Nombre = tipoAccion.Nombre;

                session.Update (tipoAccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int id
                    )
{
        try
        {
                SessionInitializeTransaction ();
                TipoAccionEN tipoAccionEN = (TipoAccionEN)session.Load (typeof(TipoAccionEN), id);
                session.Delete (tipoAccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: TipoAccionEN
public TipoAccionEN BuscarPorId (int id
                                 )
{
        TipoAccionEN tipoAccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoAccionEN = (TipoAccionEN)session.Get (typeof(TipoAccionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoAccionEN;
}

public System.Collections.Generic.IList<TipoAccionEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<TipoAccionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TipoAccionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TipoAccionEN>();
                else
                        result = session.CreateCriteria (typeof(TipoAccionEN)).List<TipoAccionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in TipoAccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
