
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_NotaInformativa_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class NotaInformativaCEN
{
public int Crear (int p_usuarioAdministrador, string p_titulo, string p_cuerpo)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_NotaInformativa_crear_customized) ENABLED START*/

        NotaInformativaEN notaInformativaEN = null;

        int oid;

        //Initialized NotaInformativaEN
        notaInformativaEN = new NotaInformativaEN ();

        if (p_usuarioAdministrador != -1) {
                notaInformativaEN.UsuarioAdministrador = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN ();
                notaInformativaEN.UsuarioAdministrador.Id = p_usuarioAdministrador;
        }

        notaInformativaEN.Titulo = p_titulo;

        notaInformativaEN.Fecha = DateTime.Now;


        notaInformativaEN.Cuerpo = p_cuerpo;

        //Call to NotaInformativaCAD

        oid = _INotaInformativaCAD.Crear (notaInformativaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
