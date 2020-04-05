
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
public class PuntoReciclajeRESTCAD : PuntoReciclajeCAD
{
public PuntoReciclajeRESTCAD()
        : base ()
{
}

public PuntoReciclajeRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<ContenedorEN> Contenedores (int id)
{
        IList<ContenedorEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ContenedorEN self inner join self.Punto as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ContenedorEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public EstanciaEN EstanciaPunto (int id)
{
        EstanciaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Estancia FROM PuntoReciclajeEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<EstanciaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in PuntoReciclajeRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
