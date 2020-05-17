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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_NotaInformativaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/NotaInformativa")]
public class NotaInformativaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/NotaInformativa/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        NotaInformativaRESTCAD notaInformativaRESTCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;

        List<NotaInformativaEN> notaInformativaEN = null;
        List<NotaInformativaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                notaInformativaRESTCAD = new NotaInformativaRESTCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaRESTCAD);

                // Data
                // TODO: paginación

                notaInformativaEN = notaInformativaCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (notaInformativaEN != null) {
                        returnValue = new List<NotaInformativaDTOA>();
                        foreach (NotaInformativaEN entry in notaInformativaEN)
                                returnValue.Add (NotaInformativaAssembler.Convert (entry, session));
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
// [Route("{idNotaInformativa}", Name="GetOIDNotaInformativa")]

[Route ("~/api/NotaInformativa/{idNotaInformativa}")]

public HttpResponseMessage BuscarPorId (int idNotaInformativa)
{
        // CAD, CEN, EN, returnValue
        NotaInformativaRESTCAD notaInformativaRESTCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;
        NotaInformativaEN notaInformativaEN = null;
        NotaInformativaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                notaInformativaRESTCAD = new NotaInformativaRESTCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaRESTCAD);

                // Data
                notaInformativaEN = notaInformativaCEN.BuscarPorId (idNotaInformativa);

                // Convert return
                if (notaInformativaEN != null) {
                        returnValue = NotaInformativaAssembler.Convert (notaInformativaEN, session);
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



// No pasa el slEnables: buscarPorTitulo

[HttpGet]

[Route ("~/api/NotaInformativa/BuscarPorTitulo")]

public HttpResponseMessage BuscarPorTitulo (string p_titulo)
{
        // CAD, CEN, EN, returnValue

        NotaInformativaRESTCAD notaInformativaRESTCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;


        System.Collections.Generic.List<NotaInformativaEN> en;

        System.Collections.Generic.List<NotaInformativaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                notaInformativaRESTCAD = new NotaInformativaRESTCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaRESTCAD);

                // CEN return



                en = notaInformativaCEN.BuscarPorTitulo (p_titulo).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<NotaInformativaDTOA>();
                        foreach (NotaInformativaEN entry in en)
                                returnValue.Add (NotaInformativaAssembler.Convert (entry, session));
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


[Route ("~/api/NotaInformativa/Crear")]




public HttpResponseMessage Crear ( [FromBody] NotaInformativaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        NotaInformativaRESTCAD notaInformativaRESTCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;
        NotaInformativaDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                notaInformativaRESTCAD = new NotaInformativaRESTCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaRESTCAD);

                // Create
                returnOID = notaInformativaCEN.Crear (
                        //Atributo OID: p_usuarioAdministrador
                        // attr.estaRelacionado: true
                        dto.UsuarioAdministrador_oid                 // association role

                        ,                                           //Atributo Primitivo: p_titulo
                        dto.Titulo,                                                                                                                                         //Atributo Primitivo: p_cuerpo
                        dto.Cuerpo);
                SessionCommit ();

                // Convert return
                returnValue = NotaInformativaAssembler.Convert (notaInformativaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDNotaInformativa", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}




[HttpPut]



[Route ("~/api/NotaInformativa/Modificar")]

public HttpResponseMessage Modificar (int idNotaInformativa, [FromBody] NotaInformativaDTO dto)
{
        // CAD, CEN, returnValue
        NotaInformativaRESTCAD notaInformativaRESTCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;
        NotaInformativaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                notaInformativaRESTCAD = new NotaInformativaRESTCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaRESTCAD);

                // Modify
                notaInformativaCEN.Modificar (idNotaInformativa,
                        dto.Titulo
                        ,
                        dto.Cuerpo
                        ,
                        dto.Fecha
                        );

                // Return modified object
                returnValue = NotaInformativaAssembler.Convert (notaInformativaRESTCAD.ReadOIDDefault (idNotaInformativa), session);

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


[Route ("~/api/NotaInformativa/Borrar")]

public HttpResponseMessage Borrar (int p_notainformativa_oid)
{
        // CAD, CEN
        NotaInformativaRESTCAD notaInformativaRESTCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                notaInformativaRESTCAD = new NotaInformativaRESTCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaRESTCAD);

                notaInformativaCEN.Borrar (p_notainformativa_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_NotaInformativaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
