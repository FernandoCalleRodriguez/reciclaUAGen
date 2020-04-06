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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_EstanciaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
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









[HttpPut]



[Route ("~/api/Estancia/Modificar")]

public HttpResponseMessage Modificar (string idEstancia, [FromBody] EstanciaDTO dto)
{
        // CAD, CEN, returnValue
        EstanciaRESTCAD estanciaRESTCAD = null;
        EstanciaCEN estanciaCEN = null;
        EstanciaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                estanciaRESTCAD = new EstanciaRESTCAD (session);
                estanciaCEN = new EstanciaCEN (estanciaRESTCAD);

                // Modify
                estanciaCEN.Modificar (idEstancia,
                        dto.Actividad
                        ,
                        dto.Latitud
                        ,
                        dto.Longitud
                        ,
                        dto.Nombre
                        );

                // Return modified object
                returnValue = EstanciaAssembler.Convert (estanciaRESTCAD.ReadOIDDefault (idEstancia), session);

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


[Route ("~/api/Estancia/Borrar")]

public HttpResponseMessage Borrar (string p_estancia_oid)
{
        // CAD, CEN
        EstanciaRESTCAD estanciaRESTCAD = null;
        EstanciaCEN estanciaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                estanciaRESTCAD = new EstanciaRESTCAD (session);
                estanciaCEN = new EstanciaCEN (estanciaRESTCAD);

                estanciaCEN.Borrar (p_estancia_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_EstanciaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
