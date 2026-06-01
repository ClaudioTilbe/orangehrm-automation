using OrangeHRM.Automation.Core.Base;
using OrangeHRM.Automation.Core.Config;
using OrangeHRM.Automation.Core.Driver;
using OrangeHRM.Automation.Database;
using OrangeHRM.Automation.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Base
{
    public class EmployeeTestBase : BaseTest
    {

        protected EmployeeDb db;

        public EmployeeTestBase()
        {
            db = new EmployeeDb();
        }

        protected DashboardPage Login(BrowserType browser)
        {
            InitializeDriver(browser);

            LoginPage loginPage = new LoginPage(driver);

            return loginPage.Login(ConfigReader.Settings.Credentials.Username,
                                   ConfigReader.Settings.Credentials.Password);
        }
    }
}
