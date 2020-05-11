
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_AccionWeb_crear) ENABLED START*/
//  references to other libraries
using ReciclaUAGenNHibernate.CP.ReciclaUA;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class AccionWebCEN
{
public int Crear (int p_usuario, int p_tipo)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_AccionWeb_crear_customized) ENABLED START*/

        AccionWebEN accionWebEN = null;

        int oid;

        //Initialized AccionWebEN
        accionWebEN = new AccionWebEN ();

        if (p_usuario != -1) {
                accionWebEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN ();
                accionWebEN.Usuario.Id = p_usuario;
        }


        if (p_tipo != -1) {
                accionWebEN.Tipo = new ReciclaUAGenNHibernate.EN.ReciclaUA.TipoAccionEN ();
                accionWebEN.Tipo.Id = p_tipo;
        }

        accionWebEN.Fecha = DateTime.Now;

        //Call to AccionWebCAD

        oid = _IAccionWebCAD.Crear (accionWebEN);

        AccionWebCP cp = new AccionWebCP ();
        cp.CrearAccion (oid);

        return oid;
        /*PROTECTED REGION END*/
}
}
}
