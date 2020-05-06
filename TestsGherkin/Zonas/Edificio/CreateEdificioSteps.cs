using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Edificio
{
    [Binding]
    public class CreateEdificioSteps
    {
        public static EdificioCEN edificioCEN;
        public static int id_edificio;

        [After(tags: "CreateEdificio")]
        public static void CleanData()
        {

            if (id_edificio > 0)
                edificioCEN.Borrar(id_edificio);
            
        }
        [Given(@"Quiero crear un Edificio nuevo con numero y pontuacion specifica")]
        public void GivenQuieroCrearUnEdificioNuevoConNumeroYPontuacionSpecifica()
        {
            edificioCEN = new EdificioCEN();
        }

        [When(@"Creo el Edificio")]
        public void WhenCreoElEdificio()
        {
            id_edificio = edificioCEN.Crear("Edificio 1", 1234);
        }

        [Then(@"Se Creo el Edificio")]
        public void ThenSeCreoElEdificio()
        {
            Assert.IsTrue(id_edificio > 0);
        }
    }
}
