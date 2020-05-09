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


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUAAdminRESTAzure_UsuarioWebVerificarCuentaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUAAdminRESTAzure.Controllers
{
[RoutePrefix ("~/api/UsuarioWebVerificarCuenta")]
public class UsuarioWebVerificarCuentaController : BasicController
{
// Voy a generar el readAll




























[HttpPost]

[Route ("~/api/UsuarioWebVerificarCuenta/VerificarEmail")]


public HttpResponseMessage VerificarEmail (int p_usuarioweb_oid)
{
        // CAD, CEN, returnValue
        UsuarioWebVerificarCuentaRESTCAD usuarioWebVerificarCuentaRESTCAD = null;
        UsuarioWebCEN usuarioWebCEN = null;

        try
        {
                SessionInitializeTransaction ();


                usuarioWebVerificarCuentaRESTCAD = new UsuarioWebVerificarCuentaRESTCAD (session);
                usuarioWebCEN = new UsuarioWebCEN (usuarioWebVerificarCuentaRESTCAD);


                // Operation
                usuarioWebCEN.VerificarEmail (p_usuarioweb_oid);
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






/*PROTECTED REGION ID(reciclaUAGenReciclaUAAdminRESTAzure_UsuarioWebVerificarCuentaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
