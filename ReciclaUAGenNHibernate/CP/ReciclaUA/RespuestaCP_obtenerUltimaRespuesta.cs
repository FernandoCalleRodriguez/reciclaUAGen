
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Respuesta_obtenerUltimaRespuesta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class RespuestaCP : BasicCP
{
public ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN ObtenerUltimaRespuesta (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Respuesta_obtenerUltimaRespuesta) ENABLED START*/

        IRespuestaCAD respuestaCAD = null;
        RespuestaCEN respuestaCEN = null;
        IDudaCAD dudaCAD = null;
        DudaCEN dudaCEN = null;

        ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN respuesta = null;


        try
        {
                SessionInitializeTransaction ();
                respuestaCAD = new RespuestaCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaCAD);
                dudaCAD = new DudaCAD (session);
                dudaCEN = new DudaCEN (dudaCAD);



                // Write here your custom transaction ...

                DudaEN duda = dudaCAD.ReadOIDDefault (p_oid);

                if (duda.Respuestas.Count > 0) {
                        respuesta = duda.Respuestas [0];
                        for (int i = 1; i < duda.Respuestas.Count; i++) {
                                if (respuesta.Fecha <= duda.Respuestas [i].Fecha) {
                                        respuesta = duda.Respuestas [i];
                                }
                        }
                }

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }

        return respuesta;


        /*PROTECTED REGION END*/
}
}
}
