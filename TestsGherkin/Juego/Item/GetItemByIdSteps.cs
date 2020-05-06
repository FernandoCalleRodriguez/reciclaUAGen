using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin
{
    [Binding]
    public class GetItemByIdSteps
    {

        public static ItemCEN itemCEN;
        public static ItemEN item = null;
        public static int itemId = -1,idMaterial;
        [Before(tags: "GetItemById")]
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
            itemId = new ItemCEN().Crear(item.Nombre, item.Descripcion, item.Imagen, -1, idMaterial);
            item = null;
        }


        [After(tags: "GetItemById")]
        public static void CleanData()
        {
            itemCEN.Borrar(itemId);
            new MaterialCEN().Borrar(idMaterial);
        }

        [Given(@"Tengo un Item con una id específico")]
        public void GivenTengoUnItemConUnaIdEspecifico()
        {
            itemCEN = new ItemCEN();
        }

        [Given(@"No hay un Item con Id (.*)")]
        public void GivenNoHayUnItemConId(int p0)
        {
            itemCEN = new ItemCEN();
            itemId = -1;
        }

        [When(@"Busco el Item pos su id")]
        public void WhenBuscoElItemPosSuId()
        {
            item = itemCEN.BuscarPorId(itemId);
        }

        [When(@"Busco un Item por ese id")]
        public void WhenBuscoUnItemPorEseId()
        {
            try
            {
                item = itemCEN.BuscarPorId(itemId);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"obtengo este Item")]
        public void ThenObtengoEsteItem()
        {
            Assert.IsNotNull(item);
        }

        [Then(@"No se puede devolver un Item")]
        public void ThenNoSePuedeDevolverUnItem()
        {
            Assert.IsNull(item);
        }
    }
}
