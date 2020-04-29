using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsGherkin.Validacion
{
    [Binding]
    public class ObtenerPuntosPorValidarSteps
    {

        public static int new_elements = 5;
        public static List<int> ids = new List<int>();
        public static List<int> changed_ids = new List<int>();
        public static PuntoReciclajeCEN puntoCEN = new PuntoReciclajeCEN();
        public static PuntoReciclajeEN punto;
        public static IList<PuntoReciclajeEN> resultado;

        [Before(tags: "ObtenerPuntosPorValidar")]
        public static void InitializeData()
        {
            // Console.WriteLine("Init");
            foreach (PuntoReciclajeEN p in puntoCEN.BuscarTodos(0, -1))
            {
                if (p.EsValido == EstadoEnum.enProceso)
                {
                    changed_ids.Add(p.Id);
                    puntoCEN.Modificar(p.Id, p.Latitud, p.Longitud, EstadoEnum.descartado);
                    // Console.WriteLine("Mod " +  m.Id);
                }
            }
            for (int i = 0; i < new_elements; i++)
            {
                int id = puntoCEN.Crear(0.0d, 0.0d, -1, null);
                punto = puntoCEN.BuscarPorId(id);
                puntoCEN.Modificar(id, punto.Latitud, punto.Longitud, EstadoEnum.enProceso);
                ids.Add(id);
                // Console.WriteLine("Added " + id);
            }
        }

        [After(tags: "ObtenerPuntosPorValidar")]
        public static void CleanData()
        {
            // Console.WriteLine("Destroy");
            foreach (int id in changed_ids)
            {
                PuntoReciclajeEN p = puntoCEN.BuscarPorId(id);
                puntoCEN.Modificar(id, p.Latitud, p.Longitud, EstadoEnum.enProceso);
                // Console.WriteLine("Recover " + id);
            }
            foreach (int id in ids)
            {
                puntoCEN.Borrar(id);
                // Console.WriteLine("Deleted " + id);
            }

        }

        [Given(@"Tengo puntos sin validar")]
        public void GivenTengoPuntosSinValidar()
        {
           
        }
        
        [When(@"Obtengo los puntos por validar")]
        public void WhenObtengoLosPuntosPorValidar()
        {
            resultado = puntoCEN.BuscarPuntosPorValidar();
            Assert.AreEqual(new_elements, resultado.Count);
        }
        
        [Then(@"Obtengo una lista con los puntos por validar")]
        public void ThenObtengoUnaListaConLosPuntosPorValidar()
        {
            foreach (var e in resultado)
            {
                Assert.AreEqual(EstadoEnum.enProceso, e.EsValido);
            }
        }
    }
}
