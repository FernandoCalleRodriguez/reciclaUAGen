
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
public class ItemRESTCAD : ItemCAD
{
public ItemRESTCAD()
        : base ()
{
}

public ItemRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public MaterialEN MaterialItem (int id)
{
        MaterialEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Material FROM ItemEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<MaterialEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public NivelEN NivelItem (int id)
{
        NivelEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Niveles FROM ItemEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NivelEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in ItemRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
