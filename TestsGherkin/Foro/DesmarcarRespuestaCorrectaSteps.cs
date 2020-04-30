using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Exceptions;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Foro
{
    [Binding]
    public class DesmarcarRespuestaCorrectaSteps
    {
        public static RespuestaCEN respuestaCEN = new RespuestaCEN();
        public string exception = "ModelException";
        public static RespuestaEN respuesta;
        public static int id;

        [Before(tags: "DesmarcarRespuestaCorrecta")]
        public static void InitializeData()
        {
            id = respuestaCEN.Crear("Respuesta Test", -1, -1);
            respuesta = respuestaCEN.BuscarPorId(id);
        }

        [After(tags: "DesmarcarRespuestaCorrecta")]
        public static void CleanData()
        {
            respuestaCEN.Borrar(id);
        }

        [Given(@"Tengo una respuesta ya correcta")]
        public void GivenTengoUnaRespuestaYaCorrecta()
        {
            respuestaCEN.Modificar(id, respuesta.Cuerpo, respuesta.Fecha, true, respuesta.Util);
        }
        
        [Given(@"Tengo una respuesta incorrecta")]
        public void GivenTengoUnaRespuestaIncorrecta()
        {
            respuestaCEN.Modificar(id, respuesta.Cuerpo, respuesta.Fecha, false, respuesta.Util);
        }
        
        [When(@"Desmarco la respuesta como correcta")]
        public void WhenDesmarcoLaRespuestaComoCorrecta()
        {
            try
            {
                respuestaCEN.DescartarRespuestaCorrecta(id);
            }
            catch (ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"La respuesta es no correcta")]
        public void ThenLaRespuestaEsNoCorrecta()
        {
            respuesta = respuestaCEN.BuscarPorId(id);
            Assert.AreEqual(false, respuesta.EsCorrecta);
        }
        
        [Then(@"La respuesta no se puede desmarcar como correcta")]
        public void ThenLaRespuestaNoSePuedeDesmarcarComoCorrecta()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
