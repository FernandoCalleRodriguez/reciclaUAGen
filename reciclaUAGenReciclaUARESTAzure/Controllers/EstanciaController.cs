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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_EstanciaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Estancia")]
public class EstanciaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Estancia/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        EstanciaRESTCAD estanciaRESTCAD = null;
        EstanciaCEN estanciaCEN = null;

        List<EstanciaEN> estanciaEN = null;
        List<EstanciaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                estanciaRESTCAD = new EstanciaRESTCAD (session);
                estanciaCEN = new EstanciaCEN (estanciaRESTCAD);

                // Data
                // TODO: paginación

                estanciaEN = estanciaCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (estanciaEN != null) {
                        returnValue = new List<EstanciaDTOA>();
                        foreach (EstanciaEN entry in estanciaEN)
                                returnValue.Add (EstanciaAssembler.Convert (entry, session));
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
// [Route("{idEstancia}", Name="GetOIDEstancia")]

[Route ("~/api/Estancia/{idEstancia}")]

public HttpResponseMessage BuscarPorId (string idEstancia)
{
        // CAD, CEN, EN, returnValue
        EstanciaRESTCAD estanciaRESTCAD = null;
        EstanciaCEN estanciaCEN = null;
        EstanciaEN estanciaEN = null;
        EstanciaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                estanciaRESTCAD = new EstanciaRESTCAD (session);
                estanciaCEN = new EstanciaCEN (estanciaRESTCAD);

                // Data
                estanciaEN = estanciaCEN.BuscarPorId (idEstancia);

                // Convert return
                if (estanciaEN != null) {
                        returnValue = EstanciaAssembler.Convert (estanciaEN, session);
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



// No pasa el slEnables: buscarEstanciasPorEdificio

[HttpGet]

[Route ("~/api/Estancia/BuscarEstanciasPorEdificio")]

public HttpResponseMessage BuscarEstanciasPorEdificio (int id_edificio)
{
        // CAD, CEN, EN, returnValue

        EstanciaRESTCAD estanciaRESTCAD = null;
        EstanciaCEN estanciaCEN = null;


        System.Collections.Generic.List<EstanciaEN> en;

        System.Collections.Generic.List<EstanciaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                estanciaRESTCAD = new EstanciaRESTCAD (session);
                estanciaCEN = new EstanciaCEN (estanciaRESTCAD);

                // CEN return



                en = estanciaCEN.BuscarEstanciasPorEdificio (id_edificio).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<EstanciaDTOA>();
                        foreach (EstanciaEN entry in en)
                                returnValue.Add (EstanciaAssembler.Convert (entry, session));
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




















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_EstanciaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
