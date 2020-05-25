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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_NivelControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Nivel")]
public class NivelController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Nivel/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;

        List<NivelEN> nivelEN = null;
        List<NivelDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                // Data
                // TODO: paginación

                nivelEN = nivelCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (nivelEN != null) {
                        returnValue = new List<NivelDTOA>();
                        foreach (NivelEN entry in nivelEN)
                                returnValue.Add (NivelAssembler.Convert (entry, session));
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





[Route ("~/api/Nivel/NivelItem")]

public HttpResponseMessage NivelItem (int idItem)
{
        // CAD, EN
        ItemRESTCAD itemRESTCAD = null;
        ItemEN itemEN = null;

        // returnValue
        NivelEN en = null;
        NivelDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);

                // Exists Item
                itemEN = itemRESTCAD.ReadOIDDefault (idItem);
                if (itemEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Item#" + idItem + " not found"));

                // Rol
                // TODO: paginación


                en = itemRESTCAD.NivelItem (idItem);



                // Convert return
                if (en != null) {
                        returnValue = NivelAssembler.Convert (en, session);
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}







[HttpGet]
// [Route("{idNivel}", Name="GetOIDNivel")]

[Route ("~/api/Nivel/{idNivel}")]

public HttpResponseMessage BuscarPorId (int idNivel)
{
        // CAD, CEN, EN, returnValue
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;
        NivelEN nivelEN = null;
        NivelDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                // Data
                nivelEN = nivelCEN.BuscarPorId (idNivel);

                // Convert return
                if (nivelEN != null) {
                        returnValue = NivelAssembler.Convert (nivelEN, session);
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





















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_NivelControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
