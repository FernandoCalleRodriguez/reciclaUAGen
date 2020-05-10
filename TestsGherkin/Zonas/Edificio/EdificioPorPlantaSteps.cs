using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Edificio
{
    [Binding]
    public class EdificioPorPlantaSteps
    {
        public static int id_planta, id_edificio;
        public static EdificioCEN edificioCEN;
        public static PlantaCEN plantaCEN;
        EdificioEN edificio = null;

        [Before(tags: "EdificioPorPlanta")]
        public static void InitializeData()
        {
            id_edificio = new EdificioCEN().Crear("Edificio 1", 13456);
            id_planta = new PlantaCEN().Crear(PlantaEnum.PB, id_edificio);
        }

        [After(tags: "EdificioPorPlanta")]
        public static void CleanData()
        {

            if (id_edificio > 0)
                edificioCEN.Borrar(id_edificio);
            if (id_planta > 0)
                plantaCEN.Borrar(id_planta);
        }

        [Given(@"Hay un edificio de una planta especifica")]
        public void GivenHayUnEdificioDeUnaPlantaEspecifica()
        {
            edificioCEN = new EdificioCEN();
            plantaCEN = new PlantaCEN();
        }

        [Given(@"No Hay un edificio de una planta especifica")]
        public void GivenNoHayUnEdificioDeUnaPlantaEspecifica()
        {
            edificioCEN = new EdificioCEN();
            plantaCEN = new PlantaCEN();
        }

        [When(@"Busco el edificio por ese planta")]
        public void WhenBuscoElEdificioPorEsePlanta()
        {
            edificio = edificioCEN.BuscarEdificioPorPlanta(id_planta);

        }

        [When(@"Busco el edificio por este planta")]
        public void WhenBuscoElEdificioPorEstePlanta()
        {
            try
            {
                edificio = edificioCEN.BuscarEdificioPorPlanta(-1);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Devuelvo el edifico")]
        public void ThenDevuelvoElEdifico()
        {
            Assert.IsNotNull(edificio);
        }

        [Then(@"No se puede devolver el edificio")]
        public void ThenNoSePuedeDevolverElEdificio()
        {
            Assert.IsNull(edificio);
        }
    }
}
