
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
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioAdministradorCEN
{
public void CambiarPassword (int p_oid, String p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_cambiarPassword) ENABLED START*/

        UsuarioAdministradorEN usuarioAdminEN = null;

        //Initialized UsuarioWebEN
        usuarioAdminEN = new UsuarioAdministradorEN ();
        usuarioAdminEN.Id = p_oid;
        usuarioAdminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to UsuarioWebCAD


        /*PROTECTED REGION END*/
}
}
}
