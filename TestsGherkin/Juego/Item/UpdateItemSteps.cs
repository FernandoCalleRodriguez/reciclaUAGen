using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Item
{
    [Binding]
    public class UpdateItemSteps
    {
        public static ItemCEN itemCEN;
        public static ItemEN item = null;
        public static int itemId = -1, idMaterial;
        [Before(tags: "UpdateItemExists")]
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
        }


        [After(tags: "UpdateItemExists")]
        public static void CleanData()
        {
            
                itemCEN.Borrar(itemId);
                new MaterialCEN().Borrar(idMaterial);
          
        }

        [Given(@"Existe un Item con id especifico")]
        public void GivenExisteUnItemConIdEspecifico()
        {
            itemCEN = new ItemCEN();
            item = itemCEN.BuscarPorId(itemId);
        }

        [Given(@"No existe un Item con id (.*)")]
        public void GivenNoExisteUnItemConId(int p0)
        {
            itemCEN = new ItemCEN();
            itemId = -1;
        }

        [When(@"Modifico los datos de este Item")]
        public void WhenModificoLosDatosDeEsteItem()
        {
            itemCEN.Modificar(itemId, item.Nombre + " modificado", item.Descripcion, item.Imagen, item.EsValido);
        }

        [When(@"Entento odifico los datos de este Item")]
        public void WhenEntentoOdificoLosDatosDeEsteItem()
        {
            try
            {
                itemCEN.Modificar(itemId, item.Nombre + " modificado", item.Descripcion, item.Imagen, item.EsValido);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Obtengo el Item con los datos modificados")]
        public void ThenObtengoElItemConLosDatosModificados()
        {
            ItemEN UpdatedItem = itemCEN.BuscarPorId(itemId);
            Assert.AreEqual(UpdatedItem.Nombre, item.Nombre + " modificado");
        }

        [Then(@"No se puede modificar el Item")]
        public void ThenNoSePuedeModificarElItem()
        {
            ItemEN UpdatedItem = itemCEN.BuscarPorId(itemId);
            Assert.IsNull(UpdatedItem);
        }
    }
}
