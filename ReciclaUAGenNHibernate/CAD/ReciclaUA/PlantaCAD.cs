
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
 * Clase Planta:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class PlantaCAD : BasicCAD, IPlantaCAD
{
public PlantaCAD() : base ()
{
}

public PlantaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PlantaEN ReadOIDDefault (int id
                                )
{
        PlantaEN plantaEN = null;

        try
        {
                SessionInitializeTransaction ();
                plantaEN = (PlantaEN)session.Get (typeof(PlantaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return plantaEN;
}

public System.Collections.Generic.IList<PlantaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PlantaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PlantaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PlantaEN>();
                        else
                                result = session.CreateCriteria (typeof(PlantaEN)).List<PlantaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PlantaEN planta)
{
        try
        {
                SessionInitializeTransaction ();
                PlantaEN plantaEN = (PlantaEN)session.Load (typeof(PlantaEN), planta.Id);

                plantaEN.Planta = planta.Planta;



                session.Update (plantaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (PlantaEN planta)
{
        try
        {
                SessionInitializeTransaction ();
                if (planta.Edificio != null) {
                        // Argumento OID y no colección.
                        planta.Edificio = (ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN), planta.Edificio.Id);

                        planta.Edificio.Plantas
                        .Add (planta);
                }

                session.Save (planta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return planta.Id;
}

public void Modificar (PlantaEN planta)
{
        try
        {
                SessionInitializeTransaction ();
                PlantaEN plantaEN = (PlantaEN)session.Load (typeof(PlantaEN), planta.Id);

                plantaEN.Planta = planta.Planta;

                session.Update (plantaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
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
                PlantaEN plantaEN = (PlantaEN)session.Load (typeof(PlantaEN), id);
                session.Delete (plantaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: PlantaEN
public PlantaEN BuscarPorId (int id
                             )
{
        PlantaEN plantaEN = null;

        try
        {
                SessionInitializeTransaction ();
                plantaEN = (PlantaEN)session.Get (typeof(PlantaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return plantaEN;
}

public System.Collections.Generic.IList<PlantaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<PlantaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PlantaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PlantaEN>();
                else
                        result = session.CreateCriteria (typeof(PlantaEN)).List<PlantaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PlantaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
