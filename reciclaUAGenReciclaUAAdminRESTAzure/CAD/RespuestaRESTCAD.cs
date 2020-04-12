
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
public class RespuestaRESTCAD : RespuestaCAD
{
public RespuestaRESTCAD()
        : base ()
{
}

public RespuestaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public UsuarioAdministradorEN UsuarioRespuesta (int id)
{
        UsuarioAdministradorEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Usuario FROM RespuestaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<UsuarioAdministradorEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public DudaEN DudaRespuesta (int id)
{
        DudaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Duda FROM RespuestaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<DudaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
