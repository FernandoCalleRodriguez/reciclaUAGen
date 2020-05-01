
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ReciclaUAGenNHibernate.Exceptions;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_crear) ENABLED START*/
//  references to other libraries
using System.Net.Mail;
using System.Net;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
    public partial class UsuarioWebCEN
    {
        public int Crear(string p_nombre, string p_apellidos, string p_email, String p_pass)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_crear_customized) ENABLED START*/

            UsuarioWebEN usuarioWebEN = null;
            UsuarioWebCEN usuarioWebCEN = new UsuarioWebCEN();
            UsuarioCEN usuarioCEN = new UsuarioCEN();


            int oid;

            //Initialized UsuarioWebEN
            usuarioWebEN = new UsuarioWebEN();
            usuarioWebEN.Nombre = p_nombre;

            usuarioWebEN.Apellidos = p_apellidos;

            usuarioWebEN.Email = p_email;

            usuarioWebEN.Pass = Utils.Util.GetEncondeMD5(p_pass);

            usuarioWebEN.Borrado = false;

            usuarioWebEN.EmailVerificado = false;

            usuarioWebEN.Fecha = DateTime.Now;

            usuarioWebEN.Puntuacion = 0;
            //Call to UsuarioAdministradorCAD
            UsuarioEN usu = usuarioCEN.BuscarPorCorreo(p_email);
            //Call to UsuarioWebCAD
            if (usu == null)
            {
                oid = _IUsuarioWebCAD.Crear(usuarioWebEN);

                var fromAddress = new MailAddress("reciclauatfm@gmail.com", "From ReciclaUA");
                var toAddress = new MailAddress(usuarioWebEN.Email, "To " + usuarioWebEN.Nombre);
                string fromPassword = "Reciclaua_1";
                string subject = "Verificaci�n de email";
                string body = "Para verifcar tu email accede al siguiente link: http://localhost:4200/verificacion/" + oid;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    try
                    {
                        smtp.Send(message);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(" El correo electronico no ha podido serenviado " + e);
                    }
                    finally
                    {
                        smtp.Dispose();
                    }
                }
            }
            else
            {
                oid = -1;
            }



            return oid;

            /*PROTECTED REGION END*/
        }
    }
}
