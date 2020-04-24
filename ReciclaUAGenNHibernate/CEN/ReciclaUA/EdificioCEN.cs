

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
 *      Definition of the class EdificioCEN
 *
 */
public partial class EdificioCEN
{
private IEdificioCAD _IEdificioCAD;

public EdificioCEN()
{
        this._IEdificioCAD = new EdificioCAD ();
}

public EdificioCEN(IEdificioCAD _IEdificioCAD)
{
        this._IEdificioCAD = _IEdificioCAD;
}

public IEdificioCAD get_IEdificioCAD ()
{
        return this._IEdificioCAD;
}

public int Crear (string p_nombre, int p_id)
{
        EdificioEN edificioEN = null;
        int oid;

        //Initialized EdificioEN
        edificioEN = new EdificioEN ();
        edificioEN.Nombre = p_nombre;

        edificioEN.Id = p_id;

        //Call to EdificioCAD

        oid = _IEdificioCAD.Crear (edificioEN);
        return oid;
}

public void Modificar (int p_Edificio_OID, string p_nombre)
{
        EdificioEN edificioEN = null;

        //Initialized EdificioEN
        edificioEN = new EdificioEN ();
        edificioEN.Id = p_Edificio_OID;
        edificioEN.Nombre = p_nombre;
        //Call to EdificioCAD

        _IEdificioCAD.Modificar (edificioEN);
}

public void Borrar (int id
                    )
{
        _IEdificioCAD.Borrar (id);
}

public EdificioEN BuscarPorId (int id
                               )
{
        EdificioEN edificioEN = null;

        edificioEN = _IEdificioCAD.BuscarPorId (id);
        return edificioEN;
}

public System.Collections.Generic.IList<EdificioEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<EdificioEN> list = null;

        list = _IEdificioCAD.BuscarTodos (first, size);
        return list;
}
public ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN BuscarEdificioPorPlanta (int planta_id)
{
        return _IEdificioCAD.BuscarEdificioPorPlanta (planta_id);
}
}
}
