
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_buscarPuntosCercanos) ENABLED START*/
//  references to other libraries
using System.Linq;
using ReciclaUAGenNHibernate.CP.ReciclaUA;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class PuntoReciclajeCEN
{
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosCercanos (double p_latitud, double p_longitud, int p_limit)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_buscarPuntosCercanos) ENABLED START*/

        PuntoReciclajeCP cp = new PuntoReciclajeCP ();

        return cp.ObtenerPuntosCercanos (p_latitud, p_longitud, p_limit);

        /*PROTECTED REGION END*/
}
}
}
