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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_TipoAccionControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/TipoAccion")]
public class TipoAccionController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/TipoAccion/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;

        List<TipoAccionEN> tipoAccionEN = null;
        List<TipoAccionDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);

                // Data
                // TODO: paginación

                tipoAccionEN = tipoAccionCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (tipoAccionEN != null) {
                        returnValue = new List<TipoAccionDTOA>();
                        foreach (TipoAccionEN entry in tipoAccionEN)
                                returnValue.Add (TipoAccionAssembler.Convert (entry, session));
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
// [Route("{idTipoAccion}", Name="GetOIDTipoAccion")]

[Route ("~/api/TipoAccion/{idTipoAccion}")]

public HttpResponseMessage BuscarPorId (int idTipoAccion)
{
        // CAD, CEN, EN, returnValue
        TipoAccionRESTCAD tipoAccionRESTCAD = null;
        TipoAccionCEN tipoAccionCEN = null;
        TipoAccionEN tipoAccionEN = null;
        TipoAccionDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                tipoAccionRESTCAD = new TipoAccionRESTCAD (session);
                tipoAccionCEN = new TipoAccionCEN (tipoAccionRESTCAD);

                // Data
                tipoAccionEN = tipoAccionCEN.BuscarPorId (idTipoAccion);

                // Convert return
                if (tipoAccionEN != null) {
                        returnValue = TipoAccionAssembler.Convert (tipoAccionEN, session);
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





















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_TipoAccionControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
