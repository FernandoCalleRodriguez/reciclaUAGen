using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Material
{
    [Binding]
    public class GetMaterialByIdSteps
    {

        public static MaterialCEN materialCEN;
        public static MaterialEN material = null;
        public static int materialId = -1;
        [Before(tags: "GetMaterialById")]
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

        [After(tags: "GetMaterialById")]
        public static void CleanData()
        {

            materialCEN.Borrar(materialId);
        }

        [Given(@"Tengo un material con una id específico")]
        public void GivenTengoUnMaterialConUnaIdEspecifico()
        {
            materialCEN = new MaterialCEN();
        }

        [Given(@"No hay un material con Id (.*)")]
        public void GivenNoHayUnMaterialConId(int p0)
        {
            materialCEN = new MaterialCEN();
            materialId = -1;
        }

        [When(@"Busco el material pos su id")]
        public void WhenBuscoElMaterialPosSuId()
        {
            material = materialCEN.BuscarPorId(materialId);
        }

        [When(@"Busco un material por ese id")]
        public void WhenBuscoUnMaterialPorEseId()
        {
            try
            {
                material = materialCEN.BuscarPorId(materialId);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [Then(@"obtengo este material")]
        public void ThenObtengoEsteMaterial()
        {
            Assert.IsNotNull(material);
        }

        [Then(@"No se puede devolver un material")]
        public void ThenNoSePuedeDevolverUnMaterial()
        {
            Assert.IsNull(material);
        }
    }
}
