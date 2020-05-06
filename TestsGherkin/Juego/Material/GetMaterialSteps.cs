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
    public class GetMaterialSteps
    {
        MaterialCEN materialCEN;
        IList<MaterialEN> materiales = new List<MaterialEN>();

        [Before(tags: "GetMaterial")]
        public static void InitializeData()
        {

            MaterialEN material = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.cristal,
                Nombre = "Contenedor 1"
            };
            MaterialEN material2 = new MaterialEN()
            {
                Contenedor = TipoContenedorEnum.cristal,
                Nombre = "Contenedor 2"
            };
            int id1 = new MaterialCEN().Crear(material.Nombre, material.Contenedor, -1);
            int id2 = new MaterialCEN().Crear(material2.Nombre, material2.Contenedor, -1);
        }


        [Given(@"tengo materiales")]
        public void GivenTengoMateriales()
        {
            materialCEN = new MaterialCEN();
        }

        [When(@"Obtengo los materiales")]
        public void WhenObtengoLosMateriales()
        {
            materiales = materialCEN.BuscarTodos(0, -1);
        }

        [Then(@"Obtengo una lista con los materiales disponible")]
        public void ThenObtengoUnaListaConLosMaterialesDisponible()
        {
            Assert.IsTrue(materiales.Count > 0);
        }
    }
}
