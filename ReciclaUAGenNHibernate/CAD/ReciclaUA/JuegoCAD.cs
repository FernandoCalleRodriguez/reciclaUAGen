
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
 * Clase Juego:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class JuegoCAD : BasicCAD, IJuegoCAD
{
public JuegoCAD() : base ()
{
}

public JuegoCAD(ISession sessionAux) : base (sessionAux)
{
}



public JuegoEN ReadOIDDefault (int id
                               )
{
        JuegoEN juegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Get (typeof(JuegoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return juegoEN;
}

public System.Collections.Generic.IList<JuegoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<JuegoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(JuegoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<JuegoEN>();
                        else
                                result = session.CreateCriteria (typeof(JuegoEN)).List<JuegoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), juego.Id);

                juegoEN.ItemActual = juego.ItemActual;


                juegoEN.Aciertos = juego.Aciertos;


                juegoEN.Fallos = juego.Fallos;


                juegoEN.Puntuacion = juego.Puntuacion;



                juegoEN.IntentosItemActual = juego.IntentosItemActual;


                juegoEN.Finalizado = juego.Finalizado;


                juegoEN.NivelActual = juego.NivelActual;

                session.Update (juegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                if (juego.Usuarios != null) {
                        // Argumento OID y no colección.
                        juego.Usuarios = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN), juego.Usuarios.Id);

                        juego.Usuarios.Juegos
                                = juego;
                }

                session.Save (juego);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return juego.Id;
}

public void Modificar (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), juego.Id);

                juegoEN.ItemActual = juego.ItemActual;


                juegoEN.Aciertos = juego.Aciertos;


                juegoEN.Fallos = juego.Fallos;


                juegoEN.Puntuacion = juego.Puntuacion;


                juegoEN.IntentosItemActual = juego.IntentosItemActual;


                juegoEN.Finalizado = juego.Finalizado;


                juegoEN.NivelActual = juego.NivelActual;

                session.Update (juegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
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
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), id);
                session.Delete (juegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: JuegoEN
public JuegoEN BuscarPorId (int id
                            )
{
        JuegoEN juegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Get (typeof(JuegoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return juegoEN;
}

public System.Collections.Generic.IList<JuegoEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<JuegoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(JuegoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<JuegoEN>();
                else
                        result = session.CreateCriteria (typeof(JuegoEN)).List<JuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN> BuscarJuegoPorUsuario (int p_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM JuegoEN self where FROM JuegoEN as juego where juego.Usuarios is not empty and juego.Usuarios = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("JuegoENbuscarJuegoPorUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
