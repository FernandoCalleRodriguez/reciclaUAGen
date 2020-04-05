
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
public class UsuarioRESTCAD : UsuarioCAD
{
public UsuarioRESTCAD()
        : base ()
{
}

public UsuarioRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<PuntoReciclajeEN> DameMisPuntos (int id)
{
        IList<PuntoReciclajeEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM PuntoReciclajeEN self inner join self.Usuario as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<PuntoReciclajeEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
