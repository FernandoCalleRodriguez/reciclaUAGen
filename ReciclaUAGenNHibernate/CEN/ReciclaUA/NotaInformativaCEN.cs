

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
 *      Definition of the class NotaInformativaCEN
 *
 */
public partial class NotaInformativaCEN
{
private INotaInformativaCAD _INotaInformativaCAD;

public NotaInformativaCEN()
{
        this._INotaInformativaCAD = new NotaInformativaCAD ();
}

public NotaInformativaCEN(INotaInformativaCAD _INotaInformativaCAD)
{
        this._INotaInformativaCAD = _INotaInformativaCAD;
}

public INotaInformativaCAD get_INotaInformativaCAD ()
{
        return this._INotaInformativaCAD;
}

public void Modificar (int p_NotaInformativa_OID, string p_titulo, string p_cuerpo, Nullable<DateTime> p_fecha)
{
        NotaInformativaEN notaInformativaEN = null;

        //Initialized NotaInformativaEN
        notaInformativaEN = new NotaInformativaEN ();
        notaInformativaEN.Id = p_NotaInformativa_OID;
        notaInformativaEN.Titulo = p_titulo;
        notaInformativaEN.Cuerpo = p_cuerpo;
        notaInformativaEN.Fecha = p_fecha;
        //Call to NotaInformativaCAD

        _INotaInformativaCAD.Modificar (notaInformativaEN);
}

public void Borrar (int id
                    )
{
        _INotaInformativaCAD.Borrar (id);
}

public NotaInformativaEN BuscarPorId (int id
                                      )
{
        NotaInformativaEN notaInformativaEN = null;

        notaInformativaEN = _INotaInformativaCAD.BuscarPorId (id);
        return notaInformativaEN;
}

public System.Collections.Generic.IList<NotaInformativaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<NotaInformativaEN> list = null;

        list = _INotaInformativaCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> BuscarPorTitulo ()
{
        return _INotaInformativaCAD.BuscarPorTitulo ();
}
}
}
