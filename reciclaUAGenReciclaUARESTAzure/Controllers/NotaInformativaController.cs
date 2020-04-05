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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_NotaInformativaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
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

public HttpResponseMessage BuscarPorTitulo (       )
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



                en = notaInformativaCEN.BuscarPorTitulo (        ).ToList ();




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




















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_NotaInformativaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
