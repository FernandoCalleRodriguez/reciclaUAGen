
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using ReciclaUAGenNHibernate.Exceptions;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;



namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class AccionReciclarCP : BasicCP
{
public AccionReciclarCP() : base ()
{
}

public AccionReciclarCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
