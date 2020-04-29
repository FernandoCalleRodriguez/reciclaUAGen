using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.UsuarioWeb
{
    [Binding]
    public class BuscarNoBorradosSteps
    {
        IList<UsuarioWebEN> usuarios;
        UsuarioWebCEN usuarioCEN;
        
        [Given(@"Existen usuarios no borrados")]
        public void GivenExistenUsuariosNoBorrados()
        {
            usuarioCEN = new UsuarioWebCEN();
        }
        
        [When(@"Obtengo los usuarios no borrados")]
        public void WhenObtengoLosUsuariosNoBorrados()
        {
            usuarios = usuarioCEN.BuscarNoBorrados();
        }
        
        [Then(@"Devuelvo el resultado")]
        public void ThenDevuelvoElResultado()
        {
            Assert.AreEqual(usuarios.Count,1);
        }
    }
}
