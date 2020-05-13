
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
 * Clase Contenedor:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class ContenedorCAD : BasicCAD, IContenedorCAD
{
public ContenedorCAD() : base ()
{
}

public ContenedorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ContenedorEN ReadOIDDefault (int id
                                    )
{
        ContenedorEN contenedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                contenedorEN = (ContenedorEN)session.Get (typeof(ContenedorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return contenedorEN;
}

public System.Collections.Generic.IList<ContenedorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ContenedorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ContenedorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ContenedorEN>();
                        else
                                result = session.CreateCriteria (typeof(ContenedorEN)).List<ContenedorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ContenedorEN contenedor)
{
        try
        {
                SessionInitializeTransaction ();
                ContenedorEN contenedorEN = (ContenedorEN)session.Load (typeof(ContenedorEN), contenedor.Id);

                contenedorEN.Tipo = contenedor.Tipo;



                session.Update (contenedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (ContenedorEN contenedor)
{
        try
        {
                SessionInitializeTransaction ();
                if (contenedor.Punto != null) {
                        // Argumento OID y no colección.
                        contenedor.Punto = (ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN), contenedor.Punto.Id);

                        contenedor.Punto.Contenedores
                        .Add (contenedor);
                }

                session.Save (contenedor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return contenedor.Id;
}

public void Modificar (ContenedorEN contenedor)
{
        try
        {
                SessionInitializeTransaction ();
                ContenedorEN contenedorEN = (ContenedorEN)session.Load (typeof(ContenedorEN), contenedor.Id);

                contenedorEN.Tipo = contenedor.Tipo;

                session.Update (contenedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
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
                ContenedorEN contenedorEN = (ContenedorEN)session.Load (typeof(ContenedorEN), id);
                session.Delete (contenedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: ContenedorEN
public ContenedorEN BuscarPorId (int id
                                 )
{
        ContenedorEN contenedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                contenedorEN = (ContenedorEN)session.Get (typeof(ContenedorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return contenedorEN;
}

public System.Collections.Generic.IList<ContenedorEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<ContenedorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ContenedorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ContenedorEN>();
                else
                        result = session.CreateCriteria (typeof(ContenedorEN)).List<ContenedorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> BuscarContenedoresPorTipo (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum ? tipo_contenedor)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ContenedorEN self where FROM ContenedorEN as contenedor where contenedor.Tipo = :tipo_contenedor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ContenedorENbuscarContenedoresPorTipoHQL");
                query.SetParameter ("tipo_contenedor", tipo_contenedor);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> BuscarContenedoresPorPunto (int id_punto)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ContenedorEN self where FROM ContenedorEN as contenedor where contenedor.Punto is not empty and contenedor.Punto.Id = :id_punto";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ContenedorENbuscarContenedoresPorPuntoHQL");
                query.SetParameter ("id_punto", id_punto);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ContenedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
