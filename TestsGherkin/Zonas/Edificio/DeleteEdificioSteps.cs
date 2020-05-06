using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Edificio
{
    [Binding]
    public class DeleteEdificioSteps
    {
        public static int id_edificio;
        public static EdificioCEN edificioCEN;
        [Before(tags: "DeleteEdificioExists")]
        public static void InitializeData()
        {
            var e = new EdificioCEN().BuscarPorId(123);
            if (e != null)
                id_edificio = 123;
            else
                id_edificio = new EdificioCEN().Crear("Edificio 1", 123);
        }
        [Given(@"Hay un Edificio con un id especifico")]
        public void GivenHayUnEdificioConUnIdEspecifico()
        {
            edificioCEN = new EdificioCEN();
        }

        [Given(@"No hay un Edificio con un id especifico")]
        public void GivenNoHayUnEdificioConUnIdEspecifico()
        {
            id_edificio = -1;
            edificioCEN = new EdificioCEN();
        }

        [When(@"Elimino El Edificio")]
        public void WhenEliminoElEdificio()
        {
            edificioCEN.Borrar(id_edificio);
        }

        [When(@"Entento elimino El Edificio")]
        public void WhenEntentoEliminoElEdificio()
        {
            try
            {
                edificioCEN.Borrar(id_edificio);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Se borra el Edificio")]
        public void ThenSeBorraElEdificio()
        {
            Assert.IsNull(edificioCEN.BuscarPorId(id_edificio));
        }

        [Then(@"no se borra el Edificio")]
        public void ThenNoSeBorraElEdificio()
        {
            Assert.IsNull(edificioCEN.BuscarPorId(id_edificio));
        }
    }
}
