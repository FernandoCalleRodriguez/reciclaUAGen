
using System;
// Definición clase JuegoEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class JuegoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo itemActual
 */
private int itemActual;



/**
 *	Atributo aciertos
 */
private int aciertos;



/**
 *	Atributo fallos
 */
private int fallos;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo usuarios
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN> usuarios;



/**
 *	Atributo nivelActual
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN nivelActual;



/**
 *	Atributo intentosItemActual
 */
private int intentosItemActual;



/**
 *	Atributo finalizado
 */
private bool finalizado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int ItemActual {
        get { return itemActual; } set { itemActual = value;  }
}



public virtual int Aciertos {
        get { return aciertos; } set { aciertos = value;  }
}



public virtual int Fallos {
        get { return fallos; } set { fallos = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN> Usuarios {
        get { return usuarios; } set { usuarios = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN NivelActual {
        get { return nivelActual; } set { nivelActual = value;  }
}



public virtual int IntentosItemActual {
        get { return intentosItemActual; } set { intentosItemActual = value;  }
}



public virtual bool Finalizado {
        get { return finalizado; } set { finalizado = value;  }
}





public JuegoEN()
{
        usuarios = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN>();
}



public JuegoEN(int id, int itemActual, int aciertos, int fallos, int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN> usuarios, ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN nivelActual, int intentosItemActual, bool finalizado
               )
{
        this.init (Id, itemActual, aciertos, fallos, puntuacion, usuarios, nivelActual, intentosItemActual, finalizado);
}


public JuegoEN(JuegoEN juego)
{
        this.init (Id, juego.ItemActual, juego.Aciertos, juego.Fallos, juego.Puntuacion, juego.Usuarios, juego.NivelActual, juego.IntentosItemActual, juego.Finalizado);
}

private void init (int id
                   , int itemActual, int aciertos, int fallos, int puntuacion, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN> usuarios, ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN nivelActual, int intentosItemActual, bool finalizado)
{
        this.Id = id;


        this.ItemActual = itemActual;

        this.Aciertos = aciertos;

        this.Fallos = fallos;

        this.Puntuacion = puntuacion;

        this.Usuarios = usuarios;

        this.NivelActual = nivelActual;

        this.IntentosItemActual = intentosItemActual;

        this.Finalizado = finalizado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        JuegoEN t = obj as JuegoEN;
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
