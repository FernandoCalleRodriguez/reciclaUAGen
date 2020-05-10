using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Accion
{
    [Binding]
    public class ObtenerAccionWebPorTipoAccionSteps
    {
        public static AccionWebCEN accionWebCEN = new AccionWebCEN();
        public static AccionWebEN accionWeb = new AccionWebEN();
        public static TipoAccionCEN tipoAccionCEN = new TipoAccionCEN();
        public static TipoAccionEN tipoAccion = new TipoAccionEN();
        public static IList<AccionWebEN> acciones = new List<AccionWebEN>();
        public static int accionWebId = -1;
        public static int accionWebId2 = -1;
        public static int tipoAccionId;

        [Before(tags: "ObtenerAccionesWebConTipoAccion")]
        public static void InitializeData()
        {
            tipoAccionId = tipoAccionCEN.Crear(5000, "Tipo Prueba");

        }

        [After(tags: "ObtenerAccionesWebConTipoAccion")]
        public static void CleanData()
        {
            accionWebCEN.Borrar(accionWebId);
            accionWebCEN.Borrar(accionWebId2);

            tipoAccionCEN.Borrar(tipoAccionId);
        }

        [Given(@"Tengo acciones web con el tipo de accion")]
        public void GivenTengoAccionesWebConElTipoDeAccion()
        {
            //
        }

        [Given(@"No tengo acciones web con el tipo de accion")]
        public void GivenNoTengoAccionesWebConElTipoDeAccion()
        {
            //
        }

        [When(@"Obtengo las acciones web con el tipo de accion")]
        public void WhenObtengoLasAccionesWebConElTipoDeAccion(Table table)
        {
            acciones = accionWebCEN.BuscarPorTipo(table.Rows[0][0]);
        }

        [Then(@"Obtengo la lista de las acciones web con el tipo de accion")]
        public void ThenObtengoLaListaDeLasAccionesWebConElTipoDeAccion()
        {
            Assert.IsTrue(acciones.Count > 0);
        }

        [Then(@"No obtengo la lista de las acciones web con el tipo de accion")]
        public void ThenNoObtengoLaListaDeLasAccionesWebConElTipoDeAccion()
        {
            Assert.IsTrue(acciones.Count == 0);
        }
    }
}
