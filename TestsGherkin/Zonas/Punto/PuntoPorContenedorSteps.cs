using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Punto
{
    [Binding]
    public class PuntoPorContenedorSteps
    {
        public static PuntoReciclajeCEN puntoCEN;
        public static int punto_id;
        public static int contenedor_id;
        public static ContenedorCEN contenedorCEN;
        public static PuntoReciclajeEN puntoReciclaje;

        [Before(tags: "PuntoPorContenedor")]
        public static void InitializeData()
        {
           
                punto_id = new PuntoReciclajeCEN().Crear(12, 12, -1, "0500PB001");
                contenedor_id = new ContenedorCEN().Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, punto_id);
           
        }

        [After(tags: "PuntoPorContenedor")]
        public static void CleanData()
        {
            if (contenedor_id > 0 && punto_id > 0)
            {
                contenedorCEN.Borrar(contenedor_id);
                puntoCEN.Borrar(punto_id);

            }
        }
        [Given(@"Hay un punto de una contenedor especifica")]
        public void GivenHayUnPuntoDeUnaContenedorEspecifica()
        {
            puntoCEN = new PuntoReciclajeCEN();
            contenedorCEN = new ContenedorCEN();
        }

        [Given(@"No Hay un punto de un contenedor especifica")]
        public void GivenNoHayUnPuntoDeUnContenedorEspecifica()
        {
            puntoCEN = new PuntoReciclajeCEN();
            contenedorCEN = new ContenedorCEN();
            contenedor_id = -1;
        }

        [When(@"Busco el punto por ese contenedor")]
        public void WhenBuscoElPuntoPorEseContenedor()
        {
            puntoReciclaje = puntoCEN.BuscarPuntoPorContenedor(contenedor_id);
        }

        [When(@"Busco el punto por este contenedor")]
        public void WhenBuscoElPuntoPorEsteContenedor()
        {
            try
            {
                puntoReciclaje = puntoCEN.BuscarPuntoPorContenedor(contenedor_id);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Devuelvo el punto")]
        public void ThenDevuelvoElPunto()
        {
            Assert.IsNotNull(puntoReciclaje);
        }

        [Then(@"No se puede devolver el punto")]
        public void ThenNoSePuedeDevolverElPunto()
        {
            Assert.IsNull(puntoReciclaje);
        }
    }
}
