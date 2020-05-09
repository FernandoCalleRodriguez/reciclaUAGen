using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Punto
{
    [Binding]
    public class CreatePuntoSteps
    {
        public static PuntoReciclajeCEN puntoReciclajeCEN;
        public static int id = -1;

        [After(tags: "CreatePunto")]
        public static void CleanData()
        {
            if (id > 0)
            {
                puntoReciclajeCEN.Borrar(id);

            }
        }
        [Given(@"Quiero crear un Punto nuevo con numero y pontuacion specifica")]
        public void GivenQuieroCrearUnPuntoNuevoConNumeroYPontuacionSpecifica()
        {
            puntoReciclajeCEN = new PuntoReciclajeCEN();

        }

        [When(@"Creo el Punto")]
        public void WhenCreoElPunto()
        {
            id = puntoReciclajeCEN.Crear(12, 12, -1, null);
        }

        [Then(@"Se Creo el Punto")]
        public void ThenSeCreoElPunto()
        {
            Assert.IsTrue(id > 0);
        }
    }
}
