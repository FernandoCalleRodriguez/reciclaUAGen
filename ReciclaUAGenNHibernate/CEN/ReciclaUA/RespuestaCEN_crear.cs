
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Respuesta_crear) ENABLED START*/
//  references to other libraries
using ReciclaUAGenNHibernate.CP.ReciclaUA;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class RespuestaCEN
{
public int Crear (string p_cuerpo, int p_duda, int p_usuario)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Respuesta_crear_customized) ENABLED START*/

        RespuestaEN respuestaEN = null;

        int oid;

        //Initialized RespuestaEN
        respuestaEN = new RespuestaEN ();
        respuestaEN.Cuerpo = p_cuerpo;

        respuestaEN.Util = 0;

        respuestaEN.EsCorrecta = false;

        respuestaEN.Fecha = DateTime.Today;


        if (p_usuario != -1) {
                respuestaEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN ();
                respuestaEN.Usuario.Id = p_usuario;
        }


        if (p_duda != -1) {
                respuestaEN.Duda = new ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN ();
                respuestaEN.Duda.Id = p_duda;
        }

        //Call to RespuestaCAD

        oid = _IRespuestaCAD.Crear (respuestaEN);

        RespuestaCP cp = new RespuestaCP ();
        cp.CrearAccionRespuesta (oid);

        return oid;
        /*PROTECTED REGION END*/
}
}
}
