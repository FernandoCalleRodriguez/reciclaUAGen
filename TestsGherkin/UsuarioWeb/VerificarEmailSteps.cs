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
        public static UsuarioWebCEN usuarioCEN = new UsuarioWebCEN();
        UsuarioWebEN usuario;
        public static int id;
        public static int id_creado;


        [Before(tags: "VerificarEmail")]
        public static void InitializeData()
        {
            Console.WriteLine("Init");
            id = usuarioCEN.Crear("usuario", "prueba", "usuario@ua.es", "contrasena");
            id_creado = id;
    }

    [After(tags: "VerificarEmail")]
        public static void CleanData()
        {
            usuarioCEN.Destroy(id_creado);

        }

        [Given(@"Un usuario (.*)")]
        public void GivenUnUsuario(int p0)
        {
            usuarioCEN = new UsuarioWebCEN();
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
