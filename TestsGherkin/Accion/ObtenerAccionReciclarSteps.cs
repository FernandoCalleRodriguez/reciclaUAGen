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
    public class ObtenerAccionReciclarSteps
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

        [Before(tags: "@ObtenerAccionesReciclarExistentes")]
        public static void InitializeData()
        {
            contenedorId = contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, -1);
            itemId = -1;
            user = -1;

            accionReciclarId = accionReciclarCEN.Crear(user, contenedorId, itemId, cantidad);
        }


        [After(tags: "ObtenerAccionesReciclarExistentes")]
        public static void CleanData()
        {
            accionReciclarCEN.Borrar(accionReciclarId);
            contenedorCEN.Borrar(contenedorId);
        }

        [Given(@"Tengo acciones de reciclaje")]
        public void GivenTengoAccionesDeReciclaje()
        {
            //
        }

        [When(@"Obtengo las acciones de reciclaje")]
        public void WhenObtengoLasAccionesDeReciclaje()
        {
            acciones = accionReciclarCEN.BuscarTodos(0, -1);
        }

        [Then(@"Obtengo la lista de las acciones de reciclaje")]
        public void ThenObtengoLaListaDeLasAccionesDeReciclaje()
        {
            Assert.IsTrue(acciones.Count > 0);
        }
    }
}
