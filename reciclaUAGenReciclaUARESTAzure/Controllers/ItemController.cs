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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_ItemControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Item")]
public class ItemController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Item/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;

        List<ItemEN> itemEN = null;
        List<ItemDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);

                // Data
                // TODO: paginación

                itemEN = itemCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (itemEN != null) {
                        returnValue = new List<ItemDTOA>();
                        foreach (ItemEN entry in itemEN)
                                returnValue.Add (ItemAssembler.Convert (entry, session));
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
// [Route("{idItem}", Name="GetOIDItem")]

[Route ("~/api/Item/{idItem}")]

public HttpResponseMessage BuscarPorId (int idItem)
{
        // CAD, CEN, EN, returnValue
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;
        ItemEN itemEN = null;
        ItemDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);

                // Data
                itemEN = itemCEN.BuscarPorId (idItem);

                // Convert return
                if (itemEN != null) {
                        returnValue = ItemAssembler.Convert (itemEN, session);
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



// No pasa el slEnables: buscarItemsPorUsuario

[HttpGet]

[Route ("~/api/Item/BuscarItemsPorUsuario")]

public HttpResponseMessage BuscarItemsPorUsuario (int id_usuario)
{
        // CAD, CEN, EN, returnValue

        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;


        System.Collections.Generic.List<ItemEN> en;

        System.Collections.Generic.List<ItemDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);

                // CEN return



                en = itemCEN.BuscarItemsPorUsuario (id_usuario).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<ItemDTOA>();
                        foreach (ItemEN entry in en)
                                returnValue.Add (ItemAssembler.Convert (entry, session));
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


[Route ("~/api/Item/Crear")]




public HttpResponseMessage Crear ( [FromBody] ItemDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;
        ItemDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);

                // Create
                returnOID = itemCEN.Crear (
                        //Atributo Primitivo: p_nombre
                        dto.Nombre,                                                                                                                                         //Atributo Primitivo: p_descripcion
                        dto.Descripcion,                                                                                                                                    //Atributo Primitivo: p_imagen
                        dto.Imagen,                                                                                                                                         //Atributo Primitivo: p_esValido
                        dto.EsValido,                                                                                                                                     //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        ,                                         //Atributo OID: p_material
                        // attr.estaRelacionado: true
                        dto.Material_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = ItemAssembler.Convert (itemRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDItem", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]



[Route ("~/api/Item/Modificar")]

public HttpResponseMessage Modificar (int idItem, [FromBody] ItemDTO dto)
{
        // CAD, CEN, returnValue
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;
        ItemDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);

                // Modify
                itemCEN.Modificar (idItem,
                        dto.Nombre
                        ,
                        dto.Descripcion
                        ,
                        dto.Imagen
                        ,
                        dto.EsValido
                        );

                // Return modified object
                returnValue = ItemAssembler.Convert (itemRESTCAD.ReadOIDDefault (idItem), session);

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


[Route ("~/api/Item/Borrar")]

public HttpResponseMessage Borrar (int p_item_oid)
{
        // CAD, CEN
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;

        try
        {
                SessionInitializeTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);

                itemCEN.Borrar (p_item_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_ItemControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
