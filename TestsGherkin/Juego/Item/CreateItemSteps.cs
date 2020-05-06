using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Item
{
    [Binding]
    public class CreateItemSteps
    {
        public static ItemCEN itemCEN;
        public static ItemEN item;
        public static int itemId = -1;
        public static int materialId = -1;
        [Given(@"Quiero crear un Item nuevo con numero y pontuacion specifica")]
        public void GivenQuieroCrearUnItemNuevoConNumeroYPontuacionSpecifica()
        {
            MaterialEN material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.cristal,
                Nombre = "Contenedor 1"
            };
            materialId = new MaterialCEN().Crear(material.Nombre, material.Contenedor, -1);

             item = new ItemEN()
            {
                Nombre = "item",
                Descripcion = "description",
                Imagen = "image file path",
                EsValido = EstadoEnum.enProceso
            };

        }

        [After(tags: "CreateItem")]
        public static void CleanData()
        {
            itemCEN.Borrar(itemId);
            new MaterialCEN().Borrar(materialId);
        }
        [When(@"Creo el Item")]
        public void WhenCreoElItem()
        {
            itemCEN = new ItemCEN();
            itemId = itemCEN.Crear(item.Nombre, item.Descripcion, item.Imagen, -1, materialId);
            item = null;
        }

        [Then(@"Se Creo el Item")]
        public void ThenSeCreoElItem()
        {
            item = itemCEN.BuscarPorId(itemId);
            Assert.IsNotNull(item);
        }
    }
}
