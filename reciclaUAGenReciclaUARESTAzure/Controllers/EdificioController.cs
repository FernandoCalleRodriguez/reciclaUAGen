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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_EdificioControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Edificio")]
public class EdificioController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Edificio/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        EdificioRESTCAD edificioRESTCAD = null;
        EdificioCEN edificioCEN = null;

        List<EdificioEN> edificioEN = null;
        List<EdificioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                edificioRESTCAD = new EdificioRESTCAD (session);
                edificioCEN = new EdificioCEN (edificioRESTCAD);

                // Data
                // TODO: paginación

                edificioEN = edificioCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (edificioEN != null) {
                        returnValue = new List<EdificioDTOA>();
                        foreach (EdificioEN entry in edificioEN)
                                returnValue.Add (EdificioAssembler.Convert (entry, session));
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
// [Route("{idEdificio}", Name="GetOIDEdificio")]

[Route ("~/api/Edificio/{idEdificio}")]

public HttpResponseMessage BuscarPorId (int idEdificio)
{
        // CAD, CEN, EN, returnValue
        EdificioRESTCAD edificioRESTCAD = null;
        EdificioCEN edificioCEN = null;
        EdificioEN edificioEN = null;
        EdificioDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                edificioRESTCAD = new EdificioRESTCAD (session);
                edificioCEN = new EdificioCEN (edificioRESTCAD);

                // Data
                edificioEN = edificioCEN.BuscarPorId (idEdificio);

                // Convert return
                if (edificioEN != null) {
                        returnValue = EdificioAssembler.Convert (edificioEN, session);
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



// No pasa el slEnables: buscarEdificioPorPlanta

[HttpGet]

[Route ("~/api/Edificio/BuscarEdificioPorPlanta")]

public HttpResponseMessage BuscarEdificioPorPlanta (int planta_id)
{
        // CAD, CEN, EN, returnValue

        EdificioRESTCAD edificioRESTCAD = null;
        EdificioCEN edificioCEN = null;


        EdificioEN en;

        EdificioDTOA returnValue;

        try
        {
                SessionInitializeWithoutTransaction ();



                edificioRESTCAD = new EdificioRESTCAD (session);
                edificioCEN = new EdificioCEN (edificioRESTCAD);

                // CEN return



                en = edificioCEN.BuscarEdificioPorPlanta (planta_id);




                // Convert return
                returnValue = EdificioAssembler.Convert (en, session);
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




















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_EdificioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
