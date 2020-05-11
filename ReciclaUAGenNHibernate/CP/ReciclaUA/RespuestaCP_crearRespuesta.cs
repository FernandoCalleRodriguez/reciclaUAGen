
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Respuesta_crearRespuesta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class RespuestaCP : BasicCP
{
public void CrearRespuesta (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Respuesta_crearRespuesta) ENABLED START*/

        IRespuestaCAD respuestaCAD = null;
        RespuestaCEN respuestaCEN = null;



        try
        {
                SessionInitializeTransaction ();
                respuestaCAD = new RespuestaCAD (session);
                respuestaCEN = new  RespuestaCEN (respuestaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method CrearRespuesta() not yet implemented.");



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


        /*PROTECTED REGION END*/
}
}
}
