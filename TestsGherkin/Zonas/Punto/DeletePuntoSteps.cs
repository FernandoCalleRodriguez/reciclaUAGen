using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Punto
{
    [Binding]
    public class DeletePuntoSteps
    {
        public static int punto_id;
        public static  PuntoReciclajeCEN puntoReciclajeCEN;
        
        [Before(tags: "DeletePuntoExists")]
        public static void InitializeData()
        {
            puntoReciclajeCEN = new PuntoReciclajeCEN();
            punto_id = puntoReciclajeCEN.Crear(12, 12, -1, null);

        }
        
        [Given(@"Hay un Punto con un id especifico")]
        public void GivenHayUnPuntoConUnIdEspecifico()
        {
            puntoReciclajeCEN = new PuntoReciclajeCEN();
        }

        [Given(@"No hay un Punto con un id especifico")]
        public void GivenNoHayUnPuntoConUnIdEspecifico()
        {
            punto_id = -1;
            puntoReciclajeCEN = new PuntoReciclajeCEN();
        }

        [When(@"Elimino El Punto")]
        public void WhenEliminoElPunto()
        {
            puntoReciclajeCEN.Borrar(punto_id);
        }

        [When(@"Entento elimino El Punto")]
        public void WhenEntentoEliminoElPunto()
        {
            try
            {
                puntoReciclajeCEN.Borrar(punto_id);
                Assert.Fail();
            }
            catch (Exception)
            {

            }        
        }

        [Then(@"Se borra el Punto")]
        public void ThenSeBorraElPunto()
        {
            Assert.IsNull(puntoReciclajeCEN.BuscarPorId(punto_id));
        }

        [Then(@"no se borra el Punto")]
        public void ThenNoSeBorraElPunto()
        {
            Assert.IsNull(puntoReciclajeCEN.BuscarPorId(punto_id));        
        }
    }
}
