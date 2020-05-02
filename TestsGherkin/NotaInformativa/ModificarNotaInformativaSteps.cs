using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;

namespace TestsGherkin.NotaInformativa
{
    [Binding]
    public class ModificarNotaInformativaSteps
    {
        public static NotaInformativaCEN notaCEN = new NotaInformativaCEN();
        public static NotaInformativaEN nota = new NotaInformativaEN();
        public static int notaId;
        public string exception = "ModelException";

        [Before(tags: "ModificarNotaInformativaExistente")]
        public static void InitializeData()
        {
            NotaInformativaEN nota = new NotaInformativaEN()
            {
                Titulo = "Titulo de nota informativa TEST",
                Cuerpo = "Cuerpo de nota informativa TEST",
            };

            nota.UsuarioAdministrador = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioAdministradorEN();
            nota.UsuarioAdministrador.Id = 32768;

            notaId = notaCEN.Crear(32768, nota.Titulo, nota.Cuerpo);
        }

        [After(tags: "ModificarNotaInformativaExistente")]
        public static void CleanData()
        {
            notaCEN.Borrar(notaId);
        }

        [Given(@"Quiero modificar una nota informativa con la siguiente informacion")]
        public void GivenQuieroModificarUnaNotaInformativaConLaSiguienteInformacion(Table table)
        {
            nota.Titulo = table.Rows[0][0];
            nota.Cuerpo = table.Rows[0][1];
        }

        [Given(@"Quiero modificar una nota informativa no existente con la siguiente informacion")]
        public void GivenQuieroModificarUnaNotaInformativaNoExistenteConLaSiguienteInformacion(Table table)
        {
            nota.Titulo = table.Rows[0][0];
            nota.Cuerpo = table.Rows[0][1];

            notaId = -1;
        }

        [When(@"Modifico la nota informativa")]
        public void WhenModificoLaNotaInformativa()
        {
            try
            {
                notaCEN.Modificar(notaId, nota.Titulo, nota.Cuerpo, null);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add(exception, e);
            }
        }

        [Then(@"Obtengo la nueva nota informativa modificada")]
        public void ThenObtengoLaNuevaNotaInformativaModificada()
        {

            String titulo = notaCEN.BuscarPorId(notaId).Titulo;
            Assert.AreEqual(titulo, nota.Titulo);
        }

        [Then(@"No se puede modificar la nota informativa")]
        public void ThenNoSePuedeModificarLaNotaInformativa()
        {
            var e = ScenarioContext.Current[exception];
            Assert.IsNotNull(e);
        }
    }
}
