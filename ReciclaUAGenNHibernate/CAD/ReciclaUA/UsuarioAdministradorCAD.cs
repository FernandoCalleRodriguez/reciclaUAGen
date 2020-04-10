
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
 * Clase UsuarioAdministrador:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class UsuarioAdministradorCAD : BasicCAD, IUsuarioAdministradorCAD
{
public UsuarioAdministradorCAD() : base ()
{
}

public UsuarioAdministradorCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioAdministradorEN ReadOIDDefault (int id
                                              )
{
        UsuarioAdministradorEN usuarioAdministradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioAdministradorEN = (UsuarioAdministradorEN)session.Get (typeof(UsuarioAdministradorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioAdministradorEN;
}

public System.Collections.Generic.IList<UsuarioAdministradorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioAdministradorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioAdministradorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioAdministradorEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioAdministradorEN)).List<UsuarioAdministradorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioAdministradorEN usuarioAdministrador)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioAdministradorEN usuarioAdministradorEN = (UsuarioAdministradorEN)session.Load (typeof(UsuarioAdministradorEN), usuarioAdministrador.Id);

                session.Update (usuarioAdministradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (UsuarioAdministradorEN usuarioAdministrador)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioAdministradorEN usuarioAdministradorEN = (UsuarioAdministradorEN)session.Load (typeof(UsuarioAdministradorEN), usuarioAdministrador.Id);

                usuarioAdministradorEN.Nombre = usuarioAdministrador.Nombre;


                usuarioAdministradorEN.Apellidos = usuarioAdministrador.Apellidos;


                usuarioAdministradorEN.Email = usuarioAdministrador.Email;

                session.Update (usuarioAdministradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
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
                UsuarioAdministradorEN usuarioAdministradorEN = (UsuarioAdministradorEN)session.Load (typeof(UsuarioAdministradorEN), id);
                session.Delete (usuarioAdministradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: UsuarioAdministradorEN
public UsuarioAdministradorEN BuscarPorId (int id
                                           )
{
        UsuarioAdministradorEN usuarioAdministradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioAdministradorEN = (UsuarioAdministradorEN)session.Get (typeof(UsuarioAdministradorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioAdministradorEN;
}

public System.Collections.Generic.IList<UsuarioAdministradorEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioAdministradorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioAdministradorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioAdministradorEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioAdministradorEN)).List<UsuarioAdministradorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int Crear (UsuarioAdministradorEN usuarioAdministrador)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioAdministrador);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioAdministrador.Id;
}

public void CambiarPassword (UsuarioAdministradorEN usuarioAdministrador)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioAdministradorEN usuarioAdministradorEN = (UsuarioAdministradorEN)session.Load (typeof(UsuarioAdministradorEN), usuarioAdministrador.Id);

                usuarioAdministradorEN.Pass = usuarioAdministrador.Pass;

                session.Update (usuarioAdministradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
