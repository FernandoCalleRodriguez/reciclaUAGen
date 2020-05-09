using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Contenedor
{
    [Binding]
    public class ContenedorPorTipoSteps
    {
        public static ContenedorEN contenedor;
        public static ContenedorCEN contenedorCEN;
        public static int tipo = -1;
        public static int id_contenedor, id_punto;

        [Before(tags: "ContenedorPorTipo")]
        public static void InitializeData()
        {
            contenedorCEN = new ContenedorCEN();
           
            id_contenedor = new ContenedorCEN().Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, -1);

        }

        [After(tags: "ContenedorPorTipo")]
        public static void CleanData()
        {
            if(id_contenedor>0)
            contenedorCEN.Borrar(id_contenedor);
        }

        [Given(@"Hay  edificios de un tipo especifica")]
        public void GivenHayEdificiosDeUnTipoEspecifica()
        {
            contenedorCEN = new ContenedorCEN();

        }

        [Given(@"No Hay edificios de una planta especifica")]
        public void GivenNoHayEdificiosDeUnaPlantaEspecifica()
        {
            contenedorCEN = new ContenedorCEN();
            tipo = -1;
        }

        [When(@"Busco el edificios por ese tipo")]
        public void WhenBuscoElEdificiosPorEseTipo()
        {
            contenedor = contenedorCEN.BuscarContenedoresPorTipo(TipoContenedorEnum.cristal)[0];
        }

        [When(@"Busco edificios por este tipo")]
        public void WhenBuscoEdificiosPorEsteTipo()
        {
            try
            {
                contenedor = contenedorCEN.BuscarContenedoresPorTipo(TipoContenedorEnum.organico)[0];
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Devuelvo la lista de edificos")]
        public void ThenDevuelvoLaListaDeEdificos()
        {
            Assert.IsNotNull(contenedor);
        }

        [Then(@"No se puede devolver los edificio")]
        public void ThenNoSePuedeDevolverLosEdificio()
        {
            Assert.IsNull(contenedor);
        }
    }
}
