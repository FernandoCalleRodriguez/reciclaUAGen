
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_incrementarPuntuacion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public void IncrementarPuntuacion (int p_oid, int p_puntuacion)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_incrementarPuntuacion) ENABLED START*/

        UsuarioWebEN resp = _IUsuarioWebCAD.BuscarPorId (p_oid);

        resp.Puntuacion += p_puntuacion;

        _IUsuarioWebCAD.Modificar (resp);

        /*PROTECTED REGION END*/
}
}
}
