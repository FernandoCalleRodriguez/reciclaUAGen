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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_MaterialControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
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


// No pasa el slEnables: buscarMaterialesPorValidar

[HttpGet]

[Route ("~/api/Material/BuscarMaterialesPorValidar")]

public HttpResponseMessage BuscarMaterialesPorValidar (            )
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



                en = materialCEN.BuscarMaterialesPorValidar (    ).ToList ();




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


// No pasa el slEnables: buscarMaterialesValidados

[HttpGet]

[Route ("~/api/Material/BuscarMaterialesValidados")]

public HttpResponseMessage BuscarMaterialesValidados (     )
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



                en = materialCEN.BuscarMaterialesValidados (     ).ToList ();




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


// No pasa el slEnables: buscarMaterialesPorValidarCount

[HttpGet]

[Route ("~/api/Material/BuscarMaterialesPorValidarCount")]

public HttpResponseMessage BuscarMaterialesPorValidarCount (       )
{
        // CAD, CEN, EN, returnValue

        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;


        int returnValue;

        try
        {
                SessionInitializeWithoutTransaction ();



                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);

                // CEN return



                returnValue = materialCEN.BuscarMaterialesPorValidarCount (      );




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






[HttpPost]

[Route ("~/api/Material/ValidarMaterial")]


public HttpResponseMessage ValidarMaterial (int p_oid)
{
        // CAD, CEN, returnValue
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;

        try
        {
                SessionInitializeTransaction ();


                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);


                // Operation
                materialCEN.ValidarMaterial (p_oid);
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

[Route ("~/api/Material/DescartarMaterial")]


public HttpResponseMessage DescartarMaterial (int p_oid)
{
        // CAD, CEN, returnValue
        MaterialRESTCAD materialRESTCAD = null;
        MaterialCEN materialCEN = null;

        try
        {
                SessionInitializeTransaction ();


                materialRESTCAD = new MaterialRESTCAD (session);
                materialCEN = new MaterialCEN (materialRESTCAD);


                // Operation
                materialCEN.DescartarMaterial (p_oid);
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






/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_MaterialControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
