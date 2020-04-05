
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IPlantaCAD
{
PlantaEN ReadOIDDefault (int id
                         );

void ModifyDefault (PlantaEN planta);

System.Collections.Generic.IList<PlantaEN> ReadAllDefault (int first, int size);



int Crear (PlantaEN planta);

void Modificar (PlantaEN planta);


void Borrar (int id
             );


PlantaEN BuscarPorId (int id
                      );


System.Collections.Generic.IList<PlantaEN> BuscarTodos (int first, int size);
}
}
