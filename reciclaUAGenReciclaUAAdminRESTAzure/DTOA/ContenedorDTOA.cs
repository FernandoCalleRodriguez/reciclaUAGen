using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class ContenedorDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum tipo;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum Tipo
{
        get { return tipo; }
        set { tipo = value; }
}
}
}
