
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
public class DudaRESTCAD : DudaCAD
{
public DudaRESTCAD()
        : base ()
{
}

public DudaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<RespuestaEN> RespuestasDuda (int id)
{
        IList<RespuestaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM RespuestaEN self inner join self.Duda as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<RespuestaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public UsuarioWebEN UsuarioDuda (int id)
{
        UsuarioWebEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Usuario FROM DudaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<UsuarioWebEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in DudaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
