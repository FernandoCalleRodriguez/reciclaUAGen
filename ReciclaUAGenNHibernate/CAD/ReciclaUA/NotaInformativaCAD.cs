
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
 * Clase NotaInformativa:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class NotaInformativaCAD : BasicCAD, INotaInformativaCAD
{
public NotaInformativaCAD() : base ()
{
}

public NotaInformativaCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotaInformativaEN ReadOIDDefault (int id
                                         )
{
        NotaInformativaEN notaInformativaEN = null;

        try
        {
                SessionInitializeTransaction ();
                notaInformativaEN = (NotaInformativaEN)session.Get (typeof(NotaInformativaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notaInformativaEN;
}

public System.Collections.Generic.IList<NotaInformativaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotaInformativaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotaInformativaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotaInformativaEN>();
                        else
                                result = session.CreateCriteria (typeof(NotaInformativaEN)).List<NotaInformativaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotaInformativaEN notaInformativa)
{
        try
        {
                SessionInitializeTransaction ();
                NotaInformativaEN notaInformativaEN = (NotaInformativaEN)session.Load (typeof(NotaInformativaEN), notaInformativa.Id);


                notaInformativaEN.Titulo = notaInformativa.Titulo;


                notaInformativaEN.Cuerpo = notaInformativa.Cuerpo;


                notaInformativaEN.Fecha = notaInformativa.Fecha;

                session.Update (notaInformativaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (NotaInformativaEN notaInformativa)
{
        try
        {
                SessionInitializeTransaction ();
                if (notaInformativa.UsuarioAdministrador != null) {
                        // Argumento OID y no colección.
                        notaInformativa.UsuarioAdministrador = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN), notaInformativa.UsuarioAdministrador.Id);

                        notaInformativa.UsuarioAdministrador.Notas
                        .Add (notaInformativa);
                }

                session.Save (notaInformativa);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notaInformativa.Id;
}

public void Modificar (NotaInformativaEN notaInformativa)
{
        try
        {
                SessionInitializeTransaction ();
                NotaInformativaEN notaInformativaEN = (NotaInformativaEN)session.Load (typeof(NotaInformativaEN), notaInformativa.Id);

                notaInformativaEN.Titulo = notaInformativa.Titulo;


                notaInformativaEN.Cuerpo = notaInformativa.Cuerpo;


                notaInformativaEN.Fecha = notaInformativa.Fecha;

                session.Update (notaInformativaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
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
                NotaInformativaEN notaInformativaEN = (NotaInformativaEN)session.Load (typeof(NotaInformativaEN), id);
                session.Delete (notaInformativaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: NotaInformativaEN
public NotaInformativaEN BuscarPorId (int id
                                      )
{
        NotaInformativaEN notaInformativaEN = null;

        try
        {
                SessionInitializeTransaction ();
                notaInformativaEN = (NotaInformativaEN)session.Get (typeof(NotaInformativaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notaInformativaEN;
}

public System.Collections.Generic.IList<NotaInformativaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<NotaInformativaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotaInformativaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotaInformativaEN>();
                else
                        result = session.CreateCriteria (typeof(NotaInformativaEN)).List<NotaInformativaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> BuscarPorTitulo (string p_titulo)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotaInformativaEN self where FROM NotaInformativaEN as nota WHERE nota.Titulo LIKE '%'+:p_titulo+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotaInformativaENbuscarPorTituloHQL");
                query.SetParameter ("p_titulo", p_titulo);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in NotaInformativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
