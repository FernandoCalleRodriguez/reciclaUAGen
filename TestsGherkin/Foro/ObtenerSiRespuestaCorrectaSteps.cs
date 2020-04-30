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
    public class ObtenerSiRespuestaCorrectaSteps
    {
        public static RespuestaCEN respuestaCEN = new RespuestaCEN();
        public static DudaCEN dudaCEN = new DudaCEN();
        public string exception = "ModelException";
        public static RespuestaEN respuesta;
        public static List<int> ids = new List<int>();
        public static int id_duda;
        public static bool resultado;

        [Before(tags: "ObtenerSiRespuestaCorrecta")]
        public static void InitializeData()
        {
            id_duda = dudaCEN.Crear("Duda Test", "Duda Test", -1, TemaEnum.anecdota);
        }

        [After(tags: "ObtenerSiRespuestaCorrecta")]
        public static void CleanData()
        {
            dudaCEN.Borrar(id_duda);
        }

        [Given(@"Tengo una duda con respuesta correcta")]
        public void GivenTengoUnaDudaConRespuestaCorrecta()
        {
            int id = 0;
            for (int i = 0; i < 5; i++)
            {
                id = respuestaCEN.Crear("Respuesta Test", id_duda, -1);
                ids.Add(id);
            }
            RespuestaEN r = respuestaCEN.BuscarPorId(id);
            respuestaCEN.Modificar(id, r.Cuerpo, r.Fecha, true, r.Util);
        }
        
        [Given(@"Tengo una duda sin respuesta correcta")]
        public void GivenTengoUnaDudaSinRespuestaCorrecta()
        {
            for (int i = 0; i < 5; i++)
            {
                int id = respuestaCEN.Crear("Respuesta Test", id_duda, -1);
                ids.Add(id);
            }
        }
        
        [When(@"Obtengo si respuesta correcta")]
        public void WhenObtengoSiRespuestaCorrecta()
        {
            resultado = new DudaCP().ObtenerSiRespuestaValida(id_duda);
        }
        
        [Then(@"Obtengo respuesta correcta como verdadero")]
        public void ThenObtengoRespuestaCorrectaComoVerdadero()
        {
            Assert.IsTrue(resultado);
        }
        
        [Then(@"Obtengo respuesta correcta como falso")]
        public void ThenObtengoRespuestaCorrectaComoFalso()
        {
            Assert.IsFalse(resultado);
        }
    }
}
