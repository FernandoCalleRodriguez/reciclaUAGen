using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Accion
{
    [Binding]
    public class ObtenerTiposAccionSteps
    {
        public static TipoAccionCEN tipoAccionCEN = new TipoAccionCEN();
        public static TipoAccionEN tipoAccion = new TipoAccionEN();
        public static IList<TipoAccionEN> tiposAccion = new List<TipoAccionEN>();
        public static int tipoAccionId = -1;
        public static int tipoAccionId2 = -1;
        public string exception = "ModelException";

        [Before(tags: "ObtenerTiposAccionExistentes")]
        public static void InitializeData()
        {
            TipoAccionEN tipoAccion = new TipoAccionEN()
            {
                Puntuacion = 100,
                Nombre = "Puntuacion doble",
            };


            TipoAccionEN tipoAccion2 = new TipoAccionEN()
            {
                Puntuacion = 300,
                Nombre = "Puntuacion triple",
            };

            tipoAccionId = tipoAccionCEN.Crear(tipoAccion.Puntuacion, tipoAccion.Nombre);
            tipoAccionId2 = tipoAccionCEN.Crear(tipoAccion2.Puntuacion, tipoAccion2.Nombre);
        }

        [After(tags: "ObtenerTiposAccionExistentes")]
        public static void CleanData()
        {
            tipoAccionCEN.Borrar(tipoAccionId);
            tipoAccionCEN.Borrar(tipoAccionId2);
        }

        [Given(@"Tengo tipos de acciones")]
        public void GivenTengoTiposDeAcciones()
        {
            //Vacio
        }

        [When(@"Obtengo los tipos de acciones")]
        public void WhenObtengoLosTiposDeAcciones()
        {
            try
            {
                tiposAccion = tipoAccionCEN.BuscarTodos(0, -1);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add(exception, e);
                Assert.IsNotNull(e);
            }
        }

        [Then(@"Obtengo una lista de los tipos de acciones")]
        public void ThenObtengoUnaListaDeLosTiposDeAcciones()
        {
            Assert.IsTrue(tiposAccion.Count > 1);
        }
    }
}
