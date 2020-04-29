using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using ReciclaUAGenNHibernate.Exceptions;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Validacion
{
    [Binding]
    public class DescartarMaterialSteps
    {
        public MaterialCEN materialCEN = new MaterialCEN();
        public string exception = "ModelException";
        public MaterialEN material;
        public int id;

        [Before]
        public void InitializeData()
        {
            id = materialCEN.Crear("Material Test", TipoContenedorEnum.cristal, -1);
            material = materialCEN.BuscarPorId(id);
        }

        [After]
        public void CleanData()
        {
            materialCEN.Borrar(id);
        }

        [Given(@"Tengo un material sin descartar")]
        public void GivenTengoUnMaterialSinDescartar()
        {
            materialCEN.Modificar(id, material.Nombre, material.Contenedor, EstadoEnum.enProceso);
        }
        
        [Given(@"Tengo un material ya validado")]
        public void GivenTengoUnMaterialYaValidado()
        {
            materialCEN.Modificar(id, material.Nombre, material.Contenedor, EstadoEnum.verificado);
        }
        
        [Given(@"Tengo un material ya descartado")]
        public void GivenTengoUnMaterialYaDescartado()
        {
            materialCEN.Modificar(id, material.Nombre, material.Contenedor, EstadoEnum.descartado);
        }
        
        [When(@"Descarto el material")]
        public void WhenDescartoElMaterial()
        {
            try
            {
                materialCEN.DescartarMaterial(id);
            }
            catch (ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"El material es descartado")]
        public void ThenElMaterialEsDescartado()
        {
            material = materialCEN.BuscarPorId(id);
            Assert.AreEqual(EstadoEnum.descartado, material.EsValido);
        }
        
        [Then(@"No se puede descartar el material")]
        public void ThenNoSePuedeDescartarElMaterial()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
