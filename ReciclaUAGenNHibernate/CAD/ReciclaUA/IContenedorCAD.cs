
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IContenedorCAD
{
ContenedorEN ReadOIDDefault (int id
                             );

void ModifyDefault (ContenedorEN contenedor);

System.Collections.Generic.IList<ContenedorEN> ReadAllDefault (int first, int size);



int Crear (ContenedorEN contenedor);

void Modificar (ContenedorEN contenedor);


void Borrar (int id
             );


ContenedorEN BuscarPorId (int id
                          );


System.Collections.Generic.IList<ContenedorEN> BuscarTodos (int first, int size);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN> BuscarContenedoresPorTipo ();
}
}
