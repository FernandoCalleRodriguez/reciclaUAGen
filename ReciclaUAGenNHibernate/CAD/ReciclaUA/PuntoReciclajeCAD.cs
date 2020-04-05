
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
 * Clase PuntoReciclaje:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class PuntoReciclajeCAD : BasicCAD, IPuntoReciclajeCAD
{
public PuntoReciclajeCAD() : base ()
{
}

public PuntoReciclajeCAD(ISession sessionAux) : base (sessionAux)
{
}



public PuntoReciclajeEN ReadOIDDefault (int id
                                        )
{
        PuntoReciclajeEN puntoReciclajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                puntoReciclajeEN = (PuntoReciclajeEN)session.Get (typeof(PuntoReciclajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return puntoReciclajeEN;
}

public System.Collections.Generic.IList<PuntoReciclajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PuntoReciclajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PuntoReciclajeEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PuntoReciclajeEN>();
                        else
                                result = session.CreateCriteria (typeof(PuntoReciclajeEN)).List<PuntoReciclajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PuntoReciclajeEN puntoReciclaje)
{
        try
        {
                SessionInitializeTransaction ();
                PuntoReciclajeEN puntoReciclajeEN = (PuntoReciclajeEN)session.Load (typeof(PuntoReciclajeEN), puntoReciclaje.Id);

                puntoReciclajeEN.Latitud = puntoReciclaje.Latitud;


                puntoReciclajeEN.Longitud = puntoReciclaje.Longitud;


                puntoReciclajeEN.EsValido = puntoReciclaje.EsValido;




                session.Update (puntoReciclajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (PuntoReciclajeEN puntoReciclaje)
{
        try
        {
                SessionInitializeTransaction ();
                if (puntoReciclaje.Usuario != null) {
                        // Argumento OID y no colección.
                        puntoReciclaje.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN), puntoReciclaje.Usuario.Id);

                        puntoReciclaje.Usuario.Puntos
                        .Add (puntoReciclaje);
                }
                if (puntoReciclaje.Estancia != null) {
                        // Argumento OID y no colección.
                        puntoReciclaje.Estancia = (ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN), puntoReciclaje.Estancia.Id);

                        puntoReciclaje.Estancia.Puntos
                        .Add (puntoReciclaje);
                }

                session.Save (puntoReciclaje);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return puntoReciclaje.Id;
}

public void Modificar (PuntoReciclajeEN puntoReciclaje)
{
        try
        {
                SessionInitializeTransaction ();
                PuntoReciclajeEN puntoReciclajeEN = (PuntoReciclajeEN)session.Load (typeof(PuntoReciclajeEN), puntoReciclaje.Id);

                puntoReciclajeEN.Latitud = puntoReciclaje.Latitud;


                puntoReciclajeEN.Longitud = puntoReciclaje.Longitud;


                puntoReciclajeEN.EsValido = puntoReciclaje.EsValido;

                session.Update (puntoReciclajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
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
                PuntoReciclajeEN puntoReciclajeEN = (PuntoReciclajeEN)session.Load (typeof(PuntoReciclajeEN), id);
                session.Delete (puntoReciclajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: PuntoReciclajeEN
public PuntoReciclajeEN BuscarPorId (int id
                                     )
{
        PuntoReciclajeEN puntoReciclajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                puntoReciclajeEN = (PuntoReciclajeEN)session.Get (typeof(PuntoReciclajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return puntoReciclajeEN;
}

public System.Collections.Generic.IList<PuntoReciclajeEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<PuntoReciclajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PuntoReciclajeEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PuntoReciclajeEN>();
                else
                        result = session.CreateCriteria (typeof(PuntoReciclajeEN)).List<PuntoReciclajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorValidar ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PuntoReciclajeEN self where FROM PuntoReciclajeEN as punto where EsValido = 2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PuntoReciclajeENbuscarPuntosPorValidarHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosValidados ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PuntoReciclajeEN self where FROM PuntoReciclajeEN as punto where EsValido = 1";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PuntoReciclajeENbuscarPuntosValidadosHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorEdificio (int ? id_edificio)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PuntoReciclajeEN self where FROM PuntoReciclajeEN as punto where punto.Estancia is not empty and punto.Estancia.Edificio is not empty and punto.Estancia.Edificio.Id = :id_edificio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PuntoReciclajeENbuscarPuntosPorEdificioHQL");
                query.SetParameter ("id_edificio", id_edificio);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorEstancia (string id_estancia)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PuntoReciclajeEN self where FROM PuntoReciclajeEN as punto where punto.Estancia is not empty and punto.Estancia.Id = :id_estancia";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PuntoReciclajeENbuscarPuntosPorEstanciaHQL");
                query.SetParameter ("id_estancia", id_estancia);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorPlanta (int? id_edificio, int ? num_planta)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PuntoReciclajeEN self where FROM PuntoReciclajeEN as punto where punto.Estancia is not empty and punto.Estancia.Edificio is not empty and punto.Estancia.Planta is not empty and punto.Estancia.Edificio.Id = :id_edificio and punto.Estancia.Planta.Planta = :num_planta";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PuntoReciclajeENbuscarPuntosPorPlantaHQL");
                query.SetParameter ("id_edificio", id_edificio);
                query.SetParameter ("num_planta", num_planta);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorUsuario (int id_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PuntoReciclajeEN self where FROM PuntoReciclajeEN as punto where punto.Usuario is not empty and punto.Usuario.Id = :id_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PuntoReciclajeENbuscarPuntosPorUsuarioHQL");
                query.SetParameter ("id_usuario", id_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
