
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
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class DudaCEN
{
public int Crear (string p_titulo, string p_cuerpo, string p_temas, int p_usuario)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Duda_crear_customized) ENABLED START*/

        DudaEN dudaEN = null;

        int oid;

        //Initialized DudaEN
        dudaEN = new DudaEN ();
        dudaEN.Titulo = p_titulo;

        dudaEN.Cuerpo = p_cuerpo;

        dudaEN.Temas = p_temas;

        dudaEN.Fecha = DateTime.Today;


        if (p_usuario != -1) {
                dudaEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN ();
                dudaEN.Usuario.Id = p_usuario;
        }

        //Call to DudaCAD

        oid = _IDudaCAD.Crear (dudaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
