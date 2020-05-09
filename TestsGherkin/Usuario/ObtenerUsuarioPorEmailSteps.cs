
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.PruebasAceptacion
{
    [Binding]
    public class ObtenerUsuarioPorEmailSteps
    {

        ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioCEN usuarioCEN;
        public static UsuarioAdministradorCEN adminCEN = new UsuarioAdministradorCEN();
        UsuarioEN usuario;
        string email;
        public static int id;

        [Before(tags: "ObtenerUsuarioPorEmail")]
        public static void InitializeData()
        {
            Console.WriteLine("Init");
            id = adminCEN.Crear("usuario", "prueba", "usuario@ua.es", "contrasena");

        }

        [After(tags: "ObtenerUsuarioPorEmail")]
        public static void CleanData()
        {
            adminCEN.Destroy(id);

        }

        [Given(@"Hay un usuario con email ""(.*)""")]
        public void GivenHayUnUsuarioConEmail(string p0)
        {

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

        [Then(@"No se puede devolver al suario")]
        public void ThenNoSePuedeDevolverAlSuario()
        {
            Assert.IsNull(usuario);
        }

    }
}
