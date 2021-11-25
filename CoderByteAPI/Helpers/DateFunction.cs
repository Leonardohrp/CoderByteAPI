using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Helpers
{
    public static class DateFunction
    {
        public static int GetAgeFromDate(DateTime date)
        {
            int age = 0;

            if (DateTime.Now.Year <= date.Year)
                return age;

            return DateTime.Now.AddYears(-date.Year).Year;
        }
    }
}
