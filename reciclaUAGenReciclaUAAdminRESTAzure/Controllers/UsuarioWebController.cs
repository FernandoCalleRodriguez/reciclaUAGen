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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_UsuarioWebControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
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
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



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
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



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



// No pasa el slEnables: obtenerRanking

[HttpGet]

[Route ("~/api/UsuarioWeb/ObtenerRanking")]

public HttpResponseMessage ObtenerRanking (        )
{
        // CAD, CEN, EN, returnValue

        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;


        System.Collections.Generic.List<UsuarioWebEN> en;

        System.Collections.Generic.List<UsuarioWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // CEN return



                en = usuarioWebCEN.ObtenerRanking (      ).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<UsuarioWebDTOA>();
                        foreach (UsuarioWebEN entry in en)
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


// No pasa el slEnables: obtenerPuntuaciones

[HttpGet]

[Route ("~/api/UsuarioWeb/ObtenerPuntuaciones")]

public HttpResponseMessage ObtenerPuntuaciones (           )
{
        // CAD, CEN, EN, returnValue

        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;


        System.Collections.Generic.List<UsuarioWebEN> en;

        System.Collections.Generic.List<UsuarioWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // CEN return



                en = usuarioWebCEN.ObtenerPuntuaciones ( ).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<UsuarioWebDTOA>();
                        foreach (UsuarioWebEN entry in en)
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


// No pasa el slEnables: buscarNoBorrados

[HttpGet]

[Route ("~/api/UsuarioWeb/BuscarNoBorrados")]

public HttpResponseMessage BuscarNoBorrados (      )
{
        // CAD, CEN, EN, returnValue

        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;


        System.Collections.Generic.List<UsuarioWebEN> en;

        System.Collections.Generic.List<UsuarioWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // CEN return



                en = usuarioWebCEN.BuscarNoBorrados (    ).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<UsuarioWebDTOA>();
                        foreach (UsuarioWebEN entry in en)
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


// No pasa el slEnables: BuscarTodosCount

[HttpGet]

[Route ("~/api/UsuarioWeb/BuscarTodosCount")]

public HttpResponseMessage BuscarTodosCount (      )
{
        // CAD, CEN, EN, returnValue

        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;


        int returnValue;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // CEN return



                returnValue = usuarioWebCEN.BuscarTodosCount (   );




                // Convert return
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





[HttpPost]


[Route ("~/api/UsuarioWeb/Crear")]




public HttpResponseMessage Crear ( [FromBody] UsuarioWebDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebDTOA returnValue = null;
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



                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // Create
                returnOID = usuarioWebCEN.Crear (
                        //Atributo Primitivo: p_nombre
                        dto.Nombre,                                                                                                                                         //Atributo Primitivo: p_apellidos
                        dto.Apellidos,                                                                                                                                      //Atributo Primitivo: p_email
                        dto.Email,                                                                                                                                          //Atributo Primitivo: p_pass
                        dto.Pass);
                SessionCommit ();

                // Convert return
                returnValue = UsuarioWebAssembler.Convert (usuarioWebRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDUsuarioWeb", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}





[HttpPut]



[Route ("~/api/UsuarioWeb/Modificar")]


public HttpResponseMessage Modificar (int idUsuarioWeb, [FromBody] UsuarioWebDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioWebRESTCAD usuarioWebRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;
        UsuarioWebDTOA returnValue = null;

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



                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);

                // Modify
                usuarioWebCEN.Modificar (idUsuarioWeb,
                        dto.Nombre
                        ,
                        dto.Apellidos
                        ,
                        dto.Email
                        );

                // Return modified object
                returnValue = UsuarioWebAssembler.Convert (usuarioWebRESTCAD.ReadOIDDefault (idUsuarioWeb), session);

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


[Route ("~/api/UsuarioWeb/Borrar")]

public HttpResponseMessage Borrar (int p_usuarioweb_oid)
{
        UsuarioWebRESTCAD usuarioWebRESTCAD = null;

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



                usuarioWebRESTCAD = new UsuarioWebRESTCAD (session);

                usuarioWebCEN = new UsuarioWebCEN (usuarioWebRESTCAD);


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








/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_UsuarioWebControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs


[HttpPost]



[Route ("~/api/UsuarioWeb/BuscarPor")]


public HttpResponseMessage BuscarPor ( [FromBody] UsuarioWebDTO dto)
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
                if (dto.Nombre != null && dto.Nombre != "") {
                        usuarioWebEN = usuarioWebEN.Where (x => x.Nombre.ToLower () == dto.Nombre.ToLower ()).ToList<UsuarioWebEN>();;
                }
                if (dto.Apellidos != null && dto.Apellidos != "") {
                        usuarioWebEN = usuarioWebEN.Where (x => x.Apellidos.ToLower () == dto.Apellidos.ToLower ()).ToList<UsuarioWebEN>();;
                }
                if (dto.Email != null && dto.Email != "") {
                        usuarioWebEN = usuarioWebEN.Where (x => x.Email.ToLower () == dto.Email.ToLower ()).ToList<UsuarioWebEN>();;
                }
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

/*PROTECTED REGION END*/
}
}
