using OrangeHRM.Automation.Core.Base;
using OrangeHRM.Automation.Core.Utilities;
using OrangeHRM.Automation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Pages.Employee
{

    public class AddEmployeePage : BasePage
    {

        public AddEmployeePage(IWebDriver driver) : base(driver)
        {

        }


        // =========================================================================
        // Locators
        // =========================================================================

        #region Locators

        private By txtFirstName = By.Name("firstName");

        private By txtLastName = By.Name("lastName");

        private By txtMiddleName = By.Name("middleName");

        private By btnSave = By.XPath("//button[@type='submit']");

        private By loader = By.ClassName("oxd-form-loader");

        private By txtEmployeeId = By.XPath("//label[contains(text(),'Employee Id')]/following::input[1]");

        private By inputEmployeeImage = By.CssSelector("input[type='file']");

        private By txtUsername = By.XPath("//label[text()='Username']/ancestor::div[contains(@class,'oxd-input-group')]//input");

        private By txtPassword = By.XPath("//label[text()='Password']/ancestor::div[contains(@class,'oxd-input-group')]//input");

        private By txtConfirmPassword = By.XPath("//label[text()='Confirm Password']/ancestor::div[contains(@class,'oxd-input-group')]//input");

        private By switchLoginDetails = By.CssSelector("span.oxd-switch-input");

        #endregion




        public EmployeePersonalDetailsPage CreateEmployee(EmployeeModel employee)
        {

            // ID generado desde Factory
            Type(txtEmployeeId, employee.Id);


            // Completar formulario
            Type(txtFirstName, employee.FirstName);

            Type(txtMiddleName, employee.MiddleName);

            Type(txtLastName, employee.LastName);

            SafeClick(switchLoginDetails);

            WaitVisible(txtUsername);

            Type(txtUsername, employee.Username + employee.Id);

            Type(txtPassword, employee.Password);

            Type(txtConfirmPassword, employee.Password);

            UploadEmployeeImage(employee.ImageName);

            SafeClick(btnSave);

            WaitUntilInvisible(loader);

            // validación final
            //wait.Until(d => d.Url.Contains("viewPersonalDetails"));
            WaitForPersonalDetailsPage();

            return new EmployeePersonalDetailsPage(driver);
        }



        private void UploadEmployeeImage(string imageName)
        {
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Resources",
                "Images",
                imageName);

            driver.FindElement(inputEmployeeImage).SendKeys(path);
        }





    }

}
