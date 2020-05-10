using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Nivel
{
    [Binding]
    public class GetNivelSteps
    {
        public static IList<NivelEN> niveles;
        public static NivelCEN nivelCEN;
        public static int id;


        [Before(tags: "GetNivel")]
        public static void InitializeData()
        {
            Console.WriteLine("Init");
            NivelEN nivel = new NivelEN()
            {
                Numero = 1,
                Puntuacion = 1
            };
            id = new NivelCEN().Crear(nivel.Numero, nivel.Puntuacion);
        }

        [After(tags: "GetNivel")]
        public static void CleanData()
        {
            nivelCEN.Borrar(id);
        }

        [Given(@"tengo niveles")]
        public void GivenTengoNiveles()
        {
            nivelCEN = new NivelCEN();
        }

        [When(@"Obtengo los niveles")]
        public void WhenObtengoLosNiveles()
        {
            niveles = nivelCEN.BuscarTodos(0, -1);
        }

        [Then(@"Obtengo una lista con los niveles disponible")]
        public void ThenObtengoUnaListaConLosNivelesDisponible()
        {
            Assert.AreNotEqual(niveles.Count, 0);
        }
    }
}
