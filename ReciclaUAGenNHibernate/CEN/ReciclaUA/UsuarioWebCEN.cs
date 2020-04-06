

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
 *      Definition of the class UsuarioWebCEN
 *
 */
public partial class UsuarioWebCEN
{
private IUsuarioWebCAD _IUsuarioWebCAD;

public UsuarioWebCEN()
{
        this._IUsuarioWebCAD = new UsuarioWebCAD ();
}

public UsuarioWebCEN(IUsuarioWebCAD _IUsuarioWebCAD)
{
        this._IUsuarioWebCAD = _IUsuarioWebCAD;
}

public IUsuarioWebCAD get_IUsuarioWebCAD ()
{
        return this._IUsuarioWebCAD;
}

public UsuarioWebEN BuscarPorId (int id
                                 )
{
        UsuarioWebEN usuarioWebEN = null;

        usuarioWebEN = _IUsuarioWebCAD.BuscarPorId (id);
        return usuarioWebEN;
}

public System.Collections.Generic.IList<UsuarioWebEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioWebEN> list = null;

        list = _IUsuarioWebCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> ObtenerRanking ()
{
        return _IUsuarioWebCAD.ObtenerRanking ();
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> ObtenerPuntuaciones ()
{
        return _IUsuarioWebCAD.ObtenerPuntuaciones ();
}
}
}
