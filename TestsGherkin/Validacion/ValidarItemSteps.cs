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
    public class ValidarItemSteps
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

        [Given(@"Tengo un item sin validar")]
        public void GivenTengoUnItemSinValidar()
        {
            itemCEN.Modificar(id, item.Nombre, item.Descripcion, item.Imagen, EstadoEnum.enProceso);
        }

        [Given(@"Tengo un item validado")]
        public void GivenTengoUnItemValidado()
        {
            itemCEN.Modificar(id, item.Nombre, item.Descripcion, item.Imagen, EstadoEnum.verificado);
        }

        [Given(@"Tengo un item descartado")]
        public void GivenTengoUnItemDescartado()
        {
            itemCEN.Modificar(id, item.Nombre, item.Descripcion, item.Imagen, EstadoEnum.descartado);
        }

        [When(@"Valido el item")]
        public void WhenValidoElItem()
        {
            try
            {
                itemCEN.ValidarItem(id);
            }
            catch (ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }

        }

        [Then(@"El item es validado")]
        public void ThenElItemEsValidado()
        {
            item = itemCEN.BuscarPorId(id);
            Assert.AreEqual(EstadoEnum.verificado, item.EsValido);
        }

        [Then(@"No se puede validar el item")]
        public void ThenNoSePuedeValidarElItem()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
