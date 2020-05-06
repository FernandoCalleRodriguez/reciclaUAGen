using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Material
{
    [Binding]
    public class UpdateMaterialSteps
    {

        public static MaterialCEN materialCEN;
        public static MaterialEN material = null;
        public static int materialId = -1;
        [Before(tags: "UpdateMaterialExists")]
        public static void InitializeData()
        {


            material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.cristal,
                Nombre = "Contenedor 2"
            };

            materialId = new MaterialCEN().Crear(material.Nombre, material.Contenedor, -1);


        }

        [After(tags: "UpdateMaterialExists")]
        public static void CleanData()
        {

            materialCEN.Borrar(materialId);

        }

        [Given(@"Existe un Material con id especifico")]
        public void GivenExisteUnMaterialConIdEspecifico()
        {
            materialCEN = new MaterialCEN();
        }

        [Given(@"No existe un Material con id (.*)")]
        public void GivenNoExisteUnMaterialConId(int p0)
        {
            materialCEN = new MaterialCEN();
            materialId = -1;
        }

        [When(@"Modifico los datos de este Material")]
        public void WhenModificoLosDatosDeEsteMaterial()
        {
            materialCEN.Modificar(materialId, material.Nombre + " Modificado", material.Contenedor, material.EsValido);
        }

        [When(@"Entento odifico los datos de este Material")]
        public void WhenEntentoOdificoLosDatosDeEsteMaterial()
        {
            try
            {
                materialCEN.Modificar(materialId, material.Nombre + " Modificado", material.Contenedor, material.EsValido);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Then(@"Obtengo el Material con los datos modificados")]
        public void ThenObtengoElMaterialConLosDatosModificados()
        {
            Assert.AreEqual(materialCEN.BuscarPorId(materialId).Nombre, material.Nombre + " Modificado");
        }

        [Then(@"No se puede modificar el Material")]
        public void ThenNoSePuedeModificarElMaterial()
        {
            Assert.IsNull(materialCEN.BuscarPorId(materialId));
        }
    }
}
