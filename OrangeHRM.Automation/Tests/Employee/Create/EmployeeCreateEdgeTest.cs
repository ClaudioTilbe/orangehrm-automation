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

namespace OrangeHRM.Automation.Tests.Employee.Create
{
    public class EmployeeCreateEdgeTest : EmployeeTestBase
    {
        [Fact]
        public void CreateEmployee_Edge_ShouldCreateSuccessfully()
        {
            try
            {
                LoggerHelper.Info("Starting CreateEmployee Edge test");

                DashboardPage dashboard = Login(BrowserType.Edge);

                EmployeeModel employee = EmployeeBuilder.CreateDefaultEmployee();

                AddEmployeePage addEmployeePage = dashboard.GoToAddEmployee();

                EmployeePersonalDetailsPage detailsPage = addEmployeePage.CreateEmployee(employee);

                EmployeeListPage employeeListPage = detailsPage.GoToEmployeeList();

                Assert.Multiple(() =>
                {
                    Assert.True(employeeListPage.EmployeeExistsById(employee.Id)); // UI
                    Assert.True(db.EmployeeExists(employee.Id)); // DB
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
