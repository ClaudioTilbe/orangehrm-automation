using OrangeHRM.Automation.Core.Config;
using OrangeHRM.Automation.Core.Driver;
using OrangeHRM.Automation.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OrangeHRM.Automation.Core.Base
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver driver => DriverManager.Driver;

        private bool testFailed;

        protected void InitializeDriver(BrowserType browser)
        {
            DriverManager.Driver = DriverFactory.CreateDriver(browser);

            driver.Navigate().GoToUrl(ConfigReader.Settings.ApplicationUrl);
        }

        protected void MarkTestAsFailed()
        {
            testFailed = true;
        }

        public void Dispose()
        {
            if (testFailed)
            {
                ScreenshotHelper.TakeScreenshot(driver, GetType().Name);
            }

            driver?.Quit();
        }
    }


}
