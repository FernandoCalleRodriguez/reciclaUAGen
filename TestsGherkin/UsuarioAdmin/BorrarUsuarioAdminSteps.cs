using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.UsuarioAdmin
{

    [Binding]
    public class BorrarUsuarioAdminSteps
    {

        UsuarioAdministradorCEN usuarioCEN;
        UsuarioAdministradorEN usuario;
        int id;

        [Given(@"Hay un usuario admin (.*)")]
        public void GivenHayUnUsuarioAdmin(int p0)
        {
            usuarioCEN = new UsuarioAdministradorCEN();
            this.id = p0;

        }
        
        [When(@"Elimino el usuario")]
        public void WhenEliminoElUsuario()
        {
            usuarioCEN.Borrar(id);
            usuario = usuarioCEN.BuscarPorId(id);
        }

        
        
        [Then(@"Devuelvo el usuario con datos borrados")]
        public void ThenDevuelvoElUsuarioConDatosBorrados()
        {
            Assert.AreEqual(usuario.Nombre, "");
        }

        [Then(@"No se puede borrar el usuario")]
        public void ThenNoSePuedeBorrarElUsuario()
        {
            Assert.IsNull(usuario);
        }

    }
}
