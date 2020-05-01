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
        public static UsuarioAdministradorCEN adminCEN = new UsuarioAdministradorCEN();
        UsuarioAdministradorEN usuario;
        public static int id;

        [Before(tags: "ModificarUsuario")]
        public static void InitializeData()
        {
            Console.WriteLine("Init");
            id = adminCEN.Crear("usuario", "prueba", "usuario@ua.es", "contrasena");
            if (id == -1)
            {
                id = adminCEN.BuscarPorCorreo("usuario@ua.es").Id;

            }
        }

        [Given(@"Existe un usuario")]
        public void GivenExisteUnUsuario()
        {
        }

        [Given(@"No existe el usuario (.*)")]
        public void GivenNoExisteElUsuario(int p0)
        {
            id = p0;
        }


        [When(@"Modifico los datos del usuario")]
        public void WhenModificoLosDatosDelUsuario()
        {
            adminCEN.Modificar(id, "usuarioprueba", "prueba", "usuario@ua.es");
            usuario = adminCEN.BuscarPorId(id);
        }

        [Then(@"Obtengo el usuario con los datos modificados")]
        public void ThenObtengoElUsuarioConLosDatosModificados()
        {
            Assert.AreEqual("usuarioprueba", usuario.Nombre);
        }

        [Then(@"No se puede modificar el usuario")]
        public void ThenNoSePuedeModificarElUsuario()
        {
            Assert.IsNull(usuario);
        }

    }
}
