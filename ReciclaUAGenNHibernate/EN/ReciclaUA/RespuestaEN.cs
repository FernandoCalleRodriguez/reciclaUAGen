
using System;
// Definición clase RespuestaEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class RespuestaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo duda
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN duda;



/**
 *	Atributo usuario
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo esCorrecta
 */
private bool esCorrecta;



/**
 *	Atributo util
 */
private int util;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN Duda {
        get { return duda; } set { duda = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual bool EsCorrecta {
        get { return esCorrecta; } set { esCorrecta = value;  }
}



public virtual int Util {
        get { return util; } set { util = value;  }
}





public RespuestaEN()
{
}



public RespuestaEN(int id, string cuerpo, ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN duda, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, Nullable<DateTime> fecha, bool esCorrecta, int util
                   )
{
        this.init (Id, cuerpo, duda, usuario, fecha, esCorrecta, util);
}


public RespuestaEN(RespuestaEN respuesta)
{
        this.init (Id, respuesta.Cuerpo, respuesta.Duda, respuesta.Usuario, respuesta.Fecha, respuesta.EsCorrecta, respuesta.Util);
}

private void init (int id
                   , string cuerpo, ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN duda, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, Nullable<DateTime> fecha, bool esCorrecta, int util)
{
        this.Id = id;


        this.Cuerpo = cuerpo;

        this.Duda = duda;

        this.Usuario = usuario;

        this.Fecha = fecha;

        this.EsCorrecta = esCorrecta;

        this.Util = util;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RespuestaEN t = obj as RespuestaEN;
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
