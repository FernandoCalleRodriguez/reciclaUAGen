using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin
{
    [Binding]
    public class VerificarEmailSteps
    {
        UsuarioWebCEN usuarioCEN;
        UsuarioWebEN usuario;
        int id;

        [Given(@"Un usuario (.*)")]
        public void GivenUnUsuario(int p0)
        {
            usuarioCEN = new UsuarioWebCEN();
            this.id = Convert.ToInt32(p0);
        }


        [When(@"Cambio el usuario a verificado")]
        public void WhenCambioElUsuarioAVerificado()
        {
            usuarioCEN.VerificarEmail(id, true);
            usuario = usuarioCEN.BuscarPorId(id);

        }

        [Then(@"obtengo el usuario verificado")]
        public void ThenObtengoElUsuarioVerificado()
        {
            Assert.IsTrue(usuario.EmailVerificado);
        }

    }
}
