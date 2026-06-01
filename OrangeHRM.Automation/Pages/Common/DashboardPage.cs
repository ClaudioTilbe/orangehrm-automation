using OrangeHRM.Automation.Core.Base;
using OrangeHRM.Automation.Pages.Employee;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Pages.Common
{
    public class DashboardPage : BasePage
    {

        public DashboardPage(IWebDriver driver): base(driver)
        {
        }

        // =====================================================
        // LOCATORS
        // =====================================================

        private readonly By pageHeader = By.XPath("//h6[text()='Dashboard']");

        private readonly By menuPim = By.XPath("//a[contains(@href,'viewPimModule')]");

        private readonly By btnAdd = By.XPath("//button[normalize-space()='Add']");




        public bool IsDashboardDisplayed()
        {
            return WaitVisible(pageHeader).Displayed;
        }



        // =====================================================
        // NAVIGATION
        // =====================================================

        public EmployeeListPage GoToEmployeeList()
        {
            SafeClick(menuPim);

            return new EmployeeListPage(driver);
        }

        public AddEmployeePage GoToAddEmployee()
        {
            SafeClick(menuPim);

            SafeClick(btnAdd);

            return new AddEmployeePage(driver);
        }


    }


}
