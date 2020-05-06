using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Contenedor
{
    [Binding]
    public class CreateContenedorSteps
    {
        public static ContenedorEN contenedor;
        public static ContenedorCEN contenedorCEN;
        public static int tipo = -1;
        public static int id_contenedor, id_punto;

        [After(tags: "CreateContenedor")]
        public static void CleanData()
        {

            contenedorCEN.Borrar(id_contenedor);
        }

        [Given(@"Quiero crear un Contenedor nuevo con numero y pontuacion specifica")]
        public void GivenQuieroCrearUnContenedorNuevoConNumeroYPontuacionSpecifica()
        {
            contenedorCEN = new ContenedorCEN();
        }

        [When(@"Creo el Contenedor")]
        public void WhenCreoElContenedor()
        {
            id_contenedor = contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, -1);
        }

        [Then(@"Se Creo el Contenedor")]
        public void ThenSeCreoElContenedor()
        {
            contenedor = contenedorCEN.BuscarPorId(id_contenedor);
            Assert.IsNotNull(contenedor);
        }
    }
}
