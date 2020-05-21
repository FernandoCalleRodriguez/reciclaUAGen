
using System;
// Definición clase UsuarioEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class UsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo items
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items;



/**
 *	Atributo dudas
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> dudas;



/**
 *	Atributo respuestas
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas;



/**
 *	Atributo puntos
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos;



/**
 *	Atributo emailVerificado
 */
private bool emailVerificado;



/**
 *	Atributo materiales
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> materiales;



/**
 *	Atributo borrado
 */
private bool borrado;



/**
 *	Atributo juegos
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN juegos;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> Items {
        get { return items; } set { items = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> Dudas {
        get { return dudas; } set { dudas = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> Respuestas {
        get { return respuestas; } set { respuestas = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> Puntos {
        get { return puntos; } set { puntos = value;  }
}



public virtual bool EmailVerificado {
        get { return emailVerificado; } set { emailVerificado = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> Materiales {
        get { return materiales; } set { materiales = value;  }
}



public virtual bool Borrado {
        get { return borrado; } set { borrado = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN Juegos {
        get { return juegos; } set { juegos = value;  }
}





public UsuarioEN()
{
        items = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
        dudas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN>();
        respuestas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN>();
        puntos = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
        materiales = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN>();
}



public UsuarioEN(int id, string nombre, string apellidos, string email, String pass, Nullable<DateTime> fecha, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> dudas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos, bool emailVerificado, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> materiales, bool borrado, ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN juegos
                 )
{
        this.init (Id, nombre, apellidos, email, pass, fecha, items, dudas, respuestas, puntos, emailVerificado, materiales, borrado, juegos);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Nombre, usuario.Apellidos, usuario.Email, usuario.Pass, usuario.Fecha, usuario.Items, usuario.Dudas, usuario.Respuestas, usuario.Puntos, usuario.EmailVerificado, usuario.Materiales, usuario.Borrado, usuario.Juegos);
}

private void init (int id
                   , string nombre, string apellidos, string email, String pass, Nullable<DateTime> fecha, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> dudas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos, bool emailVerificado, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> materiales, bool borrado, ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN juegos)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Email = email;

        this.Pass = pass;

        this.Fecha = fecha;

        this.Items = items;

        this.Dudas = dudas;

        this.Respuestas = respuestas;

        this.Puntos = puntos;

        this.EmailVerificado = emailVerificado;

        this.Materiales = materiales;

        this.Borrado = borrado;

        this.Juegos = juegos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
