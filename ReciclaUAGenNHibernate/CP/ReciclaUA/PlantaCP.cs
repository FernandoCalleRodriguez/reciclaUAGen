
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
public partial class PlantaCP : BasicCP
{
public PlantaCP() : base ()
{
}

public PlantaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
