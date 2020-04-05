

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
 *      Definition of the class AulaCEN
 *
 */
public partial class AulaCEN
{
private IAulaCAD _IAulaCAD;

public AulaCEN()
{
        this._IAulaCAD = new AulaCAD ();
}

public AulaCEN(IAulaCAD _IAulaCAD)
{
        this._IAulaCAD = _IAulaCAD;
}

public IAulaCAD get_IAulaCAD ()
{
        return this._IAulaCAD;
}

public int Crear (int p_edificio, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum p_planta)
{
        AulaEN aulaEN = null;
        int oid;

        //Initialized AulaEN
        aulaEN = new AulaEN ();

        if (p_edificio != -1) {
                // El argumento p_edificio -> Property edificio es oid = false
                // Lista de oids id
                aulaEN.Edificio = new ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN ();
                aulaEN.Edificio.Id = p_edificio;
        }

        aulaEN.Planta = p_planta;

        //Call to AulaCAD

        oid = _IAulaCAD.Crear (aulaEN);
        return oid;
}

public void Modificar (int p_Aula_OID, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum p_planta)
{
        AulaEN aulaEN = null;

        //Initialized AulaEN
        aulaEN = new AulaEN ();
        aulaEN.Id = p_Aula_OID;
        aulaEN.Planta = p_planta;
        //Call to AulaCAD

        _IAulaCAD.Modificar (aulaEN);
}

public void Eliminar (int id
                      )
{
        _IAulaCAD.Eliminar (id);
}

public AulaEN BuscarPorID (int id
                           )
{
        AulaEN aulaEN = null;

        aulaEN = _IAulaCAD.BuscarPorID (id);
        return aulaEN;
}

public System.Collections.Generic.IList<AulaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<AulaEN> list = null;

        list = _IAulaCAD.BuscarTodos (first, size);
        return list;
}
}
}
