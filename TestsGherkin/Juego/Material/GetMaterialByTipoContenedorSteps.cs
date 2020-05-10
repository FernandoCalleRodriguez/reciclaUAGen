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
    public class GetMaterialByTipoContenedorSteps
    {

        public static MaterialCEN materialCEN;
        public static IList<MaterialEN> materiales = new List<MaterialEN>();
        public static int materialId = -1;
        public static int id1, id2;

        [Before(tags: "GetMaterialByTipoContenedor")]
        public static void InitializeData()
        {
            MaterialEN material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.organico,
                Nombre = "Contenedor 1"
            };
            MaterialEN material2 = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.papel,
                Nombre = "Contenedor 2"
            };
            id1 = new MaterialCEN().Crear(material.Nombre, material.Contenedor, -1);
            id2 = new MaterialCEN().Crear(material2.Nombre, material2.Contenedor, -1);

        }

        [After(tags: "GetMaterialByTipoContenedor")]
        public static void CleanData()
        {
            materialCEN.Borrar(id1);
            materialCEN.Borrar(id2);
        }

        [Given(@"Tengo materiales de un TipoContenedor específico")]
        public void GivenTengoMaterialesDeUnTipoContenedorEspecifico()
        {
            materialCEN = new MaterialCEN();
        }

        [Given(@"No hay un material de tipo Cristal")]
        public void GivenNoHayUnMaterialDeTipoCristal()
        {
            materialCEN = new MaterialCEN();
        }

        [When(@"Busco esos material por su TipoContenedor")]
        public void WhenBuscoEsosMaterialPorSuTipoContenedor()
        {
            materiales = materialCEN.BuscarPorTipoContenedor(TipoContenedorEnum.papel);
        }

        [When(@"Busco un material por ese tipo")]
        public void WhenBuscoUnMaterialPorEseTipo()
        {
            try
            {

                int tipo = -1;
                materiales = materialCEN.BuscarPorTipoContenedor((TipoContenedorEnum)tipo );
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"obtengo una lista de materiales de este TipoContenedor")]
        public void ThenObtengoUnaListaDeMaterialesDeEsteTipoContenedor()
        {
            Assert.IsTrue(materiales.Count > 0);
        }

        [Then(@"Obtengo una lista vacia")]
        public void ThenObtengoUnaListaVacia()
        {
            Assert.IsTrue(materiales.Count == 0);
        }
    }
}
