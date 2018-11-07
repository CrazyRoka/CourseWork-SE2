using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SE2.CourseWork
{
    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Date can not be empty.");
            try
            {
                DateTime.ParseExact(value as string, "yyyy-MM-dd", null);
            }catch(FormatException)
            {
                return new ValidationResult(false, "Invalid date format. Please, write in format: year-month-day");
            }
            return new ValidationResult(true, null);
        }
    }
}
