
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
 * Clase UsuarioWeb:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class UsuarioWebCAD : BasicCAD, IUsuarioWebCAD
{
public UsuarioWebCAD() : base ()
{
}

public UsuarioWebCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioWebEN ReadOIDDefault (int id
                                    )
{
        UsuarioWebEN usuarioWebEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioWebEN = (UsuarioWebEN)session.Get (typeof(UsuarioWebEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioWebEN;
}

public System.Collections.Generic.IList<UsuarioWebEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioWebEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioWebEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioWebEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioWebEN)).List<UsuarioWebEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioWebEN usuarioWeb)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioWebEN usuarioWebEN = (UsuarioWebEN)session.Load (typeof(UsuarioWebEN), usuarioWeb.Id);


                usuarioWebEN.Puntuacion = usuarioWeb.Puntuacion;

                session.Update (usuarioWebEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (UsuarioWebEN usuarioWeb)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioWeb);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioWeb.Id;
}

public void Modificar (UsuarioWebEN usuarioWeb)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioWebEN usuarioWebEN = (UsuarioWebEN)session.Load (typeof(UsuarioWebEN), usuarioWeb.Id);

                usuarioWebEN.Nombre = usuarioWeb.Nombre;


                usuarioWebEN.Apellidos = usuarioWeb.Apellidos;


                usuarioWebEN.Email = usuarioWeb.Email;

                session.Update (usuarioWebEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
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
                UsuarioWebEN usuarioWebEN = (UsuarioWebEN)session.Load (typeof(UsuarioWebEN), id);
                session.Delete (usuarioWebEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: UsuarioWebEN
public UsuarioWebEN BuscarPorId (int id
                                 )
{
        UsuarioWebEN usuarioWebEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioWebEN = (UsuarioWebEN)session.Get (typeof(UsuarioWebEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioWebEN;
}

public System.Collections.Generic.IList<UsuarioWebEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioWebEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioWebEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioWebEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioWebEN)).List<UsuarioWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> ObtenerRanking ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioWebEN self where FROM UsuarioWebEN as usu order by usu.Puntuacion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioWebENobtenerRankingHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> ObtenerPuntuaciones ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioWebEN self where FROM UsuarioWebEN as usu order by usu.Puntuacion desc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioWebENobtenerPuntuacionesHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
