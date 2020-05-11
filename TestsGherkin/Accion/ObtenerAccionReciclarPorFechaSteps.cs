using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CP.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Accion
{
    [Binding]
    public class ObtenerAccionReciclarPorFechaSteps
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
        public static DateTime fechaActual;

        [Before(tags: "ObtenerAccionesReciclarPorFecha")]
        public static void InitializeData()
        {
            contenedorId = contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, -1);
            itemId = -1;
            user = -1;
            fechaActual = DateTime.Now;

            accionReciclarId = new AccionReciclarCP().Crear(user, contenedorId, itemId, cantidad).Id;
        }

        [After(tags: "ObtenerAccionesReciclarPorFecha")]
        public static void CleanData()
        {
            accionReciclarCEN.Borrar(accionReciclarId);
            contenedorCEN.Borrar(contenedorId);
        }

        [Given(@"Tengo acciones de reciclaje con la fecha indicada")]
        public void GivenTengoAccionesDeReciclajeConLaFechaIndicada()
        {
           //
        }
        
        [Given(@"No tengo acciones de reciclaje con la fecha indicada")]
        public void GivenNoTengoAccionesDeReciclajeConLaFechaIndicada()
        {
            //
        }
        
        [When(@"Obtengo las acciones de reciclaje con la fecha")]
        public void WhenObtengoLasAccionesDeReciclajeConLaFecha(Table table)
        {
            acciones = accionReciclarCEN.BuscarPorFecha(fechaActual);
        }
        
        [Then(@"Obtengo la lista de las acciones de reciclaje con la fecha indicada")]
        public void ThenObtengoLaListaDeLasAccionesDeReciclajeConLaFechaIndicada()
        {
            Assert.IsTrue(acciones.Count > 0);
        }
        
        [Then(@"No obtengo la lista de las acciones de reciclaje con la fecha indicada")]
        public void ThenNoObtengoLaListaDeLasAccionesDeReciclajeConLaFechaIndicada()
        {
            Assert.IsTrue(acciones.Count == 0);
        }
    }
}
