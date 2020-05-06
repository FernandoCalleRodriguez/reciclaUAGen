using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Juego.Material
{
    [Binding]
    public class CreateMaterialSteps
    {
        public static MaterialCEN materialCEN;
        public static MaterialEN material = null;
        public static int materialId = -1;

        [After(tags: "CreateMaterial")]
        public static void CleanData()
        {

            materialCEN.Borrar(materialId);
        }

        [Given(@"Quiero crear un material nuevo con informaciones specificas")]
        public void GivenQuieroCrearUnMaterialNuevoConInformacionesSpecificas()
        {
            material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.organico,
                Nombre = "Contenedor 123"
            };
            materialCEN = new MaterialCEN();

        }

        [When(@"Creo el material")]
        public void WhenCreoElMaterial()
        {
            materialId = materialCEN.Crear(material.Nombre, material.Contenedor, -1);
        }

        [Then(@"Se Creo el material")]
        public void ThenSeCreoElMaterial()
        {
            Assert.IsNotNull(materialCEN.BuscarPorId(materialId));
        }
    }
}
