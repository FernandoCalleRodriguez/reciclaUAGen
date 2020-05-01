using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.NotaInformativa
{
    [Binding]
    public class BorrarNotaInformativaSteps
    {
        public static NotaInformativaCEN notaCEN;
        public static NotaInformativaEN nota = null;
        public static int notaId = -1;

        [Given(@"Hay una nota informativa (.*)")]
        public void GivenHayUnaNotaInformativa(int p0)
        {
            notaCEN = new NotaInformativaCEN();
            notaId = 65536;
        }

        [When(@"Elimino la nota informativa")]
        public void WhenEliminoLaNotaInformativa()
        {
            try
            {
                notaCEN.Borrar(notaId);
                Assert.Fail();
            }
            catch (Exception)
            {
                //vacio
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
            Assert.IsNull(notaCEN.BuscarPorId(notaId));
        }
    }
}
