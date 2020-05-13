

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
 *      Definition of the class JuegoCEN
 *
 */
public partial class JuegoCEN
{
private IJuegoCAD _IJuegoCAD;

public JuegoCEN()
{
        this._IJuegoCAD = new JuegoCAD ();
}

public JuegoCEN(IJuegoCAD _IJuegoCAD)
{
        this._IJuegoCAD = _IJuegoCAD;
}

public IJuegoCAD get_IJuegoCAD ()
{
        return this._IJuegoCAD;
}

public int Crear (int p_itemActual, int p_aciertos, int p_fallos, int p_puntuacion, int p_nivelActual, int p_intentosItemActual, bool p_finalizado)
{
        JuegoEN juegoEN = null;
        int oid;

        //Initialized JuegoEN
        juegoEN = new JuegoEN ();
        juegoEN.ItemActual = p_itemActual;

        juegoEN.Aciertos = p_aciertos;

        juegoEN.Fallos = p_fallos;

        juegoEN.Puntuacion = p_puntuacion;


        if (p_nivelActual != -1) {
                // El argumento p_nivelActual -> Property nivelActual es oid = false
                // Lista de oids id
                juegoEN.NivelActual = new ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN ();
                juegoEN.NivelActual.Id = p_nivelActual;
        }

        juegoEN.IntentosItemActual = p_intentosItemActual;

        juegoEN.Finalizado = p_finalizado;

        //Call to JuegoCAD

        oid = _IJuegoCAD.Crear (juegoEN);
        return oid;
}

public void Modificar (int p_Juego_OID, int p_itemActual, int p_aciertos, int p_fallos, int p_puntuacion, int p_intentosItemActual, bool p_finalizado)
{
        JuegoEN juegoEN = null;

        //Initialized JuegoEN
        juegoEN = new JuegoEN ();
        juegoEN.Id = p_Juego_OID;
        juegoEN.ItemActual = p_itemActual;
        juegoEN.Aciertos = p_aciertos;
        juegoEN.Fallos = p_fallos;
        juegoEN.Puntuacion = p_puntuacion;
        juegoEN.IntentosItemActual = p_intentosItemActual;
        juegoEN.Finalizado = p_finalizado;
        //Call to JuegoCAD

        _IJuegoCAD.Modificar (juegoEN);
}

public void Borrar (int id
                    )
{
        _IJuegoCAD.Borrar (id);
}

public JuegoEN BuscarPorId (int id
                            )
{
        JuegoEN juegoEN = null;

        juegoEN = _IJuegoCAD.BuscarPorId (id);
        return juegoEN;
}

public System.Collections.Generic.IList<JuegoEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<JuegoEN> list = null;

        list = _IJuegoCAD.BuscarTodos (first, size);
        return list;
}
}
}
