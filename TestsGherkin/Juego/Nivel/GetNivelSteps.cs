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


        [Before(tags: "GetNivel")]
        public static void InitializeData()
        {
            ItemEN item = new ItemEN()
            {
                Nombre = "item",
                Descripcion = "description",
                Imagen = "image file path",
                EsValido = EstadoEnum.enProceso
            };
            ItemEN item2 = new ItemEN()
            {
                Nombre = "item2",
                Descripcion = "description2",
                Imagen = "image file path2",
                EsValido = EstadoEnum.enProceso
            };
            List<ItemEN> items = new List<ItemEN>();
            items.Add(item);
            Console.WriteLine("Init");
            NivelEN nivel = new NivelEN()
            {
                Item = items,
                Numero = 1,
                Puntuacion = 1
            };
            new NivelCEN().Crear(nivel.Numero, nivel.Puntuacion);
        }

        [After(tags: "GetNivel")]
        public static void CleanData()
        {
            foreach (var item in niveles)
            {
                nivelCEN.Borrar(item.Id);

            }

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
