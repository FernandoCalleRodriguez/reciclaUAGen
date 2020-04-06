
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public void Modificar (int p_UsuarioWeb_OID, string p_nombre, string p_apellidos, string p_email)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_modificar_customized) START*/

        UsuarioWebEN usuarioWebEN = null;

        //Initialized UsuarioWebEN
        usuarioWebEN = new UsuarioWebEN ();
        usuarioWebEN.Id = p_UsuarioWeb_OID;
        usuarioWebEN.Nombre = p_nombre;
        usuarioWebEN.Apellidos = p_apellidos;
        usuarioWebEN.Email = p_email;
        //Call to UsuarioWebCAD

        _IUsuarioWebCAD.Modificar (usuarioWebEN);

        /*PROTECTED REGION END*/
}
}
}
