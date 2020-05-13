
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_PuntoReciclaje_obtenerPuntosCercanos) ENABLED START*/
//  references to other libraries
using System.Linq;
using System.Device.Location;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class PuntoReciclajeCP : BasicCP
{
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> ObtenerPuntosCercanos (double p_latitud, double p_longitud, int p_limit)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_PuntoReciclaje_obtenerPuntosCercanos) ENABLED START*/

        IPuntoReciclajeCAD puntoReciclajeCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;

        System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> result = null;


        try
        {
                SessionInitializeTransaction ();
                puntoReciclajeCAD = new PuntoReciclajeCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeCAD);

                GeoCoordinate referencia = new GeoCoordinate (p_latitud, p_longitud);

                IList<Tuple<GeoCoordinate, PuntoReciclajeEN> > coordenadas = new List<Tuple<GeoCoordinate, PuntoReciclajeEN> >();

                foreach (PuntoReciclajeEN punto in puntoReciclajeCEN.BuscarTodos (0, -1)) {
                        Console.WriteLine (punto.Estancia.Edificio + " " + punto.Estancia.Planta);
                        coordenadas.Add (new Tuple<GeoCoordinate, PuntoReciclajeEN>(new GeoCoordinate (punto.Latitud, punto.Longitud), punto));
                }

                var query = coordenadas.OrderBy (tupla => tupla.Item1.GetDistanceTo (referencia)).Select (tupla => tupla.Item2);

                if (p_limit > 0) {
                        query = query.Take (p_limit);
                }

                result = query.ToList ();


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
