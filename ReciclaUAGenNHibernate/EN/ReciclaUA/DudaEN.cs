
using System;
// Definición clase DudaEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class DudaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo usuario
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario;



/**
 *	Atributo respuestas
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo util
 */
private int util;



/**
 *	Atributo temas
 */
private string temas;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> Respuestas {
        get { return respuestas; } set { respuestas = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual int Util {
        get { return util; } set { util = value;  }
}



public virtual string Temas {
        get { return temas; } set { temas = value;  }
}





public DudaEN()
{
        respuestas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN>();
}



public DudaEN(int id, string titulo, string cuerpo, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, Nullable<DateTime> fecha, int util, string temas
              )
{
        this.init (Id, titulo, cuerpo, usuario, respuestas, fecha, util, temas);
}


public DudaEN(DudaEN duda)
{
        this.init (Id, duda.Titulo, duda.Cuerpo, duda.Usuario, duda.Respuestas, duda.Fecha, duda.Util, duda.Temas);
}

private void init (int id
                   , string titulo, string cuerpo, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> respuestas, Nullable<DateTime> fecha, int util, string temas)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Cuerpo = cuerpo;

        this.Usuario = usuario;

        this.Respuestas = respuestas;

        this.Fecha = fecha;

        this.Util = util;

        this.Temas = temas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DudaEN t = obj as DudaEN;
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
