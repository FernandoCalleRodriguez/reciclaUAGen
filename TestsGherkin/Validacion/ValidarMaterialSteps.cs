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
    public class ValidarMaterialSteps
    {
        public static MaterialCEN materialCEN = new MaterialCEN();
        public string exception = "ModelException";
        public static MaterialEN material;
        public static int id;

        [Before(tags: "ValidarMaterial")]
        public static void InitializeData()
        {
            id = materialCEN.Crear("Material Test", TipoContenedorEnum.cristal, -1);
            material = materialCEN.BuscarPorId(id);
        }

        [After(tags: "ValidarMaterial")]
        public static void CleanData()
        {
            materialCEN.Borrar(id);
        }

        [Given(@"Tengo un material sin validar")]
        public void GivenTengoUnMaterialSinValidar()
        {
            materialCEN.Modificar(id, material.Nombre, material.Contenedor, EstadoEnum.enProceso);
        }
        
        [Given(@"Tengo un material validado")]
        public void GivenTengoUnMaterialValidado()
        {
            materialCEN.Modificar(id, material.Nombre, material.Contenedor, EstadoEnum.verificado);
        }
        
        [Given(@"Tengo un material descartado")]
        public void GivenTengoUnMaterialDescartado()
        {
            materialCEN.Modificar(id, material.Nombre, material.Contenedor, EstadoEnum.descartado);
        }
        
        [When(@"Valido el material")]
        public void WhenValidoElMaterial()
        {
            try
            {
                materialCEN.ValidarMaterial(id);
            }
            catch (ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"El material es validado")]
        public void ThenElMaterialEsValidado()
        {
            material = materialCEN.BuscarPorId(id);
            Assert.AreEqual(EstadoEnum.verificado, material.EsValido);
        }
        
        [Then(@"No se puede validar el material")]
        public void ThenNoSePuedeValidarElMaterial()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
