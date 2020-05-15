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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_MaterialControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/Material")]
public class MaterialController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Material/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;

        List<MaterialEN> materialEN = null;
        List<MaterialDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                // Data
                // TODO: paginación

                materialEN = materialCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (materialEN != null) {
                        returnValue = new List<MaterialDTOA>();
                        foreach (MaterialEN entry in materialEN)
                                returnValue.Add (MaterialAssembler.Convert (entry, session));
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
// [Route("{idMaterial}", Name="GetOIDMaterial")]

[Route ("~/api/Material/{idMaterial}")]

public HttpResponseMessage BuscarPorId (int idMaterial)
{
        // CAD, CEN, EN, returnValue
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;
        MaterialEN materialEN = null;
        MaterialDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                // Data
                materialEN = materialCEN.BuscarPorId (idMaterial);

                // Convert return
                if (materialEN != null) {
                        returnValue = MaterialAssembler.Convert (materialEN, session);
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



// No pasa el slEnables: buscarPorTipoContenedor

[HttpGet]

[Route ("~/api/Material/BuscarPorTipoContenedor")]

public HttpResponseMessage BuscarPorTipoContenedor (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum ? tipo_contenedor)
{
        // CAD, CEN, EN, returnValue

        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;


        System.Collections.Generic.List<MaterialEN> en;

        System.Collections.Generic.List<MaterialDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                // CEN return



                en = materialCEN.BuscarPorTipoContenedor (tipo_contenedor).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<MaterialDTOA>();
                        foreach (MaterialEN entry in en)
                                returnValue.Add (MaterialAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarMaterialesPorUsuario

[HttpGet]

[Route ("~/api/Material/BuscarMaterialesPorUsuario")]

public HttpResponseMessage BuscarMaterialesPorUsuario (int id_usuario)
{
        // CAD, CEN, EN, returnValue

        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;


        System.Collections.Generic.List<MaterialEN> en;

        System.Collections.Generic.List<MaterialDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                // CEN return



                en = materialCEN.BuscarMaterialesPorUsuario (id_usuario).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<MaterialDTOA>();
                        foreach (MaterialEN entry in en)
                                returnValue.Add (MaterialAssembler.Convert (entry, session));
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


[Route ("~/api/Material/Crear")]




public HttpResponseMessage Crear ( [FromBody] MaterialDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;
        MaterialDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                // Create
                returnOID = materialCEN.Crear (
                        //Atributo Primitivo: p_nombre
                        dto.Nombre,                                                                                                                                         //Atributo Primitivo: p_contenedor
                        dto.Contenedor,                                                                                                                                   //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = MaterialAssembler.Convert (materialRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDMaterial", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}




[HttpPut]



[Route ("~/api/Material/Modificar")]

public HttpResponseMessage Modificar (int idMaterial, [FromBody] MaterialDTO dto)
{
        // CAD, CEN, returnValue
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;
        MaterialDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                // Modify
                materialCEN.Modificar (idMaterial,
                        dto.Nombre
                        ,
                        dto.Contenedor
                        ,
                        dto.EsValido
                        );

                // Return modified object
                returnValue = MaterialAssembler.Convert (materialRESTCAD.ReadOIDDefault (idMaterial), session);

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


[Route ("~/api/Material/Borrar")]

public HttpResponseMessage Borrar (int p_material_oid)
{
        // CAD, CEN
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;

        try
        {
                SessionInitializeTransaction ();


                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                materialCEN.Borrar (p_material_oid);
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









/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_MaterialControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs

[HttpPost]
[Route ("~/api/Material/CrearCP")]
public HttpResponseMessage CrearCP ( [FromBody] MaterialDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;
        MaterialDTOA returnValue = null;
        MaterialCP materialCP = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();

                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);
                materialCP = new MaterialCP (session);

                // Create
                returnOID = materialCEN.Crear (dto.Nombre, dto.Contenedor, dto.Usuario_oid);
                materialCP.CrearAccionMaterial (returnOID);

                SessionCommit ();

                // Convert return
                returnValue = MaterialAssembler.Convert (materialRESTCAD.ReadOIDDefault (returnOID), session);
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
