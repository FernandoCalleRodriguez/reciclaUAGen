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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_EdificioControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
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



[HttpPost]


[Route ("~/api/Edificio/Crear")]




public HttpResponseMessage Crear ( [FromBody] EdificioDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        EdificioRESTCAD edificioRESTCAD = null;
        EdificioCEN edificioCEN = null;
        EdificioDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                edificioRESTCAD = new EdificioRESTCAD (session);
                edificioCEN = new EdificioCEN (edificioRESTCAD);

                // Create
                returnOID = edificioCEN.Crear (
                        //Atributo Primitivo: p_nombre
                        dto.Nombre,                                                                                                                                         //Atributo Primitivo: p_id
                        dto.Id);
                SessionCommit ();

                // Convert return
                returnValue = EdificioAssembler.Convert (edificioRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDEdificio", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]



[Route ("~/api/Edificio/Modificar")]

public HttpResponseMessage Modificar (int idEdificio, [FromBody] EdificioDTO dto)
{
        // CAD, CEN, returnValue
        EdificioRESTCAD edificioRESTCAD = null;
        EdificioCEN edificioCEN = null;
        EdificioDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                edificioRESTCAD = new EdificioRESTCAD (session);
                edificioCEN = new EdificioCEN (edificioRESTCAD);

                // Modify
                edificioCEN.Modificar (idEdificio,
                        dto.Nombre
                        );

                // Return modified object
                returnValue = EdificioAssembler.Convert (edificioRESTCAD.ReadOIDDefault (idEdificio), session);

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


[Route ("~/api/Edificio/Borrar")]

public HttpResponseMessage Borrar (int p_edificio_oid)
{
        // CAD, CEN
        EdificioRESTCAD edificioRESTCAD = null;
        EdificioCEN edificioCEN = null;

        try
        {
                SessionInitializeTransaction ();


                edificioRESTCAD = new EdificioRESTCAD (session);
                edificioCEN = new EdificioCEN (edificioRESTCAD);

                edificioCEN.Borrar (p_edificio_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_EdificioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
