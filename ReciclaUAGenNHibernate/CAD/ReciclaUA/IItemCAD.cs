
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IItemCAD
{
ItemEN ReadOIDDefault (int id
                       );

void ModifyDefault (ItemEN item);

System.Collections.Generic.IList<ItemEN> ReadAllDefault (int first, int size);



int Crear (ItemEN item);

void Modificar (ItemEN item);


void Borrar (int id
             );


ItemEN BuscarPorId (int id
                    );


System.Collections.Generic.IList<ItemEN> BuscarTodos (int first, int size);




System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorValidar ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsValidados ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN> BuscarItemsPorUsuario (int id_usuario);
}
}
