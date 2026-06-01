using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Models
{
    public class EmployeeModel
    {

        // =========================================
        // ACCOUNT
        // =========================================

        public string Username { get; set; }
        public string Password { get; set; }



        // =========================================
        // BASIC INFO
        // =========================================

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ImageName { get; set; }



        // =========================================
        // PERSONAL DETAILS
        // =========================================

        public string DriverLicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }


    }
}
