using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Accion
{
    [Binding]
    public class ObtenerAccionReciclarPorAutorSteps
    {
        public static AccionReciclarCEN accionReciclarCEN = new AccionReciclarCEN();
        public static AccionReciclarEN accionReciclar = new AccionReciclarEN();
        public static ContenedorCEN contenedorCEN = new ContenedorCEN();
        public static IList<AccionReciclarEN> acciones = new List<AccionReciclarEN>();
        public static int contenedorId = -1;
        public static int itemId = -1;
        public static int accionReciclarId = -1;
        public static int cantidad;
        public static int user;

        [Before(tags: "ObtenerAccionesReciclarPorAutor")]
        public static void InitializeData()
        {
            contenedorId = contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, 360448);
            itemId = 196608;
            user = 32769;

            accionReciclarId = accionReciclarCEN.Crear(user, DateTime.Now, contenedorId, itemId, cantidad);
        }

        [After(tags: "ObtenerAccionesReciclarPorAutor")]
        public static void CleanData()
        {
            accionReciclarCEN.Borrar(accionReciclarId);
            contenedorCEN.Borrar(contenedorId);
        }

        [Given(@"Tengo acciones de reciclaje con el autor indicado")]
        public void GivenTengoAccionesDeReciclajeConElAutorIndicado()
        {
            //
        }
        
        [Given(@"No tengo acciones de reciclaje con el autor indicado")]
        public void GivenNoTengoAccionesDeReciclajeConElAutorIndicado()
        {
            //
        }
        
        [When(@"Obtengo las acciones de reciclaje con el autor (.*)")]
        public void WhenObtengoLasAccionesDeReciclajeConElAutor(int p0)
        {
            acciones = accionReciclarCEN.BuscarPorAutor(p0);
        }
        
        [Then(@"Obtengo la lista de las acciones de reciclaje con el autor indicado")]
        public void ThenObtengoLaListaDeLasAccionesDeReciclajeConElAutorIndicado()
        {
            Assert.IsTrue(acciones.Count > 0);
        }
        
        [Then(@"No obtengo la lista de las acciones de reciclaje con el autor indicado")]
        public void ThenNoObtengoLaListaDeLasAccionesDeReciclajeConElAutorIndicado()
        {
            Assert.IsTrue(acciones.Count == 0);
        }
    }
}
