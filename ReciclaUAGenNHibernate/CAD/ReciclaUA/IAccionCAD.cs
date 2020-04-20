
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IAccionCAD
{
AccionEN ReadOIDDefault (int id
                         );

void ModifyDefault (AccionEN accion);

System.Collections.Generic.IList<AccionEN> ReadAllDefault (int first, int size);



int Crear (AccionEN accion);

AccionEN BuscarPorId (int id
                      );


System.Collections.Generic.IList<AccionEN> BuscarTodos (int first, int size);
}
}
