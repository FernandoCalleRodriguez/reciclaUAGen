
using System;
// Definición clase UsuarioWebEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class UsuarioWebEN                                                                   : ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN


{
/**
 *	Atributo acciones
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN> acciones;



/**
 *	Atributo puntuacion
 */
private int puntuacion;






public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN> Acciones {
        get { return acciones; } set { acciones = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}





public UsuarioWebEN() : base ()
{
        acciones = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN>();
}



public UsuarioWebEN(int id, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN> acciones, int puntuacion
                    , string nombre, string apellidos, string email, String pass, Nullable<DateTime> fecha, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> dudas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos, bool emailVerificado, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> materiales, bool borrado
                    )
{
        this.init (Id, acciones, puntuacion, nombre, apellidos, email, pass, fecha, items, dudas, respuestas, puntos, emailVerificado, materiales, borrado);
}


public UsuarioWebEN(UsuarioWebEN usuarioWeb)
{
        this.init (Id, usuarioWeb.Acciones, usuarioWeb.Puntuacion, usuarioWeb.Nombre, usuarioWeb.Apellidos, usuarioWeb.Email, usuarioWeb.Pass, usuarioWeb.Fecha, usuarioWeb.Items, usuarioWeb.Dudas, usuarioWeb.Respuestas, usuarioWeb.Puntos, usuarioWeb.EmailVerificado, usuarioWeb.Materiales, usuarioWeb.Borrado);
}

private void init (int id
                   , System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN> acciones, int puntuacion, string nombre, string apellidos, string email, String pass, Nullable<DateTime> fecha, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> dudas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos, bool emailVerificado, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> materiales, bool borrado)
{
        this.Id = id;


        this.Acciones = acciones;

        this.Puntuacion = puntuacion;

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
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioWebEN t = obj as UsuarioWebEN;
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
