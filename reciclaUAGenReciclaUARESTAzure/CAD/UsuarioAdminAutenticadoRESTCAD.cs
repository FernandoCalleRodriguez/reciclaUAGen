
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
public class UsuarioAdminAutenticadoRESTCAD : UsuarioAdministradorCAD
{
public UsuarioAdminAutenticadoRESTCAD()
        : base ()
{
}

public UsuarioAdminAutenticadoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
