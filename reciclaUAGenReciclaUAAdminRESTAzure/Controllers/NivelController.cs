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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_NivelControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
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
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



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
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                new UsuarioCEN ().CheckToken (token);


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
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



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



// No pasa el slEnables: buscarNivelCount

[HttpGet]

[Route ("~/api/Nivel/BuscarNivelCount")]

public HttpResponseMessage BuscarNivelCount (      )
{
        // CAD, CEN, EN, returnValue

        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;


        int returnValue;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);




                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                // CEN return



                returnValue = nivelCEN.BuscarNivelCount (        );




                // Convert return
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


[Route ("~/api/Nivel/Crear")]




public HttpResponseMessage Crear ( [FromBody] NivelDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;
        NivelDTOA returnValue = null;
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



                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                // Create
                returnOID = nivelCEN.Crear (
                        //Atributo Primitivo: p_numero
                        dto.Numero,                                                                                                                                         //Atributo Primitivo: p_puntuacion
                        dto.Puntuacion);
                SessionCommit ();

                // Convert return
                returnValue = NivelAssembler.Convert (nivelRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDNivel", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]



[Route ("~/api/Nivel/Modificar")]

public HttpResponseMessage Modificar (int idNivel, [FromBody] NivelDTO dto)
{
        // CAD, CEN, returnValue
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;
        NivelDTOA returnValue = null;

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



                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                // Modify
                nivelCEN.Modificar (idNivel,
                        dto.Numero
                        ,
                        dto.Puntuacion
                        );

                // Return modified object
                returnValue = NivelAssembler.Convert (nivelRESTCAD.ReadOIDDefault (idNivel), session);

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


[Route ("~/api/Nivel/Borrar")]

public HttpResponseMessage Borrar (int p_nivel_oid)
{
        // CAD, CEN
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                nivelCEN.Borrar (p_nivel_oid);
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





[HttpPut]

[Route ("~/api/AccionReciclar/{idAccionReciclar}/ItemAccion/{idItem}/NivelItem/AsignarItems")]

public HttpResponseMessage AsignarItems (int p_nivel_oid, System.Collections.Generic.IList<int> p_item_oids)
{
        // CAD, CEN, returnValue
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                // Relationer
                nivelCEN.AsignarItems (p_nivel_oid, p_item_oids);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK);
}



[HttpPut]

[Route ("~/api/AccionReciclar/{idAccionReciclar}/ItemAccion/{idItem}/NivelItem/DesasignarItems")]

public HttpResponseMessage DesasignarItems (int p_nivel_oid, System.Collections.Generic.IList<int> p_item_oids)
{
        // CAD, CEN, returnValue
        NivelRESTCAD nivelRESTCAD = null;
        NivelCEN nivelCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new UsuarioCEN ().CheckToken (token);



                nivelRESTCAD = new NivelRESTCAD (session);
                nivelCEN = new NivelCEN (nivelRESTCAD);

                // UnRelationer
                nivelCEN.DesasignarItems (p_nivel_oid, p_item_oids);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK);
}







/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_NivelControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
[HttpGet]
[Route ("~/api/Nivel/NivelCount")]
public int NivelCount ()
{
        return new NivelCEN ().BuscarTodos (0, -1).Count ();
}
/*PROTECTED REGION END*/
}
}
