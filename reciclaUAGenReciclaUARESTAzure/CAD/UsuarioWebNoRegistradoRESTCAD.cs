
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
public class UsuarioWebNoRegistradoRESTCAD : UsuarioWebCAD
{
public UsuarioWebNoRegistradoRESTCAD()
        : base ()
{
}

public UsuarioWebNoRegistradoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public JuegoEN JuegoUsuario (int id)
{
        JuegoEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Juego FROM UsuarioWebEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<JuegoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ReciclaUAGenNHibernate.Exceptions.ModelException) throw ex;
                throw new ReciclaUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioWebRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
