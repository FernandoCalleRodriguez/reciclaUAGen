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
    public class UpdateNivelSteps
    {
        public static NivelCEN nivelCEN;
        public static NivelEN nivel = null;
        public static int nivelId = 0;

        [Before(tags: "UpdateNivelExists")]
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
            nivel = new NivelEN()
            {
                Item = items,
                Numero = 1,
                Puntuacion = 1
            };
            nivelId = new NivelCEN().Crear(nivel.Numero, nivel.Puntuacion);
            nivel.Id = nivelId;
        }
        [After(tags: "UpdateNivelExists")]

        public static void CleanData()
        {

            nivelCEN.Borrar(nivelId);
        }

        [Given(@"Existe un nivel con id especifico")]
        public void GivenExisteUnNivelConIdEspecifico()
        {
            nivelCEN = new NivelCEN();
        }

        [Given(@"No existe un nivel con id (.*)")]
        public void GivenNoExisteUnNivelConId(int p0)
        {
            nivelId = -1;
            nivelCEN = new NivelCEN();
        }

        [When(@"Modifico los datos de este nivel")]
        public void WhenModificoLosDatosDeEsteNivel()
        {
            try
            {
                nivelCEN.Modificar(nivelId, 5, 5);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [Then(@"Obtengo el nivel con los datos modificados")]
        public void ThenObtengoElNivelConLosDatosModificados()
        {
            Assert.AreNotEqual(nivel.Numero, nivelCEN.BuscarPorId(nivelId).Numero);
        }

        [Then(@"No se puede modificar el nivel")]
        public void ThenNoSePuedeModificarElNivel()
        {
            try
            {
                nivelCEN.Modificar(nivelId, 5, 5);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
