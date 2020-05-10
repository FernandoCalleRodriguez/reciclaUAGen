
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
public class UsuarioWebVerificarCuentaRESTCAD : UsuarioWebCAD
{
public UsuarioWebVerificarCuentaRESTCAD()
        : base ()
{
}

public UsuarioWebVerificarCuentaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
