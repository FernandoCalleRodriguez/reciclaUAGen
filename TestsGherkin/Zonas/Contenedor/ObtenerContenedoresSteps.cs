using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Zonas.Contenedor
{
    [Binding]
    public class ObtenerContenedoresSteps
    {
        public static IList<ContenedorEN> contenedores = new List<ContenedorEN>();
        public static IList<int> id_contenedores = new List<int>();

        public static ContenedorEN contenedor;
        public static ContenedorCEN contenedorCEN;
        public static int tipo = -1;
        public static int id_contenedor, id_punto;

        [Before(tags: "GetContenedors")]
        public static void InitializeData()
        {
            contenedorCEN = new ContenedorCEN();
            id_contenedores.Add(contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.plastico, -1));
            id_contenedores.Add(contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.organico, -1));
            id_contenedores.Add(contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, -1));

        }

        [After(tags: "GetContenedors")]
        public static void CleanData()
        {
            if (contenedores.Count > 0)
                foreach (var item in id_contenedores)
                {
                    contenedorCEN.Borrar(item);
                }

        }

        [Given(@"tengo Contenedors")]
        public void GivenTengoContenedors()
        {
            contenedorCEN = new ContenedorCEN();
        }

        [When(@"Obtengo los Contenedors")]
        public void WhenObtengoLosContenedors()
        {
            contenedores = contenedorCEN.BuscarTodos(0,-1);
        }

        [Then(@"Obtengo una lista con los Contenedors disponible")]
        public void ThenObtengoUnaListaConLosContenedorsDisponible()
        {
            Assert.IsTrue(contenedores.Count > 0);
        }
    }
}
