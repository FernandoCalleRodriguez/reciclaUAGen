using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin
{
    [Binding]
    public class CreateNivelSteps
    {
        public static NivelCEN nivelCEN;
        public static NivelEN nivel = null;
        public static ItemEN item;
        public static int nivelId = 0;

        [After(tags: "CreateNivel")]
        public static void CleanData()
        {

            nivelCEN.Borrar(nivelId);
        }

        [Given(@"Quiero crear un nivel nuevo con numero y pontuacion specifica")]
        public void GivenQuieroCrearUnNivelNuevoConNumeroYPontuacionSpecifica()
        {

             item = new ItemEN()
            {
                Nombre = "item",
                Descripcion = "description",
                Imagen = "image file path",
                EsValido = EstadoEnum.enProceso
            };

            List<ItemEN> items = new List<ItemEN>();
            items.Add(item);
            Console.WriteLine("Init");
            nivel = new NivelEN()
            {
                Item = items,
                Numero = 1,
                Puntuacion = 1
            };
        }

        [When(@"Creo el nivel")]
        public void WhenCreoElNivel()
        {
            nivelCEN = new NivelCEN();
            nivelId = nivelCEN.Crear(nivel.Numero, nivel.Puntuacion);
        }

        [Then(@"Se Creo el nivel")]
        public void ThenSeCreoElNivel()
        {
            Assert.AreNotEqual(0, nivelId);
        }
    }
}
