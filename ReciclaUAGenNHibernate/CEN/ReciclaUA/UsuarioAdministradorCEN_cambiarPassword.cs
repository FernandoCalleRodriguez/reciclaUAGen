
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_cambiarPassword) ENABLED START*/
using System.Net;
using System.Net.Mail;
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioAdministradorCEN
{
public void CambiarPassword (int p_UsuarioAdministrador_OID, String p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_cambiarPassword_customized) ENABLED START*/

        UsuarioAdministradorEN usuarioAdministradorEN = null;

        //Initialized UsuarioAdministradorEN
        usuarioAdministradorEN = new UsuarioAdministradorEN ();
        usuarioAdministradorEN.Id = p_UsuarioAdministrador_OID;
        usuarioAdministradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to UsuarioAdministradorCAD

        _IUsuarioAdministradorCAD.CambiarPassword (usuarioAdministradorEN);

        /*PROTECTED REGION END*/
}
}
}
