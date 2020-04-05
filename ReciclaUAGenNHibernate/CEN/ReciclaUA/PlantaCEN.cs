

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
 *      Definition of the class PlantaCEN
 *
 */
public partial class PlantaCEN
{
private IPlantaCAD _IPlantaCAD;

public PlantaCEN()
{
        this._IPlantaCAD = new PlantaCAD ();
}

public PlantaCEN(IPlantaCAD _IPlantaCAD)
{
        this._IPlantaCAD = _IPlantaCAD;
}

public IPlantaCAD get_IPlantaCAD ()
{
        return this._IPlantaCAD;
}

public int Crear (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum p_planta, int p_edificio)
{
        PlantaEN plantaEN = null;
        int oid;

        //Initialized PlantaEN
        plantaEN = new PlantaEN ();
        plantaEN.Planta = p_planta;


        if (p_edificio != -1) {
                // El argumento p_edificio -> Property edificio es oid = false
                // Lista de oids id
                plantaEN.Edificio = new ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN ();
                plantaEN.Edificio.Id = p_edificio;
        }

        //Call to PlantaCAD

        oid = _IPlantaCAD.Crear (plantaEN);
        return oid;
}

public void Modificar (int p_Planta_OID, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum p_planta)
{
        PlantaEN plantaEN = null;

        //Initialized PlantaEN
        plantaEN = new PlantaEN ();
        plantaEN.Id = p_Planta_OID;
        plantaEN.Planta = p_planta;
        //Call to PlantaCAD

        _IPlantaCAD.Modificar (plantaEN);
}

public void Borrar (int id
                    )
{
        _IPlantaCAD.Borrar (id);
}

public PlantaEN BuscarPorId (int id
                             )
{
        PlantaEN plantaEN = null;

        plantaEN = _IPlantaCAD.BuscarPorId (id);
        return plantaEN;
}

public System.Collections.Generic.IList<PlantaEN> BuscarTodos (int first, int size)
{
        System.Collections.Generic.IList<PlantaEN> list = null;

        list = _IPlantaCAD.BuscarTodos (first, size);
        return list;
}
}
}
