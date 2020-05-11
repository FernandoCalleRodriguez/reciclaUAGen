

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
 *      Definition of the class AccionWebCEN
 *
 */
public partial class AccionWebCEN
{
private IAccionWebCAD _IAccionWebCAD;

public AccionWebCEN()
{
        this._IAccionWebCAD = new AccionWebCAD ();
}

public AccionWebCEN(IAccionWebCAD _IAccionWebCAD)
{
        this._IAccionWebCAD = _IAccionWebCAD;
}

public IAccionWebCAD get_IAccionWebCAD ()
{
        return this._IAccionWebCAD;
}

public void Modificar (int p_AccionWeb_OID, Nullable<DateTime> p_fecha)
{
        AccionWebEN accionWebEN = null;

        //Initialized AccionWebEN
        accionWebEN = new AccionWebEN ();
        accionWebEN.Id = p_AccionWeb_OID;
        accionWebEN.Fecha = p_fecha;
        //Call to AccionWebCAD

        _IAccionWebCAD.Modificar (accionWebEN);
}

public void Borrar (int id
                    )
{
        _IAccionWebCAD.Borrar (id);
}

public AccionWebEN BuscarPorId (int id
                                )
{
        AccionWebEN accionWebEN = null;

        accionWebEN = _IAccionWebCAD.BuscarPorId (id);
        return accionWebEN;
}

public System.Collections.Generic.IList<AccionWebEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AccionWebEN> list = null;

        list = _IAccionWebCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorAutor (int ? p_user_id)
{
        return _IAccionWebCAD.BuscarPorAutor (p_user_id);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorFecha (Nullable<DateTime> p_date)
{
        return _IAccionWebCAD.BuscarPorFecha (p_date);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorTipo (string p_type)
{
        return _IAccionWebCAD.BuscarPorTipo (p_type);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarAccionesWebPorUsuario (int id_usuario)
{
        return _IAccionWebCAD.BuscarAccionesWebPorUsuario (id_usuario);
}
}
}
