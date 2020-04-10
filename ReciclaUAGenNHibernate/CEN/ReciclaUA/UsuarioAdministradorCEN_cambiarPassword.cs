
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_cambiarPassword) ENABLED START*/
using System.Net;
using System.Net.Mail;
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class UsuarioAdministradorCEN
{
public void CambiarPassword (int p_UsuarioAdministrador_OID, String p_pass)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_UsuarioAdministrador_cambiarPassword_customized) ENABLED START*/

        UsuarioAdministradorEN usuarioAdministradorEN = null;

        //Initialized UsuarioAdministradorEN
        usuarioAdministradorEN = new UsuarioAdministradorEN ();
        usuarioAdministradorEN.Id = p_UsuarioAdministrador_OID;
        usuarioAdministradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to UsuarioAdministradorCAD

        _IUsuarioAdministradorCAD.CambiarPassword (usuarioAdministradorEN);
        usuarioAdministradorEN = _IUsuarioAdministradorCAD.BuscarPorId (p_UsuarioAdministrador_OID);

        var fromAddress = new MailAddress ("reciclauatfm@gmail.com", "From ReciclaUA");
        var toAddress = new MailAddress (usuarioAdministradorEN.Email, "To " + usuarioAdministradorEN.Nombre);
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
                Credentials = new NetworkCredential (fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage (fromAddress, toAddress){
                       Subject = subject,
                       Body = body
               })
        {
                try
                {
                        smtp.Send (message);
                }
                catch (Exception e)
                {
                        throw new Exception (" El correo electronico no ha podido serenviado " + e);
                }
                finally
                {
                        smtp.Dispose ();
                }
        }


        /*PROTECTED REGION END*/
}
}
}
