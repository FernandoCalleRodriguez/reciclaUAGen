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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_UsuarioWebControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioWeb")]
public class UsuarioWebController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/UsuarioWeb/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;

        List<UsuarioWebEN> usuarioWebEN = null;
        List<UsuarioWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // Data
                // TODO: paginación

                usuarioWebEN = usuarioWebCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (usuarioWebEN != null) {
                        returnValue = new List<UsuarioWebDTOA>();
                        foreach (UsuarioWebEN entry in usuarioWebEN)
                                returnValue.Add (UsuarioWebAssembler.Convert (entry, session));
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}









[HttpGet]
// [Route("{idUsuarioWeb}", Name="GetOIDUsuarioWeb")]

[Route ("~/api/UsuarioWeb/{idUsuarioWeb}")]

public HttpResponseMessage BuscarPorId (int idUsuarioWeb)
{
        // CAD, CEN, EN, returnValue
        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebEN usuarioWebEN = null;
        UsuarioWebDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // Data
                usuarioWebEN = usuarioWebCEN.BuscarPorId (idUsuarioWeb);

                // Convert return
                if (usuarioWebEN != null) {
                        returnValue = UsuarioWebAssembler.Convert (usuarioWebEN, session);
                }
        }

        catch (Exception e)
        {
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
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_UsuarioWebControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
