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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_AccionReciclarControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/AccionReciclar")]
public class AccionReciclarController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/AccionReciclar/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;

        List<AccionReciclarEN> accionReciclarEN = null;
        List<AccionReciclarDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // Data
                // TODO: paginación

                accionReciclarEN = accionReciclarCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (accionReciclarEN != null) {
                        returnValue = new List<AccionReciclarDTOA>();
                        foreach (AccionReciclarEN entry in accionReciclarEN)
                                returnValue.Add (AccionReciclarAssembler.Convert (entry, session));
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
// [Route("{idAccionReciclar}", Name="GetOIDAccionReciclar")]

[Route ("~/api/AccionReciclar/{idAccionReciclar}")]

public HttpResponseMessage BuscarPorId (int idAccionReciclar)
{
        // CAD, CEN, EN, returnValue
        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;
        AccionReciclarEN accionReciclarEN = null;
        AccionReciclarDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // Data
                accionReciclarEN = accionReciclarCEN.BuscarPorId (idAccionReciclar);

                // Convert return
                if (accionReciclarEN != null) {
                        returnValue = AccionReciclarAssembler.Convert (accionReciclarEN, session);
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



// No pasa el slEnables: buscarAccionesReciclajePorUsuario

[HttpGet]

[Route ("~/api/AccionReciclar/BuscarAccionesReciclajePorUsuario")]

public HttpResponseMessage BuscarAccionesReciclajePorUsuario (int id_usuario)
{
        // CAD, CEN, EN, returnValue

        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;


        System.Collections.Generic.List<AccionReciclarEN> en;

        System.Collections.Generic.List<AccionReciclarDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // CEN return



                en = accionReciclarCEN.BuscarAccionesReciclajePorUsuario (id_usuario).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionReciclarDTOA>();
                        foreach (AccionReciclarEN entry in en)
                                returnValue.Add (AccionReciclarAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPorAutor

[HttpGet]

[Route ("~/api/AccionReciclar/BuscarPorAutor")]

public HttpResponseMessage BuscarPorAutor (int ? p_user_id)
{
        // CAD, CEN, EN, returnValue

        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;


        System.Collections.Generic.List<AccionReciclarEN> en;

        System.Collections.Generic.List<AccionReciclarDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // CEN return



                en = accionReciclarCEN.BuscarPorAutor (p_user_id).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionReciclarDTOA>();
                        foreach (AccionReciclarEN entry in en)
                                returnValue.Add (AccionReciclarAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPorFecha

[HttpGet]

[Route ("~/api/AccionReciclar/BuscarPorFecha")]

public HttpResponseMessage BuscarPorFecha (Nullable<DateTime> p_date)
{
        // CAD, CEN, EN, returnValue

        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;


        System.Collections.Generic.List<AccionReciclarEN> en;

        System.Collections.Generic.List<AccionReciclarDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // CEN return



                en = accionReciclarCEN.BuscarPorFecha (p_date).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionReciclarDTOA>();
                        foreach (AccionReciclarEN entry in en)
                                returnValue.Add (AccionReciclarAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarPorMaterial

[HttpGet]

[Route ("~/api/AccionReciclar/BuscarPorMaterial")]

public HttpResponseMessage BuscarPorMaterial (string p_material)
{
        // CAD, CEN, EN, returnValue

        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;


        System.Collections.Generic.List<AccionReciclarEN> en;

        System.Collections.Generic.List<AccionReciclarDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // CEN return



                en = accionReciclarCEN.BuscarPorMaterial (p_material).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<AccionReciclarDTOA>();
                        foreach (AccionReciclarEN entry in en)
                                returnValue.Add (AccionReciclarAssembler.Convert (entry, session));
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


[Route ("~/api/AccionReciclar/Crear")]




public HttpResponseMessage Crear ( [FromBody] AccionReciclarDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;
        AccionReciclarDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // Create
                returnOID = accionReciclarCEN.Crear (

                        //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        , dto.Fecha                                                                                                                                                      //Atributo Primitivo: p_fecha
                        ,
                        //Atributo OID: p_contenedor
                        // attr.estaRelacionado: true
                        dto.Contenedor_oid                 // association role

                        ,
                        //Atributo OID: p_item
                        // attr.estaRelacionado: true
                        dto.Item_oid                 // association role

                        , dto.Cantidad                                                                                                                                                   //Atributo Primitivo: p_cantidad
                        );
                SessionCommit ();

                // Convert return
                returnValue = AccionReciclarAssembler.Convert (accionReciclarRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDAccionReciclar", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]

[Route ("~/api/AccionReciclar/{idAccionReciclar}/")]


public HttpResponseMessage Modificar (int idAccionReciclar, [FromBody] AccionReciclarDTO dto)
{
        // CAD, CEN, returnValue
        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;
        AccionReciclarDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                // Modify
                accionReciclarCEN.Modificar (idAccionReciclar,
                        dto.Fecha
                        ,
                        dto.Cantidad
                        );

                // Return modified object
                returnValue = AccionReciclarAssembler.Convert (accionReciclarRESTCAD.ReadOIDDefault (idAccionReciclar), session);

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

[Route ("~/api/AccionReciclar/{idAccionReciclar}/")]

public HttpResponseMessage Borrar (int p_accionreciclar_oid)
{
        // CAD, CEN
        AccionReciclarRESTCAD accionReciclarRESTCAD = null;
        AccionReciclarCEN accionReciclarCEN = null;

        try
        {
                SessionInitializeTransaction ();


                accionReciclarRESTCAD = new AccionReciclarRESTCAD (session);
                accionReciclarCEN = new AccionReciclarCEN (accionReciclarRESTCAD);

                accionReciclarCEN.Borrar (p_accionreciclar_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_AccionReciclarControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
