using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Core.Config
{
    public class Settings
    {
        public string ApplicationUrl { get; set; }

        public Credentials Credentials { get; set; }

        public Timeouts Timeouts { get; set; }
    }

    public class Credentials
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class Timeouts
    {
        public int ImplicitWait { get; set; }

        public int ExplicitWait { get; set; }
    }
}
