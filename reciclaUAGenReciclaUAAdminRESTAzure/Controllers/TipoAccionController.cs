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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_TipoAccionControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/TipoAccion")]
public class TipoAccionController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/TipoAccion/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;

        List<TipoAccionEN> tipoAccionEN = null;
        List<TipoAccionDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);

                // Data
                // TODO: paginación

                tipoAccionEN = tipoAccionCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (tipoAccionEN != null) {
                        returnValue = new List<TipoAccionDTOA>();
                        foreach (TipoAccionEN entry in tipoAccionEN)
                                returnValue.Add (TipoAccionAssembler.Convert (entry, session));
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
// [Route("{idTipoAccion}", Name="GetOIDTipoAccion")]

[Route ("~/api/TipoAccion/{idTipoAccion}")]

public HttpResponseMessage BuscarPorId (int idTipoAccion)
{
        // CAD, CEN, EN, returnValue
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;
        TipoAccionEN tipoAccionEN = null;
        TipoAccionDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);

                // Data
                tipoAccionEN = tipoAccionCEN.BuscarPorId (idTipoAccion);

                // Convert return
                if (tipoAccionEN != null) {
                        returnValue = TipoAccionAssembler.Convert (tipoAccionEN, session);
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




[HttpPost]


[Route ("~/api/TipoAccion/Crear")]




public HttpResponseMessage Crear ( [FromBody] TipoAccionDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;
        TipoAccionDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);

                // Create
                returnOID = tipoAccionCEN.Crear (
                        //Atributo Primitivo: p_puntuacion
                        dto.Puntuacion,                                                                                                                                     //Atributo Primitivo: p_nombre
                        dto.Nombre);
                SessionCommit ();

                // Convert return
                returnValue = TipoAccionAssembler.Convert (tipoAccionRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDTipoAccion", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]



[Route ("~/api/TipoAccion/Modificar")]

public HttpResponseMessage Modificar (int idTipoAccion, [FromBody] TipoAccionDTO dto)
{
        // CAD, CEN, returnValue
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;
        TipoAccionDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);

                // Modify
                tipoAccionCEN.Modificar (idTipoAccion,
                        dto.Puntuacion
                        ,
                        dto.Nombre
                        );

                // Return modified object
                returnValue = TipoAccionAssembler.Convert (tipoAccionRESTCAD.ReadOIDDefault (idTipoAccion), session);

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





[HttpDelete]


[Route ("~/api/TipoAccion/Borrar")]

public HttpResponseMessage Borrar (int p_tipoaccion_oid)
{
        // CAD, CEN
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);

                tipoAccionCEN.Borrar (p_tipoaccion_oid);
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

        // Return 204 - No Content
        return this.Request.CreateResponse (HttpStatusCode.NoContent);
}









/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_TipoAccionControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
