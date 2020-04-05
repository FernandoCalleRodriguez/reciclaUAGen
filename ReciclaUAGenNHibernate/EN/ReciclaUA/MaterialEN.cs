
using System;
// Definición clase MaterialEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class MaterialEN
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
 *	Atributo contenedor
 */
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum contenedor;



/**
 *	Atributo items
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items;



/**
 *	Atributo esValido
 */
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;



/**
 *	Atributo usuario
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum Contenedor {
        get { return contenedor; } set { contenedor = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> Items {
        get { return items; } set { items = value;  }
}



public virtual ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido {
        get { return esValido; } set { esValido = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public MaterialEN()
{
        items = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
}



public MaterialEN(int id, string nombre, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum contenedor, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario
                  )
{
        this.init (Id, nombre, contenedor, items, esValido, usuario);
}


public MaterialEN(MaterialEN material)
{
        this.init (Id, material.Nombre, material.Contenedor, material.Items, material.EsValido, material.Usuario);
}

private void init (int id
                   , string nombre, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum contenedor, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> items, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Contenedor = contenedor;

        this.Items = items;

        this.EsValido = esValido;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MaterialEN t = obj as MaterialEN;
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
