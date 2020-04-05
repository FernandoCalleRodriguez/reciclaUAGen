
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_desautenticar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioCEN
{
public void Desautenticar (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_desautenticar) ENABLED START*/

        UsuarioAdministradorCEN usu = new UsuarioAdministradorCEN ();
        UsuarioAdministradorEN usuAdm = usu.BuscarPorId (p_oid);

        if (usuAdm.Estado) {
                usu.Modificar (usuAdm.Id, usuAdm.Nombre, usuAdm.Apellidos, usuAdm.Email, usuAdm.Pass, usuAdm.Fecha, false, false);
                System.Console.WriteLine ("El usuario se ha desautenticado correctamente");
        }
        else{
                System.Console.WriteLine ("Este usuario ya esta desautenticado");
        }
        /*PROTECTED REGION END*/
}
}
}
