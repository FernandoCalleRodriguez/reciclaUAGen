
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface INotaInformativaCAD
{
NotaInformativaEN ReadOIDDefault (int id
                                  );

void ModifyDefault (NotaInformativaEN notaInformativa);

System.Collections.Generic.IList<NotaInformativaEN> ReadAllDefault (int first, int size);



int Crear (NotaInformativaEN notaInformativa);

void Modificar (NotaInformativaEN notaInformativa);


void Borrar (int id
             );


NotaInformativaEN BuscarPorId (int id
                               );


System.Collections.Generic.IList<NotaInformativaEN> BuscarTodos (int first, int size);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN> BuscarPorTitulo ();
}
}
