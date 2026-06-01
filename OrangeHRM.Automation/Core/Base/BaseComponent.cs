using OrangeHRM.Automation.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Core.Base
{
    public class BaseComponent
    {

        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public BaseComponent(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(
                    ConfigReader.Settings.Timeouts.ExplicitWait));
        }

    }
}
