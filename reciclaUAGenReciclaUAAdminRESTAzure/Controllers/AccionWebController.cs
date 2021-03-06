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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_AccionWebControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/AccionWeb")]
public class AccionWebController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/AccionWeb/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;

        List<AccionWebEN> accionWebEN = null;
        List<AccionWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // Data
                // TODO: paginación

                accionWebEN = accionWebCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (accionWebEN != null) {
                        returnValue = new List<AccionWebDTOA>();
                        foreach (AccionWebEN entry in accionWebEN)
                                returnValue.Add (AccionWebAssembler.Convert (entry, session));
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
// [Route("{idAccionWeb}", Name="GetOIDAccionWeb")]

[Route ("~/api/AccionWeb/{idAccionWeb}")]

public HttpResponseMessage BuscarPorId (int idAccionWeb)
{
        // CAD, CEN, EN, returnValue
        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;
        AccionWebEN accionWebEN = null;
        AccionWebDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // Data
                accionWebEN = accionWebCEN.BuscarPorId (idAccionWeb);

                // Convert return
                if (accionWebEN != null) {
                        returnValue = AccionWebAssembler.Convert (accionWebEN, session);
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



// No pasa el slEnables: buscarPorTipo

[HttpGet]

[Route ("~/api/AccionWeb/BuscarPorTipo")]

public HttpResponseMessage BuscarPorTipo (string p_type)
{
        // CAD, CEN, EN, returnValue

        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;


        System.Collections.Generic.List<AccionWebEN> en;

        System.Collections.Generic.List<AccionWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // CEN return



                en = accionWebCEN.BuscarPorTipo (p_type).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionWebDTOA>();
                        foreach (AccionWebEN entry in en)
                                returnValue.Add (AccionWebAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarAccionesWebPorUsuario

[HttpGet]

[Route ("~/api/AccionWeb/BuscarAccionesWebPorUsuario")]

public HttpResponseMessage BuscarAccionesWebPorUsuario (           )
{
        // CAD, CEN, EN, returnValue

        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;


        System.Collections.Generic.List<AccionWebEN> en;

        System.Collections.Generic.List<AccionWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // CEN return



                en = accionWebCEN.BuscarAccionesWebPorUsuario (id).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionWebDTOA>();
                        foreach (AccionWebEN entry in en)
                                returnValue.Add (AccionWebAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPorAutor

[HttpGet]

[Route ("~/api/AccionWeb/BuscarPorAutor")]

public HttpResponseMessage BuscarPorAutor (int ? p_user_id)
{
        // CAD, CEN, EN, returnValue

        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;


        System.Collections.Generic.List<AccionWebEN> en;

        System.Collections.Generic.List<AccionWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // CEN return



                en = accionWebCEN.BuscarPorAutor (p_user_id).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionWebDTOA>();
                        foreach (AccionWebEN entry in en)
                                returnValue.Add (AccionWebAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPorFecha

[HttpGet]

[Route ("~/api/AccionWeb/BuscarPorFecha")]

public HttpResponseMessage BuscarPorFecha (Nullable<DateTime> p_date)
{
        // CAD, CEN, EN, returnValue

        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;


        System.Collections.Generic.List<AccionWebEN> en;

        System.Collections.Generic.List<AccionWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // CEN return



                en = accionWebCEN.BuscarPorFecha (p_date).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionWebDTOA>();
                        foreach (AccionWebEN entry in en)
                                returnValue.Add (AccionWebAssembler.Convert (entry, session));
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



[Route ("~/api/AccionWeb/Modificar")]

public HttpResponseMessage Modificar (int idAccionWeb, [FromBody] AccionWebDTO dto)
{
        // CAD, CEN, returnValue
        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;
        AccionWebDTOA returnValue = null;

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



                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // Modify
                accionWebCEN.Modificar (idAccionWeb,
                        dto.Fecha
                        );

                // Return modified object
                returnValue = AccionWebAssembler.Convert (accionWebRESTCAD.ReadOIDDefault (idAccionWeb), session);

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


[Route ("~/api/AccionWeb/Borrar")]

public HttpResponseMessage Borrar (int p_accionweb_oid)
{
        // CAD, CEN
        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                accionWebCEN.Borrar (p_accionweb_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_AccionWebControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
