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
    public class GetNivelByIdSteps
    {
        public static NivelEN nivel;
        public static int nivelId;
        public static NivelCEN nivelCEN;

        [Before(tags: "GetNivelById")]
        public static void InitializeData()
        {
            ItemEN item = new ItemEN()
            {
                Nombre = "item",
                Descripcion = "description",
                Imagen = "image file path",
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
            nivelId = new NivelCEN().Crear(nivel.Numero, nivel.Puntuacion);
        }

        [After(tags: "GetNivelById")]
        public static void CleanData()
        {
            if (nivelId > 0)
                nivelCEN.Borrar(nivelId);
        }

        [Given(@"Tengo un nivel con una id específico")]
        public void GivenTengoUnNivelConUnaIdEspecifico()
        {
            nivelCEN = new NivelCEN();
        }


        [When(@"Busco el nivel pos su id")]
        public void WhenBuscoElNivelPosSuId()
        {
            nivel = nivelCEN.BuscarPorId(nivelId);
        }

        [Then(@"obtengo este nivel")]
        public void ThenObtengoEsteNivel()
        {
            Assert.IsNotNull(nivel);
        }

        [Given(@"No hay un nivel con Id")]
        public void GivenNoHayUnNivelConId()
        {
            nivelCEN = new NivelCEN();
        }

        [When(@"Busco un nivel por ese nivel")]
        public void WhenBuscoUnNivelPorEseNivel()
        {
            nivel = nivelCEN.BuscarPorId(-1);
        }

        [Then(@"No se puede devolver un nivel")]
        public void ThenNoSePuedeDevolverUnNivel()
        {
            Assert.IsNull(nivel);
        }
    }
}
