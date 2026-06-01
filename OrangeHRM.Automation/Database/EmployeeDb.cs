using OrangeHRM.Automation.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Database
{
    public class EmployeeDb
    {

        public bool EmployeeExists(string id)
        {
            //SqlConnection _cnn = new SqlConnection(ConnectionDb.Cnn());
            //bool _exists = false;

            //SqlCommand _comando = new SqlCommand(@"
            //                                    SELECT COUNT(1)
            //                                    FROM Employees
            //                                    WHERE EmployeeId = @id", _cnn);

            //_comando.Parameters.AddWithValue("@id", id);

            //try
            //{
            //    _cnn.Open();

            //    int count = Convert.ToInt32(_comando.ExecuteScalar());

            //    _exists = count > 0;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //finally
            //{
            //    _cnn.Close();
            //}

            //return _exists;

            return true;
        }



        public EmployeeModel GetEmployee(string id)
        {
            //SqlConnection _cnn = new SqlConnection(ConnectionDb.Cnn());
            //Employee employee = null;

            //SqlCommand _comando = new SqlCommand(@"
            //                                        SELECT 
            //                                            EmployeeId,
            //                                            FirstName,
            //                                            MiddleName,
            //                                            LastName,
            //                                            DriverLicenseNumber,
            //                                            Nationality,
            //                                            MaritalStatus,
            //                                            Gender,
            //                                            DateOfBirth,
            //                                            LicenseExpiryDate
            //                                        FROM Employees
            //                                        WHERE EmployeeId = @id", _cnn);

            //_comando.Parameters.AddWithValue("@id", id);

            //try
            //{
            //    _cnn.Open();

            //    SqlDataReader _lector = _comando.ExecuteReader();

            //    if (_lector.HasRows)
            //    {
            //        _lector.Read();

            //        employee = new Employee
            //        {
            //            Id = _lector["EmployeeId"].ToString(),
            //            FirstName = _lector["FirstName"]?.ToString(),
            //            MiddleName = _lector["MiddleName"]?.ToString(),
            //            LastName = _lector["LastName"]?.ToString(),
            //            DriverLicenseNumber = _lector["DriverLicenseNumber"]?.ToString(),
            //            Nationality = _lector["Nationality"]?.ToString(),
            //            MaritalStatus = _lector["MaritalStatus"]?.ToString(),
            //            Gender = _lector["Gender"]?.ToString(),
            //            DateOfBirth = _lector["DateOfBirth"] == DBNull.Value
            //                ? null
            //                : (DateTime?)Convert.ToDateTime(_lector["DateOfBirth"]),
            //            LicenseExpiryDate = _lector["LicenseExpiryDate"] == DBNull.Value
            //                ? null
            //                : (DateTime?)Convert.ToDateTime(_lector["LicenseExpiryDate"])
            //        };
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //finally
            //{
            //    _cnn.Close();
            //}

            EmployeeModel employee = new EmployeeModel
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

            return employee;
        }






    }

}
