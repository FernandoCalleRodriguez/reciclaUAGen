

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

public void Modificar (int p_UsuarioAdministrador_OID, string p_nombre, string p_apellidos, string p_email, String p_pass, Nullable<DateTime> p_fecha, bool p_emailVerificado, bool p_borrado)
{
        UsuarioAdministradorEN usuarioAdministradorEN = null;

        //Initialized UsuarioAdministradorEN
        usuarioAdministradorEN = new UsuarioAdministradorEN ();
        usuarioAdministradorEN.Id = p_UsuarioAdministrador_OID;
        usuarioAdministradorEN.Nombre = p_nombre;
        usuarioAdministradorEN.Apellidos = p_apellidos;
        usuarioAdministradorEN.Email = p_email;
        usuarioAdministradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioAdministradorEN.Fecha = p_fecha;
        usuarioAdministradorEN.EmailVerificado = p_emailVerificado;
        usuarioAdministradorEN.Borrado = p_borrado;
        //Call to UsuarioAdministradorCAD

        _IUsuarioAdministradorCAD.Modificar (usuarioAdministradorEN);
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
}
}
