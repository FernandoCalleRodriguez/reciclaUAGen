
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_cambiarPassword) ENABLED START*/
//  references to other libraries
using System.Net.Mail;
using System.Net;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public void CambiarPassword (int p_UsuarioWeb_OID, String p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_cambiarPassword_customized) ENABLED START*/

        UsuarioWebEN usuarioWebEN = null;

        usuarioWebEN = _IUsuarioWebCAD.BuscarPorId (p_UsuarioWeb_OID);

        //Initialized UsuarioWebEN
        if (usuarioWebEN != null) {
                usuarioWebEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
                //Call to UsuarioWebCAD

                _IUsuarioWebCAD.CambiarPassword (usuarioWebEN);
        }



        /*PROTECTED REGION END*/
}
}
}
