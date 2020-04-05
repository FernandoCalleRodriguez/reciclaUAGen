
using System;
// Definición clase PuntoReciclajeEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class PuntoReciclajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo latitud
 */
private double latitud;



/**
 *	Atributo longitud
 */
private double longitud;



/**
 *	Atributo esValido
 */
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;



/**
 *	Atributo usuario
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario;



/**
 *	Atributo contenedores
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> contenedores;



/**
 *	Atributo estancia
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN estancia;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Latitud {
        get { return latitud; } set { latitud = value;  }
}



public virtual double Longitud {
        get { return longitud; } set { longitud = value;  }
}



public virtual ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido {
        get { return esValido; } set { esValido = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> Contenedores {
        get { return contenedores; } set { contenedores = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN Estancia {
        get { return estancia; } set { estancia = value;  }
}





public PuntoReciclajeEN()
{
        contenedores = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN>();
}



public PuntoReciclajeEN(int id, double latitud, double longitud, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> contenedores, ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN estancia
                        )
{
        this.init (Id, latitud, longitud, esValido, usuario, contenedores, estancia);
}


public PuntoReciclajeEN(PuntoReciclajeEN puntoReciclaje)
{
        this.init (Id, puntoReciclaje.Latitud, puntoReciclaje.Longitud, puntoReciclaje.EsValido, puntoReciclaje.Usuario, puntoReciclaje.Contenedores, puntoReciclaje.Estancia);
}

private void init (int id
                   , double latitud, double longitud, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> contenedores, ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN estancia)
{
        this.Id = id;


        this.Latitud = latitud;

        this.Longitud = longitud;

        this.EsValido = esValido;

        this.Usuario = usuario;

        this.Contenedores = contenedores;

        this.Estancia = estancia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PuntoReciclajeEN t = obj as PuntoReciclajeEN;
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
