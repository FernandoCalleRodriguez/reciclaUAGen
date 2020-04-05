
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
 * Clase Material:
 *
 */

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial class MaterialCAD : BasicCAD, IMaterialCAD
{
public MaterialCAD() : base ()
{
}

public MaterialCAD(ISession sessionAux) : base (sessionAux)
{
}



public MaterialEN ReadOIDDefault (int id
                                  )
{
        MaterialEN materialEN = null;

        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Get (typeof(MaterialEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return materialEN;
}

public System.Collections.Generic.IList<MaterialEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MaterialEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MaterialEN>();
                        else
                                result = session.CreateCriteria (typeof(MaterialEN)).List<MaterialEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MaterialEN material)
{
        try
        {
                SessionInitializeTransaction ();
                MaterialEN materialEN = (MaterialEN)session.Load (typeof(MaterialEN), material.Id);

                materialEN.Nombre = material.Nombre;


                materialEN.Contenedor = material.Contenedor;



                materialEN.EsValido = material.EsValido;


                session.Update (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarPorTipoContenedor (int ? p_tipoContenedor)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MaterialEN self where FROM MaterialEN as material WHERE material.Contenedor =:p_tipoContenedor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MaterialENbuscarPorTipoContenedorHQL");
                query.SetParameter ("p_tipoContenedor", p_tipoContenedor);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int Crear (MaterialEN material)
{
        try
        {
                SessionInitializeTransaction ();
                if (material.Usuario != null) {
                        // Argumento OID y no colección.
                        material.Usuario = (ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN)session.Load (typeof(ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN), material.Usuario.Id);

                        material.Usuario.Materiales
                        .Add (material);
                }

                session.Save (material);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return material.Id;
}

public void Modificar (MaterialEN material)
{
        try
        {
                SessionInitializeTransaction ();
                MaterialEN materialEN = (MaterialEN)session.Load (typeof(MaterialEN), material.Id);

                materialEN.Nombre = material.Nombre;


                materialEN.Contenedor = material.Contenedor;


                materialEN.EsValido = material.EsValido;

                session.Update (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
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
                MaterialEN materialEN = (MaterialEN)session.Load (typeof(MaterialEN), id);
                session.Delete (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: BuscarPorId
//Con e: MaterialEN
public MaterialEN BuscarPorId (int id
                               )
{
        MaterialEN materialEN = null;

        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Get (typeof(MaterialEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return materialEN;
}

public System.Collections.Generic.IList<MaterialEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MaterialEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MaterialEN>();
                else
                        result = session.CreateCriteria (typeof(MaterialEN)).List<MaterialEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesPorValidar ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MaterialEN self where FROM MaterialEN  as material WHERE material.EsValido=2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MaterialENbuscarMaterialesPorValidarHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesValidados ()
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MaterialEN self where FROM MaterialEN as material WHERE material.EsValido=1";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MaterialENbuscarMaterialesValidadosHQL");

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesPorUsuario (int id_usuario)
{
        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MaterialEN self where FROM MaterialEN as material where material.Usuario is not empty and material.Usuario.Id = :id_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MaterialENbuscarMaterialesPorUsuarioHQL");
                query.SetParameter ("id_usuario", id_usuario);

                result = query.List<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
