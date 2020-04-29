using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.UsuarioAdmin
{
    [Binding]
    public class ModificarUsuarioAdminSteps
    {
        UsuarioAdministradorCEN usuarioCEN;
        UsuarioAdministradorEN usuario;

        int id;

        [Given(@"Existe un usuario admin (.*)")]
        public void GivenExisteUnUsuarioAdmin(int p0)
        {
            usuario = new UsuarioAdministradorEN();
            usuarioCEN = new UsuarioAdministradorCEN();
            this.id = p0;
            usuario.Email = "admin2@ua.es";
            usuario.Nombre = "admin2@ua.es";
            usuario.Apellidos = "admin2@ua.es";
        }
        
        [When(@"Modifico los datos del usuario")]
        public void WhenModificoLosDatosDelUsuario()
        {
            usuarioCEN.Modificar(id, "admin2", "admin2", "admin2@ua.es");
            usuario = usuarioCEN.BuscarPorId(id);
        }
        
        [Then(@"Obtengo el usuario con los datos modificados")]
        public void ThenObtengoElUsuarioConLosDatosModificados()
        {
            Assert.AreEqual("admin2", usuario.Nombre);
        }
    }
}
