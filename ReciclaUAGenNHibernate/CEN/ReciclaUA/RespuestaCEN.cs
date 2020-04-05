

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
 *      Definition of the class RespuestaCEN
 *
 */
public partial class RespuestaCEN
{
private IRespuestaCAD _IRespuestaCAD;

public RespuestaCEN()
{
        this._IRespuestaCAD = new RespuestaCAD ();
}

public RespuestaCEN(IRespuestaCAD _IRespuestaCAD)
{
        this._IRespuestaCAD = _IRespuestaCAD;
}

public IRespuestaCAD get_IRespuestaCAD ()
{
        return this._IRespuestaCAD;
}

public void Modificar (int p_Respuesta_OID, string p_cuerpo, Nullable<DateTime> p_fecha, bool p_esCorrecta, int p_util)
{
        RespuestaEN respuestaEN = null;

        //Initialized RespuestaEN
        respuestaEN = new RespuestaEN ();
        respuestaEN.Id = p_Respuesta_OID;
        respuestaEN.Cuerpo = p_cuerpo;
        respuestaEN.Fecha = p_fecha;
        respuestaEN.EsCorrecta = p_esCorrecta;
        respuestaEN.Util = p_util;
        //Call to RespuestaCAD

        _IRespuestaCAD.Modificar (respuestaEN);
}

public void Borrar (int id
                    )
{
        _IRespuestaCAD.Borrar (id);
}

public RespuestaEN BuscarPorId (int id
                                )
{
        RespuestaEN respuestaEN = null;

        respuestaEN = _IRespuestaCAD.BuscarPorId (id);
        return respuestaEN;
}

public System.Collections.Generic.IList<RespuestaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> list = null;

        list = _IRespuestaCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestaPorDuda (int ? id_duda)
{
        return _IRespuestaCAD.BuscarRespuestaPorDuda (id_duda);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestaPorEsCorrecta ()
{
        return _IRespuestaCAD.BuscarRespuestaPorEsCorrecta ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestasPorUsuario (int id_usuario)
{
        return _IRespuestaCAD.BuscarRespuestasPorUsuario (id_usuario);
}
}
}
