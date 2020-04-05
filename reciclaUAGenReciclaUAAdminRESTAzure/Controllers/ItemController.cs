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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_ItemControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
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


// No pasa el slEnables: buscarItemsPorValidar

[HttpGet]

[Route ("~/api/Item/BuscarItemsPorValidar")]

public HttpResponseMessage BuscarItemsPorValidar (         )
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



                en = itemCEN.BuscarItemsPorValidar (     ).ToList ();




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


// No pasa el slEnables: buscarItemsValidados

[HttpGet]

[Route ("~/api/Item/BuscarItemsValidados")]

public HttpResponseMessage BuscarItemsValidados (          )
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



                en = itemCEN.BuscarItemsValidados (      ).ToList ();




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
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , dto.Descripcion                                                                                                                                                //Atributo Primitivo: p_descripcion
                        , dto.Imagen                                                                                                                                                     //Atributo Primitivo: p_imagen
                        , dto.EsValido                                                                                                                                                   //Atributo Primitivo: p_esValido
                        ,
                        //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        ,
                        //Atributo OID: p_material
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

[Route ("~/api/AccionReciclar/{idAccionReciclar}/ItemAccion/{idItem}/")]


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

[Route ("~/api/AccionReciclar/{idAccionReciclar}/ItemAccion/{idItem}/")]

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






[HttpPost]

[Route ("~/api/Item/ValidarItem")]


public HttpResponseMessage ValidarItem (int p_oid)
{
        // CAD, CEN, returnValue
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;

        try
        {
                SessionInitializeTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);


                // Operation
                itemCEN.ValidarItem (p_oid);
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



[HttpPost]

[Route ("~/api/Item/DescartarItem")]


public HttpResponseMessage DescartarItem (int p_oid)
{
        // CAD, CEN, returnValue
        ItemRESTCAD itemRESTCAD = null;
        ItemCEN itemCEN = null;

        try
        {
                SessionInitializeTransaction ();


                itemRESTCAD = new ItemRESTCAD (session);
                itemCEN = new ItemCEN (itemRESTCAD);


                // Operation
                itemCEN.DescartarItem (p_oid);
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






/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_ItemControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
