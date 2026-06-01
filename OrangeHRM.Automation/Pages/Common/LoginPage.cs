using OrangeHRM.Automation.Core.Base;
using OrangeHRM.Automation.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OrangeHRM.Automation.Pages.Common
{
    public class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }


        // =====================================================
        // LOCATORS
        // =====================================================

        #region Locators

        private readonly By txtUsername = By.Name("username");

        private readonly By txtPassword = By.Name("password");

        private readonly By btnLogin = By.CssSelector("button[type='submit']");

        private readonly By loader = By.CssSelector(".oxd-form-loader");

        #endregion






        public DashboardPage Login(string username, string password)
        {
            Type(txtUsername, username);

            Type(txtPassword, password);

            SafeClick(btnLogin);

            WaitUntilInvisible(loader);

            return new DashboardPage(driver);
        }




    }

}
