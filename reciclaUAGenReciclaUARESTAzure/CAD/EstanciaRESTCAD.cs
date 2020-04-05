
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
public class EstanciaRESTCAD : EstanciaCAD
{
public EstanciaRESTCAD()
        : base ()
{
}

public EstanciaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public EdificioEN EdificioEstancia (string id)
{
        EdificioEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Edificio FROM EstanciaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<EdificioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public PlantaEN PlantaEstancia (string id)
{
        PlantaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Planta FROM EstanciaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<PlantaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EstanciaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
