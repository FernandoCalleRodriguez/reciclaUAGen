
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioAdministradorCEN
{
public int Crear (string p_nombre, string p_apellidos, string p_email, String p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_crear_customized) ENABLED START*/

        UsuarioAdministradorEN usuarioAdministradorEN = null;
        UsuarioCEN usuarioCEN = new UsuarioCEN ();

        int oid;

        //Initialized UsuarioAdministradorEN
        usuarioAdministradorEN = new UsuarioAdministradorEN ();
        usuarioAdministradorEN.Nombre = p_nombre;

        usuarioAdministradorEN.Apellidos = p_apellidos;

        usuarioAdministradorEN.Email = p_email;

        usuarioAdministradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioAdministradorEN.Borrado = false;

        usuarioAdministradorEN.EmailVerificado = false;

        usuarioAdministradorEN.Fecha = DateTime.Now;

        //Call to UsuarioAdministradorCAD
        UsuarioEN usu = usuarioCEN.BuscarPorCorreo (p_email);
        //Call to UsuarioWebCAD
        if (usu == null) {
                oid = _IUsuarioAdministradorCAD.Crear (usuarioAdministradorEN);
        }
        else{
                oid = -1;
        }
        return oid;
        /*PROTECTED REGION END*/
}
}
}
