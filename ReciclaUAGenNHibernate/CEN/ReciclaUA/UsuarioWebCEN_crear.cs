
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public int Crear (string p_nombre, string p_apellidos, string p_email, String p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_crear_customized) ENABLED START*/

        UsuarioWebEN usuarioWebEN = null;

        int oid;

        //Initialized UsuarioWebEN
        usuarioWebEN = new UsuarioWebEN ();
        usuarioWebEN.Nombre = p_nombre;

        usuarioWebEN.Apellidos = p_apellidos;

        usuarioWebEN.Email = p_email;

        usuarioWebEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioWebEN.Borrado = false;

        usuarioWebEN.EmailVerificado = false;

        usuarioWebEN.Fecha = DateTime.Now;

        usuarioWebEN.Puntuacion = 0;

        //Call to UsuarioWebCAD

        oid = _IUsuarioWebCAD.Crear (usuarioWebEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
