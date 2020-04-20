

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
 *      Definition of the class MaterialCEN
 *
 */
public partial class MaterialCEN
{
private IMaterialCAD _IMaterialCAD;

public MaterialCEN()
{
        this._IMaterialCAD = new MaterialCAD ();
}

public MaterialCEN(IMaterialCAD _IMaterialCAD)
{
        this._IMaterialCAD = _IMaterialCAD;
}

public IMaterialCAD get_IMaterialCAD ()
{
        return this._IMaterialCAD;
}

public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarPorTipoContenedor (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum ? tipo_contenedor)
{
        return _IMaterialCAD.BuscarPorTipoContenedor (tipo_contenedor);
}
public void Modificar (int p_Material_OID, string p_nombre, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_contenedor, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum p_esValido)
{
        MaterialEN materialEN = null;

        //Initialized MaterialEN
        materialEN = new MaterialEN ();
        materialEN.Id = p_Material_OID;
        materialEN.Nombre = p_nombre;
        materialEN.Contenedor = p_contenedor;
        materialEN.EsValido = p_esValido;
        //Call to MaterialCAD

        _IMaterialCAD.Modificar (materialEN);
}

public void Borrar (int id
                    )
{
        _IMaterialCAD.Borrar (id);
}

public MaterialEN BuscarPorId (int id
                               )
{
        MaterialEN materialEN = null;

        materialEN = _IMaterialCAD.BuscarPorId (id);
        return materialEN;
}

public System.Collections.Generic.IList<MaterialEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> list = null;

        list = _IMaterialCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesPorValidar ()
{
        return _IMaterialCAD.BuscarMaterialesPorValidar ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesValidados ()
{
        return _IMaterialCAD.BuscarMaterialesValidados ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesPorUsuario (int id_usuario)
{
        return _IMaterialCAD.BuscarMaterialesPorUsuario (id_usuario);
}
public int BuscarMaterialesPorValidarCount ()
{
        return _IMaterialCAD.BuscarMaterialesPorValidarCount ();
}
}
}
