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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_ContenedorControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Contenedor")]
public class ContenedorController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Contenedor/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        ContenedorRESTCAD contenedorRESTCAD = null;
        ContenedorCEN contenedorCEN = null;

        List<ContenedorEN> contenedorEN = null;
        List<ContenedorDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                contenedorRESTCAD = new ContenedorRESTCAD (session);
                contenedorCEN = new ContenedorCEN (contenedorRESTCAD);

                // Data
                // TODO: paginación

                contenedorEN = contenedorCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (contenedorEN != null) {
                        returnValue = new List<ContenedorDTOA>();
                        foreach (ContenedorEN entry in contenedorEN)
                                returnValue.Add (ContenedorAssembler.Convert (entry, session));
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
// [Route("{idContenedor}", Name="GetOIDContenedor")]

[Route ("~/api/Contenedor/{idContenedor}")]

public HttpResponseMessage BuscarPorId (int idContenedor)
{
        // CAD, CEN, EN, returnValue
        ContenedorRESTCAD contenedorRESTCAD = null;
        ContenedorCEN contenedorCEN = null;
        ContenedorEN contenedorEN = null;
        ContenedorDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                contenedorRESTCAD = new ContenedorRESTCAD (session);
                contenedorCEN = new ContenedorCEN (contenedorRESTCAD);

                // Data
                contenedorEN = contenedorCEN.BuscarPorId (idContenedor);

                // Convert return
                if (contenedorEN != null) {
                        returnValue = ContenedorAssembler.Convert (contenedorEN, session);
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



// No pasa el slEnables: buscarContenedoresPorTipo

[HttpGet]

[Route ("~/api/Contenedor/BuscarContenedoresPorTipo")]

public HttpResponseMessage BuscarContenedoresPorTipo (     )
{
        // CAD, CEN, EN, returnValue

        ContenedorRESTCAD contenedorRESTCAD = null;
        ContenedorCEN contenedorCEN = null;


        System.Collections.Generic.List<ContenedorEN> en;

        System.Collections.Generic.List<ContenedorDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                contenedorRESTCAD = new ContenedorRESTCAD (session);
                contenedorCEN = new ContenedorCEN (contenedorRESTCAD);

                // CEN return



                en = contenedorCEN.BuscarContenedoresPorTipo (   ).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<ContenedorDTOA>();
                        foreach (ContenedorEN entry in en)
                                returnValue.Add (ContenedorAssembler.Convert (entry, session));
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


[Route ("~/api/Contenedor/Crear")]




public HttpResponseMessage Crear ( [FromBody] ContenedorDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        ContenedorRESTCAD contenedorRESTCAD = null;
        ContenedorCEN contenedorCEN = null;
        ContenedorDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                contenedorRESTCAD = new ContenedorRESTCAD (session);
                contenedorCEN = new ContenedorCEN (contenedorRESTCAD);

                // Create
                returnOID = contenedorCEN.Crear (
                        dto.Tipo                                                                                 //Atributo Primitivo: p_tipo
                        ,
                        //Atributo OID: p_punto
                        // attr.estaRelacionado: true
                        dto.Punto_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = ContenedorAssembler.Convert (contenedorRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDContenedor", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]

[Route ("~/api/PuntoReciclaje/{idPuntoReciclaje}/Contenedores/{idContenedor}/")]
[Route ("~/api/AccionReciclar/{idAccionReciclar}/ContenedorAccion/{idContenedor}/")]


public HttpResponseMessage Modificar (int idContenedor, [FromBody] ContenedorDTO dto)
{
        // CAD, CEN, returnValue
        ContenedorRESTCAD contenedorRESTCAD = null;
        ContenedorCEN contenedorCEN = null;
        ContenedorDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                contenedorRESTCAD = new ContenedorRESTCAD (session);
                contenedorCEN = new ContenedorCEN (contenedorRESTCAD);

                // Modify
                contenedorCEN.Modificar (idContenedor,
                        dto.Tipo
                        );

                // Return modified object
                returnValue = ContenedorAssembler.Convert (contenedorRESTCAD.ReadOIDDefault (idContenedor), session);

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

[Route ("~/api/PuntoReciclaje/{idPuntoReciclaje}/Contenedores/{idContenedor}/")]
[Route ("~/api/AccionReciclar/{idAccionReciclar}/ContenedorAccion/{idContenedor}/")]

public HttpResponseMessage Borrar (int p_contenedor_oid)
{
        // CAD, CEN
        ContenedorRESTCAD contenedorRESTCAD = null;
        ContenedorCEN contenedorCEN = null;

        try
        {
                SessionInitializeTransaction ();


                contenedorRESTCAD = new ContenedorRESTCAD (session);
                contenedorCEN = new ContenedorCEN (contenedorRESTCAD);

                contenedorCEN.Borrar (p_contenedor_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_ContenedorControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
