using OrangeHRM.Automation.Core.Base;
using OrangeHRM.Automation.Core.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Pages.Employee
{
    public class EmployeeListPage : BasePage
    {

        public EmployeeListPage(IWebDriver driver) : base(driver)
        {

        }

        // =========================================================================
        // Locators
        // =========================================================================

        #region Locators

        private By loader = By.ClassName("oxd-form-loader");

        private By txtSearchEmployeeId = By.XPath("//label[text()='Employee Id']/ancestor::div[contains(@class,'oxd-input-group')]//input");

        private By btnSearch = By.XPath("//button[normalize-space()='Search']");

        private By btnConfirmDelete = By.XPath("//button[normalize-space()='Yes, Delete']");

        private By toastSuccess = By.ClassName("oxd-toast-container");

        private By dialogDelete = By.ClassName("oxd-dialog-container-default");

        private By lblNoRecordsFound = By.XPath("//span[text()='No Records Found']");
        private By DeleteButtonInsideRow => By.XPath(".//button[i[contains(@class,'bi-trash')]]");

        private By txtLastNamePersonalDetails = By.Name("lastName");
        private By EmployeeRowById(string employeeId) => By.XPath($"//div[text()='{employeeId}']/ancestor::div[@role='row']");
        private By EditButtonInsideRow => By.XPath(".//button[contains(@class,'oxd-icon-button')]");

        #endregion




        public EmployeeListPage DeleteEmployee(string employeeId)
        {
            Type(txtSearchEmployeeId, employeeId);

            SafeClick(btnSearch);

            WaitUntilInvisible(loader);

            wait.Until(d => d.FindElements(EmployeeRowById(employeeId)).Count > 0);

            wait.Until(d =>
            {
                try
                {
                    IWebElement employeeRow = d.FindElement(EmployeeRowById(employeeId));

                    IWebElement deleteButton = employeeRow.FindElement(DeleteButtonInsideRow);

                    deleteButton.Click();

                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (ElementClickInterceptedException)
                {
                    return false;
                }
            });

            SafeClick(btnConfirmDelete);

            WaitVisible(toastSuccess);

            WaitUntilInvisible(dialogDelete);

            return this;
        }


        public bool EmployeeExistsById(string employeeId)
        {
            Type(txtSearchEmployeeId, employeeId);

            SafeClick(btnSearch);

            WaitUntilInvisible(loader);

            wait.Until(d =>
                d.FindElements(lblNoRecordsFound).Count > 0 ||
                d.FindElements(GetEmployeeRowById(employeeId)).Count > 0
            );

            return driver.FindElements(GetEmployeeRowById(employeeId)).Count > 0;
        }


        public EmployeePersonalDetailsPage OpenEmployeePersonalDetailsById(string employeeId)
        {
            Type(txtSearchEmployeeId, employeeId);

            SafeClick(btnSearch);

            WaitUntilInvisible(loader);

            wait.Until(d => d.FindElements(EmployeeRowById(employeeId)).Count > 0);

            wait.Until(d =>
            {
                try
                {
                    IWebElement employeeRow = d.FindElement(EmployeeRowById(employeeId));

                    IWebElement editButton = employeeRow.FindElement(EditButtonInsideRow);

                    editButton.Click();

                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (ElementClickInterceptedException)
                {
                    return false;
                }
            });

            WaitUntilInvisible(loader);

            WaitVisible(txtLastNamePersonalDetails);

            return new EmployeePersonalDetailsPage(driver);
        }



        private By GetEmployeeRowById(string employeeId)
        {
            return By.XPath($"//div[@class='oxd-table-card']//div[text()='{employeeId}']");
        }





    }

}
