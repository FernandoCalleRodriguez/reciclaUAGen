

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
 *      Definition of the class DudaCEN
 *
 */
public partial class DudaCEN
{
private IDudaCAD _IDudaCAD;

public DudaCEN()
{
        this._IDudaCAD = new DudaCAD ();
}

public DudaCEN(IDudaCAD _IDudaCAD)
{
        this._IDudaCAD = _IDudaCAD;
}

public IDudaCAD get_IDudaCAD ()
{
        return this._IDudaCAD;
}

public void Modificar (int p_Duda_OID, string p_titulo, string p_cuerpo, Nullable<DateTime> p_fecha, int p_util, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TemaEnum p_tema)
{
        DudaEN dudaEN = null;

        //Initialized DudaEN
        dudaEN = new DudaEN ();
        dudaEN.Id = p_Duda_OID;
        dudaEN.Titulo = p_titulo;
        dudaEN.Cuerpo = p_cuerpo;
        dudaEN.Fecha = p_fecha;
        dudaEN.Util = p_util;
        dudaEN.Tema = p_tema;
        //Call to DudaCAD

        _IDudaCAD.Modificar (dudaEN);
}

public void Borrar (int id
                    )
{
        _IDudaCAD.Borrar (id);
}

public DudaEN BuscarPorId (int id
                           )
{
        DudaEN dudaEN = null;

        dudaEN = _IDudaCAD.BuscarPorId (id);
        return dudaEN;
}

public System.Collections.Generic.IList<DudaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<DudaEN> list = null;

        list = _IDudaCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudaPorTitulo (string p_titulo)
{
        return _IDudaCAD.BuscarDudaPorTitulo (p_titulo);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudaPorTema (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TemaEnum ? p_tema)
{
        return _IDudaCAD.BuscarDudaPorTema (p_tema);
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudasPorUsuario (int id_usuario)
{
        return _IDudaCAD.BuscarDudasPorUsuario (id_usuario);
}
}
}
