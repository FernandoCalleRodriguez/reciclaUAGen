
using System;
// Definición clase AccionWebEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class AccionWebEN                                                                    : ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN


{
/**
 *	Atributo tipo
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN tipo;






public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN Tipo {
        get { return tipo; } set { tipo = value;  }
}





public AccionWebEN() : base ()
{
}



public AccionWebEN(int id, ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN tipo
                   , ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN usuario, Nullable<DateTime> fecha
                   )
{
        this.init (Id, tipo, usuario, fecha);
}


public AccionWebEN(AccionWebEN accionWeb)
{
        this.init (Id, accionWeb.Tipo, accionWeb.Usuario, accionWeb.Fecha);
}

private void init (int id
                   , ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN tipo, ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN usuario, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Tipo = tipo;

        this.Usuario = usuario;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AccionWebEN t = obj as AccionWebEN;
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
