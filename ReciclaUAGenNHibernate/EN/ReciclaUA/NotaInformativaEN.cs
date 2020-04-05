
using System;
// Definición clase NotaInformativaEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class NotaInformativaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuarioAdministrador
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN usuarioAdministrador;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN UsuarioAdministrador {
        get { return usuarioAdministrador; } set { usuarioAdministrador = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public NotaInformativaEN()
{
}



public NotaInformativaEN(int id, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN usuarioAdministrador, string titulo, string cuerpo, Nullable<DateTime> fecha
                         )
{
        this.init (Id, usuarioAdministrador, titulo, cuerpo, fecha);
}


public NotaInformativaEN(NotaInformativaEN notaInformativa)
{
        this.init (Id, notaInformativa.UsuarioAdministrador, notaInformativa.Titulo, notaInformativa.Cuerpo, notaInformativa.Fecha);
}

private void init (int id
                   , ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN usuarioAdministrador, string titulo, string cuerpo, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.UsuarioAdministrador = usuarioAdministrador;

        this.Titulo = titulo;

        this.Cuerpo = cuerpo;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotaInformativaEN t = obj as NotaInformativaEN;
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
