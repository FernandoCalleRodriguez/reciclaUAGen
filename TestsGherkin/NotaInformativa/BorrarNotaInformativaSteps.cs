using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Exceptions;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.NotaInformativa
{
    [Binding]
    public class BorrarNotaInformativaSteps
    {
        public static NotaInformativaCEN notaCEN = new NotaInformativaCEN();
        public static NotaInformativaEN nota = null;
        public static int notaId;
        public string exception = "ModelException";

        [Before(tags: "BorrarNotaInformativa")]
        public static void InitializeData()
        {
            NotaInformativaEN nota = new NotaInformativaEN()
            {
                Titulo = "Titulo de nota informativa TEST",
                Cuerpo = "Cuerpo de nota informativa TEST",
            };

            nota.UsuarioAdministrador = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN();
            nota.UsuarioAdministrador.Id = 32768;

            notaId = notaCEN.Crear(32768, nota.Titulo, nota.Cuerpo);
        }

        [Given(@"Hay una nota informativa especifica")]
        public void GivenHayUnaNotaInformativaEspecifica()
        {
            //Se mantiene el Id creado
        }
        
        [Given(@"No existe la nota informativa especifica")]
        public void GivenNoExisteLaNotaInformativaEspecifica()
        {
            notaId = -1;
        }
        
        [When(@"Elimino la nota informativa")]
        public void WhenEliminoLaNotaInformativa()
        {
            try
            {
                notaCEN.Borrar(notaId);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"Devuelvo la nota informativa borrada")]
        public void ThenDevuelvoLaNotaInformativaBorrada()
        {
            Assert.IsNull(notaCEN.BuscarPorId(notaId));
        }
        
        [Then(@"No se puede borrar la nota informativa")]
        public void ThenNoSePuedeBorrarLaNotaInformativa()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
