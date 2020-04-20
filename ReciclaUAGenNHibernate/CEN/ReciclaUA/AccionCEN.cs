

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
 *      Definition of the class AccionCEN
 *
 */
public partial class AccionCEN
{
private IAccionCAD _IAccionCAD;

public AccionCEN()
{
        this._IAccionCAD = new AccionCAD ();
}

public AccionCEN(IAccionCAD _IAccionCAD)
{
        this._IAccionCAD = _IAccionCAD;
}

public IAccionCAD get_IAccionCAD ()
{
        return this._IAccionCAD;
}

public int Crear (int p_usuario, Nullable<DateTime> p_fecha)
{
        AccionEN accionEN = null;
        int oid;

        //Initialized AccionEN
        accionEN = new AccionEN ();

        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                accionEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN ();
                accionEN.Usuario.Id = p_usuario;
        }

        accionEN.Fecha = p_fecha;

        //Call to AccionCAD

        oid = _IAccionCAD.Crear (accionEN);
        return oid;
}

public AccionEN BuscarPorId (int id
                             )
{
        AccionEN accionEN = null;

        accionEN = _IAccionCAD.BuscarPorId (id);
        return accionEN;
}

public System.Collections.Generic.IList<AccionEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AccionEN> list = null;

        list = _IAccionCAD.BuscarTodos (first, size);
        return list;
}
}
}
