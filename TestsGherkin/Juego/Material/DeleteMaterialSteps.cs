using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Material
{
    [Binding]
    public class DeleteMaterialSteps
    {
        public static MaterialCEN materialCEN;
        public static MaterialEN material = null;
        public static int materialId = -1;
        [Before(tags: "DeleteMaterialExists")]
        public static void InitializeData()
        {


            material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.cristal,
                Nombre = "Contenedor 2"
            };

            materialId = new MaterialCEN().Crear(material.Nombre, material.Contenedor, -1);

            material = null;
        }


        //[After(tags: "DeleteMaterialExists")]
        //public static void CleanData()
        //{

        //    materialCEN.Borrar(materialId);
        //}
        [Given(@"Hay un Material con un id especifico")]
        public void GivenHayUnMaterialConUnIdEspecifico()
        {
            materialCEN = new MaterialCEN();
        }

        [Given(@"No hay un Material con un id especifico")]
        public void GivenNoHayUnMaterialConUnIdEspecifico()
        {
            materialCEN = new MaterialCEN();
            materialId = -1;
        }

        [When(@"Elimino El Material")]
        public void WhenEliminoElMaterial()
        {
            materialCEN.Borrar(materialId);
        }

        [When(@"Entento elimino El Material")]
        public void WhenEntentoEliminoElMaterial()
        {
            try
            {
                materialCEN.Borrar(materialId);
                Assert.Fail();
            }
            catch (Exception)
            {

            }

        }

        [Then(@"Se borra el Material")]
        public void ThenSeBorraElMaterial()
        {
            Assert.IsNull(materialCEN.BuscarPorId(materialId));
        }

        [Then(@"no se borra el Material")]
        public void ThenNoSeBorraElMaterial()
        {
            Assert.IsNull(materialCEN.BuscarPorId(materialId));
        }
    }
}
