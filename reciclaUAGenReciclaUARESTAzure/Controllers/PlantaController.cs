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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_PlantaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
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
                // TODO: paginaci�n

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





















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_PlantaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
