
using System;
// Definición clase AccionEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class AccionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN usuario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public AccionEN()
{
}



public AccionEN(int id, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN usuario, Nullable<DateTime> fecha
                )
{
        this.init (Id, usuario, fecha);
}


public AccionEN(AccionEN accion)
{
        this.init (Id, accion.Usuario, accion.Fecha);
}

private void init (int id
                   , ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN usuario, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AccionEN t = obj as AccionEN;
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
