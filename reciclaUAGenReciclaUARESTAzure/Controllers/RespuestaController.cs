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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_RespuestaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Respuesta")]
public class RespuestaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Respuesta/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;

        List<RespuestaEN> respuestaEN = null;
        List<RespuestaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);

                // Data
                // TODO: paginación

                respuestaEN = respuestaCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (respuestaEN != null) {
                        returnValue = new List<RespuestaDTOA>();
                        foreach (RespuestaEN entry in respuestaEN)
                                returnValue.Add (RespuestaAssembler.Convert (entry, session));
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





[Route ("~/api/Respuesta/RespuestasDuda")]

public HttpResponseMessage RespuestasDuda (int idDuda)
{
        // CAD, EN
        DudaRESTCAD dudaRESTCAD = null;
        DudaEN dudaEN = null;

        // returnValue
        List<RespuestaEN> en = null;
        List<RespuestaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                new UsuarioCEN ().CheckToken (token);


                dudaRESTCAD = new DudaRESTCAD (session);

                // Exists Duda
                dudaEN = dudaRESTCAD.ReadOIDDefault (idDuda);
                if (dudaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Duda#" + idDuda + " not found"));

                // Rol
                // TODO: paginación


                en = dudaRESTCAD.RespuestasDuda (idDuda).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<RespuestaDTOA>();
                        foreach (RespuestaEN entry in en)
                                returnValue.Add (RespuestaAssembler.Convert (entry, session));
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
// [Route("{idRespuesta}", Name="GetOIDRespuesta")]

[Route ("~/api/Respuesta/{idRespuesta}")]

public HttpResponseMessage BuscarPorId (int idRespuesta)
{
        // CAD, CEN, EN, returnValue
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;
        RespuestaEN respuestaEN = null;
        RespuestaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);

                // Data
                respuestaEN = respuestaCEN.BuscarPorId (idRespuesta);

                // Convert return
                if (respuestaEN != null) {
                        returnValue = RespuestaAssembler.Convert (respuestaEN, session);
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



// No pasa el slEnables: buscarRespuestaPorDuda

[HttpGet]

[Route ("~/api/Respuesta/BuscarRespuestaPorDuda")]

public HttpResponseMessage BuscarRespuestaPorDuda (int ? id_duda)
{
        // CAD, CEN, EN, returnValue

        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;


        System.Collections.Generic.List<RespuestaEN> en;

        System.Collections.Generic.List<RespuestaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);

                // CEN return



                en = respuestaCEN.BuscarRespuestaPorDuda (id_duda).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<RespuestaDTOA>();
                        foreach (RespuestaEN entry in en)
                                returnValue.Add (RespuestaAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarRespuestaPorEsCorrecta

[HttpGet]

[Route ("~/api/Respuesta/BuscarRespuestaPorEsCorrecta")]

public HttpResponseMessage BuscarRespuestaPorEsCorrecta (          )
{
        // CAD, CEN, EN, returnValue

        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;


        System.Collections.Generic.List<RespuestaEN> en;

        System.Collections.Generic.List<RespuestaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);

                // CEN return



                en = respuestaCEN.BuscarRespuestaPorEsCorrecta ( ).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<RespuestaDTOA>();
                        foreach (RespuestaEN entry in en)
                                returnValue.Add (RespuestaAssembler.Convert (entry, session));
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





[HttpPost]


[Route ("~/api/Respuesta/Crear")]




public HttpResponseMessage Crear ( [FromBody] RespuestaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;
        RespuestaDTOA returnValue = null;
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



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);

                // Create
                returnOID = respuestaCEN.Crear (
                        //Atributo Primitivo: p_cuerpo
                        dto.Cuerpo,                                                                                                                                       //Atributo OID: p_duda
                        // attr.estaRelacionado: true
                        dto.Duda_oid                 // association role

                        ,                                         //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = RespuestaAssembler.Convert (respuestaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDRespuesta", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}




[HttpPut]



[Route ("~/api/Respuesta/Modificar")]

public HttpResponseMessage Modificar (int idRespuesta, [FromBody] RespuestaDTO dto)
{
        // CAD, CEN, returnValue
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;
        RespuestaDTOA returnValue = null;

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



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);

                // Modify
                respuestaCEN.Modificar (idRespuesta,
                        dto.Cuerpo
                        ,
                        dto.Fecha
                        ,
                        dto.EsCorrecta
                        ,
                        dto.Util
                        );

                // Return modified object
                returnValue = RespuestaAssembler.Convert (respuestaRESTCAD.ReadOIDDefault (idRespuesta), session);

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


[Route ("~/api/Respuesta/Borrar")]

public HttpResponseMessage Borrar (int p_respuesta_oid)
{
        // CAD, CEN
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);

                respuestaCEN.Borrar (p_respuesta_oid);
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






[HttpPost]

[Route ("~/api/Respuesta/IndicarRespuestaUtil")]


public HttpResponseMessage IndicarRespuestaUtil (int p_oid)
{
        // CAD, CEN, returnValue
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);


                // Operation
                respuestaCEN.IndicarRespuestaUtil (p_oid);
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
        return this.Request.CreateResponse (HttpStatusCode.OK);
}



[HttpPost]

[Route ("~/api/Respuesta/IndicarRespuestaNoUtil")]


public HttpResponseMessage IndicarRespuestaNoUtil (int p_oid)
{
        // CAD, CEN, returnValue
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);


                // Operation
                respuestaCEN.IndicarRespuestaNoUtil (p_oid);
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
        return this.Request.CreateResponse (HttpStatusCode.OK);
}



[HttpPost]

[Route ("~/api/Respuesta/ConfirmacionRespuestaCorrecta")]


public HttpResponseMessage ConfirmacionRespuestaCorrecta (int p_oid)
{
        // CAD, CEN, returnValue
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);


                // Operation
                respuestaCEN.ConfirmacionRespuestaCorrecta (p_oid);
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
        return this.Request.CreateResponse (HttpStatusCode.OK);
}



[HttpPost]

[Route ("~/api/Respuesta/DescartarRespuestaCorrecta")]


public HttpResponseMessage DescartarRespuestaCorrecta (int p_oid)
{
        // CAD, CEN, returnValue
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;
        bool returnValue;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);


                // Operation
                returnValue = respuestaCEN.DescartarRespuestaCorrecta (p_oid);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}




[HttpPost]

[Route ("~/api/Respuesta/ObtenerUltimaRespuesta")]

public HttpResponseMessage ObtenerUltimaRespuesta (int p_oid)
{
        // CP, returnValue
        RespuestaCP respuestaCP = null;

        RespuestaDTOA returnValue;
        RespuestaEN en;

        try
        {
                SessionInitializeTransaction ();

                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                respuestaCP = new RespuestaCP (session);

                // Operation
                en = respuestaCP.ObtenerUltimaRespuesta (p_oid);
                SessionCommit ();

                // Convert return
                returnValue = RespuestaAssembler.Convert (en, session);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_RespuestaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
[HttpPost]
[Route ("~/api/Respuesta/CrearCP")]
public HttpResponseMessage CrearCP ( [FromBody] RespuestaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaCEN respuestaCEN = null;
        RespuestaDTOA returnValue = null;
        RespuestaCP respuestaCP = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                respuestaRESTCAD = new RespuestaRESTCAD (session);
                respuestaCEN = new RespuestaCEN (respuestaRESTCAD);
                respuestaCP = new RespuestaCP (session);

                // Create
                returnOID = respuestaCEN.Crear (dto.Cuerpo, dto.Duda_oid, dto.Usuario_oid);
                respuestaCP.CrearAccionRespuesta (returnOID);

                SessionCommit ();

                // Convert return
                returnValue = RespuestaAssembler.Convert (respuestaRESTCAD.ReadOIDDefault (returnOID), session);
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
        return response;
}
/*PROTECTED REGION END*/
}
}
