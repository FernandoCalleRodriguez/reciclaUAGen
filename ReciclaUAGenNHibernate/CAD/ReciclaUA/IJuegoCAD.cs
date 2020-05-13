
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IJuegoCAD
{
JuegoEN ReadOIDDefault (int id
                        );

void ModifyDefault (JuegoEN juego);

System.Collections.Generic.IList<JuegoEN> ReadAllDefault (int first, int size);



int Crear (JuegoEN juego);

void Modificar (JuegoEN juego);


void Borrar (int id
             );


JuegoEN BuscarPorId (int id
                     );


System.Collections.Generic.IList<JuegoEN> BuscarTodos (int first, int size);
}
}
