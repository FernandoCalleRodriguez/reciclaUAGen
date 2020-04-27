using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.PruebasAceptacion
{
    [Binding]
    public class ObtenerUsuarioPorEmailSteps
    {

        ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioCEN usuarioCEN;
        UsuarioEN usuario;
        string email;


        [Given(@"Hay un usuario con email ""(.*)""")]
        public void GivenHayUnUsuarioConEmail(string p0)
        {
            // CreateDB createdb = new CreateDB();
            // createdb.InitializeData();
            // inicializar inicializar = new inicializar();
            // inicializar.InitializeData();
            usuarioCEN = new ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioCEN();
            this.email = p0;

        }

        [When(@"Busco el usuario por ese email")]
        public void WhenBuscoElUsuarioPorEseEmail()
        {
            usuario = usuarioCEN.BuscarPorCorreo(email);
        }

        [Then(@"Devuelvo el ususario")]
        public void ThenDevuelvoElUsusario()
        {
            Assert.AreEqual(email, usuario.Email);
        }
    }
}
