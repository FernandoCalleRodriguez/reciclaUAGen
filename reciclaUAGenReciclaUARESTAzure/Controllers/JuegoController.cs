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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_JuegoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Juego")]
public class JuegoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Juego/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        JuegoRESTCAD juegoRESTCAD = null;
        JuegoCEN juegoCEN = null;

        List<JuegoEN> juegoEN = null;
        List<JuegoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                juegoRESTCAD = new JuegoRESTCAD (session);
                juegoCEN = new JuegoCEN (juegoRESTCAD);

                // Data
                // TODO: paginación

                juegoEN = juegoCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (juegoEN != null) {
                        returnValue = new List<JuegoDTOA>();
                        foreach (JuegoEN entry in juegoEN)
                                returnValue.Add (JuegoAssembler.Convert (entry, session));
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
// [Route("{idJuego}", Name="GetOIDJuego")]

[Route ("~/api/Juego/{idJuego}")]

public HttpResponseMessage BuscarPorId (int idJuego)
{
        // CAD, CEN, EN, returnValue
        JuegoRESTCAD juegoRESTCAD = null;
        JuegoCEN juegoCEN = null;
        JuegoEN juegoEN = null;
        JuegoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                juegoRESTCAD = new JuegoRESTCAD (session);
                juegoCEN = new JuegoCEN (juegoRESTCAD);

                // Data
                juegoEN = juegoCEN.BuscarPorId (idJuego);

                // Convert return
                if (juegoEN != null) {
                        returnValue = JuegoAssembler.Convert (juegoEN, session);
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



// No pasa el slEnables: buscarJuegoPorUsuario

[HttpGet]

[Route ("~/api/Juego/BuscarJuegoPorUsuario")]

public HttpResponseMessage BuscarJuegoPorUsuario (int p_usuario)
{
        // CAD, CEN, EN, returnValue

        JuegoRESTCAD juegoRESTCAD = null;
        JuegoCEN juegoCEN = null;


        System.Collections.Generic.List<JuegoEN> en;

        System.Collections.Generic.List<JuegoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                juegoRESTCAD = new JuegoRESTCAD (session);
                juegoCEN = new JuegoCEN (juegoRESTCAD);

                // CEN return



                en = juegoCEN.BuscarJuegoPorUsuario (p_usuario).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<JuegoDTOA>();
                        foreach (JuegoEN entry in en)
                                returnValue.Add (JuegoAssembler.Convert (entry, session));
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


[Route ("~/api/Juego/Crear")]




public HttpResponseMessage Crear ( [FromBody] JuegoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        JuegoRESTCAD juegoRESTCAD = null;
        JuegoCEN juegoCEN = null;
        JuegoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                juegoRESTCAD = new JuegoRESTCAD (session);
                juegoCEN = new JuegoCEN (juegoRESTCAD);

                // Create
                returnOID = juegoCEN.Crear (
                        //Atributo OID: p_usuarios
                        // attr.estaRelacionado: true
                        dto.Usuarios_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = JuegoAssembler.Convert (juegoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDJuego", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}




[HttpPut]



[Route ("~/api/Juego/Modificar")]

public HttpResponseMessage Modificar (int idJuego, [FromBody] JuegoDTO dto)
{
        // CAD, CEN, returnValue
        JuegoRESTCAD juegoRESTCAD = null;
        JuegoCEN juegoCEN = null;
        JuegoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                juegoRESTCAD = new JuegoRESTCAD (session);
                juegoCEN = new JuegoCEN (juegoRESTCAD);

                // Modify
                juegoCEN.Modificar (idJuego,
                        dto.ItemActual
                        ,
                        dto.Aciertos
                        ,
                        dto.Fallos
                        ,
                        dto.Puntuacion
                        ,
                        dto.IntentosItemActual
                        ,
                        dto.Finalizado
                        ,
                        dto.NivelActual
                        );

                // Return modified object
                returnValue = JuegoAssembler.Convert (juegoRESTCAD.ReadOIDDefault (idJuego), session);

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


[Route ("~/api/Juego/Borrar")]

public HttpResponseMessage Borrar (int p_juego_oid)
{
        // CAD, CEN
        JuegoRESTCAD juegoRESTCAD = null;
        JuegoCEN juegoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                juegoRESTCAD = new JuegoRESTCAD (session);
                juegoCEN = new JuegoCEN (juegoRESTCAD);

                juegoCEN.Borrar (p_juego_oid);
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







[HttpPost]

[Route ("~/api/Juego/SiguienteItem")]

public HttpResponseMessage SiguienteItem (int p_oid, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_tipocontenedor)
{
        // CP, returnValue
        JuegoCP juegoCP = null;

        JuegoDTOA returnValue;
        JuegoEN en;

        try
        {
                SessionInitializeTransaction ();




                juegoCP = new JuegoCP (session);

                // Operation
                en = juegoCP.SiguienteItem (p_oid, p_tipocontenedor);
                SessionCommit ();

                // Convert return
                returnValue = JuegoAssembler.Convert (en, session);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_JuegoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
