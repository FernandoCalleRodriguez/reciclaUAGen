
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
public class UsuarioAdminNoAutenticadoRESTCAD : UsuarioCAD
{
public UsuarioAdminNoAutenticadoRESTCAD()
        : base ()
{
}

public UsuarioAdminNoAutenticadoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
