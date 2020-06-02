using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TestSelenium
{
    /// <summary>
    /// Descripción resumida de LoginAdmin
    /// </summary>
    [TestClass]
    public class LoginAdmin
    {
        public LoginAdmin()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private IWebDriver driver = null;

        [TestInitialize]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Login()
        {
            driver.Url = "http://localhost:4200/";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Comprobamos que estamos en la página de login

            //Buscamos el input email y rellenamos
            IWebElement emailTextBox = wait.Until<IWebElement>((d) => { return driver.FindElement(By.Id("email")); });
            emailTextBox.SendKeys("admin@ua.es");
            System.Threading.Thread.Sleep(2000);

            //Buscamos el input password y rellenamos
            IWebElement passTextBox = wait.Until<IWebElement>((d) => { return driver.FindElement(By.Id("pwd")); });
            passTextBox.SendKeys("admin");
            System.Threading.Thread.Sleep(2000);

            //Obtenemos el boton login
            IWebElement loginButton = driver.FindElement(By.Id("btnlogin"));

            //Creamos una nueva acción y clicamos el botón
            Actions action = new Actions(driver);
            action.MoveToElement(loginButton);
            action.Click().Perform();

            System.Threading.Thread.Sleep(4000);

            //Comprobamos que estamos en el 
            string title = driver.Title;
            Assert.AreEqual("Inicio", title);
        }

        [TestMethod]
        public void Logout()
        { 


            Login();
            System.Threading.Thread.Sleep(2000);

            //Obtenemos el boton admin
            IWebElement adminButton = driver.FindElement(By.Id("UserDropdown"));

            //Creamos una nueva acción y clicamos el botón
            Actions action = new Actions(driver);
            action.MoveToElement(adminButton);
            action.Click().Perform();

            System.Threading.Thread.Sleep(2000);

            //Obtenemos el boton logout
            IWebElement logoutButton = driver.FindElement(By.Id("btnLogout"));

            //Creamos una nueva acción y clicamos el botón
            action = new Actions(driver);
            action.MoveToElement(logoutButton);
            action.Click().Perform();
            
        }
    }
}
