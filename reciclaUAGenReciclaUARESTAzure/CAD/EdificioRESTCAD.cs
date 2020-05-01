
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
public class EdificioRESTCAD : EdificioCAD
{
public EdificioRESTCAD()
        : base ()
{
}

public EdificioRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<PlantaEN> PlantasEdicio (int id)
{
        IList<PlantaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM PlantaEN self inner join self.Edificio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<PlantaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in EdificioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
