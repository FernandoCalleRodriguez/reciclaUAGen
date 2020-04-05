
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface INivelCAD
{
NivelEN ReadOIDDefault (int id
                        );

void ModifyDefault (NivelEN nivel);

System.Collections.Generic.IList<NivelEN> ReadAllDefault (int first, int size);



int Crear (NivelEN nivel);

void Modificar (NivelEN nivel);


void Borrar (int id
             );


NivelEN BuscarPorId (int id
                     );


System.Collections.Generic.IList<NivelEN> BuscarTodos (int first, int size);
}
}
