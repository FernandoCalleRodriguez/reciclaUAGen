

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
 *      Definition of the class UsuarioAdministradorCEN
 *
 */
public partial class UsuarioAdministradorCEN
{
private IUsuarioAdministradorCAD _IUsuarioAdministradorCAD;

public UsuarioAdministradorCEN()
{
        this._IUsuarioAdministradorCAD = new UsuarioAdministradorCAD ();
}

public UsuarioAdministradorCEN(IUsuarioAdministradorCAD _IUsuarioAdministradorCAD)
{
        this._IUsuarioAdministradorCAD = _IUsuarioAdministradorCAD;
}

public IUsuarioAdministradorCAD get_IUsuarioAdministradorCAD ()
{
        return this._IUsuarioAdministradorCAD;
}

public UsuarioAdministradorEN BuscarPorId (int id
                                           )
{
        UsuarioAdministradorEN usuarioAdministradorEN = null;

        usuarioAdministradorEN = _IUsuarioAdministradorCAD.BuscarPorId (id);
        return usuarioAdministradorEN;
}

public System.Collections.Generic.IList<UsuarioAdministradorEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioAdministradorEN> list = null;

        list = _IUsuarioAdministradorCAD.BuscarTodos (first, size);
        return list;
}
public ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN BuscarPorCorreo (string p_correo)
{
        return _IUsuarioAdministradorCAD.BuscarPorCorreo (p_correo);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN> BuscarNoBorrados ()
{
        return _IUsuarioAdministradorCAD.BuscarNoBorrados ();
}
public void Destroy (int id
                     )
{
        _IUsuarioAdministradorCAD.Destroy (id);
}
}
}
