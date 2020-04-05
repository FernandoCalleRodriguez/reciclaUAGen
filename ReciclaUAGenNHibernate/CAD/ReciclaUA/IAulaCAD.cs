
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IAulaCAD
{
AulaEN ReadOIDDefault (int id
                       );

void ModifyDefault (AulaEN aula);

System.Collections.Generic.IList<AulaEN> ReadAllDefault (int first, int size);



int Crear (AulaEN aula);

void Modificar (AulaEN aula);


void Eliminar (int id
               );


AulaEN BuscarPorID (int id
                    );


System.Collections.Generic.IList<AulaEN> BuscarTodos (int first, int size);
}
}
