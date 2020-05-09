
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_verificarEmail) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public void VerificarEmail (int p_UsuarioWeb_OID)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_verificarEmail) ENABLED START*/

        UsuarioWebEN resp = _IUsuarioWebCAD.BuscarPorId (p_UsuarioWeb_OID);

        resp.EmailVerificado = true;


        _IUsuarioWebCAD.Modificar (resp);

        /*PROTECTED REGION END*/
}
}
}
