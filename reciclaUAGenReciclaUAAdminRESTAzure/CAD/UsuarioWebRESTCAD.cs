
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
public class UsuarioWebRESTCAD : UsuarioWebCAD
{
public UsuarioWebRESTCAD()
        : base ()
{
}

public UsuarioWebRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
