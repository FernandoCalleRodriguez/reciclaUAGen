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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_AccionWebControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
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

public HttpResponseMessage BuscarAccionesWebPorUsuario (int id_usuario)
{
        // CAD, CEN, EN, returnValue

        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;


        System.Collections.Generic.List<AccionWebEN> en;

        System.Collections.Generic.List<AccionWebDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // CEN return



                en = accionWebCEN.BuscarAccionesWebPorUsuario (id_usuario).ToList ();




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



[HttpPost]


[Route ("~/api/AccionWeb/Crear")]




public HttpResponseMessage Crear ( [FromBody] AccionWebDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        AccionWebRESTCAD accionWebRESTCAD = null;
        AccionWebCEN accionWebCEN = null;
        AccionWebDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                accionWebRESTCAD = new AccionWebRESTCAD (session);
                accionWebCEN = new AccionWebCEN (accionWebRESTCAD);

                // Create
                returnOID = accionWebCEN.Crear (
                        //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        ,                                           //Atributo Primitivo: p_fecha
                        dto.Fecha,                                                                                                                                        //Atributo OID: p_tipo
                        // attr.estaRelacionado: true
                        dto.Tipo_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = AccionWebAssembler.Convert (accionWebRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDAccionWeb", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}


















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_AccionWebControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
