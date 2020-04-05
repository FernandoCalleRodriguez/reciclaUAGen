
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioCEN
{
public int Crear (string p_nombre, string p_apellidos, string p_email, String p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_crear_customized) ENABLED START*/

        UsuarioEN usuarioEN = null;

        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Email = p_email;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);


        usuarioEN.Borrado = false;

        usuarioEN.EmailVerificado = false;

        usuarioEN.Fecha = DateTime.Now;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Crear (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
