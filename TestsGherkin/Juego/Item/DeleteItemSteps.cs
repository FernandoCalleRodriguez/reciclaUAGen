using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Item
{
    [Binding]
    public class DeleteItemSteps
    {

        public static ItemCEN itemCEN;
        public static ItemEN item = null;
        public static int itemId = -1, idMaterial;


        [Before(tags: "DeleteItemExists")]
        public static void InitializeData()
        {

            MaterialEN material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.cristal,
                Nombre = "Contenedor 1"
            };
            idMaterial = new MaterialCEN().Crear(material.Nombre, material.Contenedor, -1);

            item = new ItemEN()
            {
                Nombre = "item",
                Descripcion = "description",
                Imagen = "image file path",
                EsValido = EstadoEnum.enProceso
            };
            itemId = new ItemCEN().Crear(item.Nombre, item.Descripcion, item.Imagen, -1, idMaterial);
        }
        //[After(tags: "DeleteItemExists")]
        //public static void CleanData()
        //{
        //    new MaterialCEN().Borrar(idMaterial);
        //    itemCEN.Borrar(itemId);
        //}


        [Given(@"Hay un Item con un id especifico")]
        public void GivenHayUnItemConUnIdEspecifico()
        {
            itemCEN = new ItemCEN();
        }

        [Given(@"No hay un Item con un id especifico")]
        public void GivenNoHayUnItemConUnIdEspecifico()
        {
            itemId = -1;
            itemCEN = new ItemCEN();
        }

        [When(@"Elimino El Item")]
        public void WhenEliminoElItem()
        {
            itemCEN.Borrar(itemId);
        }

        [When(@"Entento elimino El Item")]
        public void WhenEntentoEliminoElItem()
        {
            try
            {
                itemCEN.Borrar(itemId);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Se borra el Item")]
        public void ThenSeBorraElItem()
        {
            item = itemCEN.BuscarPorId(itemId);
            Assert.IsNull(item);
        }

        [Then(@"no se borra el Item")]
        public void ThenNoSeBorraElItem()
        {
            item = itemCEN.BuscarPorId(itemId);
            Assert.IsNull(item);
        }
    }
}
