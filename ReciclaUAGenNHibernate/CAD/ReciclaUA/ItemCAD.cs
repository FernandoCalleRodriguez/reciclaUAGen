
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
 * Clase Item:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class ItemCAD : BasicCAD, IItemCAD
{
public ItemCAD() : base ()
{
}

public ItemCAD(ISession sessionAux) : base (sessionAux)
{
}



public ItemEN ReadOIDDefault (int id
                              )
{
        ItemEN itemEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemEN = (ItemEN)session.Get (typeof(ItemEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return itemEN;
}

public System.Collections.Generic.IList<ItemEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ItemEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ItemEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ItemEN>();
                        else
                                result = session.CreateCriteria (typeof(ItemEN)).List<ItemEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ItemEN item)
{
        try
        {
                SessionInitializeTransaction ();
                ItemEN itemEN = (ItemEN)session.Load (typeof(ItemEN), item.Id);

                itemEN.Nombre = item.Nombre;


                itemEN.Descripcion = item.Descripcion;


                itemEN.Imagen = item.Imagen;


                itemEN.EsValido = item.EsValido;






                itemEN.Puntuacion = item.Puntuacion;

                session.Update (itemEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (ItemEN item)
{
        try
        {
                SessionInitializeTransaction ();
                if (item.Usuario != null) {
                        // Argumento OID y no colección.
                        item.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN), item.Usuario.Id);

                        item.Usuario.Items
                        .Add (item);
                }
                if (item.Material != null) {
                        // Argumento OID y no colección.
                        item.Material = (ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN), item.Material.Id);

                        item.Material.Items
                        .Add (item);
                }

                session.Save (item);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return item.Id;
}

public void Modificar (ItemEN item)
{
        try
        {
                SessionInitializeTransaction ();
                ItemEN itemEN = (ItemEN)session.Load (typeof(ItemEN), item.Id);

                itemEN.Nombre = item.Nombre;


                itemEN.Descripcion = item.Descripcion;


                itemEN.Imagen = item.Imagen;


                itemEN.EsValido = item.EsValido;


                itemEN.Puntuacion = item.Puntuacion;

                session.Update (itemEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
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
                ItemEN itemEN = (ItemEN)session.Load (typeof(ItemEN), id);
                session.Delete (itemEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: ItemEN
public ItemEN BuscarPorId (int id
                           )
{
        ItemEN itemEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemEN = (ItemEN)session.Get (typeof(ItemEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return itemEN;
}

public System.Collections.Generic.IList<ItemEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<ItemEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ItemEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ItemEN>();
                else
                        result = session.CreateCriteria (typeof(ItemEN)).List<ItemEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorValidar ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ItemEN self where FROM ItemEN as item WHERE item.EsValido=2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ItemENbuscarItemsPorValidarHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsValidados ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ItemEN self where FROM ItemEN as item WHERE item.EsValido=1";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ItemENbuscarItemsValidadosHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorUsuario (int id_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ItemEN self where FROM ItemEN as item where item.Usuario is not empty and item.Usuario.Id = :id_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ItemENbuscarItemsPorUsuarioHQL");
                query.SetParameter ("id_usuario", id_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int BuscarItemsPorValidarCount ()
{
        int result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ItemEN self where select cast(count(item) as int) FROM ItemEN as item WHERE item.EsValido=2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ItemENbuscarItemsPorValidarCountHQL");


                result = query.UniqueResult<int>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorNivel (int id_nivel)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ItemEN self where FROM ItemEN as item where item.Nivel is not empty and item.Nivel = :id_nivel";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ItemENbuscarItemsPorNivelHQL");
                query.SetParameter ("id_nivel", id_nivel);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int Operation ()
{
        int result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ItemEN self where select cast(count(item) as int) FROM ItemEN as item";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ItemENoperationHQL");


                result = query.UniqueResult<int>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
