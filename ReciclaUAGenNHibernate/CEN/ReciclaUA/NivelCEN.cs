

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
 *      Definition of the class NivelCEN
 *
 */
public partial class NivelCEN
{
private INivelCAD _INivelCAD;

public NivelCEN()
{
        this._INivelCAD = new NivelCAD ();
}

public NivelCEN(INivelCAD _INivelCAD)
{
        this._INivelCAD = _INivelCAD;
}

public INivelCAD get_INivelCAD ()
{
        return this._INivelCAD;
}

public int Crear (int p_numero, int p_puntuacion)
{
        NivelEN nivelEN = null;
        int oid;

        //Initialized NivelEN
        nivelEN = new NivelEN ();
        nivelEN.Numero = p_numero;

        nivelEN.Puntuacion = p_puntuacion;

        //Call to NivelCAD

        oid = _INivelCAD.Crear (nivelEN);
        return oid;
}

public void Modificar (int p_Nivel_OID, int p_numero, int p_puntuacion)
{
        NivelEN nivelEN = null;

        //Initialized NivelEN
        nivelEN = new NivelEN ();
        nivelEN.Id = p_Nivel_OID;
        nivelEN.Numero = p_numero;
        nivelEN.Puntuacion = p_puntuacion;
        //Call to NivelCAD

        _INivelCAD.Modificar (nivelEN);
}

public void Borrar (int id
                    )
{
        _INivelCAD.Borrar (id);
}

public NivelEN BuscarPorId (int id
                            )
{
        NivelEN nivelEN = null;

        nivelEN = _INivelCAD.BuscarPorId (id);
        return nivelEN;
}

public System.Collections.Generic.IList<NivelEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<NivelEN> list = null;

        list = _INivelCAD.BuscarTodos (first, size);
        return list;
}
public void AsignarItems (int p_Nivel_OID, System.Collections.Generic.IList<int> p_item_OIDs)
{
        //Call to NivelCAD

        _INivelCAD.AsignarItems (p_Nivel_OID, p_item_OIDs);
}
public void DesasignarItems (int p_Nivel_OID, System.Collections.Generic.IList<int> p_item_OIDs)
{
        //Call to NivelCAD

        _INivelCAD.DesasignarItems (p_Nivel_OID, p_item_OIDs);
}
public int BuscarNivelCount ()
{
        return _INivelCAD.BuscarNivelCount ();
}
}
}
