
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Estancia_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class EstanciaCEN
{
public string Crear (string p_id, string p_actividad, double p_latitud, double p_longitud, string p_nombre, int p_edificio, int p_planta)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Estancia_crear_customized) ENABLED START*/

        EstanciaEN estanciaEN = null;

        string oid;

        //Initialized EstanciaEN
        estanciaEN = new EstanciaEN ();
        estanciaEN.Id = p_id;

        estanciaEN.Actividad = p_actividad;

        estanciaEN.Latitud = p_latitud;

        estanciaEN.Longitud = p_longitud;

        estanciaEN.Nombre = p_nombre;


        if (p_edificio != -1) {
                estanciaEN.Edificio = new ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN ();
                estanciaEN.Edificio.Id = p_edificio;
        }


        if (p_planta != -1) {
                estanciaEN.Planta = new ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN ();
                estanciaEN.Planta.Id = p_planta;
        }

        //Call to EstanciaCAD

        oid = _IEstanciaCAD.Crear (estanciaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
