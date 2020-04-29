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
    public class ObtenerMaterialesPorValidarSteps
    {
        public static int new_elements = 5;
        public static List<int> ids = new List<int>();
        public static List<int> changed_ids = new List<int>();
        public static MaterialCEN materialCEN = new MaterialCEN();
        public static MaterialEN material;
        public static IList<MaterialEN> resultado;

        [Before(tags: "ObtenerMaterialesPorValidar")]
        public static void InitializeData()
        {
            // Console.WriteLine("Init");
            foreach (MaterialEN m in materialCEN.BuscarTodos(0, -1))
            {
                if (m.EsValido == EstadoEnum.enProceso)
                {
                    changed_ids.Add(m.Id);
                    materialCEN.Modificar(m.Id, m.Nombre, m.Contenedor, EstadoEnum.descartado);
                    // Console.WriteLine("Mod " +  m.Id);
                }
            }
            for (int i = 0; i < new_elements; i++)
            {
                int id = materialCEN.Crear("Material Test", TipoContenedorEnum.cristal, -1);
                material = materialCEN.BuscarPorId(id);
                materialCEN.Modificar(id, material.Nombre, material.Contenedor, EstadoEnum.enProceso);
                ids.Add(id);
                // Console.WriteLine("Added " + id);
            }
        }

        [After(tags: "ObtenerMaterialesPorValidar")]
        public static void CleanData()
        {
            // Console.WriteLine("Destroy");
            foreach (int id in changed_ids)
            {
                MaterialEN m = materialCEN.BuscarPorId(id);
                materialCEN.Modificar(id, m.Nombre, m.Contenedor, EstadoEnum.enProceso);
                // Console.WriteLine("Recover " + id);
            }
            foreach (int id in ids)
            {
                materialCEN.Borrar(id);
                // Console.WriteLine("Deleted " + id);
            }

        }

        [Given(@"Tengo materiales sin validar")]
        public void GivenTengoMaterialesSinValidar()
        {
            
        }
        
        [When(@"Obtengo los materiales por validar")]
        public void WhenObtengoLosMaterialesPorValidar()
        {
            resultado = materialCEN.BuscarMaterialesPorValidar();
            Assert.AreEqual(new_elements, resultado.Count);
        }
        
        [Then(@"Obtengo una lista con los materiales por validar")]
        public void ThenObtengoUnaListaConLosMaterialesPorValidar()
        {
            foreach (var e in resultado)
            {
                Assert.AreEqual(EstadoEnum.enProceso, e.EsValido);
            }
        }
    }
}
