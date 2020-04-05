
using System;
// Definición clase ContenedorEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class ContenedorEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipo
 */
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum tipo;



/**
 *	Atributo punto
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN punto;



/**
 *	Atributo acciones
 */
private System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> acciones;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN Punto {
        get { return punto; } set { punto = value;  }
}



public virtual System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> Acciones {
        get { return acciones; } set { acciones = value;  }
}





public ContenedorEN()
{
        acciones = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
}



public ContenedorEN(int id, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum tipo, ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN punto, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> acciones
                    )
{
        this.init (Id, tipo, punto, acciones);
}


public ContenedorEN(ContenedorEN contenedor)
{
        this.init (Id, contenedor.Tipo, contenedor.Punto, contenedor.Acciones);
}

private void init (int id
                   , ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum tipo, ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN punto, System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> acciones)
{
        this.Id = id;


        this.Tipo = tipo;

        this.Punto = punto;

        this.Acciones = acciones;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ContenedorEN t = obj as ContenedorEN;
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
