
using System;
// Definición clase NivelEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class NivelEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo numero
 */
private int numero;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo item
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> item;



/**
 *	Atributo juego
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN> juego;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> Item {
        get { return item; } set { item = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN> Juego {
        get { return juego; } set { juego = value;  }
}





public NivelEN()
{
        item = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
        juego = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN>();
}



public NivelEN(int id, int numero, int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> item, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN> juego
               )
{
        this.init (Id, numero, puntuacion, item, juego);
}


public NivelEN(NivelEN nivel)
{
        this.init (Id, nivel.Numero, nivel.Puntuacion, nivel.Item, nivel.Juego);
}

private void init (int id
                   , int numero, int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> item, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN> juego)
{
        this.Id = id;


        this.Numero = numero;

        this.Puntuacion = puntuacion;

        this.Item = item;

        this.Juego = juego;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NivelEN t = obj as NivelEN;
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
