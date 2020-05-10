
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
using System.Net.Mail;
using System.Net;


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_cambiarPassword) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
    public partial class UsuarioWebCEN
    {
        public void CambiarPassword(int p_UsuarioWeb_OID, String p_pass)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioWeb_cambiarPassword_customized) ENABLED START*/

            UsuarioWebEN usuarioWebEN = null;
            usuarioWebEN = _IUsuarioWebCAD.BuscarPorId(p_UsuarioWeb_OID);

            //Initialized UsuarioWebEN
            if (usuarioWebEN != null)
            {
                usuarioWebEN.Pass = Utils.Util.GetEncondeMD5(p_pass);
                //Call to UsuarioWebCAD

                _IUsuarioWebCAD.CambiarPassword(usuarioWebEN);


                var fromAddress = new MailAddress("reciclauatfm@gmail.com", "From ReciclaUA");
                var toAddress = new MailAddress(usuarioWebEN.Email, "To " + usuarioWebEN.Nombre);
                string fromPassword = "Reciclaua_1";
                string subject = "Recuperar contrasena";
                string body = "La nueva contrase�a es: " + p_pass + ". Te sugerimos cambiarla a la mayor brevedad en la gest�n del perfil una vez que inicies sesi�n";

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



            /*PROTECTED REGION END*/
        }
    }
}
