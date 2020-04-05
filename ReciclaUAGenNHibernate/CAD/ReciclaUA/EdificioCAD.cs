
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
 * Clase Edificio:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class EdificioCAD : BasicCAD, IEdificioCAD
{
public EdificioCAD() : base ()
{
}

public EdificioCAD(ISession sessionAux) : base (sessionAux)
{
}



public EdificioEN ReadOIDDefault (int id
                                  )
{
        EdificioEN edificioEN = null;

        try
        {
                SessionInitializeTransaction ();
                edificioEN = (EdificioEN)session.Get (typeof(EdificioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return edificioEN;
}

public System.Collections.Generic.IList<EdificioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EdificioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EdificioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EdificioEN>();
                        else
                                result = session.CreateCriteria (typeof(EdificioEN)).List<EdificioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EdificioEN edificio)
{
        try
        {
                SessionInitializeTransaction ();
                EdificioEN edificioEN = (EdificioEN)session.Load (typeof(EdificioEN), edificio.Id);

                edificioEN.Nombre = edificio.Nombre;



                session.Update (edificioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (EdificioEN edificio)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (edificio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return edificio.Id;
}

public void Modificar (EdificioEN edificio)
{
        try
        {
                SessionInitializeTransaction ();
                EdificioEN edificioEN = (EdificioEN)session.Load (typeof(EdificioEN), edificio.Id);

                edificioEN.Nombre = edificio.Nombre;

                session.Update (edificioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
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
                EdificioEN edificioEN = (EdificioEN)session.Load (typeof(EdificioEN), id);
                session.Delete (edificioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: EdificioEN
public EdificioEN BuscarPorId (int id
                               )
{
        EdificioEN edificioEN = null;

        try
        {
                SessionInitializeTransaction ();
                edificioEN = (EdificioEN)session.Get (typeof(EdificioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return edificioEN;
}

public System.Collections.Generic.IList<EdificioEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<EdificioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EdificioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EdificioEN>();
                else
                        result = session.CreateCriteria (typeof(EdificioEN)).List<EdificioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
