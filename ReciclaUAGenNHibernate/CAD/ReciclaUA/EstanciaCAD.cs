
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
 * Clase Estancia:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class EstanciaCAD : BasicCAD, IEstanciaCAD
{
public EstanciaCAD() : base ()
{
}

public EstanciaCAD(ISession sessionAux) : base (sessionAux)
{
}



public EstanciaEN ReadOIDDefault (string id
                                  )
{
        EstanciaEN estanciaEN = null;

        try
        {
                SessionInitializeTransaction ();
                estanciaEN = (EstanciaEN)session.Get (typeof(EstanciaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return estanciaEN;
}

public System.Collections.Generic.IList<EstanciaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EstanciaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EstanciaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EstanciaEN>();
                        else
                                result = session.CreateCriteria (typeof(EstanciaEN)).List<EstanciaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EstanciaEN estancia)
{
        try
        {
                SessionInitializeTransaction ();
                EstanciaEN estanciaEN = (EstanciaEN)session.Load (typeof(EstanciaEN), estancia.Id);

                estanciaEN.Actividad = estancia.Actividad;


                estanciaEN.Latitud = estancia.Latitud;


                estanciaEN.Longitud = estancia.Longitud;


                estanciaEN.Nombre = estancia.Nombre;




                session.Update (estanciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (EstanciaEN estancia)
{
        try
        {
                SessionInitializeTransaction ();
                EstanciaEN estanciaEN = (EstanciaEN)session.Load (typeof(EstanciaEN), estancia.Id);

                estanciaEN.Actividad = estancia.Actividad;


                estanciaEN.Latitud = estancia.Latitud;


                estanciaEN.Longitud = estancia.Longitud;


                estanciaEN.Nombre = estancia.Nombre;

                session.Update (estanciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (string id
                    )
{
        try
        {
                SessionInitializeTransaction ();
                EstanciaEN estanciaEN = (EstanciaEN)session.Load (typeof(EstanciaEN), id);
                session.Delete (estanciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: EstanciaEN
public EstanciaEN BuscarPorId (string id
                               )
{
        EstanciaEN estanciaEN = null;

        try
        {
                SessionInitializeTransaction ();
                estanciaEN = (EstanciaEN)session.Get (typeof(EstanciaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return estanciaEN;
}

public System.Collections.Generic.IList<EstanciaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<EstanciaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EstanciaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EstanciaEN>();
                else
                        result = session.CreateCriteria (typeof(EstanciaEN)).List<EstanciaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public string Crear (EstanciaEN estancia)
{
        try
        {
                SessionInitializeTransaction ();
                if (estancia.Edificio != null) {
                        // Argumento OID y no colección.
                        estancia.Edificio = (ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN), estancia.Edificio.Id);

                        estancia.Edificio.Estancias
                        .Add (estancia);
                }
                if (estancia.Planta != null) {
                        // Argumento OID y no colección.
                        estancia.Planta = (ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN), estancia.Planta.Id);

                        estancia.Planta.Estancias
                        .Add (estancia);
                }

                session.Save (estancia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return estancia.Id;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> BuscarEstanciasPorEdificio (int id_edificio)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EstanciaEN self where FROM EstanciaEN as estancia where estancia.Edificio is not empty and estancia.Edificio = :id_edificio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EstanciaENbuscarEstanciasPorEdificioHQL");
                query.SetParameter ("id_edificio", id_edificio);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
