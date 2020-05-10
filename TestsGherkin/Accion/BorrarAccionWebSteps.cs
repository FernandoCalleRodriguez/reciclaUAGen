using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Accion
{
    [Binding]
    public class BorrarAccionWebSteps
    {
        public static AccionWebCEN accionWebCEN = new AccionWebCEN();
        public static AccionWebEN accionWeb = new AccionWebEN();
        public static TipoAccionCEN tipoAccionCEN = new TipoAccionCEN();
        public static TipoAccionEN tipoAccion = new TipoAccionEN();
        public static IList<AccionWebEN> acciones = new List<AccionWebEN>();
        public static int accionWebId = -1;
        public static int accionWebId2 = -1;
        public static int tipoAccionId;
        public string exception = "ModelException";

        [Before(tags: "@BorrarAccionWeb")]
        public static void InitializeData()
        {
            tipoAccionId = tipoAccionCEN.Crear(5000, "Tipo Prueba");

            accionWebId = accionWebCEN.Crear(-1, DateTime.Now, tipoAccionId);
        }

        [After(tags: "@BorrarAccionWeb")]
        public static void CleanData()
        {
            tipoAccionCEN.Borrar(tipoAccionId);
        }

        [Given(@"Hay un accion web especifica")]
        public void GivenHayUnAccionWebEspecifica()
        {
           //
        }
        
        [Given(@"No hay un accion web especifica")]
        public void GivenNoHayUnAccionWebEspecifica()
        {
            accionWebId = -1;
        }
        
        [When(@"Elimina la accion web")]
        public void WhenEliminaLaAccionWeb()
        {
            try
            {
                accionWebCEN.Borrar(accionWebId);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }
        
        [Then(@"Devuelvo la accion web borrada")]
        public void ThenDevuelvoLaAccionWebBorrada()
        {
            Assert.IsNull(accionWebCEN.BuscarPorId(accionWebId));
        }
        
        [Then(@"No se puede borrar la accion web")]
        public void ThenNoSePuedeBorrarLaAccionWeb()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
