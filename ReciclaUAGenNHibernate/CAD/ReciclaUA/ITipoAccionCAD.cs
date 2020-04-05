
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface ITipoAccionCAD
{
TipoAccionEN ReadOIDDefault (int id
                             );

void ModifyDefault (TipoAccionEN tipoAccion);

System.Collections.Generic.IList<TipoAccionEN> ReadAllDefault (int first, int size);



int Crear (TipoAccionEN tipoAccion);

void Modificar (TipoAccionEN tipoAccion);


void Borrar (int id
             );


TipoAccionEN BuscarPorId (int id
                          );


System.Collections.Generic.IList<TipoAccionEN> BuscarTodos (int first, int size);
}
}
