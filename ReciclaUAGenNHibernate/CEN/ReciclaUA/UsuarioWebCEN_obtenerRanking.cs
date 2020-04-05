
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_obtenerRanking) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioWebCEN
{
public long ObtenerRanking (int p_id)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_obtenerRanking) ENABLED START*/
        long pos = 0;
        UsuarioWebCEN usu = new UsuarioWebCEN ();

        IList<UsuarioWebEN> listaUsu = usu.ObtenerPuntuaciones ();

        int i = 1;
        foreach (UsuarioWebEN usuD in listaUsu) {
                if (usuD.Id == p_id) {
                        pos = i;
                        break;
                }
                i++;
        }

        return pos;

        /*PROTECTED REGION END*/
}
}
}
