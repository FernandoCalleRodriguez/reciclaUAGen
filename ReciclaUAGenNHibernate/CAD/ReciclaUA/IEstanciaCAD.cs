
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IEstanciaCAD
{
EstanciaEN ReadOIDDefault (string id
                           );

void ModifyDefault (EstanciaEN estancia);

System.Collections.Generic.IList<EstanciaEN> ReadAllDefault (int first, int size);



void Modificar (EstanciaEN estancia);


void Borrar (string id
             );


EstanciaEN BuscarPorId (string id
                        );


System.Collections.Generic.IList<EstanciaEN> BuscarTodos (int first, int size);


string Crear (EstanciaEN estancia);
}
}
