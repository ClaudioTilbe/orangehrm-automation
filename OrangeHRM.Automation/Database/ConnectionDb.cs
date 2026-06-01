using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;



namespace OrangeHRM.Automation.Database
{
    public static class ConnectionDb
    {

        public static string Cnn()
        {
            return "Server=localhost;Database=OrangeHRM;Trusted_Connection=True;TrustServerCertificate=True;";
        }

    }

}
