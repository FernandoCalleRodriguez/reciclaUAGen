using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Edificio
{
    [Binding]
    public class GetEdificiosSteps
    {
        public static int id_edificio1, id_edificio2;
        IList<EdificioEN> edificios = new List<EdificioEN>();
        public static EdificioCEN edificioCEN;
        [Before(tags: "GetEdificios")]
        public static void InitializeData()
        {
            id_edificio2 = new EdificioCEN().Crear("Edificio 1", 3212341);
            id_edificio1 = new EdificioCEN().Crear("Edificio 2", 4443432);
        }


        [After(tags: "GetEdificios")]
        public static void CleanData()
        {
            if (id_edificio1 > 0 && id_edificio2 > 0)
            {
                edificioCEN.Borrar(id_edificio1);
                edificioCEN.Borrar(id_edificio2);
            }
        }

        [Given(@"tengo Edificios")]
        public void GivenTengoEdificios()
        {
            edificioCEN = new EdificioCEN();
        }

        [When(@"Obtengo los Edificios")]
        public void WhenObtengoLosEdificios()
        {
            edificios = edificioCEN.BuscarTodos(0, -1);
        }

        [Then(@"Obtengo una lista con los Edificios disponible")]
        public void ThenObtengoUnaListaConLosEdificiosDisponible()
        {
            Assert.IsTrue(edificios.Count > 0);
        }
    }
}
