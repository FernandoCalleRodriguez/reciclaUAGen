using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestsGherkin.UsuarioWeb
{
    [Binding]
    public class CrearUsuarioWebSteps
    {
        public static ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioWebCEN usuarioCEN = new ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioWebCEN();
        UsuarioEN usuarioCrear;
        public static int id;

        [After(tags: "CrearUsuarioWeb")]
        public static void CleanData()

        {
            usuarioCEN.Destroy(id);
        }

        [Given(@"No existe un usuario")]
        public void GivenNoExisteUnUsuario(Table table)
        {
            usuarioCrear = new UsuarioEN();
            var usuarios = table.CreateSet<UsuarioEN>();

            foreach (UsuarioEN usuario in usuarios)
            {
                usuarioCrear.Email = usuario.Email; 
                usuarioCrear.Pass = usuario.Pass; 
                usuarioCrear.Nombre = usuario.Nombre; 
                usuarioCrear.Apellidos = usuario.Apellidos;
            }
        }


        [When(@"Creo el usuario")]
        public void WhenCreoElUsuario()
        {
            id = usuarioCEN.Crear(usuarioCrear.Nombre, usuarioCrear.Apellidos, usuarioCrear.Email, usuarioCrear.Pass);
        }

        [Then(@"Obtengo al nuevo usuario")]
        public void ThenObtengoAlNuevoUsuario()
        {
            Assert.IsNotNull(id);
        }
    }
}
