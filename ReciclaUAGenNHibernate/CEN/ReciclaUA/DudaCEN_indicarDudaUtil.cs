
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ReciclaUAGenNHibernate.Exceptions;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Duda_indicarDudaUtil) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class DudaCEN
{
public void IndicarDudaUtil (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Duda_indicarDudaUtil) ENABLED START*/

        DudaEN duda = _IDudaCAD.BuscarPorId (p_oid);

        duda.Util++;

        _IDudaCAD.Modificar (duda);

        /*PROTECTED REGION END*/
}
}
}
