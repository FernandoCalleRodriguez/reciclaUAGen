using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Item
{
    [Binding]
    public class GetItemsSteps
    {
        public static ItemCEN itemCEN;
        public static IList<ItemEN> items = new List<ItemEN>();
        public static int idMaterial;
        public static int itemId1, itemId2;

        [Before(tags: "GetItems")]
        public static void InitializeData()
        {

            MaterialEN material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.cristal,
                Nombre = "Contenedor 1"
            };
            idMaterial = new MaterialCEN().Crear(material.Nombre, material.Contenedor, -1);

            ItemEN item = new ItemEN()
            {
                Nombre = "item",
                Descripcion = "description",
                Imagen = "image file path",
                EsValido = EstadoEnum.enProceso
            };
            itemId1 = new ItemCEN().Crear(item.Nombre, item.Descripcion, item.Imagen, -1, idMaterial);
            item = new ItemEN()
            {
                Nombre = "item2",
                Descripcion = "description2",
                Imagen = "image file path2",
                EsValido = EstadoEnum.descartado
            };
            itemId2 = new ItemCEN().Crear(item.Nombre, item.Descripcion, item.Imagen, -1, idMaterial);

        }

        [After(tags: "GetItems")]
        public static void CleanData()
        {
            new MaterialCEN().Borrar(idMaterial);
            itemCEN.Borrar(itemId1);
            itemCEN.Borrar(itemId2);
        }

        [Given(@"tengo Items")]
        public void GivenTengoItems()
        {
            itemCEN = new ItemCEN();
        }

        [When(@"Obtengo los Items")]
        public void WhenObtengoLosItems()
        {
            items = itemCEN.BuscarTodos(0, -1);
        }

        [Then(@"Obtengo una lista con los Items disponible")]
        public void ThenObtengoUnaListaConLosItemsDisponible()
        {
            Assert.IsTrue(items.Count > 0);
        }
    }
}
