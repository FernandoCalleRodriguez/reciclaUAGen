using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestsGherkin.UsuarioWeb
{
    [Binding]
    public class CrearUsuarioWebSteps
    {
        ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioCEN usuarioCEN;
        UsuarioEN usuarioCrear;
        int id;

        [Given(@"No existe un usuario")]
        public void GivenNoExisteUnUsuario(Table table)
        
        
        {
            usuarioCrear = new UsuarioEN();
            var usuarios = table.CreateSet<UsuarioEN>();
            usuarioCEN = new ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioCEN();

            foreach (UsuarioEN usuario in usuarios)
            {
                usuarioCrear.Email = usuario.Email; 
                usuarioCrear.Pass = usuario.Pass; 
                usuarioCrear.Nombre = usuario.Nombre; 
                usuarioCrear.Apellidos = usuario.Apellidos;



            }
        }

        [When(@"Creo el usuario")]
        public void WhenCreoElUsuario()
        {
            id = usuarioCEN.Crear(usuarioCrear.Nombre, usuarioCrear.Apellidos, usuarioCrear.Email, usuarioCrear.Pass);
        }

        [Then(@"Obtengo al nuevo usuario")]
        public void ThenObtengoAlNuevoUsuario()
        {
            Assert.IsNotNull(id);
        }
    }
}
