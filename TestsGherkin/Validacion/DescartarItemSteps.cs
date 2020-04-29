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
    public class DescartarItemSteps
    {
        public ItemCEN itemCEN = new ItemCEN();
        public string exception = "ModelException";
        public ItemEN item;
        public int id;

        [Before]
        public void InitializeData()
        {
            id = itemCEN.Crear("Item Test", "Item Test", "IMG TEST", -1, -1);
            item = itemCEN.BuscarPorId(id);
        }

        [After]
        public void CleanData()
        {
            itemCEN.Borrar(id);
        }

        [Given(@"Tengo un item sin descartar")]
        public void GivenTengoUnItemSinDescartar()
        {
            itemCEN.Modificar(id, item.Nombre, item.Descripcion, item.Imagen, EstadoEnum.enProceso);
        }
        
        [Given(@"Tengo un item ya validado")]
        public void GivenTengoUnItemYaValidado()
        {
            itemCEN.Modificar(id, item.Nombre, item.Descripcion, item.Imagen, EstadoEnum.verificado);
        }
        
        [Given(@"Tengo un item ya descartado")]
        public void GivenTengoUnItemYaDescartado()
        {
            itemCEN.Modificar(id, item.Nombre, item.Descripcion, item.Imagen, EstadoEnum.descartado);
        }
        
        [When(@"Descarto el item")]
        public void WhenDescartoElItem()
        {
            try
            {
                itemCEN.DescartarItem(id);
            }
            catch (ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"El item es descartado")]
        public void ThenElItemEsDescartado()
        {
            item = itemCEN.BuscarPorId(id);
            Assert.AreEqual(EstadoEnum.descartado, item.EsValido);
        }
        
        [Then(@"No se puede descartar el item")]
        public void ThenNoSePuedeDescartarElItem()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
