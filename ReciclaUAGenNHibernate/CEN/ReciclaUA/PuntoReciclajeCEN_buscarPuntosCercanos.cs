
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
using System.Device.Location;
using System.Linq;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
    public partial class PuntoReciclajeCEN
    {
        public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosCercanos(double p_latitud, double p_longitud, int p_limit)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_buscarPuntosCercanos) ENABLED START*/

            GeoCoordinate referencia = new GeoCoordinate(p_latitud, p_longitud);

            PuntoReciclajeCEN cen = new PuntoReciclajeCEN();

            IList<Tuple<GeoCoordinate, PuntoReciclajeEN>> coordenadas = new List<Tuple<GeoCoordinate, PuntoReciclajeEN>>();

            foreach (PuntoReciclajeEN punto in cen.BuscarTodos(0, -1))
            {
                coordenadas.Add(new Tuple<GeoCoordinate, PuntoReciclajeEN>(new GeoCoordinate(punto.Latitud, punto.Longitud), punto));
            }

            var query = coordenadas.OrderBy(tupla => tupla.Item1.GetDistanceTo(referencia)).Select(tupla => tupla.Item2);

            if (p_limit > 0)
            {
                query = query.Take(p_limit);
            }

            IList<PuntoReciclajeEN> cercanos = query.ToList();

            return cercanos;

            /*PROTECTED REGION END*/
        }
    }
}
