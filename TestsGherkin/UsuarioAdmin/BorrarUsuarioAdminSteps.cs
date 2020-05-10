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

        public static UsuarioAdministradorCEN usuarioCEN = new UsuarioAdministradorCEN();
        UsuarioAdministradorEN usuario;
        public static int id;
        public static int id_creado;


        [Before(tags: "BorrarUsuario")]
        public static void InitializeData()
        {
            Console.WriteLine("Init");
            id = usuarioCEN.Crear("usuario", "prueba", "usuarioborrar@ua.es", "contrasena");
            if(id == -1)
            {
                id = usuarioCEN.BuscarPorCorreo("usuarioborrar@ua.es").Id;
            }

            id_creado = id;
        }

        [After(tags: "BorrarUsuario")]
        public static void CleanData()
        {
            usuarioCEN.Destroy(id_creado);

        }


        [Given(@"TEngo un usuario existente")]
        public void GivenTEngoUnUsuarioExistente()
        {
        }

        [Given(@"No existe un usuario admin (.*)")]
        public void GivenNoExisteUnUsuarioAdmin(int p0)
        {
            usuarioCEN = new UsuarioAdministradorCEN();
            id = p0;
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
