
using System;
// Definición clase TipoAccionEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class TipoAccionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo acciones
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> acciones;



/**
 *	Atributo nombre
 */
private string nombre;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> Acciones {
        get { return acciones; } set { acciones = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}





public TipoAccionEN()
{
        acciones = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN>();
}



public TipoAccionEN(int id, int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> acciones, string nombre
                    )
{
        this.init (Id, puntuacion, acciones, nombre);
}


public TipoAccionEN(TipoAccionEN tipoAccion)
{
        this.init (Id, tipoAccion.Puntuacion, tipoAccion.Acciones, tipoAccion.Nombre);
}

private void init (int id
                   , int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> acciones, string nombre)
{
        this.Id = id;


        this.Puntuacion = puntuacion;

        this.Acciones = acciones;

        this.Nombre = nombre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TipoAccionEN t = obj as TipoAccionEN;
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
