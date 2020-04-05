
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
 * Clase AccionReciclar:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class AccionReciclarCAD : BasicCAD, IAccionReciclarCAD
{
public AccionReciclarCAD() : base ()
{
}

public AccionReciclarCAD(ISession sessionAux) : base (sessionAux)
{
}



public AccionReciclarEN ReadOIDDefault (int id
                                        )
{
        AccionReciclarEN accionReciclarEN = null;

        try
        {
                SessionInitializeTransaction ();
                accionReciclarEN = (AccionReciclarEN)session.Get (typeof(AccionReciclarEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionReciclarEN;
}

public System.Collections.Generic.IList<AccionReciclarEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AccionReciclarEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AccionReciclarEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AccionReciclarEN>();
                        else
                                result = session.CreateCriteria (typeof(AccionReciclarEN)).List<AccionReciclarEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AccionReciclarEN accionReciclar)
{
        try
        {
                SessionInitializeTransaction ();
                AccionReciclarEN accionReciclarEN = (AccionReciclarEN)session.Load (typeof(AccionReciclarEN), accionReciclar.Id);



                accionReciclarEN.Cantidad = accionReciclar.Cantidad;

                session.Update (accionReciclarEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (AccionReciclarEN accionReciclar)
{
        try
        {
                SessionInitializeTransaction ();
                if (accionReciclar.Usuario != null) {
                        // Argumento OID y no colección.
                        accionReciclar.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN), accionReciclar.Usuario.Id);

                        accionReciclar.Usuario.Acciones
                        .Add (accionReciclar);
                }
                if (accionReciclar.Contenedor != null) {
                        // Argumento OID y no colección.
                        accionReciclar.Contenedor = (ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN), accionReciclar.Contenedor.Id);

                        accionReciclar.Contenedor.Acciones
                        .Add (accionReciclar);
                }
                if (accionReciclar.Item != null) {
                        // Argumento OID y no colección.
                        accionReciclar.Item = (ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN), accionReciclar.Item.Id);

                        accionReciclar.Item.AccionReciclar
                        .Add (accionReciclar);
                }

                session.Save (accionReciclar);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionReciclar.Id;
}

public void Modificar (AccionReciclarEN accionReciclar)
{
        try
        {
                SessionInitializeTransaction ();
                AccionReciclarEN accionReciclarEN = (AccionReciclarEN)session.Load (typeof(AccionReciclarEN), accionReciclar.Id);

                accionReciclarEN.Fecha = accionReciclar.Fecha;


                accionReciclarEN.Cantidad = accionReciclar.Cantidad;

                session.Update (accionReciclarEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
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
                AccionReciclarEN accionReciclarEN = (AccionReciclarEN)session.Load (typeof(AccionReciclarEN), id);
                session.Delete (accionReciclarEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: AccionReciclarEN
public AccionReciclarEN BuscarPorId (int id
                                     )
{
        AccionReciclarEN accionReciclarEN = null;

        try
        {
                SessionInitializeTransaction ();
                accionReciclarEN = (AccionReciclarEN)session.Get (typeof(AccionReciclarEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return accionReciclarEN;
}

public System.Collections.Generic.IList<AccionReciclarEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AccionReciclarEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AccionReciclarEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AccionReciclarEN>();
                else
                        result = session.CreateCriteria (typeof(AccionReciclarEN)).List<AccionReciclarEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorAutor (int ? p_user_id)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionReciclarEN self where FROM AccionReciclarEN as acc WHERE acc.Usuario.Id = :p_user_id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionReciclarENbuscarPorAutorHQL");
                query.SetParameter ("p_user_id", p_user_id);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorFecha (Nullable<DateTime> p_date)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionReciclarEN self where FROM AccionReciclarEN as acc WHERE acc.Fecha = :p_date";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionReciclarENbuscarPorFechaHQL");
                query.SetParameter ("p_date", p_date);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorMaterial (string p_material)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionReciclarEN self where FROM AccionReciclarEN as material inner join material.Item as it WHERE  it.Material.Nombre = :p_material";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionReciclarENbuscarPorMaterialHQL");
                query.SetParameter ("p_material", p_material);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarAccionesReciclajePorUsuario (int id_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AccionReciclarEN self where FROM AccionReciclarEN as accion where accion.Usuario is not empty and accion.Usuario.Id = :id_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AccionReciclarENbuscarAccionesReciclajePorUsuarioHQL");
                query.SetParameter ("id_usuario", id_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
