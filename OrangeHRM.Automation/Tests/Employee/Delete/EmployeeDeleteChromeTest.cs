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


namespace OrangeHRM.Automation.Tests.Employee.Delete
{

    public class EmployeeDeleteChromeTest: EmployeeTestBase
    {

        [Fact]
        public void DeleteEmployee_Chrome_ShouldDeleteSuccessfully()
        {
            try
            {
                LoggerHelper.Info("Starting DeleteEmployee Chrome test");

                DashboardPage dashboard = Login(BrowserType.Chrome);

                EmployeeModel employee = EmployeeBuilder.CreateDefaultEmployee();

                AddEmployeePage addPage = dashboard.GoToAddEmployee();

                EmployeePersonalDetailsPage detailsPage = addPage.CreateEmployee(employee);

                EmployeeListPage employeeListPage = detailsPage.GoToEmployeeList();

                employeeListPage.DeleteEmployee(employee.Id);

                Assert.False(employeeListPage.EmployeeExistsById(employee.Id));


                Assert.Multiple(() =>
                {
                    Assert.False(employeeListPage.EmployeeExistsById(employee.Id)); // UI
                    Assert.False(!db.EmployeeExists(employee.Id)); // DB
                });
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
