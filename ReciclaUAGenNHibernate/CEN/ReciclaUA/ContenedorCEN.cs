

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
 *      Definition of the class ContenedorCEN
 *
 */
public partial class ContenedorCEN
{
private IContenedorCAD _IContenedorCAD;

public ContenedorCEN()
{
        this._IContenedorCAD = new ContenedorCAD ();
}

public ContenedorCEN(IContenedorCAD _IContenedorCAD)
{
        this._IContenedorCAD = _IContenedorCAD;
}

public IContenedorCAD get_IContenedorCAD ()
{
        return this._IContenedorCAD;
}

public int Crear (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_tipo, int p_punto)
{
        ContenedorEN contenedorEN = null;
        int oid;

        //Initialized ContenedorEN
        contenedorEN = new ContenedorEN ();
        contenedorEN.Tipo = p_tipo;


        if (p_punto != -1) {
                // El argumento p_punto -> Property punto es oid = false
                // Lista de oids id
                contenedorEN.Punto = new ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN ();
                contenedorEN.Punto.Id = p_punto;
        }

        //Call to ContenedorCAD

        oid = _IContenedorCAD.Crear (contenedorEN);
        return oid;
}

public void Modificar (int p_Contenedor_OID, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_tipo)
{
        ContenedorEN contenedorEN = null;

        //Initialized ContenedorEN
        contenedorEN = new ContenedorEN ();
        contenedorEN.Id = p_Contenedor_OID;
        contenedorEN.Tipo = p_tipo;
        //Call to ContenedorCAD

        _IContenedorCAD.Modificar (contenedorEN);
}

public void Borrar (int id
                    )
{
        _IContenedorCAD.Borrar (id);
}

public ContenedorEN BuscarPorId (int id
                                 )
{
        ContenedorEN contenedorEN = null;

        contenedorEN = _IContenedorCAD.BuscarPorId (id);
        return contenedorEN;
}

public System.Collections.Generic.IList<ContenedorEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<ContenedorEN> list = null;

        list = _IContenedorCAD.BuscarTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> BuscarContenedoresPorTipo (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum ? tipo_contenedor)
{
        return _IContenedorCAD.BuscarContenedoresPorTipo (tipo_contenedor);
}
}
}
