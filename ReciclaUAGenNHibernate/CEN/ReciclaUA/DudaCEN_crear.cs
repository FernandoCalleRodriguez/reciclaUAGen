
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Duda_crear) ENABLED START*/
//  references to other libraries
using ReciclaUAGenNHibernate.CP.ReciclaUA;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class DudaCEN
{
public int Crear (string p_titulo, string p_cuerpo, int p_usuario, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TemaEnum p_tema)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Duda_crear_customized) ENABLED START*/

        DudaEN dudaEN = null;

        int oid;

        //Initialized DudaEN
        dudaEN = new DudaEN ();
        dudaEN.Titulo = p_titulo;

        dudaEN.Cuerpo = p_cuerpo;

        dudaEN.Tema = p_tema;

        dudaEN.Fecha = DateTime.Today;


        if (p_usuario != -1) {
                dudaEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN ();
                dudaEN.Usuario.Id = p_usuario;
        }

        //Call to DudaCAD

        oid = _IDudaCAD.Crear (dudaEN);

        DudaCP cp = new DudaCP ();
        cp.CrearAccionDuda (oid);

        return oid;
        /*PROTECTED REGION END*/
}
}
}
