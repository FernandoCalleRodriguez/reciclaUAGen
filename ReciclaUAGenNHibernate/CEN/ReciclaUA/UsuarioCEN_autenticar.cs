
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_autenticar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioCEN
{
public void Autenticar (string p_correo, string p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_autenticar) ENABLED START*/

        // Write here your custom code...
        UsuarioCEN usu = new UsuarioCEN ();
        UsuarioEN usuRes = usu.BuscarPorCorreo (p_correo);

        if (usuRes != null) {
                p_pass = usuRes.Pass;
                if (usuRes.Pass == p_pass) {
                        System.Console.WriteLine ("Login exitoso");
                        UsuarioAdministradorCEN usuAdm = new UsuarioAdministradorCEN ();
                        usuAdm.Modificar (usuRes.Id, usuRes.Nombre, usuRes.Apellidos, usuRes.Email, usuRes.Pass, usuRes.Fecha, true, false);
                }
                else{
                        System.Console.WriteLine ("La contrasena no es correcta");
                }
        }
        else{
                System.Console.WriteLine ("El correo indicado no esta registrado");
        }

        /*PROTECTED REGION END*/
}
}
}
