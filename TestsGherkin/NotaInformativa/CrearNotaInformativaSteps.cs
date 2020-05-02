using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.NotaInformativa
{
    [Binding]
    public class CrearNotaInformativaSteps
    {
        public static NotaInformativaCEN notaCEN = new NotaInformativaCEN();
        public static NotaInformativaEN nota = new NotaInformativaEN();
        public static int notaId = -1;

        [After(tags: "@CrearNuevaNotaInformativa")]
        public static void CleanData()
        {
            notaCEN.Borrar(notaId);
        }

        [Given(@"Quiero crear una nueva nota informativa que contenga")]
        public void GivenQuieroCrearUnaNuevaNotaInformativaQueContenga(Table table)
        {
            nota.Titulo = table.Rows[0][0];
            nota.Cuerpo = table.Rows[0][1];
        }

        [Given(@"Logueado con el usuario admin (.*)")]
        public void GivenLogueadoConElUsuarioAdmin(int p0)
        {
            nota.UsuarioAdministrador = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN();
            nota.UsuarioAdministrador.Id = p0;
        }

        [When(@"Creo la nota informativa")]
        public void WhenCreoLaNotaInformativa()
        {
            notaId = notaCEN.Crear(nota.UsuarioAdministrador.Id, nota.Titulo, nota.Cuerpo);
        }

        [Then(@"Obtengo la nueva nota informativa")]
        public void ThenObtengoLaNuevaNotaInformativa()
        {
            Assert.IsNotNull(notaCEN.BuscarPorId(notaId));
        }
    }
}
