
using System;
// Definición clase ItemEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class ItemEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo esValido
 */
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido;



/**
 *	Atributo usuario
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario;



/**
 *	Atributo niveles
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN niveles;



/**
 *	Atributo material
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN material;



/**
 *	Atributo accionReciclar
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> accionReciclar;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum EsValido {
        get { return esValido; } set { esValido = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN Niveles {
        get { return niveles; } set { niveles = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN Material {
        get { return material; } set { material = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> AccionReciclar {
        get { return accionReciclar; } set { accionReciclar = value;  }
}





public ItemEN()
{
        accionReciclar = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
}



public ItemEN(int id, string nombre, string descripcion, string imagen, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN niveles, ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN material, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> accionReciclar
              )
{
        this.init (Id, nombre, descripcion, imagen, esValido, usuario, niveles, material, accionReciclar);
}


public ItemEN(ItemEN item)
{
        this.init (Id, item.Nombre, item.Descripcion, item.Imagen, item.EsValido, item.Usuario, item.Niveles, item.Material, item.AccionReciclar);
}

private void init (int id
                   , string nombre, string descripcion, string imagen, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.EstadoEnum esValido, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN usuario, ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN niveles, ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN material, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> accionReciclar)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Imagen = imagen;

        this.EsValido = esValido;

        this.Usuario = usuario;

        this.Niveles = niveles;

        this.Material = material;

        this.AccionReciclar = accionReciclar;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ItemEN t = obj as ItemEN;
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
