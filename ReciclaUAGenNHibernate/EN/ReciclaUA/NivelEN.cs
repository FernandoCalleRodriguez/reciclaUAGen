
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





public NivelEN()
{
        item = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
}



public NivelEN(int id, int numero, int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> item
               )
{
        this.init (Id, numero, puntuacion, item);
}


public NivelEN(NivelEN nivel)
{
        this.init (Id, nivel.Numero, nivel.Puntuacion, nivel.Item);
}

private void init (int id
                   , int numero, int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> item)
{
        this.Id = id;


        this.Numero = numero;

        this.Puntuacion = puntuacion;

        this.Item = item;
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
