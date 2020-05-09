using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.UsuarioWeb
{
    [Binding]
    public class BuscarNoBorradosSteps
    {
        IList<UsuarioWebEN> usuarios;
        public static UsuarioWebCEN usuarioCEN = new UsuarioWebCEN();
        public static int id;
        public static int id_creado;



        [Before(tags: "BuscarNoBorrados")]
        public static void InitializeData()
        {
            Console.WriteLine("Init");
            id = usuarioCEN.Crear("usuario", "prueba", "usuarioweb@ua.es", "contrasena");
            if (id == -1)
            {
                id = usuarioCEN.BuscarPorCorreo("usuarioweb@ua.es").Id;

            }

            id_creado = id;
        }


        [After(tags: "BuscarNoBorrados")]
        public static void CleanData()
        {
            usuarioCEN.Destroy(id_creado);

        }

        [Given(@"Existen usuarios no borrados")]
        public void GivenExistenUsuariosNoBorrados()
        {
            usuarioCEN = new UsuarioWebCEN();
        }

        [When(@"Obtengo los usuarios no borrados")]
        public void WhenObtengoLosUsuariosNoBorrados()
        {
            usuarios = usuarioCEN.BuscarNoBorrados();
        }

        [Then(@"Devuelvo el los usuario no borrados")]
        public void ThenDevuelvoElLosUsuarioNoBorrados()
        {
            Assert.IsNotNull(usuarios);
        }

    }
}
