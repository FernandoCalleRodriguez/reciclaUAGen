using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using reciclaUAGenReciclaUAAdminRESTAzure.DTO;
using reciclaUAGenReciclaUAAdminRESTAzure.DTOA;
using reciclaUAGenReciclaUAAdminRESTAzure.CAD;
using reciclaUAGenReciclaUAAdminRESTAzure.Assemblers;
using reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CP.ReciclaUA;


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_UsuarioAdminNoAutenticadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioAdminNoAutenticado")]
public class UsuarioAdminNoAutenticadoController : BasicController
{
// Voy a generar el readAll















[HttpPost]

[Route ("~/api/UsuarioAdminNoAutenticado/Login")]


public HttpResponseMessage Login ( [FromBody] UsuarioDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioAdminNoAutenticadoRESTCAD usuarioAdminNoAutenticadoRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        string token = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioAdminNoAutenticadoRESTCAD = new UsuarioAdminNoAutenticadoRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioAdminNoAutenticadoRESTCAD);


                // Operation
                token = usuarioCEN.Login (
                        dto.Id
                        , dto.Pass
                        );

                SessionCommit ();
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 200 - OK
        if (token != null)
                return this.Request.CreateResponse (HttpStatusCode.OK, token);
        else
                return this.Request.CreateResponse (HttpStatusCode.Unauthorized, "");
}



















/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_UsuarioAdminNoAutenticadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
