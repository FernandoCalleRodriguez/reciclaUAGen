

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

public int Crear (int p_usuario, Nullable<DateTime> p_fecha, int p_contenedor, int p_item, int p_cantidad)
{
        AccionReciclarEN accionReciclarEN = null;
        int oid;

        //Initialized AccionReciclarEN
        accionReciclarEN = new AccionReciclarEN ();

        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                accionReciclarEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN ();
                accionReciclarEN.Usuario.Id = p_usuario;
        }

        accionReciclarEN.Fecha = p_fecha;


        if (p_contenedor != -1) {
                // El argumento p_contenedor -> Property contenedor es oid = false
                // Lista de oids id
                accionReciclarEN.Contenedor = new ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN ();
                accionReciclarEN.Contenedor.Id = p_contenedor;
        }


        if (p_item != -1) {
                // El argumento p_item -> Property item es oid = false
                // Lista de oids id
                accionReciclarEN.Item = new ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN ();
                accionReciclarEN.Item.Id = p_item;
        }

        accionReciclarEN.Cantidad = p_cantidad;

        //Call to AccionReciclarCAD

        oid = _IAccionReciclarCAD.Crear (accionReciclarEN);
        return oid;
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
