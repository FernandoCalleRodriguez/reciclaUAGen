

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
 *      Definition of the class TipoAccionCEN
 *
 */
public partial class TipoAccionCEN
{
private ITipoAccionCAD _ITipoAccionCAD;

public TipoAccionCEN()
{
        this._ITipoAccionCAD = new TipoAccionCAD ();
}

public TipoAccionCEN(ITipoAccionCAD _ITipoAccionCAD)
{
        this._ITipoAccionCAD = _ITipoAccionCAD;
}

public ITipoAccionCAD get_ITipoAccionCAD ()
{
        return this._ITipoAccionCAD;
}

public int Crear (int p_puntuacion, string p_nombre)
{
        TipoAccionEN tipoAccionEN = null;
        int oid;

        //Initialized TipoAccionEN
        tipoAccionEN = new TipoAccionEN ();
        tipoAccionEN.Puntuacion = p_puntuacion;

        tipoAccionEN.Nombre = p_nombre;

        //Call to TipoAccionCAD

        oid = _ITipoAccionCAD.Crear (tipoAccionEN);
        return oid;
}

public void Modificar (int p_TipoAccion_OID, int p_puntuacion, string p_nombre)
{
        TipoAccionEN tipoAccionEN = null;

        //Initialized TipoAccionEN
        tipoAccionEN = new TipoAccionEN ();
        tipoAccionEN.Id = p_TipoAccion_OID;
        tipoAccionEN.Puntuacion = p_puntuacion;
        tipoAccionEN.Nombre = p_nombre;
        //Call to TipoAccionCAD

        _ITipoAccionCAD.Modificar (tipoAccionEN);
}

public void Borrar (int id
                    )
{
        _ITipoAccionCAD.Borrar (id);
}

public TipoAccionEN BuscarPorId (int id
                                 )
{
        TipoAccionEN tipoAccionEN = null;

        tipoAccionEN = _ITipoAccionCAD.BuscarPorId (id);
        return tipoAccionEN;
}

public System.Collections.Generic.IList<TipoAccionEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<TipoAccionEN> list = null;

        list = _ITipoAccionCAD.BuscarTodos (first, size);
        return list;
}
}
}
