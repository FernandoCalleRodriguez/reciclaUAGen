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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_UsuarioAdminRecuperarPassControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioAdminRecuperarPass")]
public class UsuarioAdminRecuperarPassController : BasicController
{
// Voy a generar el readAll




















[HttpPut]



[Route ("~/api/UsuarioAdminRecuperarPass/RecuperarPassword")]


public HttpResponseMessage RecuperarPassword (int idUsuarioAdminRecuperarPass, [FromBody] UsuarioAdministradorDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioAdminRecuperarPassRESTCAD usuarioAdminRecuperarPassRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;
        UsuarioAdminRecuperarPassDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                usuarioAdminRecuperarPassRESTCAD = new UsuarioAdminRecuperarPassRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminRecuperarPassRESTCAD);

                // Modify
                usuarioAdministradorCEN.RecuperarPassword (idUsuarioAdminRecuperarPass,
                        dto.Pass
                        );

                // Return modified object
                returnValue = UsuarioAdminRecuperarPassAssembler.Convert (usuarioAdminRecuperarPassRESTCAD.ReadOIDDefault (idUsuarioAdminRecuperarPass), session);

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

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else{
                response = this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
                return response;
        }
}












/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_UsuarioAdminRecuperarPassControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
