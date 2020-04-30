using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestsGherkin.Usuario
{
    [Binding]
    public class LoginSteps
    {

        ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioCEN usuarioCEN;
        public static UsuarioAdministradorCEN adminCEN = new UsuarioAdministradorCEN();
        public static string email;
        public static string contrasena;
        public static int id;
        public static string token;


        [Before(tags: "Login")]
        public static void InitializeData()
        {
            Console.WriteLine("Init");
            id = adminCEN.Crear("usuario", "prueba", "usuario@ua.es", "contrasena");
            if (id == -1)
            {
                id = adminCEN.BuscarPorCorreo("usuario@ua.es")[0].Id;

            }
        }


        [Given(@"Hay un usuario")]
        public void GivenHayUnUsuario(Table table)
        {

            var usuarios = table.CreateSet<UsuarioEN>();
            usuarioCEN = new ReciclaUAGenNHibernate.CEN.ReciclaUA.UsuarioCEN();

            foreach (UsuarioEN usuario in usuarios)
            {
                email = usuario.Email;
                contrasena = usuario.Pass;
            }

        }

        [When(@"Compruebo las credenciales")]
        public void WhenComprueboLasCredenciales()
        {

            token = usuarioCEN.Login(contrasena, email);
        }

        [Then(@"Obtengo al usuario")]
        public void ThenObtengoAlUsuario()
        {

            var jwtToken = new JwtSecurityToken(token);
            Console.WriteLine(jwtToken);
            string idtoken;
            foreach (Claim claim in jwtToken.Claims)
            {
                idtoken = claim.Value.ToString();
                Assert.AreEqual(id, Convert.ToInt32(idtoken));

            }

        }

        [Then(@"No existe el usuario")]
        public void ThenNoExisteElUsuario()
        {
            Assert.IsNull(token);
        }

    }
}
