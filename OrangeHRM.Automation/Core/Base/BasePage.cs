using OrangeHRM.Automation.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Core.Base
{

    public class BasePage
    {

        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;


        private By loader = By.ClassName("oxd-form-loader");


        public BasePage(IWebDriver driver)
        {
            // Guarda la instancia del navegador recibida para que todas las páginas puedan usar el mismo driver
            this.driver = driver;

            // Inicializa el Explicit Wait global del framework usando el tiempo configurado en appsettings/config
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ConfigReader.Settings.Timeouts.ExplicitWait));
        }



        // =========================
        // Metodos
        // =========================

        protected IWebElement WaitVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitClickable(By locator)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            ((IJavaScriptExecutor)driver)
                .ExecuteScript(
                    "arguments[0].scrollIntoView({block: 'center'});",
                    element);

            return element;
        }

        protected void WaitUntilInvisible(By locator)
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        protected void ScrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
        }

        protected void SafeClick(By locator)
        {
            WebDriverWait retryWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            retryWait.Until(d =>
            {
                try
                {
                    WaitUntilInvisible(loader);

                    // Espera que el elemento exista y sea clickable
                    var element = WaitClickable(locator);

                    ScrollIntoView(element);

                    element.Click();

                    return true;
                }
                catch (ElementClickInterceptedException)
                {
                     // Otro elemento interceptó el click. Selenium volverá a reintentar
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    // El DOM cambió y el elemento quedó inválido. Selenium volverá a buscarlo y reintentar
                    return false;
                }
            });
        }

        protected void Type(By locator, string text)
        {
            //Crea un wait específico de 5 segundos (No bloquea)
            WebDriverWait retryWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Empieza ciclo de retry automático
            retryWait.Until(d =>
            {
                try
                {
                    WaitUntilInvisible(loader);

                    // Espera que el input exista y sea clickable
                    IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));

                    ScrollIntoView(element);

                    element.Click();

                    element.SendKeys(Keys.Control + "a");
                    element.SendKeys(Keys.Delete);
                    element.SendKeys(text);

                    return true;
                }
                catch (ElementClickInterceptedException)
                {
                    // Algún overlay o loader interceptó la interacción. Selenium volverá a reintentar
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    // El DOM cambió y el elemento quedó inválido. Selenium volverá a buscarlo y reintentar
                    return false;
                }
            });
        }



        protected void WaitForPersonalDetailsPage()
        {
            WebDriverWait longWait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

            longWait.Until(d => d.Url.Contains("viewPersonalDetails"));
        }



    }





}
