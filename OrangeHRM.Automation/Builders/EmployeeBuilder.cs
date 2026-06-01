using OrangeHRM.Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Builders
{
    public static class EmployeeBuilder
    {
        public static EmployeeModel CreateDefaultEmployee()
        {
            string employeeId = GenerateRandomEmployeeId();

            return new EmployeeModel
            {
                Id = employeeId,
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Test",
                Username = $"john{employeeId}",
                Password = "Password123!",
                ImageName = "employee.jpg"
            };
        }

        public static EmployeeModel CreateModifiedEmployee()
        {
            return new EmployeeModel
            {
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Modificado",
                Username = "john.modified",
                Password = "Password123!",
                ImageName = "employee.jpg",
                DriverLicenseNumber = "TEST-LIC-001",
                LicenseExpiryDate = DateTime.Today,
                Nationality = "Uruguayan",
                MaritalStatus = "Single",
                DateOfBirth = DateTime.Today.AddYears(-20),
                Gender = "Male"
            };
        }

        private static string GenerateRandomEmployeeId()
        {
            byte[] bytes = new byte[8];
            RandomNumberGenerator.Fill(bytes);
            long number = Math.Abs(BitConverter.ToInt64(bytes, 0));

            // Genera exactamente 10 dígitos
            number = (number % 9000000000L) + 1000000000L;

            return number.ToString();
        }


    }
}


