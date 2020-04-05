
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
 * Clase Nivel:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class NivelCAD : BasicCAD, INivelCAD
{
public NivelCAD() : base ()
{
}

public NivelCAD(ISession sessionAux) : base (sessionAux)
{
}



public NivelEN ReadOIDDefault (int id
                               )
{
        NivelEN nivelEN = null;

        try
        {
                SessionInitializeTransaction ();
                nivelEN = (NivelEN)session.Get (typeof(NivelEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return nivelEN;
}

public System.Collections.Generic.IList<NivelEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NivelEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NivelEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NivelEN>();
                        else
                                result = session.CreateCriteria (typeof(NivelEN)).List<NivelEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NivelEN nivel)
{
        try
        {
                SessionInitializeTransaction ();
                NivelEN nivelEN = (NivelEN)session.Load (typeof(NivelEN), nivel.Id);

                nivelEN.Numero = nivel.Numero;


                nivelEN.Puntuacion = nivel.Puntuacion;


                session.Update (nivelEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (NivelEN nivel)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (nivel);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return nivel.Id;
}

public void Modificar (NivelEN nivel)
{
        try
        {
                SessionInitializeTransaction ();
                NivelEN nivelEN = (NivelEN)session.Load (typeof(NivelEN), nivel.Id);

                nivelEN.Numero = nivel.Numero;


                nivelEN.Puntuacion = nivel.Puntuacion;

                session.Update (nivelEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
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
                NivelEN nivelEN = (NivelEN)session.Load (typeof(NivelEN), id);
                session.Delete (nivelEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: NivelEN
public NivelEN BuscarPorId (int id
                            )
{
        NivelEN nivelEN = null;

        try
        {
                SessionInitializeTransaction ();
                nivelEN = (NivelEN)session.Get (typeof(NivelEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return nivelEN;
}

public System.Collections.Generic.IList<NivelEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<NivelEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NivelEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NivelEN>();
                else
                        result = session.CreateCriteria (typeof(NivelEN)).List<NivelEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NivelCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
