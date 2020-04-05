
using System;
// Definición clase EdificioEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class EdificioEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estancias
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> estancias;



/**
 *	Atributo plantas
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN> plantas;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> Estancias {
        get { return estancias; } set { estancias = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN> Plantas {
        get { return plantas; } set { plantas = value;  }
}





public EdificioEN()
{
        estancias = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN>();
        plantas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN>();
}



public EdificioEN(int id, string nombre, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> estancias, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN> plantas
                  )
{
        this.init (Id, nombre, estancias, plantas);
}


public EdificioEN(EdificioEN edificio)
{
        this.init (Id, edificio.Nombre, edificio.Estancias, edificio.Plantas);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN> estancias, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN> plantas)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Estancias = estancias;

        this.Plantas = plantas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EdificioEN t = obj as EdificioEN;
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
