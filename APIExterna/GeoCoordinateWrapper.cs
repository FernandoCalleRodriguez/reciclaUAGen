using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIExterna
{
    public class GeoCoordinateWrapper
    {
        private GeoCoordinate geo = null;

        public GeoCoordinateWrapper(double lat, double lng)
        {
            geo = new GeoCoordinate(lat, lng);
        } 

        public double GetDistanceTo(GeoCoordinateWrapper point)
        {
            return geo.GetDistanceTo(point.GetGeo());
        }

        public GeoCoordinate GetGeo()
        {
            return geo;
        }
    }
}
