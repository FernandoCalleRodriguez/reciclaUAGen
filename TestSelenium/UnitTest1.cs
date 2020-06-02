using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace TestSelenium
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver = null;
        
        [TestInitialize]
        public void setup() { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        
        //[TestMethod]
        public void Login()
        {
            driver.Url = "http://localhost:8100/login";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Comprobamos que estamos en la página de login

            //Buscamos el input email y rellenamos
            IWebElement emailTextBox = wait.Until<IWebElement>( (d) => { return driver.FindElement(By.Name("ion-input-0")); });
            emailTextBox.SendKeys("usu1@ua.es");
            System.Threading.Thread.Sleep(2000);

            //Buscamos el input password y rellenamos
            IWebElement passTextBox = wait.Until<IWebElement>((d) => { return driver.FindElement(By.Name("ion-input-1")); });
            passTextBox.SendKeys("usu1");
            System.Threading.Thread.Sleep(2000);

            //Obtenemos el boton login
            IWebElement loginButton = driver.FindElement(By.Id("btnlogin"));

            //Creamos una nueva acción y clicamos el botón
            Actions action = new Actions(driver);
            action.MoveToElement(loginButton);
            action.Click().Perform();

            System.Threading.Thread.Sleep(4000);

            //Comprobamos que estamos en el inicio
            IWebElement inicioPage = wait.Until<IWebElement>((d) => { return driver.FindElement(By.Id("Inicio")); });

            //Assert.AreEqual("Home", inicioPage.GetAttribute("value"));
        }
    }
}
