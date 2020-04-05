
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_borrar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public void Borrar (int id
                    )
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_borrar_customized) ENABLED START*/


        UsuarioWebEN usuarioWebEN = null;

        //Initialized UsuarioAdministradorEN
        usuarioWebEN = _IUsuarioWebCAD.BuscarPorId (id);
        usuarioWebEN.Id = id;
        usuarioWebEN.Nombre = "";
        usuarioWebEN.Apellidos = "";
        usuarioWebEN.Email = "";
        usuarioWebEN.Borrado = true;
        usuarioWebEN.Puntuacion = -1;
        //Call to UsuarioAdministradorCAD

        _IUsuarioWebCAD.Modificar (usuarioWebEN);
        /*PROTECTED REGION END*/
}
}
}
