using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Core.Utilities
{
    public static class DateHelper
    {
        public static DateTime? ParseOrangeDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return DateTime.ParseExact(value, "yyyy-dd-MM", CultureInfo.InvariantCulture);
        }
    }


}
