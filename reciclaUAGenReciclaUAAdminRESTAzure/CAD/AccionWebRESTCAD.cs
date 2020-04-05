
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

namespace reciclaUAGenReciclaUAAdminRESTAzure.CAD
{
public class AccionWebRESTCAD : AccionWebCAD
{
public AccionWebRESTCAD()
        : base ()
{
}

public AccionWebRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public TipoAccionEN Tipo (int id)
{
        TipoAccionEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Tipo FROM AccionWebEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<TipoAccionEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in AccionWebRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
