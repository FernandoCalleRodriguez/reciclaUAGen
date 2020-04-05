using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class NotaInformativaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string titulo;
public string Titulo
{
        get { return titulo; }
        set { titulo = value; }
}

private string cuerpo;
public string Cuerpo
{
        get { return cuerpo; }
        set { cuerpo = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}
}
}
