

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
 *      Definition of the class ItemCEN
 *
 */
public partial class ItemCEN
{
private IItemCAD _IItemCAD;

public ItemCEN()
{
        this._IItemCAD = new ItemCAD ();
}

public ItemCEN(IItemCAD _IItemCAD)
{
        this._IItemCAD = _IItemCAD;
}

public IItemCAD get_IItemCAD ()
{
        return this._IItemCAD;
}

public void Modificar (int p_Item_OID, string p_nombre, string p_descripcion, string p_imagen, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum p_esValido)
{
        ItemEN itemEN = null;

        //Initialized ItemEN
        itemEN = new ItemEN ();
        itemEN.Id = p_Item_OID;
        itemEN.Nombre = p_nombre;
        itemEN.Descripcion = p_descripcion;
        itemEN.Imagen = p_imagen;
        itemEN.EsValido = p_esValido;
        //Call to ItemCAD

        _IItemCAD.Modificar (itemEN);
}

public void Borrar (int id
                    )
{
        _IItemCAD.Borrar (id);
}

public ItemEN BuscarPorId (int id
                           )
{
        ItemEN itemEN = null;

        itemEN = _IItemCAD.BuscarPorId (id);
        return itemEN;
}

public System.Collections.Generic.IList<ItemEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<ItemEN> list = null;

        list = _IItemCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorValidar ()
{
        return _IItemCAD.BuscarItemsPorValidar ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsValidados ()
{
        return _IItemCAD.BuscarItemsValidados ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorUsuario (int id_usuario)
{
        return _IItemCAD.BuscarItemsPorUsuario (id_usuario);
}
public int BuscarItemsPorValidarCount ()
{
        return _IItemCAD.BuscarItemsPorValidarCount ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorNivel (int id_nivel)
{
        return _IItemCAD.BuscarItemsPorNivel (id_nivel);
}
public int Operation ()
{
        return _IItemCAD.Operation ();
}
}
}
