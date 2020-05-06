using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.Accion
{
    [Binding]
    public class CrearAccionReciclarSteps
    {
        public static AccionReciclarCEN accionReciclarCEN = new AccionReciclarCEN();
        public static AccionReciclarEN accionReciclar = new AccionReciclarEN();
        public static ContenedorCEN contenedorCEN = new ContenedorCEN();
        public static int contenedorId = -1;
        public static int itemId = -1;
        public static int accionReciclarId = -1;
        public static int cantidad;
        public static int user;

        [Before(tags: "CrearNuevaAccionReciclaje")]
        public static void InitializeData()
        {
            contenedorId = contenedorCEN.Crear(ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum.cristal, 360448);
            itemId = 196608;
        }

        [After(tags: "CrearNuevaAccionReciclaje")]
        public static void CleanData()
        {
            accionReciclarCEN.Borrar(accionReciclarId);
            contenedorCEN.Borrar(contenedorId);
        }

        [Given(@"Quiero crear una nueva accion de reciclaje")]
        public void GivenQuieroCrearUnaNuevaAccionDeReciclaje(Table table)
        {
            cantidad = Int32.Parse(table.Rows[0][0]);
        }
        
        [Given(@"Logueado con el usuario (.*)")]
        public void GivenLogueadoConElUsuario(int p0)
        {
            user = p0;
        }
        
        [When(@"Creo la accion de reciclaje")]
        public void WhenCreoLaAccionDeReciclaje()
        {
            accionReciclarId = accionReciclarCEN.Crear(user, DateTime.Now, contenedorId, itemId, cantidad);
        }
        
        [Then(@"Obtengo la accion de reciclaje")]
        public void ThenObtengoLaAccionDeReciclaje()
        {
            Assert.IsNotNull(accionReciclarCEN.BuscarPorId(accionReciclarId));
        }
    }
}
