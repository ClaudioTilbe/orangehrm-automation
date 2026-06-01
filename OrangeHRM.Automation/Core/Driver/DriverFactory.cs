using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;



namespace OrangeHRM.Automation.Core.Driver
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(
            BrowserType browser)
        {
            return browser switch
            {
                BrowserType.Chrome => CreateChrome(),

                BrowserType.Edge => CreateEdge(),

                _ => throw new ArgumentException(
                    "Navegador no soportado")
            };
        }

        private static IWebDriver CreateChrome()
        {
            ChromeOptions options = new();

            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }

        private static IWebDriver CreateEdge()
        {
            EdgeOptions options = new();

            options.AddArgument("start-maximized");

            return new EdgeDriver(options);
        }
    }


}
