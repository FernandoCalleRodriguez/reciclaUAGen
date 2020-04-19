

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ReciclaUAGenNHibernate.Exceptions;

using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;


namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
/*
 *      Definition of the class EstanciaCEN
 *
 */
public partial class EstanciaCEN
{
private IEstanciaCAD _IEstanciaCAD;

public EstanciaCEN()
{
        this._IEstanciaCAD = new EstanciaCAD ();
}

public EstanciaCEN(IEstanciaCAD _IEstanciaCAD)
{
        this._IEstanciaCAD = _IEstanciaCAD;
}

public IEstanciaCAD get_IEstanciaCAD ()
{
        return this._IEstanciaCAD;
}

public void Modificar (string p_Estancia_OID, string p_actividad, double p_latitud, double p_longitud, string p_nombre)
{
        EstanciaEN estanciaEN = null;

        //Initialized EstanciaEN
        estanciaEN = new EstanciaEN ();
        estanciaEN.Id = p_Estancia_OID;
        estanciaEN.Actividad = p_actividad;
        estanciaEN.Latitud = p_latitud;
        estanciaEN.Longitud = p_longitud;
        estanciaEN.Nombre = p_nombre;
        //Call to EstanciaCAD

        _IEstanciaCAD.Modificar (estanciaEN);
}

public void Borrar (string id
                    )
{
        _IEstanciaCAD.Borrar (id);
}

public EstanciaEN BuscarPorId (string id
                               )
{
        EstanciaEN estanciaEN = null;

        estanciaEN = _IEstanciaCAD.BuscarPorId (id);
        return estanciaEN;
}

public System.Collections.Generic.IList<EstanciaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<EstanciaEN> list = null;

        list = _IEstanciaCAD.BuscarTodos (first, size);
        return list;
}
public string Crear (string p_id, string p_actividad, double p_latitud, double p_longitud, string p_nombre, int p_edificio, int p_planta)
{
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
                // El argumento p_edificio -> Property edificio es oid = false
                // Lista de oids id
                estanciaEN.Edificio = new ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN ();
                estanciaEN.Edificio.Id = p_edificio;
        }


        if (p_planta != -1) {
                // El argumento p_planta -> Property planta es oid = false
                // Lista de oids id
                estanciaEN.Planta = new ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN ();
                estanciaEN.Planta.Id = p_planta;
        }

        //Call to EstanciaCAD

        oid = _IEstanciaCAD.Crear (estanciaEN);
        return oid;
}
}
}
