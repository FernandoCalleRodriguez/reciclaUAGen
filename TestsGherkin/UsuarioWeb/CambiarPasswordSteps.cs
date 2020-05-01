using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.UsuarioWeb
{
    [Binding]
    public class CambiarPasswordSteps
    {

        UsuarioWebCEN usuarioCEN;
        UsuarioWebEN usuario;
        string newPass;
        int id;

        [Given(@"Hay un usuario con id (.*)")]
        public void GivenHayUnUsuarioConId(int p0)
        {
            usuarioCEN = new UsuarioWebCEN();
            this.id = Convert.ToInt32(p0);
            this.newPass = "new_pass";
        }

        [Given(@"No existe el web  usuario (.*)")]
        public void GivenNoExisteElWebUsuario(int p0)
        {
            usuarioCEN = new UsuarioWebCEN();
            this.id = Convert.ToInt32(p0);
            this.newPass = "new_pass";
        }

        [When(@"Cambiar la contraseña del usuario")]
        public void WhenCambiarLaContrasenaDelUsuario()
        {
            usuarioCEN.CambiarPassword(id, newPass);
        }
        
        [When(@"Obtener el usuario")]
        public void WhenObtenerElUsuario()
        {
            usuario = usuarioCEN.BuscarPorId(id);
        }

        [Then(@"obtengo el usuario con la nueva contrasena")]
        public void ThenObtengoElUsuarioConLaNuevaContrasena()
        {
            Assert.AreEqual(usuario.Pass, ReciclaUAGenNHibernate.Utils.Util.GetEncondeMD5(newPass));
        }

        [Then(@"No se puede obtener el usuario")]
        public void ThenNoSePuedeObtenerElUsuario()
        {

            Assert.IsNull(usuario);
        }


    }
}
