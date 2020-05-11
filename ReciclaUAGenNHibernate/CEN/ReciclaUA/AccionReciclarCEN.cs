

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
 *      Definition of the class AccionReciclarCEN
 *
 */
public partial class AccionReciclarCEN
{
private IAccionReciclarCAD _IAccionReciclarCAD;

public AccionReciclarCEN()
{
        this._IAccionReciclarCAD = new AccionReciclarCAD ();
}

public AccionReciclarCEN(IAccionReciclarCAD _IAccionReciclarCAD)
{
        this._IAccionReciclarCAD = _IAccionReciclarCAD;
}

public IAccionReciclarCAD get_IAccionReciclarCAD ()
{
        return this._IAccionReciclarCAD;
}

public void Modificar (int p_AccionReciclar_OID, Nullable<DateTime> p_fecha, int p_cantidad)
{
        AccionReciclarEN accionReciclarEN = null;

        //Initialized AccionReciclarEN
        accionReciclarEN = new AccionReciclarEN ();
        accionReciclarEN.Id = p_AccionReciclar_OID;
        accionReciclarEN.Fecha = p_fecha;
        accionReciclarEN.Cantidad = p_cantidad;
        //Call to AccionReciclarCAD

        _IAccionReciclarCAD.Modificar (accionReciclarEN);
}

public void Borrar (int id
                    )
{
        _IAccionReciclarCAD.Borrar (id);
}

public AccionReciclarEN BuscarPorId (int id
                                     )
{
        AccionReciclarEN accionReciclarEN = null;

        accionReciclarEN = _IAccionReciclarCAD.BuscarPorId (id);
        return accionReciclarEN;
}

public System.Collections.Generic.IList<AccionReciclarEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AccionReciclarEN> list = null;

        list = _IAccionReciclarCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorAutor (int ? p_user_id)
{
        return _IAccionReciclarCAD.BuscarPorAutor (p_user_id);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorFecha (Nullable<DateTime> p_date)
{
        return _IAccionReciclarCAD.BuscarPorFecha (p_date);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorMaterial (string p_material)
{
        return _IAccionReciclarCAD.BuscarPorMaterial (p_material);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarAccionesReciclajePorUsuario (int id_usuario)
{
        return _IAccionReciclarCAD.BuscarAccionesReciclajePorUsuario (id_usuario);
}
}
}
