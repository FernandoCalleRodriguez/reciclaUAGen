using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using ReciclaUAGenNHibernate.Exceptions;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Foro
{
    [Binding]
    public class MarcarRespuestaCorrectaSteps
    {
        public static RespuestaCEN respuestaCEN = new RespuestaCEN();
        public string exception = "ModelException";
        public static RespuestaEN respuesta;
        public static int id;

        [Before(tags: "MarcarRespuestaCorrecta")]
        public static void InitializeData()
        {
            id = respuestaCEN.Crear("Respuesta Test", -1, -1);
            respuesta = respuestaCEN.BuscarPorId(id);
        }

        [After(tags: "MarcarRespuestaCorrecta")]
        public static void CleanData()
        {
            respuestaCEN.Borrar(id);
        }

        [Given(@"Tengo una respuesta no correcta")]
        public void GivenTengoUnaRespuestaNoCorrecta()
        {
            respuestaCEN.Modificar(id, respuesta.Cuerpo, respuesta.Fecha, false, respuesta.Util);
        }
        
        [Given(@"Tengo una respuesta correcta")]
        public void GivenTengoUnaRespuestaCorrecta()
        {
            respuestaCEN.Modificar(id, respuesta.Cuerpo, respuesta.Fecha, true, respuesta.Util);
        }
        
        [When(@"Marco la respuesta como correcta")]
        public void WhenMarcoLaRespuestaComoCorrecta()
        {
            try
            {
                respuestaCEN.ConfirmacionRespuestaCorrecta(id);
            }
            catch(ModelException e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"La respuesta es correcta")]
        public void ThenLaRespuestaEsCorrecta()
        {
            respuesta = respuestaCEN.BuscarPorId(id);
            Assert.AreEqual(true, respuesta.EsCorrecta);
        }
        
        [Then(@"La respuesta no se puede marcar como correcta")]
        public void ThenLaRespuestaNoSePuedeMarcarComoCorrecta()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
