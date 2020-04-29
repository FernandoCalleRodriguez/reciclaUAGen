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
    public class DescartarPuntoSteps
    {
        public static PuntoReciclajeCEN puntoCEN = new PuntoReciclajeCEN();
        public string exception = "ModelException";
        public static PuntoReciclajeEN punto;
        public static int id;

        [Before(tags: "DescartarPunto")]
        public static void InitializeData()
        {
            id = puntoCEN.Crear(0.0d, 0.0d, -1, null);
            punto = puntoCEN.BuscarPorId(id);
        }

        [After(tags: "DescartarPunto")]
        public static void CleanData()
        {
            puntoCEN.Borrar(id);
        }

        [Given(@"Tengo un punto sin descartar")]
        public void GivenTengoUnPuntoSinDescartar()
        {
            puntoCEN.Modificar(id, punto.Latitud, punto.Longitud, EstadoEnum.enProceso);
        }
        
        [Given(@"Tengo un punto ya validado")]
        public void GivenTengoUnPuntoYaValidado()
        {
            puntoCEN.Modificar(id, punto.Latitud, punto.Longitud, EstadoEnum.verificado);
        }
        
        [Given(@"Tengo un punto ya descartado")]
        public void GivenTengoUnPuntoYaDescartado()
        {
            puntoCEN.Modificar(id, punto.Latitud, punto.Longitud, EstadoEnum.descartado);
        }
        
        [When(@"Descarto el punto")]
        public void WhenDescartoElPunto()
        {
            try
            {
                puntoCEN.DescartarPunto(id);
            }
            catch (ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"El punto es descartado")]
        public void ThenElPuntoEsDescartado()
        {
            punto = puntoCEN.BuscarPorId(id);
            Assert.AreEqual(EstadoEnum.descartado, punto.EsValido);
        }
        
        [Then(@"No se puede descartar el punto")]
        public void ThenNoSePuedeDescartarElPunto()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
