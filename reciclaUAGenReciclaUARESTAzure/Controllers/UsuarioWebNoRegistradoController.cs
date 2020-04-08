using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using reciclaUAGenReciclaUARESTAzure.DTO;
using reciclaUAGenReciclaUARESTAzure.DTOA;
using reciclaUAGenReciclaUARESTAzure.CAD;
using reciclaUAGenReciclaUARESTAzure.Assemblers;
using reciclaUAGenReciclaUARESTAzure.AssemblersDTO;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CP.ReciclaUA;


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_UsuarioWebNoRegistradoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioWebNoRegistrado")]
public class UsuarioWebNoRegistradoController : BasicController
{
// Voy a generar el readAll
















[HttpPost]


[Route ("~/api/UsuarioWebNoRegistrado/Crear")]




public HttpResponseMessage Crear ( [FromBody] UsuarioWebDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        UsuarioWebNoRegistradoRESTCAD usuarioWebNoRegistradoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebNoRegistradoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                usuarioWebNoRegistradoRESTCAD = new UsuarioWebNoRegistradoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebNoRegistradoRESTCAD);

                // Create
                returnOID = usuarioWebCEN.Crear (
                        //Atributo Primitivo: p_nombre
                        dto.Nombre,                                                                                                                                         //Atributo Primitivo: p_apellidos
                        dto.Apellidos,                                                                                                                                      //Atributo Primitivo: p_email
                        dto.Email,                                                                                                                                          //Atributo Primitivo: p_pass
                        dto.Pass);
                SessionCommit ();

                // Convert return
                returnValue = UsuarioWebNoRegistradoAssembler.Convert (usuarioWebNoRegistradoRESTCAD.ReadOIDDefault (returnOID), session);
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

        // Return 201 - Created
        response = this.Request.CreateResponse (HttpStatusCode.Created, returnValue);

        // Location Header
        /*
         * Dictionary<string, object> routeValues = new Dictionary<string, object>();
         *
         * // TODO: y rolPaths
         * routeValues.Add("id", returnOID);
         *
         * uri = Url.Link("GetOIDUsuarioWebNoRegistrado", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}
















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_UsuarioWebNoRegistradoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
