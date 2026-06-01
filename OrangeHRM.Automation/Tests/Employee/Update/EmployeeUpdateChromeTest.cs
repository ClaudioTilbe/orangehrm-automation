using OrangeHRM.Automation.Builders;
using OrangeHRM.Automation.Core.Driver;
using OrangeHRM.Automation.Core.Utilities;
using OrangeHRM.Automation.Models;
using OrangeHRM.Automation.Pages.Common;
using OrangeHRM.Automation.Pages.Employee;
using OrangeHRM.Automation.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Employee.Update
{

    public class EmployeeUpdateChromeTest : EmployeeTestBase
    {

        [Fact]
        public void UpdateEmployee_Chrome_ShouldUpdateSuccessfully()
        {
            try
            {
                LoggerHelper.Info("Starting UpdateEmployee Chrome test");

                DashboardPage dashboard = Login(BrowserType.Chrome);

                EmployeeModel employee = EmployeeBuilder.CreateDefaultEmployee();

                EmployeeModel updatedEmployee = EmployeeBuilder.CreateModifiedEmployee();

                AddEmployeePage addPage = dashboard.GoToAddEmployee();

                EmployeePersonalDetailsPage detailsPage = addPage.CreateEmployee(employee);

                EmployeeListPage employeeListPage = detailsPage.GoToEmployeeList();

                detailsPage = employeeListPage.OpenEmployeePersonalDetailsById(employee.Id);

                detailsPage.ModifyEmployee(updatedEmployee);

                EmployeeModel employeeFromPersonalDetails = detailsPage.GetEmployeeDetails();
                EmployeeModel employeeFromDB = db.GetEmployee(employee.Id);

                Assert.Multiple(() =>
                {
                    // UI
                    Assert.Equal(updatedEmployee.FirstName, employeeFromPersonalDetails.FirstName);
                    Assert.Equal(updatedEmployee.MiddleName, employeeFromPersonalDetails.MiddleName);
                    Assert.Equal(updatedEmployee.LastName, employeeFromPersonalDetails.LastName);
                    Assert.Equal(updatedEmployee.DriverLicenseNumber, employeeFromPersonalDetails.DriverLicenseNumber);
                    Assert.Equal(updatedEmployee.Nationality, employeeFromPersonalDetails.Nationality);
                    Assert.Equal(updatedEmployee.MaritalStatus, employeeFromPersonalDetails.MaritalStatus);
                    Assert.Equal(updatedEmployee.Gender, employeeFromPersonalDetails.Gender);
                    Assert.Equal(updatedEmployee.DateOfBirth?.Date, employeeFromPersonalDetails.DateOfBirth?.Date);
                    Assert.Equal(updatedEmployee.LicenseExpiryDate?.Date, employeeFromPersonalDetails.LicenseExpiryDate?.Date);

                    // DB
                    Assert.Equal(updatedEmployee.FirstName, employeeFromDB.FirstName);
                    Assert.Equal(updatedEmployee.MiddleName, employeeFromDB.MiddleName);
                    Assert.Equal(updatedEmployee.LastName, employeeFromDB.LastName);
                    Assert.Equal(updatedEmployee.DriverLicenseNumber, employeeFromDB.DriverLicenseNumber);
                    Assert.Equal(updatedEmployee.Nationality, employeeFromDB.Nationality);
                    Assert.Equal(updatedEmployee.MaritalStatus, employeeFromDB.MaritalStatus);
                    Assert.Equal(updatedEmployee.Gender, employeeFromDB.Gender);
                    Assert.Equal(updatedEmployee.DateOfBirth?.Date, employeeFromDB.DateOfBirth?.Date);
                    Assert.Equal(updatedEmployee.LicenseExpiryDate?.Date, employeeFromDB.LicenseExpiryDate?.Date);
                });

                // CLEANUP
                dashboard.GoToEmployeeList().DeleteEmployee(employee.Id);
                LoggerHelper.Info("Cleanup completed");

            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"Test failed: {ex.Message}");

                MarkTestAsFailed();

                throw;
            }
        }
    }



}
