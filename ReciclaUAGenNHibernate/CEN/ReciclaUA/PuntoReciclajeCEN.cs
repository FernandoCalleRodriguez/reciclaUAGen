

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
 *      Definition of the class PuntoReciclajeCEN
 *
 */
public partial class PuntoReciclajeCEN
{
private IPuntoReciclajeCAD _IPuntoReciclajeCAD;

public PuntoReciclajeCEN()
{
        this._IPuntoReciclajeCAD = new PuntoReciclajeCAD ();
}

public PuntoReciclajeCEN(IPuntoReciclajeCAD _IPuntoReciclajeCAD)
{
        this._IPuntoReciclajeCAD = _IPuntoReciclajeCAD;
}

public IPuntoReciclajeCAD get_IPuntoReciclajeCAD ()
{
        return this._IPuntoReciclajeCAD;
}

public void Modificar (int p_PuntoReciclaje_OID, double p_latitud, double p_longitud, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum p_esValido)
{
        PuntoReciclajeEN puntoReciclajeEN = null;

        //Initialized PuntoReciclajeEN
        puntoReciclajeEN = new PuntoReciclajeEN ();
        puntoReciclajeEN.Id = p_PuntoReciclaje_OID;
        puntoReciclajeEN.Latitud = p_latitud;
        puntoReciclajeEN.Longitud = p_longitud;
        puntoReciclajeEN.EsValido = p_esValido;
        //Call to PuntoReciclajeCAD

        _IPuntoReciclajeCAD.Modificar (puntoReciclajeEN);
}

public void Borrar (int id
                    )
{
        _IPuntoReciclajeCAD.Borrar (id);
}

public PuntoReciclajeEN BuscarPorId (int id
                                     )
{
        PuntoReciclajeEN puntoReciclajeEN = null;

        puntoReciclajeEN = _IPuntoReciclajeCAD.BuscarPorId (id);
        return puntoReciclajeEN;
}

public System.Collections.Generic.IList<PuntoReciclajeEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<PuntoReciclajeEN> list = null;

        list = _IPuntoReciclajeCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorValidar ()
{
        return _IPuntoReciclajeCAD.BuscarPuntosPorValidar ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosValidados ()
{
        return _IPuntoReciclajeCAD.BuscarPuntosValidados ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorEdificio (int ? id_edificio)
{
        return _IPuntoReciclajeCAD.BuscarPuntosPorEdificio (id_edificio);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorEstancia (string id_estancia)
{
        return _IPuntoReciclajeCAD.BuscarPuntosPorEstancia (id_estancia);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorPlanta (int? id_edificio, int ? num_planta)
{
        return _IPuntoReciclajeCAD.BuscarPuntosPorPlanta (id_edificio, num_planta);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorUsuario (int id_usuario)
{
        return _IPuntoReciclajeCAD.BuscarPuntosPorUsuario (id_usuario);
}
public int BuscarPuntosPorValidarCount ()
{
        return _IPuntoReciclajeCAD.BuscarPuntosPorValidarCount ();
}
}
}
