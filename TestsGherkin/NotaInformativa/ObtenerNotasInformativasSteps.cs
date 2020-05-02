using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.NotaInformativa
{
    [Binding]
    public class ObtenerNotasInformativasSteps
    {
        public static NotaInformativaCEN notaCEN = new NotaInformativaCEN();
        public static IList<NotaInformativaEN> notas = new List<NotaInformativaEN>();
        public static int notaId;
        public static int notaId2;
        
        [Before(tags: "ObtenerNotasInformativas")]
        public static void InitializeData()
        {
            NotaInformativaEN nota = new NotaInformativaEN()
            {
                Titulo = "Titulo de nota informativa TEST",
                Cuerpo = "Cuerpo de nota informativa TEST",
            };

            nota.UsuarioAdministrador = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN();
            nota.UsuarioAdministrador.Id = 32768;

            NotaInformativaEN nota2 = new NotaInformativaEN()
            {
                Titulo = "Titulo de nota informativa TEST 2",
                Cuerpo = "Cuerpo de nota informativa TEST 2",
            };

            nota2.UsuarioAdministrador = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN();
            nota2.UsuarioAdministrador.Id = 32768;

            notaId = notaCEN.Crear(32768, nota.Titulo, nota.Cuerpo);
            notaId2 = notaCEN.Crear(32768, nota2.Titulo, nota2.Cuerpo);
        }

        [After(tags: "ObtenerNotasInformativas")]
        public static void CleanData()
        {
            notaCEN.Borrar(notaId);
            notaCEN.Borrar(notaId2);
        }

        [Given(@"Tengo notas informativas")]
        public void GivenTengoNotasInformativas()
        {
            //Vacio
        }

        [When(@"Obtengo las notas informativas")]
        public void WhenObtengoLasNotasInformativas()
        {
            notas = notaCEN.BuscarTodos(0, -1);
        }

        [Then(@"Obtengo una lista de las notas informativas")]
        public void ThenObtengoUnaListaDeLasNotasInformativas()
        {
            Assert.IsTrue(notas.Count > 0);
        }
    }
}
