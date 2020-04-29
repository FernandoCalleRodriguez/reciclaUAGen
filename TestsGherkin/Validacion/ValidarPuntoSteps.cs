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
    public class ValidarPuntoSteps
    {
        public PuntoReciclajeCEN puntoCEN = new PuntoReciclajeCEN();
        public string exception = "ModelException";
        public PuntoReciclajeEN punto;
        public int id;

        [Before]
        public void InitializeData()
        {
            id = puntoCEN.Crear(0.0d, 0.0d, -1, null);
            punto = puntoCEN.BuscarPorId(id);
        }

        [After]
        public void CleanData()
        {
            puntoCEN.Borrar(id);
        }

        [Given(@"Tengo un punto sin validar")]
        public void GivenTengoUnPuntoSinValidar()
        {
            puntoCEN.Modificar(id, punto.Latitud, punto.Longitud, EstadoEnum.enProceso);
        }

        [Given(@"Tengo un punto validado")]
        public void GivenTengoUnPuntoValidado()
        {
            puntoCEN.Modificar(id, punto.Latitud, punto.Longitud, EstadoEnum.verificado);
        }

        [Given(@"Tengo un punto descartado")]
        public void GivenTengoUnPuntoDescartado()
        {
            puntoCEN.Modificar(id, punto.Latitud, punto.Longitud, EstadoEnum.descartado);
        }

        [When(@"Valido el punto")]
        public void WhenValidoElPunto()
        {
            try
            {
                puntoCEN.ValidarPunto(id);
            }
            catch (ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }

        [Then(@"El punto es validado")]
        public void ThenElPuntoEsValidado()
        {
            punto = puntoCEN.BuscarPorId(id);
            Assert.AreEqual(EstadoEnum.verificado, punto.EsValido);
        }

        [Then(@"No se puede validar el punto")]
        public void ThenNoSePuedeValidarElPunto()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
