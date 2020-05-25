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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_PuntoReciclajeControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/PuntoReciclaje")]
public class PuntoReciclajeController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/PuntoReciclaje/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;

        List<PuntoReciclajeEN> puntoReciclajeEN = null;
        List<PuntoReciclajeDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // Data
                // TODO: paginación

                puntoReciclajeEN = puntoReciclajeCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (puntoReciclajeEN != null) {
                        returnValue = new List<PuntoReciclajeDTOA>();
                        foreach (PuntoReciclajeEN entry in puntoReciclajeEN)
                                returnValue.Add (PuntoReciclajeAssembler.Convert (entry, session));
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
// [Route("{idPuntoReciclaje}", Name="GetOIDPuntoReciclaje")]

[Route ("~/api/PuntoReciclaje/{idPuntoReciclaje}")]

public HttpResponseMessage BuscarPorId (int idPuntoReciclaje)
{
        // CAD, CEN, EN, returnValue
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;
        PuntoReciclajeEN puntoReciclajeEN = null;
        PuntoReciclajeDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // Data
                puntoReciclajeEN = puntoReciclajeCEN.BuscarPorId (idPuntoReciclaje);

                // Convert return
                if (puntoReciclajeEN != null) {
                        returnValue = PuntoReciclajeAssembler.Convert (puntoReciclajeEN, session);
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



// No pasa el slEnables: buscarPuntosPorEdificio

[HttpGet]

[Route ("~/api/PuntoReciclaje/BuscarPuntosPorEdificio")]

public HttpResponseMessage BuscarPuntosPorEdificio (int ? id_edificio)
{
        // CAD, CEN, EN, returnValue

        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;


        System.Collections.Generic.List<PuntoReciclajeEN> en;

        System.Collections.Generic.List<PuntoReciclajeDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // CEN return



                en = puntoReciclajeCEN.BuscarPuntosPorEdificio (id_edificio).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PuntoReciclajeDTOA>();
                        foreach (PuntoReciclajeEN entry in en)
                                returnValue.Add (PuntoReciclajeAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPuntosPorEstancia

[HttpGet]

[Route ("~/api/PuntoReciclaje/BuscarPuntosPorEstancia")]

public HttpResponseMessage BuscarPuntosPorEstancia (string id_estancia)
{
        // CAD, CEN, EN, returnValue

        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;


        System.Collections.Generic.List<PuntoReciclajeEN> en;

        System.Collections.Generic.List<PuntoReciclajeDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // CEN return



                en = puntoReciclajeCEN.BuscarPuntosPorEstancia (id_estancia).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PuntoReciclajeDTOA>();
                        foreach (PuntoReciclajeEN entry in en)
                                returnValue.Add (PuntoReciclajeAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPuntosPorPlanta

[HttpGet]

[Route ("~/api/PuntoReciclaje/BuscarPuntosPorPlanta")]

public HttpResponseMessage BuscarPuntosPorPlanta (int? id_edificio, int ? num_planta)
{
        // CAD, CEN, EN, returnValue

        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;


        System.Collections.Generic.List<PuntoReciclajeEN> en;

        System.Collections.Generic.List<PuntoReciclajeDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // CEN return



                en = puntoReciclajeCEN.BuscarPuntosPorPlanta (id_edificio, num_planta).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PuntoReciclajeDTOA>();
                        foreach (PuntoReciclajeEN entry in en)
                                returnValue.Add (PuntoReciclajeAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPuntosPorUsuario

[HttpGet]

[Route ("~/api/PuntoReciclaje/BuscarPuntosPorUsuario")]

public HttpResponseMessage BuscarPuntosPorUsuario (        )
{
        // CAD, CEN, EN, returnValue

        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;


        System.Collections.Generic.List<PuntoReciclajeEN> en;

        System.Collections.Generic.List<PuntoReciclajeDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // CEN return



                en = puntoReciclajeCEN.BuscarPuntosPorUsuario (id).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PuntoReciclajeDTOA>();
                        foreach (PuntoReciclajeEN entry in en)
                                returnValue.Add (PuntoReciclajeAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPuntoPorContenedor

[HttpGet]

[Route ("~/api/PuntoReciclaje/BuscarPuntoPorContenedor")]

public HttpResponseMessage BuscarPuntoPorContenedor (int contenedor_id)
{
        // CAD, CEN, EN, returnValue

        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;


        PuntoReciclajeEN en;

        PuntoReciclajeDTOA returnValue;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // CEN return



                en = puntoReciclajeCEN.BuscarPuntoPorContenedor (contenedor_id);




                // Convert return
                returnValue = PuntoReciclajeAssembler.Convert (en, session);
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


[Route ("~/api/PuntoReciclaje/Crear")]




public HttpResponseMessage Crear ( [FromBody] PuntoReciclajeDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;
        PuntoReciclajeDTOA returnValue = null;
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



                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // Create
                returnOID = puntoReciclajeCEN.Crear (
                        //Atributo Primitivo: p_latitud
                        dto.Latitud,                                                                                                                                        //Atributo Primitivo: p_longitud
                        dto.Longitud,                                                                                                                                     //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        ,                                         //Atributo OID: p_estancia
                        // attr.estaRelacionado: true
                        dto.Estancia_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = PuntoReciclajeAssembler.Convert (puntoReciclajeRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDPuntoReciclaje", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}




[HttpPut]



[Route ("~/api/PuntoReciclaje/Modificar")]

public HttpResponseMessage Modificar (int idPuntoReciclaje, [FromBody] PuntoReciclajeDTO dto)
{
        // CAD, CEN, returnValue
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;
        PuntoReciclajeDTOA returnValue = null;

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



                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                // Modify
                puntoReciclajeCEN.Modificar (idPuntoReciclaje,
                        dto.Latitud
                        ,
                        dto.Longitud
                        ,
                        dto.EsValido
                        );

                // Return modified object
                returnValue = PuntoReciclajeAssembler.Convert (puntoReciclajeRESTCAD.ReadOIDDefault (idPuntoReciclaje), session);

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


[Route ("~/api/PuntoReciclaje/Borrar")]

public HttpResponseMessage Borrar (int p_puntoreciclaje_oid)
{
        // CAD, CEN
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);

                puntoReciclajeCEN.Borrar (p_puntoreciclaje_oid);
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

[Route ("~/api/PuntoReciclaje/BuscarPuntosCercanos")]


public HttpResponseMessage BuscarPuntosCercanos (double p_latitud, double p_longitud, int p_limit)
{
        // CAD, CEN, returnValue
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;

        System.Collections.Generic.List<PuntoReciclajeDTOA> returnValue = null;
        System.Collections.Generic.List<PuntoReciclajeEN> en;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);


                // Operation
                en = puntoReciclajeCEN.BuscarPuntosCercanos (p_latitud, p_longitud, p_limit).ToList ();
                SessionCommit ();

                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PuntoReciclajeDTOA>();
                        foreach (PuntoReciclajeEN entry in en)
                                returnValue.Add (PuntoReciclajeAssembler.Convert (entry, session));
                }
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



[HttpPost]

[Route ("~/api/PuntoReciclaje/BuscarPuntosCercanosPorContenedor")]


public HttpResponseMessage BuscarPuntosCercanosPorContenedor (double p_latitud, double p_longitud, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_tipo, int p_limit)
{
        // CAD, CEN, returnValue
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;

        System.Collections.Generic.List<PuntoReciclajeDTOA> returnValue = null;
        System.Collections.Generic.List<PuntoReciclajeEN> en;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);


                // Operation
                en = puntoReciclajeCEN.BuscarPuntosCercanosPorContenedor (p_latitud, p_longitud, p_tipo, p_limit).ToList ();
                SessionCommit ();

                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PuntoReciclajeDTOA>();
                        foreach (PuntoReciclajeEN entry in en)
                                returnValue.Add (PuntoReciclajeAssembler.Convert (entry, session));
                }
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






/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_PuntoReciclajeControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
[HttpPost]
[Route ("~/api/PuntoReciclaje/CrearCP")]
public HttpResponseMessage CrearCP ( [FromBody] PuntoReciclajeDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PuntoReciclajeRESTCAD puntoReciclajeRESTCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;
        PuntoReciclajeDTOA returnValue = null;
        PuntoReciclajeCP puntoCP = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                puntoReciclajeRESTCAD = new PuntoReciclajeRESTCAD (session);
                puntoReciclajeCEN = new PuntoReciclajeCEN (puntoReciclajeRESTCAD);
                puntoCP = new PuntoReciclajeCP (session);

                // Create
                returnOID = puntoReciclajeCEN.Crear (dto.Latitud, dto.Longitud, dto.Usuario_oid, dto.Estancia_oid);
                puntoCP.CrearAccionPunto (returnOID);
                SessionCommit ();

                // Convert return
                returnValue = PuntoReciclajeAssembler.Convert (puntoReciclajeRESTCAD.ReadOIDDefault (returnOID), session);
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

        return response;
}
/*PROTECTED REGION END*/
}
}
