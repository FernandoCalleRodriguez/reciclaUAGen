
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioAdministradorCEN
{
public void Modificar (int p_UsuarioAdministrador_OID, string p_nombre, string p_apellidos, string p_email)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_modificar_customized) ENABLED START*/

        UsuarioAdministradorEN usuarioAdministradorEN = null;

        if (_IUsuarioAdministradorCAD.BuscarPorId (p_UsuarioAdministrador_OID) != null) {
                //Initialized UsuarioAdministradorEN
                usuarioAdministradorEN = new UsuarioAdministradorEN ();
                usuarioAdministradorEN.Id = p_UsuarioAdministrador_OID;
                usuarioAdministradorEN.Nombre = p_nombre;
                usuarioAdministradorEN.Apellidos = p_apellidos;
                usuarioAdministradorEN.Email = p_email;
                //Call to UsuarioAdministradorCAD

                _IUsuarioAdministradorCAD.Modificar (usuarioAdministradorEN);
        }

        /*PROTECTED REGION END*/
}
}
}
