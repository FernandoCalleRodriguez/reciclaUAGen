
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
 * Clase Aula:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class AulaCAD : BasicCAD, IAulaCAD
{
public AulaCAD() : base ()
{
}

public AulaCAD(ISession sessionAux) : base (sessionAux)
{
}



public AulaEN ReadOIDDefault (int id
                              )
{
        AulaEN aulaEN = null;

        try
        {
                SessionInitializeTransaction ();
                aulaEN = (AulaEN)session.Get (typeof(AulaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return aulaEN;
}

public System.Collections.Generic.IList<AulaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AulaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AulaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AulaEN>();
                        else
                                result = session.CreateCriteria (typeof(AulaEN)).List<AulaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AulaEN aula)
{
        try
        {
                SessionInitializeTransaction ();
                AulaEN aulaEN = (AulaEN)session.Load (typeof(AulaEN), aula.Id);


                aulaEN.Planta = aula.Planta;

                session.Update (aulaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (AulaEN aula)
{
        try
        {
                SessionInitializeTransaction ();
                if (aula.Edificio != null) {
                        // Argumento OID y no colección.
                        aula.Edificio = (ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN), aula.Edificio.Id);

                        aula.Edificio.Aulas
                        .Add (aula);
                }

                session.Save (aula);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return aula.Id;
}

public void Modificar (AulaEN aula)
{
        try
        {
                SessionInitializeTransaction ();
                AulaEN aulaEN = (AulaEN)session.Load (typeof(AulaEN), aula.Id);

                aulaEN.Planta = aula.Planta;

                session.Update (aulaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                AulaEN aulaEN = (AulaEN)session.Load (typeof(AulaEN), id);
                session.Delete (aulaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorID
//Con e: AulaEN
public AulaEN BuscarPorID (int id
                           )
{
        AulaEN aulaEN = null;

        try
        {
                SessionInitializeTransaction ();
                aulaEN = (AulaEN)session.Get (typeof(AulaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return aulaEN;
}

public System.Collections.Generic.IList<AulaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AulaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AulaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AulaEN>();
                else
                        result = session.CreateCriteria (typeof(AulaEN)).List<AulaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AulaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
