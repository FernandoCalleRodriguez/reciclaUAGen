
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_buscarPor) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public void BuscarPor (int p_UsuarioWeb_OID, string p_nombre, string p_apellidos, string p_email, String p_pass, Nullable<DateTime> p_fecha, bool p_emailVerificado, bool p_borrado, int p_puntuacion)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_buscarPor_customized) START*/

        UsuarioWebEN usuarioWebEN = null;

        //Initialized UsuarioWebEN
        usuarioWebEN = new UsuarioWebEN ();
        usuarioWebEN.Id = p_UsuarioWeb_OID;
        usuarioWebEN.Nombre = p_nombre;
        usuarioWebEN.Apellidos = p_apellidos;
        usuarioWebEN.Email = p_email;
        usuarioWebEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioWebEN.Fecha = p_fecha;
        usuarioWebEN.EmailVerificado = p_emailVerificado;
        usuarioWebEN.Borrado = p_borrado;
        usuarioWebEN.Puntuacion = p_puntuacion;
        //Call to UsuarioWebCAD

        _IUsuarioWebCAD.BuscarPor (usuarioWebEN);

        /*PROTECTED REGION END*/
}
}
}
