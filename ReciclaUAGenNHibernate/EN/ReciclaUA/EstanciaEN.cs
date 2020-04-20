
using System;
// Definición clase EstanciaEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class EstanciaEN
{
/**
 *	Atributo id
 */
private string id;



/**
 *	Atributo actividad
 */
private string actividad;



/**
 *	Atributo latitud
 */
private double latitud;



/**
 *	Atributo longitud
 */
private double longitud;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo edificio
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio;



/**
 *	Atributo planta
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN planta;



/**
 *	Atributo puntos
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos;






public virtual string Id {
        get { return id; } set { id = value;  }
}



public virtual string Actividad {
        get { return actividad; } set { actividad = value;  }
}



public virtual double Latitud {
        get { return latitud; } set { latitud = value;  }
}



public virtual double Longitud {
        get { return longitud; } set { longitud = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN Edificio {
        get { return edificio; } set { edificio = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN Planta {
        get { return planta; } set { planta = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> Puntos {
        get { return puntos; } set { puntos = value;  }
}





public EstanciaEN()
{
        puntos = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
}



public EstanciaEN(string id, string actividad, double latitud, double longitud, string nombre, ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio, ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN planta, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos
                  )
{
        this.init (Id, actividad, latitud, longitud, nombre, edificio, planta, puntos);
}


public EstanciaEN(EstanciaEN estancia)
{
        this.init (Id, estancia.Actividad, estancia.Latitud, estancia.Longitud, estancia.Nombre, estancia.Edificio, estancia.Planta, estancia.Puntos);
}

private void init (string id
                   , string actividad, double latitud, double longitud, string nombre, ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio, ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN planta, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos)
{
        this.Id = id;


        this.Actividad = actividad;

        this.Latitud = latitud;

        this.Longitud = longitud;

        this.Nombre = nombre;

        this.Edificio = edificio;

        this.Planta = planta;

        this.Puntos = puntos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EstanciaEN t = obj as EstanciaEN;
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
