
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
 * Clase AccionWeb:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class AccionWebCAD : BasicCAD, IAccionWebCAD
{
public AccionWebCAD() : base ()
{
}

public AccionWebCAD(ISession sessionAux) : base (sessionAux)
{
}



public AccionWebEN ReadOIDDefault (int id
                                   )
{
        AccionWebEN accionWebEN = null;

        try
        {
                SessionInitializeTransaction ();
                accionWebEN = (AccionWebEN)session.Get (typeof(AccionWebEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionWebEN;
}

public System.Collections.Generic.IList<AccionWebEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AccionWebEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AccionWebEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AccionWebEN>();
                        else
                                result = session.CreateCriteria (typeof(AccionWebEN)).List<AccionWebEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AccionWebEN accionWeb)
{
        try
        {
                SessionInitializeTransaction ();
                AccionWebEN accionWebEN = (AccionWebEN)session.Load (typeof(AccionWebEN), accionWeb.Id);

                session.Update (accionWebEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (AccionWebEN accionWeb)
{
        try
        {
                SessionInitializeTransaction ();
                if (accionWeb.Usuario != null) {
                        // Argumento OID y no colección.
                        accionWeb.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN), accionWeb.Usuario.Id);

                        accionWeb.Usuario.Acciones
                        .Add (accionWeb);
                }
                if (accionWeb.Tipo != null) {
                        // Argumento OID y no colección.
                        accionWeb.Tipo = (ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN), accionWeb.Tipo.Id);

                        accionWeb.Tipo.Acciones
                        .Add (accionWeb);
                }

                session.Save (accionWeb);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionWeb.Id;
}

public void Modificar (AccionWebEN accionWeb)
{
        try
        {
                SessionInitializeTransaction ();
                AccionWebEN accionWebEN = (AccionWebEN)session.Load (typeof(AccionWebEN), accionWeb.Id);

                accionWebEN.Fecha = accionWeb.Fecha;

                session.Update (accionWebEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
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
                AccionWebEN accionWebEN = (AccionWebEN)session.Load (typeof(AccionWebEN), id);
                session.Delete (accionWebEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: AccionWebEN
public AccionWebEN BuscarPorId (int id
                                )
{
        AccionWebEN accionWebEN = null;

        try
        {
                SessionInitializeTransaction ();
                accionWebEN = (AccionWebEN)session.Get (typeof(AccionWebEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionWebEN;
}

public System.Collections.Generic.IList<AccionWebEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AccionWebEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AccionWebEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AccionWebEN>();
                else
                        result = session.CreateCriteria (typeof(AccionWebEN)).List<AccionWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorAutor (int ? p_user_id)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionWebEN self where FROM AccionWebEN as acc WHERE acc.Usuario.Id = :p_user_id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionWebENbuscarPorAutorHQL");
                query.SetParameter ("p_user_id", p_user_id);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorFecha (Nullable<DateTime> p_date)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionWebEN self where FROM AccionWebEN as acc WHERE acc.Fecha = :p_date";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionWebENbuscarPorFechaHQL");
                query.SetParameter ("p_date", p_date);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorTipo (string p_type)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionWebEN self where FROM AccionWebEN as accion WHERE accion.Tipo.Nombre = :p_type";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionWebENbuscarPorTipoHQL");
                query.SetParameter ("p_type", p_type);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarAccionesWebPorUsuario (int id_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionWebEN self where FROM AccionWebEN as accion where accion.Usuario is not empty and accion.Usuario.Id = :id_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionWebENbuscarAccionesWebPorUsuarioHQL");
                query.SetParameter ("id_usuario", id_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
