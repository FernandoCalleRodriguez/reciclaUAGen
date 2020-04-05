
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IDudaCAD
{
DudaEN ReadOIDDefault (int id
                       );

void ModifyDefault (DudaEN duda);

System.Collections.Generic.IList<DudaEN> ReadAllDefault (int first, int size);



int Crear (DudaEN duda);

void Modificar (DudaEN duda);


void Borrar (int id
             );


DudaEN BuscarPorId (int id
                    );


System.Collections.Generic.IList<DudaEN> BuscarTodos (int first, int size);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudaPorTitulo (string p_titulo);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudaPorTemas (string p_tema);






System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN> BuscarDudasPorUsuario (int id_usuario);
}
}
