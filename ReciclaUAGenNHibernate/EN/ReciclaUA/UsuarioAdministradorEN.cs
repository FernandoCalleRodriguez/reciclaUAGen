
using System;
// Definición clase UsuarioAdministradorEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class UsuarioAdministradorEN                                                                 : ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN


{
/**
 *	Atributo notas
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> notas;






public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> Notas {
        get { return notas; } set { notas = value;  }
}





public UsuarioAdministradorEN() : base ()
{
        notas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN>();
}



public UsuarioAdministradorEN(int id, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> notas
                              , string nombre, string apellidos, string email, String pass, Nullable<DateTime> fecha, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> dudas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos, bool emailVerificado, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> materiales, bool borrado, ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN juego
                              )
{
        this.init (Id, notas, nombre, apellidos, email, pass, fecha, items, dudas, respuestas, puntos, emailVerificado, materiales, borrado, juego);
}


public UsuarioAdministradorEN(UsuarioAdministradorEN usuarioAdministrador)
{
        this.init (Id, usuarioAdministrador.Notas, usuarioAdministrador.Nombre, usuarioAdministrador.Apellidos, usuarioAdministrador.Email, usuarioAdministrador.Pass, usuarioAdministrador.Fecha, usuarioAdministrador.Items, usuarioAdministrador.Dudas, usuarioAdministrador.Respuestas, usuarioAdministrador.Puntos, usuarioAdministrador.EmailVerificado, usuarioAdministrador.Materiales, usuarioAdministrador.Borrado, usuarioAdministrador.Juego);
}

private void init (int id
                   , System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> notas, string nombre, string apellidos, string email, String pass, Nullable<DateTime> fecha, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> dudas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> puntos, bool emailVerificado, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> materiales, bool borrado, ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN juego)
{
        this.Id = id;


        this.Notas = notas;

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

        this.Juego = juego;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioAdministradorEN t = obj as UsuarioAdministradorEN;
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
