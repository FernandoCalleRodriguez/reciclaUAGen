
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IUsuarioWebCAD
{
UsuarioWebEN ReadOIDDefault (int id
                             );

void ModifyDefault (UsuarioWebEN usuarioWeb);

System.Collections.Generic.IList<UsuarioWebEN> ReadAllDefault (int first, int size);



int Crear (UsuarioWebEN usuarioWeb);

void Modificar (UsuarioWebEN usuarioWeb);


void Borrar (int id
             );


UsuarioWebEN BuscarPorId (int id
                          );


System.Collections.Generic.IList<UsuarioWebEN> BuscarTodos (int first, int size);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> ObtenerRanking ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> ObtenerPuntuaciones ();


void CambiarPassword (UsuarioWebEN usuarioWeb);



System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> BuscarPorCorreo (string p_email);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN> BuscarNoBorrados ();


int BuscarTodosCount ();
}
}
