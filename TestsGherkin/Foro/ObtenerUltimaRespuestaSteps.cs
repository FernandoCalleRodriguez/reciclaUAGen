using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CP.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Foro
{
    [Binding]
    public class ObtenerUltimaRespuestaSteps
    {
        public static RespuestaCEN respuestaCEN = new RespuestaCEN();
        public static DudaCEN dudaCEN = new DudaCEN();
        public string exception = "ModelException";
        public static RespuestaEN respuesta;
        public static List<int> ids = new List<int>();
        public static int id_duda;

        [Before(tags: "ObtenerUltimaRespuesta")]
        public static void InitializeData()
        {
            id_duda = dudaCEN.Crear("Duda Test", "Duda Test", -1, TemaEnum.anecdota);
        }

        [After(tags: "ObtenerUltimaRespuesta")]
        public static void CleanData()
        {
            dudaCEN.Borrar(id_duda);
        }


        [Given(@"Tengo una duda con respuesta")]
        public void GivenTengoUnaDudaConRespuesta()
        {
            for (int i = 0; i < 5; i++)
            {
                int id = respuestaCEN.Crear("Respuesta Test", id_duda, -1);
                ids.Add(id);
            }
        }
        
        [Given(@"Tengo una duda sin respuestas")]
        public void GivenTengoUnaDudaSinRespuestas()
        {
           
        }
        
        [When(@"Obtengo la ultima respuesta")]
        public void WhenObtengoLaUltimaRespuesta()
        {
            respuesta = new RespuestaCP().ObtenerUltimaRespuesta(id_duda);
        }
        
        [Then(@"Obtengo la ultima respuesta de la duda")]
        public void ThenObtengoLaUltimaRespuestaDeLaDuda()
        {
            Assert.AreEqual(ids[ids.Count - 1], respuesta.Id);
        }
        
        [Then(@"No obtengo ninguna respuesta")]
        public void ThenNoObtengoNingunaRespuesta()
        {
            Assert.IsNull(respuesta);
        }
    }
}
