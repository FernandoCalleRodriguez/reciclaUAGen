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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_UsuarioAdminAutenticadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioAdminAutenticado")]
public class UsuarioAdminAutenticadoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/UsuarioAdminAutenticado/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        UsuarioAdminAutenticadoRESTCAD usuarioAdminAutenticadoRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;

        List<UsuarioAdministradorEN> usuarioAdministradorEN = null;
        List<UsuarioAdminAutenticadoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                usuarioAdminAutenticadoRESTCAD = new UsuarioAdminAutenticadoRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminAutenticadoRESTCAD);

                // Data
                // TODO: paginación

                usuarioAdministradorEN = usuarioAdministradorCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (usuarioAdministradorEN != null) {
                        returnValue = new List<UsuarioAdminAutenticadoDTOA>();
                        foreach (UsuarioAdministradorEN entry in usuarioAdministradorEN)
                                returnValue.Add (UsuarioAdminAutenticadoAssembler.Convert (entry, session));
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
// [Route("{idUsuarioAdminAutenticado}", Name="GetOIDUsuarioAdminAutenticado")]

[Route ("~/api/UsuarioAdminAutenticado/{idUsuarioAdminAutenticado}")]

public HttpResponseMessage BuscarPorId (int idUsuarioAdminAutenticado)
{
        // CAD, CEN, EN, returnValue
        UsuarioAdminAutenticadoRESTCAD usuarioAdminAutenticadoRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;
        UsuarioAdministradorEN usuarioAdministradorEN = null;
        UsuarioAdminAutenticadoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                usuarioAdminAutenticadoRESTCAD = new UsuarioAdminAutenticadoRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminAutenticadoRESTCAD);

                // Data
                usuarioAdministradorEN = usuarioAdministradorCEN.BuscarPorId (idUsuarioAdminAutenticado);

                // Convert return
                if (usuarioAdministradorEN != null) {
                        returnValue = UsuarioAdminAutenticadoAssembler.Convert (usuarioAdministradorEN, session);
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


[Route ("~/api/UsuarioAdminAutenticado/Crear")]




public HttpResponseMessage Crear ( [FromBody] UsuarioAdministradorDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        UsuarioAdminAutenticadoRESTCAD usuarioAdminAutenticadoRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;
        UsuarioAdminAutenticadoDTOA returnValue = null;
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



                usuarioAdminAutenticadoRESTCAD = new UsuarioAdminAutenticadoRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminAutenticadoRESTCAD);

                // Create
                returnOID = usuarioAdministradorCEN.Crear (
                        //Atributo Primitivo: p_nombre
                        dto.Nombre,                                                                                                                                         //Atributo Primitivo: p_apellidos
                        dto.Apellidos,                                                                                                                                      //Atributo Primitivo: p_email
                        dto.Email,                                                                                                                                          //Atributo Primitivo: p_pass
                        dto.Pass);
                SessionCommit ();

                // Convert return
                returnValue = UsuarioAdminAutenticadoAssembler.Convert (usuarioAdminAutenticadoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDUsuarioAdminAutenticado", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}





[HttpPut]



[Route ("~/api/UsuarioAdminAutenticado/Modificar")]


public HttpResponseMessage Modificar (int idUsuarioAdminAutenticado, [FromBody] UsuarioAdministradorDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioAdminAutenticadoRESTCAD usuarioAdminAutenticadoRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;
        UsuarioAdminAutenticadoDTOA returnValue = null;

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



                usuarioAdminAutenticadoRESTCAD = new UsuarioAdminAutenticadoRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminAutenticadoRESTCAD);

                // Modify
                usuarioAdministradorCEN.Modificar (idUsuarioAdminAutenticado,
                        dto.Nombre
                        ,
                        dto.Apellidos
                        ,
                        dto.Email
                        );

                // Return modified object
                returnValue = UsuarioAdminAutenticadoAssembler.Convert (usuarioAdminAutenticadoRESTCAD.ReadOIDDefault (idUsuarioAdminAutenticado), session);

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

[HttpPut]



[Route ("~/api/UsuarioAdminAutenticado/CambiarPassword")]


public HttpResponseMessage CambiarPassword (int idUsuarioAdminAutenticado, [FromBody] UsuarioAdministradorDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioAdminAutenticadoRESTCAD usuarioAdminAutenticadoRESTCAD = null;
        UsuarioAdministradorCEN usuarioAdministradorCEN = null;
        UsuarioAdminAutenticadoDTOA returnValue = null;

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



                usuarioAdminAutenticadoRESTCAD = new UsuarioAdminAutenticadoRESTCAD (session);
                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminAutenticadoRESTCAD);

                // Modify
                usuarioAdministradorCEN.CambiarPassword (idUsuarioAdminAutenticado,
                        dto.Pass
                        );

                // Return modified object
                returnValue = UsuarioAdminAutenticadoAssembler.Convert (usuarioAdminAutenticadoRESTCAD.ReadOIDDefault (idUsuarioAdminAutenticado), session);

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


[Route ("~/api/UsuarioAdminAutenticado/Borrar")]

public HttpResponseMessage Borrar (int p_usuarioadministrador_oid)
{
        UsuarioAdminAutenticadoRESTCAD usuarioAdminAutenticadoRESTCAD = null;

        UsuarioAdministradorCEN usuarioAdministradorCEN = null;




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



                usuarioAdminAutenticadoRESTCAD = new UsuarioAdminAutenticadoRESTCAD (session);

                usuarioAdministradorCEN = new UsuarioAdministradorCEN (usuarioAdminAutenticadoRESTCAD);


                // Destroy

                usuarioAdministradorCEN.Borrar (p_usuarioadministrador_oid);


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








/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_UsuarioAdminAutenticadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
