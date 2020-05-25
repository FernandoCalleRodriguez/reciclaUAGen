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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_PlantaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/Planta")]
public class PlantaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Planta/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        PlantaRESTCAD plantaRESTCAD = null;
        PlantaCEN plantaCEN = null;

        List<PlantaEN> plantaEN = null;
        List<PlantaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                plantaRESTCAD = new PlantaRESTCAD (session);
                plantaCEN = new PlantaCEN (plantaRESTCAD);

                // Data
                // TODO: paginación

                plantaEN = plantaCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (plantaEN != null) {
                        returnValue = new List<PlantaDTOA>();
                        foreach (PlantaEN entry in plantaEN)
                                returnValue.Add (PlantaAssembler.Convert (entry, session));
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
// [Route("{idPlanta}", Name="GetOIDPlanta")]

[Route ("~/api/Planta/{idPlanta}")]

public HttpResponseMessage BuscarPorId (int idPlanta)
{
        // CAD, CEN, EN, returnValue
        PlantaRESTCAD plantaRESTCAD = null;
        PlantaCEN plantaCEN = null;
        PlantaEN plantaEN = null;
        PlantaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                plantaRESTCAD = new PlantaRESTCAD (session);
                plantaCEN = new PlantaCEN (plantaRESTCAD);

                // Data
                plantaEN = plantaCEN.BuscarPorId (idPlanta);

                // Convert return
                if (plantaEN != null) {
                        returnValue = PlantaAssembler.Convert (plantaEN, session);
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


[Route ("~/api/Planta/Crear")]




public HttpResponseMessage Crear ( [FromBody] PlantaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PlantaRESTCAD plantaRESTCAD = null;
        PlantaCEN plantaCEN = null;
        PlantaDTOA returnValue = null;
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



                plantaRESTCAD = new PlantaRESTCAD (session);
                plantaCEN = new PlantaCEN (plantaRESTCAD);

                // Create
                returnOID = plantaCEN.Crear (
                        //Atributo Primitivo: p_planta
                        dto.Planta,                                                                                                                                       //Atributo OID: p_edificio
                        // attr.estaRelacionado: true
                        dto.Edificio_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = PlantaAssembler.Convert (plantaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDPlanta", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]



[Route ("~/api/Planta/Modificar")]

public HttpResponseMessage Modificar (int idPlanta, [FromBody] PlantaDTO dto)
{
        // CAD, CEN, returnValue
        PlantaRESTCAD plantaRESTCAD = null;
        PlantaCEN plantaCEN = null;
        PlantaDTOA returnValue = null;

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



                plantaRESTCAD = new PlantaRESTCAD (session);
                plantaCEN = new PlantaCEN (plantaRESTCAD);

                // Modify
                plantaCEN.Modificar (idPlanta,
                        dto.Planta
                        );

                // Return modified object
                returnValue = PlantaAssembler.Convert (plantaRESTCAD.ReadOIDDefault (idPlanta), session);

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


[Route ("~/api/Planta/Borrar")]

public HttpResponseMessage Borrar (int p_planta_oid)
{
        // CAD, CEN
        PlantaRESTCAD plantaRESTCAD = null;
        PlantaCEN plantaCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                plantaRESTCAD = new PlantaRESTCAD (session);
                plantaCEN = new PlantaCEN (plantaRESTCAD);

                plantaCEN.Borrar (p_planta_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_PlantaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
