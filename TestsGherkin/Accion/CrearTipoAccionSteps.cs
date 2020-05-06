using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Accion
{
    [Binding]
    public class CrearTipoAccionSteps
    {
        public static TipoAccionCEN tipoAccionCEN = new TipoAccionCEN();
        public static TipoAccionEN tipoAccion = new TipoAccionEN();
        public static int tipoAccionId = -1;

        [After(tags: "CrearNuevoTipoAccion")]
        public static void CleanData()
        {
            tipoAccionCEN.Borrar(tipoAccionId);
        }

        [Given(@"Quiero crear un nuevo tipo de accion con estas caracteristicas")]
        public void GivenQuieroCrearUnNuevoTipoDeAccionConEstasCaracteristicas(Table table)
        {
            tipoAccion.Puntuacion = Int32.Parse(table.Rows[0][0]);
            tipoAccion.Nombre = table.Rows[0][1];
        }
        
        [When(@"Creo el nuevo tipo de accion")]
        public void WhenCreoElNuevoTipoDeAccion()
        {
            tipoAccionId = tipoAccionCEN.Crear(tipoAccion.Puntuacion, tipoAccion.Nombre);
        }
        
        [Then(@"Obtengo el nuevo tipo de accion")]
        public void ThenObtengoElNuevoTipoDeAccion()
        {
            Assert.IsNotNull(tipoAccionCEN.BuscarPorId(tipoAccionId));
        }
    }
}
