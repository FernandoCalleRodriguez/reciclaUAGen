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
    public class DeleteNivelSteps
    {
        public static NivelEN nivel = null;
        public static int nivelId = -1;
        public static NivelCEN nivelCEN;

        [Before(tags: "DeleteNivelExists")]
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

        //[After(tags: "DeleteNivelExists")]
        //public static void CleanData()
        //{

        //    nivelCEN.Borrar(nivelId);

        //}

        [Given(@"Hay un nivel con un id especifico")]
        public void GivenHayUnNivelConUnIdEspecifico()
        {
            nivelCEN = new NivelCEN();
        }
        
        [Given(@"No ay un nivel con un id especifico")]
        public void GivenNoAyUnNivelConUnIdEspecifico()
        {
            nivelId = -1;
            nivelCEN = new NivelCEN();
        }

        [When(@"Elimino El nivel")]
        public void WhenEliminoElNivel()
        {
            try
            {
                nivelCEN.Borrar(nivelId);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
        
        [Then(@"Se borra el nivel")]
        public void ThenSeBorraElNivel()
        {
            Assert.IsNull(nivelCEN.BuscarPorId(nivelId));
        }
        
        [Then(@"no se borra el nivel")]
        public void ThenNoSeBorraElNivel()
        {
            Assert.IsNull(nivelCEN.BuscarPorId(nivelId));
        }
    }
}
