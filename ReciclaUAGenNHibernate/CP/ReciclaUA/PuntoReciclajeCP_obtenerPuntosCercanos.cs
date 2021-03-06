
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
using APIExterna;
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

                GeoCoordinateWrapper referencia = new GeoCoordinateWrapper (p_latitud, p_longitud);

                IList<Tuple<GeoCoordinateWrapper, PuntoReciclajeEN> > coordenadas = new List<Tuple<GeoCoordinateWrapper, PuntoReciclajeEN> >();

                foreach (PuntoReciclajeEN punto in puntoReciclajeCEN.BuscarPuntosValidados ()) {
                        Console.WriteLine (punto.Estancia.Edificio + " " + punto.Estancia.Planta);
                        coordenadas.Add (new Tuple<GeoCoordinateWrapper, PuntoReciclajeEN>(new GeoCoordinateWrapper (punto.Latitud, punto.Longitud), punto));
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
