
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IUsuarioAdministradorCAD
{
UsuarioAdministradorEN ReadOIDDefault (int id
                                       );

void ModifyDefault (UsuarioAdministradorEN usuarioAdministrador);

System.Collections.Generic.IList<UsuarioAdministradorEN> ReadAllDefault (int first, int size);



void Modificar (UsuarioAdministradorEN usuarioAdministrador);


void Borrar (int id
             );


UsuarioAdministradorEN BuscarPorId (int id
                                    );


System.Collections.Generic.IList<UsuarioAdministradorEN> BuscarTodos (int first, int size);


int Crear (UsuarioAdministradorEN usuarioAdministrador);

void CambiarPassword (UsuarioAdministradorEN usuarioAdministrador);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN> BuscarPorCorreo (string p_correo);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN> BuscarNoBorrados ();
}
}
