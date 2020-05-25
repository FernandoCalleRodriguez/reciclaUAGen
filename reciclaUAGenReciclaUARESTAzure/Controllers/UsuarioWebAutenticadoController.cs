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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_UsuarioWebAutenticadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioWebAutenticado")]
public class UsuarioWebAutenticadoController : BasicController
{
// Voy a generar el readAll













[HttpGet]
// [Route("{idUsuarioWebAutenticado}", Name="GetOIDUsuarioWebAutenticado")]

[Route ("~/api/UsuarioWebAutenticado/{idUsuarioWebAutenticado}")]

public HttpResponseMessage BuscarPorId (int idUsuarioWebAutenticado)
{
        // CAD, CEN, EN, returnValue
        UsuarioWebAutenticadoRESTCAD usuarioWebAutenticadoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebEN usuarioWebEN = null;
        UsuarioWebAutenticadoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                usuarioWebAutenticadoRESTCAD = new UsuarioWebAutenticadoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebAutenticadoRESTCAD);

                // Data
                usuarioWebEN = usuarioWebCEN.BuscarPorId (idUsuarioWebAutenticado);

                // Convert return
                if (usuarioWebEN != null) {
                        returnValue = UsuarioWebAutenticadoAssembler.Convert (usuarioWebEN, session);
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



// No pasa el slEnables: obtenerRanking

[HttpGet]

[Route ("~/api/UsuarioWebAutenticado/ObtenerRanking")]

public HttpResponseMessage ObtenerRanking (        )
{
        // CAD, CEN, EN, returnValue

        UsuarioWebAutenticadoRESTCAD usuarioWebAutenticadoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;


        System.Collections.Generic.List<UsuarioWebEN> en;

        System.Collections.Generic.List<UsuarioWebAutenticadoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                usuarioWebAutenticadoRESTCAD = new UsuarioWebAutenticadoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebAutenticadoRESTCAD);

                // CEN return



                en = usuarioWebCEN.ObtenerRanking (      ).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<UsuarioWebAutenticadoDTOA>();
                        foreach (UsuarioWebEN entry in en)
                                returnValue.Add (UsuarioWebAutenticadoAssembler.Convert (entry, session));
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


// No pasa el slEnables: obtenerPuntuaciones

[HttpGet]

[Route ("~/api/UsuarioWebAutenticado/ObtenerPuntuaciones")]

public HttpResponseMessage ObtenerPuntuaciones (           )
{
        // CAD, CEN, EN, returnValue

        UsuarioWebAutenticadoRESTCAD usuarioWebAutenticadoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;


        System.Collections.Generic.List<UsuarioWebEN> en;

        System.Collections.Generic.List<UsuarioWebAutenticadoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                usuarioWebAutenticadoRESTCAD = new UsuarioWebAutenticadoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebAutenticadoRESTCAD);

                // CEN return



                en = usuarioWebCEN.ObtenerPuntuaciones ( ).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<UsuarioWebAutenticadoDTOA>();
                        foreach (UsuarioWebEN entry in en)
                                returnValue.Add (UsuarioWebAutenticadoAssembler.Convert (entry, session));
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









[HttpPut]



[Route ("~/api/UsuarioWebAutenticado/Modificar")]


public HttpResponseMessage Modificar (int idUsuarioWebAutenticado, [FromBody] UsuarioWebDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioWebAutenticadoRESTCAD usuarioWebAutenticadoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebAutenticadoDTOA returnValue = null;

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



                usuarioWebAutenticadoRESTCAD = new UsuarioWebAutenticadoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebAutenticadoRESTCAD);

                // Modify
                usuarioWebCEN.Modificar (idUsuarioWebAutenticado,
                        dto.Nombre
                        ,
                        dto.Apellidos
                        ,
                        dto.Email
                        );

                // Return modified object
                returnValue = UsuarioWebAutenticadoAssembler.Convert (usuarioWebAutenticadoRESTCAD.ReadOIDDefault (idUsuarioWebAutenticado), session);

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



[Route ("~/api/UsuarioWebAutenticado/CambiarPassword")]


public HttpResponseMessage CambiarPassword (int idUsuarioWebAutenticado, [FromBody] UsuarioWebDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioWebAutenticadoRESTCAD usuarioWebAutenticadoRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebAutenticadoDTOA returnValue = null;

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



                usuarioWebAutenticadoRESTCAD = new UsuarioWebAutenticadoRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebAutenticadoRESTCAD);

                // Modify
                usuarioWebCEN.CambiarPassword (idUsuarioWebAutenticado,
                        dto.Pass
                        );

                // Return modified object
                returnValue = UsuarioWebAutenticadoAssembler.Convert (usuarioWebAutenticadoRESTCAD.ReadOIDDefault (idUsuarioWebAutenticado), session);

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


[Route ("~/api/UsuarioWebAutenticado/Borrar")]

public HttpResponseMessage Borrar (int p_usuarioweb_oid)
{
        UsuarioWebAutenticadoRESTCAD usuarioWebAutenticadoRESTCAD = null;

        UsuarioWebCEN usuarioWebCEN = null;




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



                usuarioWebAutenticadoRESTCAD = new UsuarioWebAutenticadoRESTCAD (session);

                usuarioWebCEN = new UsuarioWebCEN (usuarioWebAutenticadoRESTCAD);


                // Destroy

                usuarioWebCEN.Borrar (p_usuarioweb_oid);


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








/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_UsuarioWebAutenticadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
