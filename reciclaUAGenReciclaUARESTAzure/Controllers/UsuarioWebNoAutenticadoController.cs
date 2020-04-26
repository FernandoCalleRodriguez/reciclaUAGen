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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_UsuarioWebNoAutenticadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioWebNoAutenticado")]
public class UsuarioWebNoAutenticadoController : BasicController
{
// Voy a generar el readAll













// No pasa el slEnables: buscarPorCorreo

[HttpGet]

[Route ("~/api/UsuarioWebNoAutenticado/BuscarPorCorreo")]

public HttpResponseMessage BuscarPorCorreo (string p_correo)
{
        // CAD, CEN, EN, returnValue

        UsuarioWebNoAutenticadoRESTCAD usuarioWebNoAutenticadoRESTCAD = null;
        UsuarioCEN usuarioCEN = null;


        UsuarioEN en;

        UsuarioWebNoAutenticadoDTOA returnValue;

        try
        {
                SessionInitializeWithoutTransaction ();



                usuarioWebNoAutenticadoRESTCAD = new UsuarioWebNoAutenticadoRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioWebNoAutenticadoRESTCAD);

                // CEN return



                en = usuarioCEN.BuscarPorCorreo (p_correo);




                // Convert return
                returnValue = UsuarioWebNoAutenticadoAssembler.Convert (en, session);
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

[Route ("~/api/UsuarioWebNoAutenticado/Login")]


public HttpResponseMessage Login ( [FromBody] UsuarioDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioWebNoAutenticadoRESTCAD usuarioWebNoAutenticadoRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        string token = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioWebNoAutenticadoRESTCAD = new UsuarioWebNoAutenticadoRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioWebNoAutenticadoRESTCAD);


                // Operation
                token = usuarioCEN.Login (
                        dto.Pass
                        , dto.Email
                        );

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
        if (token != null)
                return this.Request.CreateResponse (HttpStatusCode.OK, token);
        else
                return this.Request.CreateResponse (HttpStatusCode.Unauthorized, "");
}



















/*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_UsuarioWebNoAutenticadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
