using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Contenedor
{
    [Binding]
    public class DeleteContenedorSteps
    {
        public static ContenedorEN contenedor;
        public static ContenedorCEN contenedorCEN;
        public static int tipo = -1;
        public static int id_contenedor, id_punto;

        [Before(tags: "DeleteContenedorExists")]
        public static void InitializeData()
        {

            id_contenedor = new ContenedorCEN().Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, -1);
        }

        [Given(@"Hay un Contenedor con un id especifico")]
        public void GivenHayUnContenedorConUnIdEspecifico()
        {
            contenedorCEN = new ContenedorCEN();
        }

        [Given(@"No hay un Contenedor con un id especifico")]
        public void GivenNoHayUnContenedorConUnIdEspecifico()
        {
            id_contenedor = -1;
            contenedorCEN = new ContenedorCEN();
        }

        [When(@"Elimino El Contenedor")]
        public void WhenEliminoElContenedor()
        {
            contenedorCEN.Borrar(id_contenedor);
        }

        [When(@"Entento elimino El Contenedor")]
        public void WhenEntentoEliminoElContenedor()
        {
            try
            {
                contenedorCEN = new ContenedorCEN();
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Se borra el Contenedor")]
        public void ThenSeBorraElContenedor()
        {
            contenedor = contenedorCEN.BuscarPorId(id_contenedor);
            Assert.IsNull(contenedor);
        }

        [Then(@"no se borra el Contenedor")]
        public void ThenNoSeBorraElContenedor()
        {
            contenedor = contenedorCEN.BuscarPorId(id_contenedor);
            Assert.IsNull(contenedor);
        }
    }
}
