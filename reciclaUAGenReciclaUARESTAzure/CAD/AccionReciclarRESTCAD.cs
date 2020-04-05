
using System;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using System.Collections.Generic;

using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.CAD
{
public class AccionReciclarRESTCAD : AccionReciclarCAD
{
public AccionReciclarRESTCAD()
        : base ()
{
}

public AccionReciclarRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public ItemEN ItemAccion (int id)
{
        ItemEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Item FROM AccionReciclarEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<ItemEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public ContenedorEN ContenedorAccion (int id)
{
        ContenedorEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Contenedor FROM AccionReciclarEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<ContenedorEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionReciclarRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
