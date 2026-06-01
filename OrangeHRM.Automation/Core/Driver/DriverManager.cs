using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;


namespace OrangeHRM.Automation.Core.Driver
{
    public static class DriverManager
    {
        private static ThreadLocal<IWebDriver> _driver  = new ThreadLocal<IWebDriver>();

        public static IWebDriver Driver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }
    }


}
