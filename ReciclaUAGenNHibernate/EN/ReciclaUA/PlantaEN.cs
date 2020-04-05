
using System;
// Definición clase PlantaEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class PlantaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo planta
 */
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta;



/**
 *	Atributo estancias
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> estancias;



/**
 *	Atributo edificio
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum Planta {
        get { return planta; } set { planta = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> Estancias {
        get { return estancias; } set { estancias = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN Edificio {
        get { return edificio; } set { edificio = value;  }
}





public PlantaEN()
{
        estancias = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN>();
}



public PlantaEN(int id, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> estancias, ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio
                )
{
        this.init (Id, planta, estancias, edificio);
}


public PlantaEN(PlantaEN planta)
{
        this.init (Id, planta.Planta, planta.Estancias, planta.Edificio);
}

private void init (int id
                   , ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> estancias, ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio)
{
        this.Id = id;


        this.Planta = planta;

        this.Estancias = estancias;

        this.Edificio = edificio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PlantaEN t = obj as PlantaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
