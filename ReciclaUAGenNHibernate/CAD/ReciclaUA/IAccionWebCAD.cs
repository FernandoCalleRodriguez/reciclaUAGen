
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IAccionWebCAD
{
AccionWebEN ReadOIDDefault (int id
                            );

void ModifyDefault (AccionWebEN accionWeb);

System.Collections.Generic.IList<AccionWebEN> ReadAllDefault (int first, int size);



int Crear (AccionWebEN accionWeb);

void Modificar (AccionWebEN accionWeb);


void Borrar (int id
             );


AccionWebEN BuscarPorId (int id
                         );


System.Collections.Generic.IList<AccionWebEN> BuscarTodos (int first, int size);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorAutor (int ? p_user_id);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorFecha (Nullable<DateTime> p_date);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarPorTipo (string p_type);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN> BuscarAccionesWebPorUsuario (int id_usuario);
}
}
