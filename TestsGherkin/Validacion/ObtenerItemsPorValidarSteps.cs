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
    public class ObtenerItemsPorValidarSteps
    {
        public static int new_elements = 5;
        public static List<int> ids = new List<int>();
        public static List<int> changed_ids = new List<int>();
        public static ItemCEN itemCEN = new ItemCEN();
        public static ItemEN item;
        public static IList<ItemEN> resultado;

        [Before(tags: "ObtenerItemsPorValidar")]
        public static void InitializeData()
        {
            // Console.WriteLine("Init");
            foreach(ItemEN i in itemCEN.BuscarTodos(0, -1))
            {
                if(i.EsValido == EstadoEnum.enProceso)
                {
                    changed_ids.Add(i.Id);
                    itemCEN.Modificar(i.Id, i.Nombre, i.Descripcion, i.Imagen, EstadoEnum.descartado, 10);
                    // Console.WriteLine("Mod " +  i.Id);
                }
            }
            for (int i = 0; i < new_elements; i++)
            {
                int id = itemCEN.Crear("Item Test", "Item Test", "TEST IMG", -1, -1);
                item = itemCEN.BuscarPorId(id);
                itemCEN.Modificar(id, item.Nombre, item.Descripcion, item.Imagen, EstadoEnum.enProceso, 10);
                ids.Add(id);
                // Console.WriteLine("Added " + id);
            }
        }

        [After(tags: "ObtenerItemsPorValidar")]
        public static void CleanData()
        {
            // Console.WriteLine("Destroy");
            foreach (int id in changed_ids)
            {
                ItemEN i = itemCEN.BuscarPorId(id);
                itemCEN.Modificar(id, i.Nombre, i.Descripcion, i.Imagen, EstadoEnum.enProceso, 10);
                // Console.WriteLine("Recover " + id);
            }
            foreach(int id in ids)
            {
                itemCEN.Borrar(id);
                // Console.WriteLine("Deleted " + id);
            }
            
        }

        [Given(@"Tengo items sin validar")]
        public void GivenTengoItemsSinValidar()
        {

        }
        
        [When(@"Obtengo los items por validar")]
        public void WhenObtengoLosItemsPorValidar()
        {
            resultado = itemCEN.BuscarItemsPorValidar();
            Assert.AreEqual(new_elements, resultado.Count);
        }
        
        [Then(@"Obtengo una lista con los items por validar")]
        public void ThenObtengoUnaListaConLosItemsPorValidar()
        {
            foreach(var e in resultado)
            {
                Assert.AreEqual(EstadoEnum.enProceso, e.EsValido);
            }
        }
    }
}
