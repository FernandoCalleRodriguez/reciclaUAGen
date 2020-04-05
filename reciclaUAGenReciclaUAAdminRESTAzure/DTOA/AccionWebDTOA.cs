using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class AccionWebDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}


/* Rol: AccionWeb o--> TipoAccion */
private TipoAccionDTOA tipo;
public TipoAccionDTOA Tipo
{
        get { return tipo; }
        set { tipo = value; }
}
}
}
