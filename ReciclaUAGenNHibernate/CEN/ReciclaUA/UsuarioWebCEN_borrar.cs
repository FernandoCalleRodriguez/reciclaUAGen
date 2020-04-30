
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
public void Borrar (int p_UsuarioWeb_OID)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_borrar_customized) ENABLED START*/


        UsuarioWebEN usuarioWebEN = null;

        usuarioWebEN = _IUsuarioWebCAD.BuscarPorId (p_UsuarioWeb_OID);

        if (usuarioWebEN != null) { //Initialized UsuarioAdministradorEN
                usuarioWebEN = _IUsuarioWebCAD.BuscarPorId (p_UsuarioWeb_OID);
                usuarioWebEN.Id = p_UsuarioWeb_OID;
                usuarioWebEN.Nombre = "";
                usuarioWebEN.Apellidos = "";
                usuarioWebEN.Email = "";
                usuarioWebEN.Borrado = true;
                usuarioWebEN.Puntuacion = -1;
                //Call to UsuarioAdministradorCAD

                _IUsuarioWebCAD.Modificar (usuarioWebEN);
        }
        /*PROTECTED REGION END*/
}
}
}
