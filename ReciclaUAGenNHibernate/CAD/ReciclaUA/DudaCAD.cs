
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
 * Clase Duda:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class DudaCAD : BasicCAD, IDudaCAD
{
public DudaCAD() : base ()
{
}

public DudaCAD(ISession sessionAux) : base (sessionAux)
{
}



public DudaEN ReadOIDDefault (int id
                              )
{
        DudaEN dudaEN = null;

        try
        {
                SessionInitializeTransaction ();
                dudaEN = (DudaEN)session.Get (typeof(DudaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return dudaEN;
}

public System.Collections.Generic.IList<DudaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DudaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DudaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<DudaEN>();
                        else
                                result = session.CreateCriteria (typeof(DudaEN)).List<DudaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DudaEN duda)
{
        try
        {
                SessionInitializeTransaction ();
                DudaEN dudaEN = (DudaEN)session.Load (typeof(DudaEN), duda.Id);

                dudaEN.Titulo = duda.Titulo;


                dudaEN.Cuerpo = duda.Cuerpo;




                dudaEN.Fecha = duda.Fecha;


                dudaEN.Util = duda.Util;


                dudaEN.Tema = duda.Tema;

                session.Update (dudaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (DudaEN duda)
{
        try
        {
                SessionInitializeTransaction ();
                if (duda.Usuario != null) {
                        // Argumento OID y no colección.
                        duda.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN), duda.Usuario.Id);

                        duda.Usuario.Dudas
                        .Add (duda);
                }

                session.Save (duda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return duda.Id;
}

public void Modificar (DudaEN duda)
{
        try
        {
                SessionInitializeTransaction ();
                DudaEN dudaEN = (DudaEN)session.Load (typeof(DudaEN), duda.Id);

                dudaEN.Titulo = duda.Titulo;


                dudaEN.Cuerpo = duda.Cuerpo;


                dudaEN.Fecha = duda.Fecha;


                dudaEN.Util = duda.Util;


                dudaEN.Tema = duda.Tema;

                session.Update (dudaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
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
                DudaEN dudaEN = (DudaEN)session.Load (typeof(DudaEN), id);
                session.Delete (dudaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: DudaEN
public DudaEN BuscarPorId (int id
                           )
{
        DudaEN dudaEN = null;

        try
        {
                SessionInitializeTransaction ();
                dudaEN = (DudaEN)session.Get (typeof(DudaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return dudaEN;
}

public System.Collections.Generic.IList<DudaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<DudaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DudaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<DudaEN>();
                else
                        result = session.CreateCriteria (typeof(DudaEN)).List<DudaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudaPorTitulo (string p_titulo)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM DudaEN self where FROM DudaEN as duda WHERE duda.Titulo LIKE '%'+:p_titulo+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("DudaENbuscarDudaPorTituloHQL");
                query.SetParameter ("p_titulo", p_titulo);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudaPorTema (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TemaEnum ? p_tema)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM DudaEN self where FROM DudaEN as duda WHERE duda.Tema = :p_tema";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("DudaENbuscarDudaPorTemaHQL");
                query.SetParameter ("p_tema", p_tema);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudasPorUsuario (int id_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM DudaEN self where FROM DudaEN as duda WHERE duda.Usuario is not empty and duda.Usuario.Id = :id_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("DudaENbuscarDudasPorUsuarioHQL");
                query.SetParameter ("id_usuario", id_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
