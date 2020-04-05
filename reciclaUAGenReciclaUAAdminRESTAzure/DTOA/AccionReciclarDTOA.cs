using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class AccionReciclarDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private int cantidad;
public int Cantidad
{
        get { return cantidad; }
        set { cantidad = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}


/* Rol: AccionReciclar o--> Item */
private ItemDTOA itemAccion;
public ItemDTOA ItemAccion
{
        get { return itemAccion; }
        set { itemAccion = value; }
}

/* Rol: AccionReciclar o--> Contenedor */
private ContenedorDTOA contenedorAccion;
public ContenedorDTOA ContenedorAccion
{
        get { return contenedorAccion; }
        set { contenedorAccion = value; }
}
}
}
