
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IEdificioCAD
{
EdificioEN ReadOIDDefault (int id
                           );

void ModifyDefault (EdificioEN edificio);

System.Collections.Generic.IList<EdificioEN> ReadAllDefault (int first, int size);



int Crear (EdificioEN edificio);

void Modificar (EdificioEN edificio);


void Borrar (int id
             );


EdificioEN BuscarPorId (int id
                        );


System.Collections.Generic.IList<EdificioEN> BuscarTodos (int first, int size);


ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN BuscarEdificioPorPlanta (int planta_id);
}
}
