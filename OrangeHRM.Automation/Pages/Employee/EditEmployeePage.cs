using OrangeHRM.Automation.Components;
using OrangeHRM.Automation.Core.Base;
using OrangeHRM.Automation.Core.Utilities;
using OrangeHRM.Automation.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrangeHRM.Automation.Database;

namespace OrangeHRM.Automation.Pages.Employee
{
    public class EditEmployeePage : BasePage
    {

        private readonly EmployeeFormComponent form;

        public EditEmployeePage(IWebDriver driver) : base(driver)
        {
            form = new EmployeeFormComponent(driver);
        }


        // =========================================================================
        // Locators
        // =========================================================================

        #region Locators

        private By loader = By.ClassName("oxd-form-loader");

        private By toastSuccess = By.ClassName("oxd-toast-container");

        private By txtLastNamePersonalDetails = By.Name("lastName");

        private By btnSavePersonalDetails = By.XPath("//p[contains(@class,'orangehrm-form-hint')]/following-sibling::button");

        private By txtDriverLicenseNumber = By.XPath("//label[text()=\"Driver's License Number\"]/../following-sibling::div/input");

        private By ddlNationality = By.XPath("//label[text()='Nationality']/../following-sibling::div//div[contains(@class,'oxd-select-text')]");

        private By ddlOptions = By.XPath("//div[@role='option']");

        private By ddlMaritalStatus = By.XPath("//label[text()='Marital Status']/../following-sibling::div//div[contains(@class,'oxd-select-text')]");

        private By txtLicenseExpiryDate = By.XPath("//label[text()='License Expiry Date']/../following-sibling::div//input");

        private By txtDateOfBirth = By.XPath("//label[text()='Date of Birth']/ancestor::div[contains(@class,'oxd-input-group')]//input");

        private By txtFirstNamePersonalDetails = By.Name("firstName");

        private By txtMiddleNamePersonalDetails = By.Name("middleName");

        #endregion



        public void ModifyEmployee(EmployeeModel employeeNewData)
        {
            WaitVisible(txtLastNamePersonalDetails);

            Type(txtLastNamePersonalDetails, employeeNewData.LastName);

            Type(txtDriverLicenseNumber, employeeNewData.DriverLicenseNumber);

            form.SelectOption(ddlNationality, ddlOptions, employeeNewData.Nationality);

            form.SelectOption(ddlMaritalStatus, ddlOptions, employeeNewData.MaritalStatus);

            form.SelectRadioOption("Gender", employeeNewData.Gender);

            Type(txtLicenseExpiryDate, employeeNewData.LicenseExpiryDate.Value.ToString("yyyy-dd-MM"));

            Type(txtDateOfBirth, employeeNewData.DateOfBirth.Value.ToString("yyyy-dd-MM"));

            SafeClick(btnSavePersonalDetails);

            WaitUntilInvisible(loader);

            WaitVisible(toastSuccess);
        }


        public EmployeeModel GetEmployeeFromPersonalDetails()
        {
            EmployeeModel employee = new EmployeeModel();

            WaitUntilInvisible(loader);

            //Obtengo datos
            employee.FirstName = driver.FindElement(txtFirstNamePersonalDetails).GetAttribute("value");
            employee.MiddleName = driver.FindElement(txtMiddleNamePersonalDetails).GetAttribute("value");
            employee.LastName = driver.FindElement(txtLastNamePersonalDetails).GetAttribute("value");

            employee.DriverLicenseNumber = driver.FindElement(txtDriverLicenseNumber).GetAttribute("value");

            employee.Nationality = driver.FindElement(ddlNationality).Text.Trim();

            employee.MaritalStatus = driver.FindElement(ddlMaritalStatus).Text.Trim();

            employee.Gender = form.GetSelectedRadioOption("Gender");

            string expiryDate = driver.FindElement(txtLicenseExpiryDate).GetAttribute("value");

            employee.LicenseExpiryDate = DateHelper.ParseOrangeDate(expiryDate);

            string birthDate = driver.FindElement(txtDateOfBirth).GetAttribute("value");

            employee.DateOfBirth = DateHelper.ParseOrangeDate(birthDate);


            return employee;
        }







    }
}
