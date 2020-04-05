
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ReciclaUAGenNHibernate.Exceptions;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_borrar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioAdministradorCEN
{
public void Borrar (int id
                    )
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_borrar_customized) ENABLED START*/

        UsuarioAdministradorEN usuarioAdministradorEN = null;

        //Initialized UsuarioAdministradorEN
        usuarioAdministradorEN = _IUsuarioAdministradorCAD.BuscarPorId (id);

        usuarioAdministradorEN.Id = id;
        usuarioAdministradorEN.Nombre = "";
        usuarioAdministradorEN.Apellidos = "";
        usuarioAdministradorEN.Email = "";
        usuarioAdministradorEN.Borrado = true;

        //Call to UsuarioAdministradorCAD

        _IUsuarioAdministradorCAD.Modificar (usuarioAdministradorEN);


        /*PROTECTED REGION END*/
}
}
}
