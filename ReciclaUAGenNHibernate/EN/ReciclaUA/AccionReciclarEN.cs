
using System;
// Definición clase AccionReciclarEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class AccionReciclarEN                                                                       : ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN


{
/**
 *	Atributo contenedor
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN contenedor;



/**
 *	Atributo item
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN item;



/**
 *	Atributo cantidad
 */
private int cantidad;






public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN Contenedor {
        get { return contenedor; } set { contenedor = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN Item {
        get { return item; } set { item = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}





public AccionReciclarEN() : base ()
{
}



public AccionReciclarEN(int id, ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN contenedor, ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN item, int cantidad
                        , ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN usuario, Nullable<DateTime> fecha
                        )
{
        this.init (Id, contenedor, item, cantidad, usuario, fecha);
}


public AccionReciclarEN(AccionReciclarEN accionReciclar)
{
        this.init (Id, accionReciclar.Contenedor, accionReciclar.Item, accionReciclar.Cantidad, accionReciclar.Usuario, accionReciclar.Fecha);
}

private void init (int id
                   , ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN contenedor, ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN item, int cantidad, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN usuario, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Contenedor = contenedor;

        this.Item = item;

        this.Cantidad = cantidad;

        this.Usuario = usuario;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AccionReciclarEN t = obj as AccionReciclarEN;
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
