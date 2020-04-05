
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IAccionReciclarCAD
{
AccionReciclarEN ReadOIDDefault (int id
                                 );

void ModifyDefault (AccionReciclarEN accionReciclar);

System.Collections.Generic.IList<AccionReciclarEN> ReadAllDefault (int first, int size);



int Crear (AccionReciclarEN accionReciclar);

void Modificar (AccionReciclarEN accionReciclar);


void Borrar (int id
             );


AccionReciclarEN BuscarPorId (int id
                              );


System.Collections.Generic.IList<AccionReciclarEN> BuscarTodos (int first, int size);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorAutor (int ? p_user_id);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorFecha (Nullable<DateTime> p_date);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarPorMaterial (string p_material);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN> BuscarAccionesReciclajePorUsuario (int id_usuario);
}
}
