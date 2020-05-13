
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_buscarPuntosCercanosPorContenedor) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class PuntoReciclajeCEN
{
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosCercanosPorContenedor (double p_latitud, double p_longitud, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_tipo, int p_limit)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_buscarPuntosCercanosPorContenedor) ENABLED START*/
        PuntoReciclajeCEN cen = new PuntoReciclajeCEN ();
        ContenedorCEN cenc = new ContenedorCEN ();

        IList<PuntoReciclajeEN> cercanos = cen.BuscarPuntosCercanos (p_latitud, p_longitud, -1);

        var query = cercanos.Where (punto => cenc.BuscarContenedoresPorPunto(punto.Id).Any(contenedor => contenedor.Tipo == p_tipo));

        if (p_limit > 0) {
                query = query.Take (p_limit);
        }

        return query.ToList ();

        /*PROTECTED REGION END*/
}
}
}
