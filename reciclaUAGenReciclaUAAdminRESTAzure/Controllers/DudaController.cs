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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_DudaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/Duda")]
public class DudaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Duda/BuscarTodos")]
public HttpResponseMessage BuscarTodos ()
{
        // CAD, CEN, EN, returnValue
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;

        List<DudaEN> dudaEN = null;
        List<DudaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                // Data
                // TODO: paginación

                dudaEN = dudaCEN.BuscarTodos (0, -1).ToList ();

                // Convert return
                if (dudaEN != null) {
                        returnValue = new List<DudaDTOA>();
                        foreach (DudaEN entry in dudaEN)
                                returnValue.Add (DudaAssembler.Convert (entry, session));
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





[Route ("~/api/Duda/DudaRespuesta")]

public HttpResponseMessage DudaRespuesta (int idRespuesta)
{
        // CAD, EN
        RespuestaRESTCAD respuestaRESTCAD = null;
        RespuestaEN respuestaEN = null;

        // returnValue
        DudaEN en = null;
        DudaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                respuestaRESTCAD = new RespuestaRESTCAD (session);

                // Exists Respuesta
                respuestaEN = respuestaRESTCAD.ReadOIDDefault (idRespuesta);
                if (respuestaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Respuesta#" + idRespuesta + " not found"));

                // Rol
                // TODO: paginación


                en = respuestaRESTCAD.DudaRespuesta (idRespuesta);



                // Convert return
                if (en != null) {
                        returnValue = DudaAssembler.Convert (en, session);
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
// [Route("{idDuda}", Name="GetOIDDuda")]

[Route ("~/api/Duda/{idDuda}")]

public HttpResponseMessage BuscarPorId (int idDuda)
{
        // CAD, CEN, EN, returnValue
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;
        DudaEN dudaEN = null;
        DudaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                // Data
                dudaEN = dudaCEN.BuscarPorId (idDuda);

                // Convert return
                if (dudaEN != null) {
                        returnValue = DudaAssembler.Convert (dudaEN, session);
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



// No pasa el slEnables: buscarDudaPorTitulo

[HttpGet]

[Route ("~/api/Duda/BuscarDudaPorTitulo")]

public HttpResponseMessage BuscarDudaPorTitulo (string p_titulo)
{
        // CAD, CEN, EN, returnValue

        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;


        System.Collections.Generic.List<DudaEN> en;

        System.Collections.Generic.List<DudaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                // CEN return



                en = dudaCEN.BuscarDudaPorTitulo (p_titulo).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<DudaDTOA>();
                        foreach (DudaEN entry in en)
                                returnValue.Add (DudaAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarDudaPorTemas

[HttpGet]

[Route ("~/api/Duda/BuscarDudaPorTemas")]

public HttpResponseMessage BuscarDudaPorTemas (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TemaEnum ? p_tema)
{
        // CAD, CEN, EN, returnValue

        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;


        System.Collections.Generic.List<DudaEN> en;

        System.Collections.Generic.List<DudaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                // CEN return



                en = dudaCEN.BuscarDudaPorTema (p_tema).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<DudaDTOA>();
                        foreach (DudaEN entry in en)
                                returnValue.Add (DudaAssembler.Convert (entry, session));
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


// No pasa el slEnables: buscarDudasPorUsuario

[HttpGet]

[Route ("~/api/Duda/BuscarDudasPorUsuario")]

public HttpResponseMessage BuscarDudasPorUsuario (int id_usuario)
{
        // CAD, CEN, EN, returnValue

        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;


        System.Collections.Generic.List<DudaEN> en;

        System.Collections.Generic.List<DudaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                // CEN return



                en = dudaCEN.BuscarDudasPorUsuario (id_usuario).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<DudaDTOA>();
                        foreach (DudaEN entry in en)
                                returnValue.Add (DudaAssembler.Convert (entry, session));
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


[Route ("~/api/Duda/Crear")]




public HttpResponseMessage Crear ( [FromBody] DudaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;
        DudaDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                // Create
                returnOID = dudaCEN.Crear (
                        //Atributo Primitivo: p_titulo
                        dto.Titulo,                                                                                                                                         //Atributo Primitivo: p_cuerpo
                        dto.Cuerpo,                                                                                                                                       //Atributo OID: p_usuario
                        // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        ,                                           //Atributo Primitivo: p_tema
                        dto.Tema);
                SessionCommit ();

                // Convert return
                returnValue = DudaAssembler.Convert (dudaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDDuda", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}




[HttpPut]



[Route ("~/api/Duda/Modificar")]

public HttpResponseMessage Modificar (int idDuda, [FromBody] DudaDTO dto)
{
        // CAD, CEN, returnValue
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;
        DudaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                // Modify
                dudaCEN.Modificar (idDuda,
                        dto.Titulo
                        ,
                        dto.Cuerpo
                        ,
                        dto.Fecha
                        ,
                        dto.Util
                        ,
                        dto.Tema
                        );

                // Return modified object
                returnValue = DudaAssembler.Convert (dudaRESTCAD.ReadOIDDefault (idDuda), session);

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


[Route ("~/api/Duda/Borrar")]

public HttpResponseMessage Borrar (int p_duda_oid)
{
        // CAD, CEN
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);

                dudaCEN.Borrar (p_duda_oid);
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

[Route ("~/api/Duda/IndicarDudaUtil")]


public HttpResponseMessage IndicarDudaUtil (int p_oid)
{
        // CAD, CEN, returnValue
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);


                // Operation
                dudaCEN.IndicarDudaUtil (p_oid);
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

[Route ("~/api/Duda/IndicarDudaNoUtil")]


public HttpResponseMessage IndicarDudaNoUtil (int p_oid)
{
        // CAD, CEN, returnValue
        DudaRESTCAD dudaRESTCAD = null;
        DudaCEN dudaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                dudaRESTCAD = new DudaRESTCAD (session);
                dudaCEN = new DudaCEN (dudaRESTCAD);


                // Operation
                dudaCEN.IndicarDudaNoUtil (p_oid);
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

[Route ("~/api/Duda/Duda_obtenerNumeroDeRespuestas")]

public HttpResponseMessage Duda_obtenerNumeroDeRespuestas (int p_oid)
{
        // CP, returnValue
        DudaCP dudaCP = null;

        int returnValue;

        try
        {
                SessionInitializeTransaction ();




                dudaCP = new DudaCP (session);

                // Operation
                returnValue = dudaCP.ObtenerNumeroDeRespuestas (p_oid);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}



[HttpPost]

[Route ("~/api/Duda/Duda_obtenerSiRespuestaValida")]

public HttpResponseMessage Duda_obtenerSiRespuestaValida (int p_oid)
{
        // CP, returnValue
        DudaCP dudaCP = null;

        bool returnValue;

        try
        {
                SessionInitializeTransaction ();




                dudaCP = new DudaCP (session);

                // Operation
                returnValue = dudaCP.ObtenerSiRespuestaValida (p_oid);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_DudaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
