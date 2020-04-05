
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
 * Clase Respuesta:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class RespuestaCAD : BasicCAD, IRespuestaCAD
{
public RespuestaCAD() : base ()
{
}

public RespuestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public RespuestaEN ReadOIDDefault (int id
                                   )
{
        RespuestaEN respuestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                respuestaEN = (RespuestaEN)session.Get (typeof(RespuestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuestaEN;
}

public System.Collections.Generic.IList<RespuestaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RespuestaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RespuestaEN>();
                        else
                                result = session.CreateCriteria (typeof(RespuestaEN)).List<RespuestaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), respuesta.Id);

                respuestaEN.Cuerpo = respuesta.Cuerpo;




                respuestaEN.Fecha = respuesta.Fecha;


                respuestaEN.EsCorrecta = respuesta.EsCorrecta;


                respuestaEN.Util = respuesta.Util;

                session.Update (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                if (respuesta.Duda != null) {
                        // Argumento OID y no colección.
                        respuesta.Duda = (ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN), respuesta.Duda.Id);

                        respuesta.Duda.Respuestas
                        .Add (respuesta);
                }
                if (respuesta.Usuario != null) {
                        // Argumento OID y no colección.
                        respuesta.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN), respuesta.Usuario.Id);

                        respuesta.Usuario.Respuestas
                        .Add (respuesta);
                }

                session.Save (respuesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuesta.Id;
}

public void Modificar (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), respuesta.Id);

                respuestaEN.Cuerpo = respuesta.Cuerpo;


                respuestaEN.Fecha = respuesta.Fecha;


                respuestaEN.EsCorrecta = respuesta.EsCorrecta;


                respuestaEN.Util = respuesta.Util;

                session.Update (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
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
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), id);
                session.Delete (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: RespuestaEN
public RespuestaEN BuscarPorId (int id
                                )
{
        RespuestaEN respuestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                respuestaEN = (RespuestaEN)session.Get (typeof(RespuestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuestaEN;
}

public System.Collections.Generic.IList<RespuestaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RespuestaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RespuestaEN>();
                else
                        result = session.CreateCriteria (typeof(RespuestaEN)).List<RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestaPorDuda (int ? id_duda)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where FROM RespuestaEN as resp where resp.Duda.Id = :id_duda";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENbuscarRespuestaPorDudaHQL");
                query.SetParameter ("id_duda", id_duda);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestaPorEsCorrecta ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where FROM RespuestaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENbuscarRespuestaPorEsCorrectaHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestasPorUsuario (int id_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where FROM RespuestaEN as respuesta WHERE respuesta.Usuario is not empty and respuesta.Usuario.Id = :id_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENbuscarRespuestasPorUsuarioHQL");
                query.SetParameter ("id_usuario", id_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
